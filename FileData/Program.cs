using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            IFileDetails adapter = new FileDetailsAdapter();
            FileManager fm = new FileManager(adapter);

            string[] array = new string[] { "-v", "c:/test.txt" };
            FileResults result = fm.ProcessArray(array);
            PrintResult(array, result);

            array = new string[] { "--v", "c:/test.txt" };
            result = fm.ProcessArray(array);
            PrintResult(array, result);

            array = new string[] { "–v", "c:/test.txt" };
            result = fm.ProcessArray(array);
            PrintResult(array, result);

            array = new string[] { "-s", "c:/test.txt" };
            result = fm.ProcessArray(array);
            PrintResult(array, result);

            array = new string[] { "--s", "c:/test.txt" };
            result = fm.ProcessArray(array);
            PrintResult(array, result);

            array = new string[] { "–s", "c:/test.txt" };
            result = fm.ProcessArray(array);
            PrintResult(array, result);

            array = new string[] { "–s" };
            result = fm.ProcessArray(array);
            PrintResult(array, result);

            array = new string[] { "–m", "c:/test.txt" };
            result = fm.ProcessArray(array);
            PrintResult(array, result);

            Console.ReadKey();
        }

        private static void PrintResult(string[] array, FileResults result)
        {
            StringBuilder sb = new StringBuilder();

            if (array != null)
            {
                sb.Append("Test     : ");
            
                for(int i =0; i < array.Count();i++)
                {
                    sb.Append(array[i] + "   ");
                }

                sb.AppendLine("");
                sb.AppendLine("Results  :");
                sb.AppendLine("Error    : " + (result.Error ? "true" : "false"));
                sb.AppendLine("Version  : " + result.Version);
                sb.AppendLine("Size     : " + (result.Size == -1 ? "" : result.Size.ToString()));
                sb.AppendLine("Message  : " + result.ErrorMessage);
            }
            Console.WriteLine(sb.ToString());
        
        }
    }
}
