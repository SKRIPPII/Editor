using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
   public interface IForm1
    {
        string FilePath { get; }
        string Content { get; set; }
        void SetSymbolCount(int count);
        event EventHandler Open;
        event EventHandler Save;
        event EventHandler Change;
    }
    public partial class Form1 : Form,IForm1
    {
        
        public Form1()
        {
            InitializeComponent();
            openfile.Click += Form1_Open;
            filesave.Click += Form1_Save;
            textcontent.TextChanged += Textcontent_TextChanged;
            choosefile.Click += Choosefile_Click;
            numericUpDown1.ValueChanged += NumericUpDown1_ValueChanged;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            textcontent.Font = new Font("Calibri",(float)numericUpDown1.Value);
        }

        private void Choosefile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                filepath.Text = open.FileName;
                Open?.Invoke(this, EventArgs.Empty);
            }
        }
        #region Events
        private void Textcontent_TextChanged(object sender, EventArgs e)
        {
            if (Change != null) Change(this,EventArgs.Empty);
        }
       
        private void Form1_Open(object sender, EventArgs e)
        {
            if (Open != null) Open(sender, EventArgs.Empty);
        }
        private void Form1_Save(object sender, EventArgs e)
        {
            if (Save != null) Save(sender, EventArgs.Empty);
        }
        #endregion

        #region IForm1
        public string FilePath => filepath.Text;

        public string Content { get => textcontent.Text; set => textcontent.Text = value; }

        public event EventHandler Open;
        public event EventHandler Save;
        public event EventHandler Change;

        public void SetSymbolCount(int count)
        {
            lblCount.Text = count.ToString();
        }
        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(this);
            form.Show();
        }
    }
}
