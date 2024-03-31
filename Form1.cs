using System;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.a.ToString();
            textBox2.Text = Properties.Settings.Default.b.ToString();
            textBox3.Text = Properties.Settings.Default.c.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b, c;
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("��� ���� ������ ���� ��������!");
                return;
            }
            try
            {
                // ��� ������ ������ ����������� ��������
                a = int.Parse(this.textBox1.Text);
                b = int.Parse(this.textBox2.Text);
                c = int.Parse(this.textBox3.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("������� ������ �����!");
                return;
            }
            bool validInput = false;
            Properties.Settings.Default.a = a;
            Properties.Settings.Default.b = b;
            Properties.Settings.Default.c = c;
            Properties.Settings.Default.Save();

            try
            {
                int res = Logic.Multiply(a,b,c);
                MessageBox.Show($"������������ ���� ���������� ����� ����� {res}");
                validInput = true;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public class Logic
        {
            public static int Multiply(int a, int b, int c)
            {
                if (a == b && b == c)
                {
                    throw new ArgumentException("��� ��� ����� ���������. ����������, ������� ��������� �����.");
                }
                else if (a <= c && b <= c)
                {
                    return a * b;
                }
                else if (a <= b && c <= b)
                {
                    return a * c;
                }
                else
                {
                    return b * c;
                }
            }
        }
    }
}
