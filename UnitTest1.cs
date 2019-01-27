using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{

     

    [TestClass]
    public class UnitTest1
    {

        public static string url = "http://deelay.me/5000/http://www.delsink.com";

        [TestMethod]
        public void TestMethod1()
        {
            var webRequest = HttpWebRequest.CreateHttp(url);
            var httpResponse = webRequest.GetResponse() as HttpWebResponse;

            var responseStream = httpResponse.GetResponseStream();

            using (var s = new StreamReader(responseStream))
            {
                var webPage = s.ReadToEnd();
                Debug.Write("done");
            }

        }


        private void HttpResponseAvailable(IAsyncResult ar)
        {

        }
    }
}
