namespace FormToPDF.Services
{
    public class SmtpConfiguration
    {
        public string Host { get; set; }
        public bool UseSSL { get; set; }
        public int Port { get; set; }
        public Credentials Credentials { get; set; }
        public string Auditor { get; set; }
    }
}