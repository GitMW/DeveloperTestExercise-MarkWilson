using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileData
{
    public class FileManager 
    {
        private FileDetailsAdapter _adapter;
       

        public FileManager(IFileDetails adapter)
        {
            this._adapter = adapter as FileDetailsAdapter;
        }

        public FileResults ProcessArray(string[] array)
        {
            FileResults result = _adapter.ProcessArray(array);

            return result;
        }
    }
}
