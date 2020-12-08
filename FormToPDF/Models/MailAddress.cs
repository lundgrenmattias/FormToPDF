namespace FormToPDF.Models
{
    public class MailAddress
    {
        public MailAddress()
        {

        }

        public MailAddress(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; set; }
        public string Address { get; set; }
    }
}
