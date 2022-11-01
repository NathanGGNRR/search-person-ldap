namespace Diiage.Directory.MailSender
{
    public class SmtpConfiguration
    {
        /// <summary>
        /// IP adress or the host used for SMTP transaction.
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Port used form SMTP. Usually SMTP works with port 25, 
        /// but it can work also with 587.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Sender's mail
        /// </summary>
        public string SenderMail { get; set; }

        /// <summary>
        /// Sender's name
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// Gets or sets the login.
        /// </summary>
        /// <value>
        /// The login.
        /// </value>
        public string Login { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }

        /// <summary>
        /// Enable SSL/TLS
        /// </summary>
        public bool EnableSsl { get; set; }
    }
}
