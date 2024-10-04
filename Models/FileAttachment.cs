

namespace DragandDrop.Models
{
    public class FileAttachment
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public FileAttachment(string fileName, string filePath)
        {
            FileName = fileName;
            FilePath = filePath;
        }
    }
}
