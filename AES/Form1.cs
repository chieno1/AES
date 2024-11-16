using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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



        public int [,]mixColumnMatrix = {
    { 2, 3, 1, 1 },
    { 1, 2, 3, 1 },
    { 1, 1, 2, 3 },
    { 3, 1, 1, 2 }
};
    public static byte[] Rcon = new byte[]
{
    0,0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1B, 0x36
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
        public int numE;
    public string []k = new string[15];
    public string []w = new string[100];
        public Form1()
        {
            InitializeComponent();
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

        public int[] shift_row(int[] a, int b) 
        {
            int[]c = new int[a.Length];
            for(int i = a.Length - b; i < a.Length; ++i)
            {
                c[i] = a[i - b];
            }
            for(int i = 0; i < b; ++i)
            {
                c[i] = a[i + b];
            }
            return c;
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

        public void sinhKhoa(String s) 
        {
            k[0] = s;
            for(int i = 0; i < numE / 4; i++)
            {
                w[i] = s.Substring(i * 4, 4);
                txt_giai_thich.Text += $"w[{i}] = {StringToHex(w[i ])}\r\n";
            }
            //txt_giai_thich.Text += "K[0] : \r\n";
            //for (int i = 0; i < 4; i++)
            //{
            //    for (int j = 0; j < 4; j++)
            //        txt_giai_thich.Text += CharToHex((Byte)(w[j][i])) + " ";
            //        txt_giai_thich.Text += "\r\n";

            //}
            if (numE == 16)
            {
                for (int i = 4; i < 44; i++)
                {
                    

                    // Tính w[i * 4]
                    if(i % 4 == 0)
                    {
                        w[i ] = xor(g(w[i -1], i / 4), w[(i - 4)]);
                        
                       
                    }
                    else
                    {
                        w[i] = xor(w[i - 1], w[i - 4]);
                        ;
                    }
                    if (string.IsNullOrEmpty(k[i / 4]))
                        k[i / 4] = w[i];
                    else
                        k[i/4] += w[i];
                    txt_giai_thich.Text += $"w[{i}] = {StringToHex(w[i])}\r\n";

                    // Khởi tạo hoặc nối thêm vào k[i]


                    // Tính w[i * 4 + j] cho j từ 1 đến 3




                }

            }




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
            if(txt_ro.Text.Length % numE != 0)
            {
                txt_giai_thich.Text += $"Thêm {(numE -(txt_ro.Text.Length % numE))} ký tự X\r\n{txt_ro.Text} => ";
            }
            while (txt_ro.Text.Length % numE != 0) 
            {
                txt_ro.Text += "X";
            }
            txt_giai_thich.Text += txt_ro.Text + "\r\n";
            sinhKhoa("+~\u0015\u0016(\u00AE\u00D2\u00A6\u00AB\u00F7\u0015\u0088\t\u00CFO<");

        }
    }
}
