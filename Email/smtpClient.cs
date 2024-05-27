// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;



class emailSender
{
    public void Email()
    {

        string fromMail = "abbas.hyder@shispare.com";
        string fromPassword = "";

        MailMessage message = new MailMessage();
        message.From = new MailAddress(fromMail);
        message.Subject = "Testing System.Net.Mail";

        message.To.Add(new MailAddress("testsmptclient@gmail.com"));

        message.Body = "<html><body> Sending you an Attachment </body></html>";

        message.IsBodyHtml = true;

        Attachment attachment;
        attachment = new Attachment("C:/Users/Shispare/Documents/Attachement.txt");
        message.Attachments.Add(attachment);





        var smtpClient = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(fromMail, fromPassword),
            EnableSsl = true,
        };
        try
        {
            smtpClient.Send(message);
            Console.WriteLine("Email Send successfully");
        }
        catch (Exception e)
        {
            Console.Write(e.Message);
        }


    }
}

