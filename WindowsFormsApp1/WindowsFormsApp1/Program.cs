using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEditor.BL;
using DfEditor;
using TextEditor;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form = new Form1();
            FileManager manager = new FileManager();
            MessageService messageService = new MessageService();
            MainPresentor mainPresentor = new MainPresentor(form,manager,messageService);
            Application.Run(form);
        }
    }
}
