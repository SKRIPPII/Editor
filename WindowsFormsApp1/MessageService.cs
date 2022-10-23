using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DfEditor
{
   public interface IMessageService
    {
        void ShowMessage(string mes);
        void ShowExclamation(string ex);
        void ShowError(string error);
    }
   public class MessageService:IMessageService
    {
        public void ShowError(string error)
        {
            MessageBox.Show(error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowExclamation(string ex)
        {
            MessageBox.Show(ex, "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void ShowMessage(string mes)
        {
            MessageBox.Show(mes,"Сообщение",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
