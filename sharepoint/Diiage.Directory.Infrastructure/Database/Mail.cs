namespace Diiage.Directory.Infrastructure.Database
{
    public class Mail
    {
        public int Id { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
