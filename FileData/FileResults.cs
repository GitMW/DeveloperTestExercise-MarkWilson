namespace FileData
{
    public class FileResults
    {
        public bool Error { get; set; }

        public string Version { get; set; }

        public int Size { get; set; } = -1;

        public string ErrorMessage { get; set; }
    }
}