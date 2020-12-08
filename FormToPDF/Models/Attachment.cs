using System.IO;

namespace FormToPDF.Models
{
    public class Attachment
    {
        public Attachment()
        {

        }

        public Attachment(string fileName, Stream stream)
        {
            FileName = fileName;
            Stream = stream;
        }

        public string FileName { get; set; }
        public Stream Stream { get; set; }
    }
}
