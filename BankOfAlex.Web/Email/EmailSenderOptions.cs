namespace BankOfAlex.Web.Email
{
    public class EmailSenderOptions
    {
        public string SendGridUser { get; set; }

        public string SendGridKey { get; set; }

        public ServerEmailAddressCollection EmailAddresses { get; set; }

    }
}
