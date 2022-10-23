using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEditor.BL;
using DfEditor;
using WindowsFormsApp1; 

namespace TextEditor
{
   
  public  class MainPresentor
    {
        string refFilePath;
        IForm1 form1{ get; }
        IFileManager manager { get; }
        IMessageService message { get; }
        public MainPresentor(IForm1 form, IFileManager manager, IMessageService messageService)
        {
            form1 = form;
            this.manager = manager;
            message = messageService;

            form1.SetSymbolCount(0);
            form1.Change += Form1_Change;
            form1.Open += Form1_Open;
            form1.Save += Form1_Save;
        }

        private void Form1_Save(object sender, EventArgs e)
        {
            try
            {
                string content = form1.Content;
                manager.SaveContent(content,refFilePath);
                message.ShowMessage("Файл успешно сохранен.");
            }
            catch (Exception ex)
            {
                message.ShowError(ex.Message);
            }
        }

        private void Form1_Open(object sender, EventArgs e)
        {
            try
            {
                string filepath = form1.FilePath;
                bool isExist = manager.IsExist(filepath);
                if (!isExist) { message.ShowExclamation("Выбранный файл не существует."); return; }
                refFilePath = filepath;
                string content = manager.GetContent(refFilePath);
                int count = manager.Check(content);
                form1.Content = content;
                form1.SetSymbolCount(count);
            }
            catch (Exception ex)
            {

                message.ShowError(ex.Message);
            }
        }

        private void Form1_Change(object sender, EventArgs e)
        {
            string content = form1.Content;
            int count = manager.Check(content);
            form1.SetSymbolCount(count);
        }
    }
}
