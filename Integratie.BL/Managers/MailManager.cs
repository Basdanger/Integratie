using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integratie.BL.Managers.Interfaces;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.RegularExpressions;

namespace Integratie.BL.Managers
{
    public class MailManager : IMailManager
    {
        public LinkedResource LinkedResource { get; private set; }

        public void SendMail(string body,string adress,string name)
        {
            try
            {
                MailMessage mail = new MailMessage("integratie.tesla@gmail.com",adress);
                SmtpClient smtpClient = new SmtpClient
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Host = "smtp.gmail.com",
                    UseDefaultCredentials = false,
                    Credentials = new System.Net.NetworkCredential("integratie.tesla@gmail.com", "PepeH4nds!"),
                    EnableSsl = true
                };
                //string htmlMessage = @"<html><body>" + Body + @"<br><img src='cid:Graph' /></body></html>";
                string htmlMessage = @"<html><body>" + name + @"<br><br>" + body + "<br><br>TeamTesla</body></html>";
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                                               htmlMessage,
                                               Encoding.UTF8,
                                               MediaTypeNames.Text.Html);
                // Create a plain text message for client that don't support HTML
                AlternateView plainView = AlternateView.CreateAlternateViewFromString(name + " \n\n" + body + " \n\nTeamTesla",Encoding.UTF8,MediaTypeNames.Text.Plain);
                //LinkedResource graph = new LinkedResource(@"C:\Users\Marnick\Source\Repos\IntegratieProject\Integratie.BL\Managers\4.png","image/png");
                //graph.ContentId = "Graph";
                //graph.ContentType.MediaType = "image/png";
                //graph.TransferEncoding = TransferEncoding.Base64;
                //graph.ContentType.Name = graph.ContentId;
                //graph.ContentLink = new Uri("cid:" + graph.ContentId);
                //htmlView.LinkedResources.Add(graph);
                mail.AlternateViews.Add(plainView);
                mail.AlternateViews.Add(htmlView);
                mail.IsBodyHtml = true;
                mail.Subject = "SMTP Test";
                smtpClient.Send(mail);
                Console.WriteLine("Mail send");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
