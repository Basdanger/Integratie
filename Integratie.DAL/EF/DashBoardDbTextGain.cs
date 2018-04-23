using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Integratie.DAL.EF
{
    public class DashBoardDbTextGain
    {
        public HttpWebRequest httpWebRequest { get; set; }

        public DashBoardDbTextGain()
        {
            httpWebRequest = (HttpWebRequest)WebRequest.Create("http://kdg.textgain.com/query");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            httpWebRequest.Headers.Add("X-API-Key", "aEN3K6VJPEoh3sMp9ZVA73kkr");
    }
        
        public String postJson()
        {
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return streamReader.ReadToEnd().Replace("\"geo\": false", "\"geo\": [null, null]").Replace("\"urls\": []", "\"urls\": null");
            }
        }
    }
}
