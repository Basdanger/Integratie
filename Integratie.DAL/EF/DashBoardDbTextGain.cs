﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
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
<<<<<<< Updated upstream
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                //Dit fixt all Geo en de lege arrays, zoek manier om aanhalingstekens te verwijderen in gevulde arrays

                string stream=streamReader.ReadToEnd().Replace("\"geo\": false", "\"geo\": [null, null]")
                    /*.Replace("/\\[[^a-zA-Z][a-z A-Z]*[^a-zA-Z]\\]/", "/\\[[a-z A-Z]*\\]/")*/
                    .Replace("[","\"[").Replace("]", "]\"").Trim('"');

                char[] test = new char[] { '[',']'};
                string[] filter = stream.Split(test);
                
                for (int i = 0; i < filter.Length; i = i + 2)
                {
                    filter[i]=filter[i].Replace("\"",string.Empty);
                }
               
                return string.Join("",filter);
         
=======
            string pattern = @"^((?!(source | id | mentions | geo | words | profile | persons | education | hashtags | language | sentiment | urls | date | age | gender | themes | personality | retweet)).)*$";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                foreach (Match m in Regex.Matches(streamReader.ReadToEnd(), "\\[(\".*\"), *\\]"))
                {
                    Regex.Replace(m, "\"", String.Empty);
                }
                
                return streamReader.ReadToEnd().Replace("\"geo\": false", "\"geo\": [null, null]").Replace("[","\"[").Replace("]", "]\"").Trim('"');
>>>>>>> Stashed changes
            }
        }

    }
}