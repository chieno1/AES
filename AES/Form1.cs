using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AES
{
    public partial class Form1 : Form
    {
       byte[,] SBox = new byte[16, 16] {
    { 0x63, 0x7C, 0x77, 0x7B, 0xF2, 0x6B, 0x6F, 0xC5, 0x30, 0x01, 0x67, 0x2B, 0xFE, 0xD7, 0xAB, 0x76 },
    { 0xCA, 0x82, 0xC9, 0x7D, 0xFA, 0x59, 0x47, 0xF0, 0xAD, 0xD4, 0xA2, 0xAF, 0x9C, 0xA4, 0x72, 0xC0 },
    { 0xB7, 0xFD, 0x93, 0x26, 0x36, 0x3F, 0xF7, 0xCC, 0x34, 0xA5, 0xE5, 0xF1, 0x71, 0xD8, 0x31, 0x15 },
    { 0x04, 0xC7, 0x23, 0xC3, 0x18, 0x96, 0x05, 0x9A, 0x07, 0x12, 0x80, 0xE2, 0xEB, 0x27, 0xB2, 0x75 },
    { 0x09, 0x83, 0x2C, 0x1A, 0x1B, 0x6E, 0x5A, 0xA0, 0x52, 0x3B, 0xD6, 0xB3, 0x29, 0xE3, 0x2F, 0x84 },
    { 0x53, 0xD1, 0x00, 0xED, 0x20, 0xFC, 0xB1, 0x5B, 0x6A, 0xCB, 0xBE, 0x39, 0x4A, 0x4C, 0x58, 0xCF },
    { 0xD0, 0xEF, 0xAA, 0xFB, 0x43, 0x4D, 0x33, 0x85, 0x45, 0xF9, 0x02, 0x7F, 0x50, 0x3C, 0x9F, 0xA8 },
    { 0x51, 0xA3, 0x40, 0x8F, 0x92, 0x9D, 0x38, 0xF5, 0xBC, 0xB6, 0xDA, 0x21, 0x10, 0xFF, 0xF3, 0xD2 },
    { 0xCD, 0x0C, 0x13, 0xEC, 0x5F, 0x97, 0x44, 0x17, 0xC4, 0xA7, 0x7E, 0x3D, 0x64, 0x5D, 0x19, 0x73 },
    { 0x60, 0x81, 0x4F, 0xDC, 0x22, 0x2A, 0x90, 0x88, 0x46, 0xEE, 0xB8, 0x14, 0xDE, 0x5E, 0x0B, 0xDB },
    { 0xE0, 0x32, 0x3A, 0x0A, 0x49, 0x06, 0x24, 0x5C, 0xC2, 0xD3, 0xAC, 0x62, 0x91, 0x95, 0xE4, 0x79 },
    { 0xE7, 0xC8, 0x37, 0x6D, 0x8D, 0xD5, 0x4E, 0xA9, 0x6C, 0x56, 0xF4, 0xEA, 0x65, 0x7A, 0xAE, 0x08 },
    { 0xBA, 0x78, 0x25, 0x2E, 0x1C, 0xA6, 0xB4, 0xC6, 0xE8, 0xDD, 0x74, 0x1F, 0x4B, 0xBD, 0x8B, 0x8A },
    { 0x70, 0x3E, 0xB5, 0x66, 0x48, 0x03, 0xF6, 0x0E, 0x61, 0x35, 0x57, 0xB9, 0x86, 0xC1, 0x1D, 0x9E },
    { 0xE1, 0xF8, 0x98, 0x11, 0x69, 0xD9, 0x8E, 0x94, 0x9B, 0x1E, 0x87, 0xE9, 0xCE, 0x55, 0x28, 0xDF },
    { 0x8C, 0xA1, 0x89, 0x0D, 0xBF, 0xE6, 0x42, 0x68, 0x41, 0x99, 0x2D, 0x0F, 0xB0, 0x54, 0xBB, 0x16 }
};



    public static int [,]mixMat = {
    { 2, 3, 1, 1 },
    { 1, 2, 3, 1 },
    { 1, 1, 2, 3 },
    { 3, 1, 1, 2 }
};
        public static byte[] Rcon = new byte[]
    {
    0,0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1B, 0x36,0xDB,0x8E, 0x43,0xC0
    };

        public static Dictionary<int, string> hexDict = new Dictionary<int, string>()
        {
            { 0, "0" },
            { 1, "1" },
            { 2, "2" },
            { 3, "3" },
            { 4, "4" },
            { 5, "5" },
            { 6, "6" },
            { 7, "7" },
            { 8, "8" },
            { 9, "9" },
            { 10, "A" },
            { 11, "B" },
            { 12, "C" },
            { 13, "D" },
            { 14, "E" },
            { 15, "F" }
        };

        byte[,] invSBox = new byte[16, 16] { {0x52, 0x09, 0x6a, 0xd5, 0x30, 0x36, 0xa5, 0x38, 0xbf, 0x40, 0xa3, 0x9e, 0x81, 0xf3, 0xd7, 0xfb},
            {0x7c, 0xe3, 0x39, 0x82, 0x9b, 0x2f, 0xff, 0x87, 0x34, 0x8e, 0x43, 0x44, 0xc4, 0xde, 0xe9, 0xcb},
            {0x54, 0x7b, 0x94, 0x32, 0xa6, 0xc2, 0x23, 0x3d, 0xee, 0x4c, 0x95, 0x0b, 0x42, 0xfa, 0xc3, 0x4e},
            {0x08, 0x2e, 0xa1, 0x66, 0x28, 0xd9, 0x24, 0xb2, 0x76, 0x5b, 0xa2, 0x49, 0x6d, 0x8b, 0xd1, 0x25},
            {0x72, 0xf8, 0xf6, 0x64, 0x86, 0x68, 0x98, 0x16, 0xd4, 0xa4, 0x5c, 0xcc, 0x5d, 0x65, 0xb6, 0x92},
            {0x6c, 0x70, 0x48, 0x50, 0xfd, 0xed, 0xb9, 0xda, 0x5e, 0x15, 0x46, 0x57, 0xa7, 0x8d, 0x9d, 0x84},
            {0x90, 0xd8, 0xab, 0x00, 0x8c, 0xbc, 0xd3, 0x0a, 0xf7, 0xe4, 0x58, 0x05, 0xb8, 0xb3, 0x45, 0x06},
            {0xd0, 0x2c, 0x1e, 0x8f, 0xca, 0x3f, 0x0f, 0x02, 0xc1, 0xaf, 0xbd, 0x03, 0x01, 0x13, 0x8a, 0x6b},
            {0x3a, 0x91, 0x11, 0x41, 0x4f, 0x67, 0xdc, 0xea, 0x97, 0xf2, 0xcf, 0xce, 0xf0, 0xb4, 0xe6, 0x73},
            {0x96, 0xac, 0x74, 0x22, 0xe7, 0xad, 0x35, 0x85, 0xe2, 0xf9, 0x37, 0xe8, 0x1c, 0x75, 0xdf, 0x6e},
            {0x47, 0xf1, 0x1a, 0x71, 0x1d, 0x29, 0xc5, 0x89, 0x6f, 0xb7, 0x62, 0x0e, 0xaa, 0x18, 0xbe, 0x1b},
            {0xfc, 0x56, 0x3e, 0x4b, 0xc6, 0xd2, 0x79, 0x20, 0x9a, 0xdb, 0xc0, 0xfe, 0x78, 0xcd, 0x5a, 0xf4},
            {0x1f, 0xdd, 0xa8, 0x33, 0x88, 0x07, 0xc7, 0x31, 0xb1, 0x12, 0x10, 0x59, 0x27, 0x80, 0xec, 0x5f},
            {0x60, 0x51, 0x7f, 0xa9, 0x19, 0xb5, 0x4a, 0x0d, 0x2d, 0xe5, 0x7a, 0x9f, 0x93, 0xc9, 0x9c, 0xef},
            {0xa0, 0xe0, 0x3b, 0x4d, 0xae, 0x2a, 0xf5, 0xb0, 0xc8, 0xeb, 0xbb, 0x3c, 0x83, 0x53, 0x99, 0x61},
            {0x17, 0x2b, 0x04, 0x7e, 0xba, 0x77, 0xd6, 0x26, 0xe1, 0x69, 0x14, 0x63, 0x55, 0x21, 0x0c, 0x7d} };
        public int numE;

        public static byte[,] mixMatrix = {
            { 0x02, 0x03, 0x01, 0x01 },
            { 0x01, 0x02, 0x03, 0x01 },
            { 0x01, 0x01, 0x02, 0x03 },
            { 0x03, 0x01, 0x01, 0x02 }
        };
        
        public string []k = new string[15];
    public string []w = new string[100];
        public Form1()
        {
            InitializeComponent();
        }
        public static  byte GFMult(byte a, byte b)
        {
            byte p = 0;
            for (int i = 0; i < 8; i++)
            {
                if ((b & 1) != 0)
                    p ^= a;

                bool carry = (a & 0x80) != 0;
                a <<= 1;
                if (carry)
                    a ^= 0x1B; // Xử lý phép nhân trong GF(2^8)
                b >>= 1;
            }
            return p;
        }
        public static string MixColumns(string input)
        {
            // Bước 1: Chuyển chuỗi ASCII thành ma trận 4x4
            byte[,] state = new byte[4, 4];
            byte[] inputBytes = Encoding.ASCII.GetBytes(input.PadRight(16, '\0')); // Padding để đủ 16 byte
            int index = 0;
            for (int col = 0; col < 4; col++)
            {
                for (int row = 0; row < 4; row++)
                {
                    state[row, col] = (byte)input[index++];
                }
            }
            // Bước 2: Thực hiện MixColumns
            byte[,] mixedState = new byte[4, 4];
            for (int col = 0; col < 4; col++)
            {
                mixedState[0, col] = (byte)(GFMult(state[0, col], 2) ^ GFMult(state[1, col], 3) ^ state[2, col] ^ state[3, col]);
                mixedState[1, col] = (byte)(state[0, col] ^ GFMult(state[1, col], 2) ^ GFMult(state[2, col], 3) ^ state[3, col]);
                mixedState[2, col] = (byte)(state[0, col] ^ state[1, col] ^ GFMult(state[2, col], 2) ^ GFMult(state[3, col], 3));
                mixedState[3, col] = (byte)(GFMult(state[0, col], 3) ^ state[1, col] ^ state[2, col] ^ GFMult(state[3, col], 2));
            }
            string temp = "";
            // Bước 3: Chuyển ma trận kết quả thành mảng byte
            
            for (int col = 0; col < 4; col++)
            {
                for (int row = 0; row < 4; row++)
                {
                    char c = (char)mixedState[row, col];
                    temp += c;
                }
            }

            // Bước 4: Chuyển mảng byte thành chuỗi ASCII và trả về
            return temp;
        }

        // Nhân ma trận 4x4 với cột 4x1
        static byte[] MultiplyColumn(byte[,] matrix, byte[] column)
        {
            byte[] result = new byte[4];
            for (int row = 0; row < 4; row++)
            {
                result[row] = (byte)(
                    GaloisMult(matrix[row, 0], column[0]) ^
                    GaloisMult(matrix[row, 1], column[1]) ^
                    GaloisMult(matrix[row, 2], column[2]) ^
                    GaloisMult(matrix[row, 3], column[3])
                );
            }
            return result;
        }
        static byte GaloisMult(byte a, byte b)
        {
            byte result = 0;
            byte hiBitSet;
            for (int i = 0; i < 8; i++)
            {
                if ((b & 1) != 0)
                    result ^= a;

                hiBitSet = (byte)(a & 0x80);
                a <<= 1;
                if (hiBitSet != 0)
                    a ^= 0x1B; // Giảm đa thức modulo AES: x^8 + x^4 + x^3 + x + 1

                b >>= 1;
            }
            return result;
        }

        public static byte Multiply(byte x, byte y)
        {
            byte result = 0;
            if ((y & 1) != 0)
                result ^= x;

            if ((y >> 1 & 1) != 0)
                result ^= xtime(x);

            if ((y >> 2 & 1) != 0)
                result ^= xtime(xtime(x));

            if ((y >> 3 & 1) != 0)
                result ^= xtime(xtime(xtime(x)));

            if ((y >> 4 & 1) != 0)
                result ^= xtime(xtime(xtime(xtime(x))));

            return result;
        }
        public static byte xtime(byte x)
        {
            return (byte)((x << 1) ^ ((x >> 7 & 1) * 0x1b));
        }

        public static string InvMixColumns(string input)
        {
            // Kiểm tra độ dài chuỗi, nếu không đúng thì thông báo lỗi
            if (input.Length != 16) // 16 ký tự ASCII = 16 bytes
                throw new ArgumentException("Input phải là chuỗi ASCII dài 16 ký tự");

            // Chuyển chuỗi ASCII thành mảng byte 2 chiều (4x4 matrix)
            byte[,] state = new byte[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    state[i, j] = (byte)input[i * 4 + j]; // Chuyển từng ký tự ASCII thành byte
                }
            }

            // Thực hiện phép toán Inverse MixColumns
            for (int i = 0; i < 4; ++i)
            {
                byte a = state[i, 0];
                byte b = state[i, 1];
                byte c = state[i, 2];
                byte d = state[i, 3];

                state[i, 0] = (byte)(Multiply(a, 0x0e) ^ Multiply(b, 0x0b) ^ Multiply(c, 0x0d) ^ Multiply(d, 0x09));
                state[i, 1] = (byte)(Multiply(a, 0x09) ^ Multiply(b, 0x0e) ^ Multiply(c, 0x0b) ^ Multiply(d, 0x0d));
                state[i, 2] = (byte)(Multiply(a, 0x0d) ^ Multiply(b, 0x09) ^ Multiply(c, 0x0e) ^ Multiply(d, 0x0b));
                state[i, 3] = (byte)(Multiply(a, 0x0b) ^ Multiply(b, 0x0d) ^ Multiply(c, 0x09) ^ Multiply(d, 0x0e));
            }

            // Xây dựng chuỗi kết quả từ mảng byte
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    result.Append((char)state[i, j]); // Chuyển thành chuỗi hex với 2 ký tự
                }
            }

            return result.ToString();
        }


        // Hàm nhân trong trường Galois GF(2^8)
        private static byte GaloisMultiply(byte a, byte b)
        {
            byte p = 0;
            for (int i = 0; i < 8; i++)
            {
                if ((b & 1) != 0) // Nếu bit thấp nhất của b là 1
                    p ^= a;

                bool highBitSet = (a & 0x80) != 0; // Kiểm tra bit cao nhất
                a <<= 1;
                if (highBitSet)
                    a ^= 0x1b; // XOR với đa thức sinh AES (x^8 + x^4 + x^3 + x + 1)

                b >>= 1;
            }
            return p;
        }

        static string CharToHex(Byte c)
        { 
            string temp = "";
            if (c < 10)
                return "0" + hexDict[c];
            return hexDict[c / 16] + hexDict[c % 16];
        }
        public string RotWord(string s)
        {
            if (s.Length != 4)
                return "";
            return s.Substring(1) + s[0];
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        public string xor(string s1, string s2)
        {
            if (s1.Length != s2.Length)
                return ""; // Trả về chuỗi rỗng nếu độ dài không khớp
            
            StringBuilder s3 = new StringBuilder();  // Dùng StringBuilder để xây dựng chuỗi kết quả
            for (int i = 0; i < s1.Length; i++)
            {
                // Chuyển ký tự thành byte và thực hiện phép XOR
                byte byte1 = (byte)s1[i];
                byte byte2 = (byte)s2[i];
                byte result = (byte)(byte1 ^ byte2);

                // Chuyển byte kết quả thành ký tự và thêm vào chuỗi kết quả
                s3.Append((char)result);
            }
            return s3.ToString();
        }



        public string SubByte(string s)
        {
            string c = "";
            for (int i = 0; i < s.Length; ++i)
            {
                // Chuyển ký tự a[i] sang giá trị số nguyên
                byte value = (byte)s[i];

                // Tách hàng và cột từ giá trị (giả sử input trong dải 0-255)
                int row = value / 16;        // Lấy 4 bit cao
                int col = value % 16;     // Lấy 4 bit thấp

                // Tra cứu giá trị trong SBox
                byte sboxValue = SBox[row, col];

                // Thêm giá trị S-box vào kết quả dưới dạng hex
                char t = (char)sboxValue;
                c += t;
            }
            return c;
        }
        public string InverseSubByte(string s)
        {
            string result = "";

            // Duyệt qua từng ký tự trong chuỗi
            for (int i = 0; i < s.Length; i++)
            {
                // Chuyển ký tự s[i] sang giá trị số nguyên (byte)
                byte value = (byte)s[i];

                // Tách hàng và cột từ giá trị (giả sử input trong dải 0-255)
                int row = value / 16;    // Lấy 4 bit cao
                int col = value % 16;    // Lấy 4 bit thấp

                // Tra cứu giá trị trong InvSBox
                byte invSBoxValue = invSBox[row, col];

                // Thêm giá trị từ InvSBox vào kết quả dưới dạng ký tự
                result += (char)invSBoxValue;
            }

            return result;
        }



        public string XorRcon(string s, int i)
        {
            // Kiểm tra tham số đầu vào
            if (string.IsNullOrEmpty(s) || s.Length < 4)
                throw new ArgumentException("Chuỗi đầu vào phải có ít nhất 4 ký tự.");

            if (i <= 0 || i > Rcon.Length)
                throw new ArgumentOutOfRangeException("Chỉ số i không hợp lệ.");

            // Lấy ký tự đầu tiên của chuỗi và XOR với giá trị rcon
            char c = (char)((byte)s[0] ^ Rcon[i]);

            // Ghép ký tự mới với các ký tự còn lại
            return c.ToString() + s.Substring(1, 3);
        }

        public string g(string s, int i) 
        {
            string temp = RotWord(s);
            //txt_giai_thich.Text += $"saurotword g[{i * 4 - 1}] = {StringToHex(temp)}\r\n";
            temp = SubByte(temp);
           // txt_giai_thich.Text += $"sausubyte g[{i * 4 - 1}] = {StringToHex(temp)}  {temp}\r\n";
            temp = XorRcon(temp,i);
           // txt_giai_thich.Text += $"g[{i*4 - 1}] = {StringToHex(temp)}\r\n";
            return temp;
        }
        public void printMat(String s)
        {
            for(int i = 0; i < 4; i++)
            {
                for (int j = i; j < s.Length; j += 4)
                    txt_giai_thich.Text += CharToHex((byte)s[j]) + " ";
                txt_giai_thich.Text += "\r\n";
            }
        }

        public string shift_row(string s)
        {
            if (s == null || s.Length < 16)
                throw new ArgumentException("Input string must be at least 16 characters long.");

            // Tách chuỗi `s` thành các hàng
            string[] row = new string[4];
            for (int i = 0; i < 4; i++)
            {
                row[i] = "";
                for (int j = i; j < s.Length; j += 4)
                {
                    row[i] += s[j];
                }
            }

            // Xoay các hàng
            row[1] = row[1].Substring(1) + row[1].Substring(0, 1); // Dịch 1 vị trí
            row[2] = row[2].Substring(2) + row[2].Substring(0, 2); // Dịch 2 vị trí
            row[3] = row[3].Substring(3) + row[3].Substring(0, 3); // Dịch 3 vị trí

            // Gom lại thành chuỗi
            string rs = "";
            for (int i = 0; i < row[0].Length; i++) // `i` chạy từ 0
            {
                for (int j = 0; j < 4; j++) // `j` duyệt qua các hàng
                {
                    rs += row[j][i];
                }
            }

            return rs;
        }
        public string InverseShiftRow(string s)
        {
            if (s == null || s.Length < 16)
                throw new ArgumentException("Input string must be at least 16 characters long.");

            // Tách chuỗi `s` thành các hàng
            string[] row = new string[4];
            for (int i = 0; i < 4; i++)
            {
                row[i] = "";
                for (int j = i; j < s.Length; j += 4)
                {
                    row[i] += s[j];
                }
            }

            // Dịch ngược các hàng
            row[1] = row[1].Substring(row[1].Length - 1) + row[1].Substring(0, row[1].Length - 1); // Dịch phải 1 vị trí
            row[2] = row[2].Substring(row[2].Length - 2) + row[2].Substring(0, row[2].Length - 2); // Dịch phải 2 vị trí
            row[3] = row[3].Substring(row[3].Length - 3) + row[3].Substring(0, row[3].Length - 3); // Dịch phải 3 vị trí

            // Gom lại thành chuỗi
            string rs = "";
            for (int i = 0; i < row[0].Length; i++) // `i` chạy từ 0
            {
                for (int j = 0; j < 4; j++) // `j` duyệt qua các hàng
                {
                    rs += row[j][i];
                }
            }

            return rs;
        }


        public string StringToHex(string input)
        {
            string hexOutput = "";
            foreach (char c in input)
            {
                // Lấy mã ASCII của ký tự và chuyển nó thành chuỗi hex
                hexOutput += ((int)c).ToString("X2") + " ";
            }
            return hexOutput.Trim(); // Trả về kết quả và loại bỏ khoảng trắng cuối
        }
        
        private void maHoa(String s, int t, int sw)
        {
            
            

            txt_giai_thich.Text += $"Ma hóa khôi ki tư {s}\r\n";
            txt_giai_thich.Text += $"Ma trận trạng thái (hex):\r\n";

            printMat(s);
            txt_giai_thich.Text += $"Ma trận khóa K[0] (hex):\r\n";
            printMat(k[0]);
            s = xor(s, k[0]);
            txt_giai_thich.Text += $"Sau Addroundkey với k[0](hex):\r\n";
            printMat(s);
            // Các vòng mã hóa
            for (int i = 1; i <= t; i++)
            {
                txt_giai_thich.Text += $"Sau subbyte {i}(hex):\r\n";
                
                s = SubByte(s);
                printMat(s);
                txt_giai_thich.Text += $"Sau shift row {i}(hex):\r\n";
                
                s = shift_row(s);
                printMat(s);


                // Bỏ qua MixColumns ở vòng cuối
                if (i < t)
                {
                    s = MixColumns(s);
                    txt_giai_thich.Text += $"Sau  mixcloum {i}(hex):\r\n";
                    printMat(s);
                }
                txt_giai_thich.Text += $"Ma trận khóa K[{i}]:\r\n";
                printMat(k[i]);
                txt_giai_thich.Text += $"Sau  AddRoundKey {i}(hex):\r\n";
                s = xor(s, k[i]); // AddRoundKey với khóa con
                printMat(s);
            }
            txt_giai_thich.Text += $"Bản mã là : {s}";
            txt_ma.Text += s;

        }

        public void sinhKhoa(string s, int t, int sw)
        {
            // Kiểm tra đầu vào
            if (s == null || s.Length < sw * 4)
                throw new ArgumentException($"Input key string 's' must be at least {sw * 4} characters long.");

            // Tạo các từ khóa ban đầu
            for (int i = 0; i < sw; ++i)
            {
                w[i] = s.Substring(i * 4, 4);
                txt_giai_thich.Text += $"w[{i}] = {StringToHex(w[i])}\r\n";
            }

            // Sinh các từ khóa tiếp theo
            for (int i = sw; i < (t + 1) * 4; ++i)
            {
                if (i % sw == 0)
                {
                    w[i] = xor(g(w[i - 1], i / sw), w[i - sw]);
                }
                else
                {
                    w[i] = xor(w[i - 1], w[i - sw]);
                }
                txt_giai_thich.Text += $"w[{i}] = {StringToHex(w[i])}\r\n";
            }

            // Gom từ khóa thành khóa con
            for (int i = 0; i <= t; ++i)
            {
                k[i] = "";
                k[i] += w[i * 4] + w[i * 4 + 1] + w[i * 4 + 2] + w[i * 4 + 3];
            }
        }
        private void giaiMa(String s, int t, int sw)
        {
            txt_giai_thich.Text += $"Giải mã khối kí tự {s}\r\n";
            txt_giai_thich.Text += $"Ma trận trạng thái (hex):\r\n";

            printMat(s);  // In ma trận ban đầu
            txt_giai_thich.Text += $"Ma trận khóa K[{t}] (hex):\r\n";
            printMat(k[t]);  // In khóa con cuối cùng

            s = xor(s, k[t]);  // AddRoundKey với khóa con cuối cùng
            txt_giai_thich.Text += $"Sau AddRoundKey với k[{t}](hex):\r\n";
            printMat(s);  // In kết quả sau AddRoundKey

            // Các vòng giải mã
            for (int i = t - 1; i >= 0; i--)
            {



                if (s.Length != 16)
                {
                    MessageBox.Show("s" + s + "k" + i);
                    return;
                }
                txt_giai_thich.Text += $"Sau InverseShiftRow {i}(hex):\r\n";
                s = InverseShiftRow(s);  // Dịch hàng ngược
                printMat(s);

                txt_giai_thich.Text += $"Sau InverseSubByte {i}(hex):\r\n";
                s = InverseSubByte(s);  // Tra cứu ngược trong InvSBox
                printMat(s);
                txt_giai_thich.Text += $"Sau AddRoundKey {i}(hex):\r\n";
                
                s = xor(s, k[i]);  // AddRoundKey với khóa con
                printMat(s);

                if(i > 0)
                {
                    
                    txt_giai_thich.Text += $"Sau InverseMixColumns {i}(hex):\r\n";
                    s = InvMixColumns(s);  // Bước mix columns ngược
                    printMat(s);
                }

                // Bỏ qua bước MixColumns ở vòng cuối

            }

            // Vòng cuối không có MixColumns
           

            txt_giai_thich.Text += $"Bản rõ là : {s}";
            txt_ro.Text += s;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            txt_giai_thich.Text = string.Empty;
            txt_ma.Text = string.Empty;
            if(txt_ro.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập bản rõ");
                return;
            }
            if(rad128.Checked == false && rad192.Checked == false && rad256.Checked == false)
            {
                MessageBox.Show("Chưa chọn loại khóa");
                return;
            }
            if (rad128.Checked == true)
                numE = 16;
            else if(rad192.Checked == true)
                numE = 24;
            else
                numE = 32;
            if(numE != txt_khoa.Text.Length)
            {
                MessageBox.Show("Độ dài khóa và loại khóa không bằng nhau");
                return;
            }
            if(txt_ro.Text.Length % 16 != 0)
            {
                txt_giai_thich.Text += $"Thêm {(16 -(txt_ro.Text.Length % 16))} ký tự X\r\n{txt_ro.Text} => ";
            }
            while (txt_ro.Text.Length % 16 != 0) 
            {
                txt_ro.Text += "X";
            }
            txt_giai_thich.Text += txt_ro.Text + "\r\n";
            int t, sw;
            if (numE == 16)
            {
                t = 10;
                sw = 4;
            }
            else if (numE == 24)
            {
                t = 12;
                sw = 6;
            }
            else
            {
                t = 14;
                sw = 8;
            }
            sinhKhoa(txt_khoa.Text,t , sw);
            string p =txt_ro.Text;
            for(int i = 0; i < p.Length; i += 16)
            {
                maHoa(p.Substring(i, 16), t, sw);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
            txt_ro.Text = string.Empty;
            if (txt_ma.Text.Length == 0)
            {
                MessageBox.Show("Chưa nhập bản mã");
                return;
            }
            if (rad128.Checked == false && rad192.Checked == false && rad256.Checked == false)
            {
                MessageBox.Show("Chưa chọn loại khóa");
                return;
            }
            if (rad128.Checked == true)
                numE = 16;
            else if (rad192.Checked == true)
                numE = 24;
            else
                numE = 32;
            int t, sw;
            if (numE == 16)
            {
                t = 10;
                sw = 4;
            }
            else if (numE == 24)
            {
                t = 12;
                sw = 6;
            }
            else
            {
                t = 14;
                sw = 8;
            }
            txt_ro.Text = "";
            txt_giai_thich.Text = "";
            sinhKhoa(txt_khoa.Text,t,sw);
            string c = txt_ma.Text;
            
            for (int i = 0; i < c.Length; i += 16)
            { 
                giaiMa(c.Substring(i, 16), t, sw);
            }

        }
    }
}
