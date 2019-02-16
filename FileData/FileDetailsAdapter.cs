using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdPartyTools;

namespace FileData
{
    public class FileDetailsAdapter : IFileDetails
    {
        private const string ERROR_INVALID_COMMAND = "Error: Invalid input";
       
        List<string> listOfVersionCommands = new List<string>();
        List<string> listOfSizeCommands = new List<string>();

        public FileDetailsAdapter()
        {
            listOfVersionCommands.Add("-v");
            listOfVersionCommands.Add("--v");
            listOfVersionCommands.Add("–v");
            listOfVersionCommands.Add("/v");
            listOfVersionCommands.Add("--version");


            listOfSizeCommands.Add("-s");
            listOfSizeCommands.Add("--s");
            listOfSizeCommands.Add("–s");
            listOfSizeCommands.Add("/s");
            listOfSizeCommands.Add("--size");
        }

        FileDetails fd = new FileDetails();

        public string GetVersion(string filepath)
        {
            return fd.Version(filepath);
        }

        public int GetSize(string filepath)
        {
            return fd.Size(filepath);
        }

        public bool ValidteInput(List<String> array)
        {
            bool bVersionFound = false;

            if(array == null || array.Count() != 2)
            {
                return false;
            }

            List<string> command = new List<string>();

            string cmd = array[0];
            cmd = cmd.ToLower().Trim();

            // Check for version command
            var result = listOfVersionCommands.Where(c => c == cmd).FirstOrDefault();

            if (result != null)
            {
                return true;
            }
            
            // Check size command
            var result2 = listOfSizeCommands.Where(c => c == cmd).FirstOrDefault();


            if (result2 != null)
            {
                return true;
            }

            return false;
        }

        public FileResults ProcessArray(string[] arrayPassedIn)
        {
            FileResults results = new FileResults();
            string str = String.Empty;

            List<String> array = arrayPassedIn.ToList();

            if (!ValidteInput(array))
            {
                results.Error = true;
                results.ErrorMessage =  ERROR_INVALID_COMMAND;
            }
            else
            {
                String cmd = array[0].ToLower().Trim();

                var result = listOfVersionCommands.Where(c => c == cmd).FirstOrDefault();

                if (result != null)
                {
                    results.Version = GetVersion(array[1]);
                }

                var result2 = listOfSizeCommands.Where(c => c == cmd).FirstOrDefault();

                if (result2 != null)
                {
                    results.Size = GetSize(array[1]);
                }
            }

            return results;
        }
    }
}
