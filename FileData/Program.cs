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

            Console.ReadKey();
        }

        private static void PrintResult(string[] array, FileResults result)
        {
           // String.Format("Test: {0} {1} "  + array[0],array[1] )

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(String.Format("Test: {0} {1} ", array[0], array[1]));
            sb.AppendLine("Results:");
            sb.AppendLine("Error    : " + (result.Error?"true":"false"));
            sb.AppendLine("Version  : " + result.Version);
            sb.AppendLine("Size     : " + (result.Size == -1?"": result.Size.ToString()));
            sb.AppendLine("Error Message  : " + result.ErrorMessage);

            Console.WriteLine(sb.ToString());
        
        }
    }
}
