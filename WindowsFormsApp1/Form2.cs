using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Xml.Linq;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        StreamReader str;
        SmtpClient smtp;
        MailMessage message;
        Form1 Form1 = null;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            Form1 = form1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(Post).Start();
        }
        void Post()
        {
            try
            {
                str = new StreamReader(Form1.FilePath, Encoding.Default);
                message = new MailMessage();
                smtp = new SmtpClient();
                message.From = new MailAddress(textBox1.Text);
                message.To.Add(new MailAddress(textBox2.Text));
                message.Subject = "Test";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = str.ReadToEnd();
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(textBox1.Text, textBox3.Text);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            }
            catch { MessageBox.Show("Неверные данные!"); }
            try
            {
                smtp.Send(message);
                str.Close();
            }
            catch { MessageBox.Show("Ошибка,попробуйте еше раз!"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void гдеВзятьКлючToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1.Откройте страницу Аккаунт Google.(https://myaccount.google.com/)\r\n2.Нажмите Безопасность.\r\n3.В разделе \"Вход в аккаунт Google\" выберите Пароли приложений. При необходимости выполните вход. Этот параметр недоступен, если:\r\na.двухэтапная аутентификация не настроена для вашего аккаунта;\r\nb.двухэтапная аутентификация настроена только для электронных ключей;\r\nc.вы вошли в рабочий, учебный или другой корпоративный аккаунт;\r\nd.в аккаунте включена Дополнительная защита.\r\n4.В нижней части страницы нажмите Приложение и выберите нужный вариант затем нажмите Устройство и укажите модель затем Создать.\r\n5.Следуя инструкциям, введите пароль приложения (код из 16 символов в желтой строке).\r\n6.Нажмите Готово.");
        }
    }
}
