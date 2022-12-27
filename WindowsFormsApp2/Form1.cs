using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public int length = 5;
        public int i = 0;
        public string Result;
        public string G;
        public long EL;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public static string GenerateStr(int length)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < length; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }
            return sb.ToString();
        }
        public string GenerateLink(string format)
        {
            
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string g = GenerateStr(length);
            string result = "https://i.imgur.com/" + g + format;
            Result = result;
            WebClient webcl = new WebClient();
            webcl.DownloadFile(result, g + format);
            i++;
            long el = stopwatch.ElapsedMilliseconds;
            EL = el;
            stopwatch.Stop();
            return result;
           
        }
        public async void button1_Click(object sender, EventArgs e)
        {
            
            int y = Convert.ToInt32(textBox1.Text);
            richTextBox1.Clear();
            for (int i = 0; i < y; i++)
            {
                button4.Text = "Loading: " + i;
                await AsyncGenerateLink();
                richTextBox1.AppendText(" " + Result + " | Downloaded for: " + EL + "ms" + " | Count: " + i + " |");
            }
            button4.Text = button4.Text + " + 1";


        }
        public async Task AsyncGenerateLink()
        {
            await Task.Run(() => GenerateLink(textBox2.Text));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
    }
}
