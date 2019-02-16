using System;
using FileData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private const string FILEPATH = "C:\text.txt";
        private const string ERROR_INVALID_COMMAND = "Error: Invalid input";
        
        [TestMethod]
        public void Test_ThirdParty_Details_Version()
        {
            ThirdPartyTools.FileDetails temp = new ThirdPartyTools.FileDetails();

            String returnedStr = temp.Version(FILEPATH);
             
            Assert.IsNotNull(returnedStr);
        }

        [TestMethod]
        public void Test_ThirdParty_Details_Size()
        {
            ThirdPartyTools.FileDetails temp = new ThirdPartyTools.FileDetails();

            int returnedValue = temp.Size(FILEPATH);

            Assert.IsTrue(returnedValue > 0);
        }

        [TestMethod]
        public void Test_CreateFileManager()
        {
            IFileDetails adapper = new FileDetailsAdapter();
            FileManager fm = new FileManager(adapper);
            Assert.IsNotNull(fm);
        }

        [TestMethod]
        public void Test_AdaptorVersionCommand()
        {
            String[] array = new string[] { "-v", "c:/test.txt" };

            FileDetailsAdapter adapter = new FileDetailsAdapter();
           
            string strVersion = adapter.GetVersion(array[1]);
          
            Assert.IsNotNull(strVersion);
        }

        [TestMethod]
        public void Test_AdaptorSizeCommand()
        {
            String[] array = new string[] { "-s", "c:/test.txt" };
            FileDetailsAdapter adapter = new FileDetailsAdapter();
            int size = adapter.GetSize(array[1]);

            Assert.IsTrue(size != -1);
        }

        [TestMethod]
        public void Test_VersionCommand_V1()
        {
            string[] array = new string[] { "-v", "c:/test.txt" };

            IFileDetails adapter = new FileDetailsAdapter();
            FileManager fm = new FileManager(adapter);

            FileResults result = fm.ProcessArray(array);
            Assert.IsFalse(result.Error);
            Assert.IsNotNull(result.Version);
        }

        [TestMethod]
        public void Test_VersionCommand_V2()
        {
            string[] array = new string[] { "--v", "c:/test.txt" };

            IFileDetails adapter = new FileDetailsAdapter();
            FileManager fm = new FileManager(adapter);

            FileResults result = fm.ProcessArray(array);
            Assert.IsFalse(result.Error);
            Assert.IsNotNull(result.Version);
        }

        // Not sure if it was if this command was -v or –v so put in both.
        [TestMethod]
        public void Test_VersionCommand_V3()
        {
            string[] array = new string[] { "–v", "c:/test.txt" };

            IFileDetails adapter = new FileDetailsAdapter();
            FileManager fm = new FileManager(adapter);

            FileResults result = fm.ProcessArray(array);
            Assert.IsFalse(result.Error);
            Assert.IsNotNull(result.Version);
        }

        [TestMethod]
        public void Test_VersionCommand_V4()
        {
            string[] array = new string[] { "/v", "c:/test.txt" };

            IFileDetails adapter = new FileDetailsAdapter();
            FileManager fm = new FileManager(adapter);

            FileResults result = fm.ProcessArray(array);
            Assert.IsFalse(result.Error);
            Assert.IsNotNull(result.Version);
        }

        [TestMethod]
        public void Test_VersionCommand_V5()
        {
            string[] array = new string[] { "--version", "c:/test.txt" };

            IFileDetails adapter = new FileDetailsAdapter();
            FileManager fm = new FileManager(adapter);

            FileResults result = fm.ProcessArray(array);
            Assert.IsFalse(result.Error);
            Assert.IsNotNull(result.Version);
        }

        [TestMethod]
        public void Test_VersionCommand_UpperCase()
        {
            string[] array = new string[] { "--V", "c:/test.txt" };

            IFileDetails adapter = new FileDetailsAdapter();
            FileManager fm = new FileManager(adapter);

            FileResults result = fm.ProcessArray(array);
            Assert.IsFalse(result.Error);
            Assert.IsNotNull(result.Version);
        }


        [TestMethod ]
        public void Test_VersionCommand_Incorrect_value()
        {
            String[] array = new string[] { "+v", "c:/test.txt" };

            IFileDetails adapter = new FileDetailsAdapter();
            FileManager fm = new FileManager(adapter);

            FileResults result = fm.ProcessArray(array);

            Assert.IsTrue(result.Error);
            Assert.IsTrue(result.ErrorMessage == ERROR_INVALID_COMMAND);
        }

        [TestMethod]
        public void Test_SizeCommand_S1()
        {
            string[] array = new string[] { "-s", "c:/test.txt" };

            IFileDetails adapter = new FileDetailsAdapter();
            FileManager fm = new FileManager(adapter);

            FileResults result = fm.ProcessArray(array);
            Assert.IsFalse(result.Error);
            Assert.IsTrue(result.Size > -1);

        }

        [TestMethod]
        public void Test_SizeCommand_S2()
        {
            string[] array = new string[] { "--s", "c:/test.txt" };

            IFileDetails adapter = new FileDetailsAdapter();
            FileManager fm = new FileManager(adapter);

            FileResults result = fm.ProcessArray(array);
            Assert.IsFalse(result.Error);
            Assert.IsTrue(result.Size > -1 );
           ;

        }

        [TestMethod]
        public void Test_SizeCommand_S3()
        {
            string[] array = new string[] { "–s", "c:/test.txt" };

            IFileDetails adapter = new FileDetailsAdapter();
            FileManager fm = new FileManager(adapter);

            FileResults result = fm.ProcessArray(array);
            Assert.IsFalse(result.Error);
            Assert.IsTrue(result.Size > -1);
        }

        [TestMethod]
        public void Test_SizeCommand_S4()
        {
            string[] array = new string[] { "/s", "c:/test.txt" };

            IFileDetails adapter = new FileDetailsAdapter();
            FileManager fm = new FileManager(adapter);

            FileResults result = fm.ProcessArray(array);
            Assert.IsFalse(result.Error);
            Assert.IsTrue(result.Size > -1);
        }

        [TestMethod]
        public void Test_SizeCommand_S5()
        {
            string[] array = new string[] { "--size", "c:/test.txt" };

            IFileDetails adapter = new FileDetailsAdapter();
            FileManager fm = new FileManager(adapter);

            FileResults result = fm.ProcessArray(array);
            Assert.IsFalse(result.Error);
            Assert.IsTrue(result.Size != -1);
        }

        [TestMethod]
        public void Test_SizeCommand_UpperCase()
        {
            string[] array = new string[] { "–S", "c:/test.txt" };

            IFileDetails adapter = new FileDetailsAdapter();
            FileManager fm = new FileManager(adapter);

            FileResults result = fm.ProcessArray(array);
            Assert.IsFalse(result.Error);
            Assert.IsTrue(result.Size > -1);
        }

        [TestMethod]
        public void Test_SizeCommand_AddExtraSpace()
        {
            string[] array = new string[] { "  –S  ", "c:/test.txt" };

            IFileDetails adapter = new FileDetailsAdapter();
            FileManager fm = new FileManager(adapter);

            FileResults result = fm.ProcessArray(array);
            Assert.IsFalse(result.Error);
            Assert.IsTrue(result.Size > -1);
        }

        [TestMethod]
        public void Test_EmptyArray()
        {
            string[] array = new string[] {  };

            IFileDetails adapter = new FileDetailsAdapter();
            FileManager fm = new FileManager(adapter);

            FileResults result = fm.ProcessArray(array);
            Assert.IsTrue(result.Error);
            Assert.IsTrue(result.ErrorMessage == ERROR_INVALID_COMMAND);
        }

        [TestMethod]
        public void Test_IncorectCommandMissingFile()
        {
            string[] array = new string[] { "bbb" };

            IFileDetails adapter = new FileDetailsAdapter();
            FileManager fm = new FileManager(adapter);

            FileResults result = fm.ProcessArray(array);
            Assert.IsTrue(result.Error);
            Assert.IsTrue(result.ErrorMessage == ERROR_INVALID_COMMAND);
        }
    }
}
