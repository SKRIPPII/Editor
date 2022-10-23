using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TextEditor.BL
{
   public interface IFileManager
    {
        string GetContent(string file, Encoding enc);
        string GetContent(string file);
        void SaveContent(string content, string path, Encoding enc);
        void SaveContent(string content, string path);
        bool IsExist(string path);
        int Check(string con);
    }
   public class FileManager:IFileManager
    {
        public Encoding def { get; } = Encoding.Default;
        public string GetContent(string file,Encoding enc) => File.ReadAllText(file,enc);
        public string GetContent(string file) => File.ReadAllText(file,def);
        public void SaveContent(string content, string path, Encoding enc) => File.WriteAllText(path,content,enc);
        public void SaveContent(string content, string path) => File.WriteAllText(path,content,def);
        public bool IsExist(string path) => File.Exists(path);
        public int Check(string con) => con.Length;
    }
}
