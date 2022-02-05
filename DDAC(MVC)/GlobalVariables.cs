using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DDAC_MVC_
{
    public class GlobalVariables
    {
        public static HttpClient WebApiClient = new HttpClient();

        static GlobalVariables()
        {
            WebApiClient.BaseAddress = new Uri("https://localhost:44382/api/");

            //Points to Lambda - Old Test-Lambda
            //WebApiClient.BaseAddress = new Uri("https://99uzriezxl.execute-api.ap-southeast-1.amazonaws.com/Prod/api/");

            //US Lambda
            //WebApiClient.BaseAddress = new Uri("https://2b9fmscy46.execute-api.us-east-1.amazonaws.com/Prod/api");

            //New Lambda JFC-Lambda - Singapore
            //WebApiClient.BaseAddress = new Uri("https://bjaknfg5nl.execute-api.ap-southeast-1.amazonaws.com/Prod/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //To change lambdas
            //Change json settings to singapore region
            //Put breakpoints in startup
        }

    }
}
