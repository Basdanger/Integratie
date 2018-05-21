using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Threading.Tasks;
using System.IO;


namespace Integratie.BL.Managers
{
    class FireBaseManager
    {
        public void SendNotification(string tekst, string deviceId)
        {
            try
            {
                //API Key
                string applicationID = "AAAAcTfJnS4:APA91bHFFcGS8Xj_lM-rebISWu4PIcPAX37n602vBrpPNeIAePiIiBFF38C22_fo0Zh4ZcIb_oRT6KtYokzPhRV6B3s82WD1lnfF9kYSsSdtkHSwZAVc5hJwYiAeFmNlpgLzfZoIS1nD";
                string senderId = "486267264302";
;

                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var data = new
                {
                    to = deviceId,
                    notification = new
                    {
                        body = tekst,
                        title = "Tesla",
                        sound = "Enabled"
                    }
                };

                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));
                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
                tRequest.ContentLength = byteArray.Length;

                using (Stream dataStream = tRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = tRequest.GetResponse())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {
                                String sResponseFromServer = tReader.ReadToEnd();
                                string str = sResponseFromServer;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                Console.WriteLine(str);
                Console.ReadLine();
            }
        }
    }
}
