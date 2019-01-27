using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using  System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{

     

    [TestClass]
    public class UnitTest1
    {

        public static string url = "http://deelay.me/5000/http://www.delsink.com";

        public static string connectionString = "Data Source=.\\local2;Initial Catalog=honey;Integrated Security=True";


        public void responseReady(IAsyncResult ar)
        {
            var sqlComment = ar.AsyncState as SqlCommand;
            using (var reader = sqlComment.EndExecuteReader(ar))
            {
                while (reader.Read())
                {
                    string version = reader[0].ToString();

                }

            }

           


        }

        [TestMethod]
        public  void test_db()
        {
            string sqlQuery = "Select @@VERSION";

            using ( var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                var sqlcommend =  new SqlCommand(sqlQuery,sqlConnection);

                var callBack = new AsyncCallback(responseReady); 

               var ar =   sqlcommend.BeginExecuteReader(callBack, sqlcommend);


               ar.AsyncWaitHandle.WaitOne();

               //using (var sqlComment = new SqlCommand(sqlQuery,sqlConnection))
               //{
               //    //using (var reader = sqlComment.ExecuteReader())
               //    //{
               //    //    while (reader.Read())
               //    //    {
               //    //        string version = reader[0].ToString();
               //    //        Debug.WriteLine(version);
               //    //    }
               //    //}
               //}

            }

        }


        [TestMethod]
        public void TestMethod1()
        {
            //var webRequest = HttpWebRequest.CreateHttp(url);

            //var callBack = new AsyncCallback(HttpResponseAvailable);


            //var httpResponse = webRequest.BeginGetResponse(callBack, webRequest);

            ////var httpResponse = webRequest.GetResponse() as HttpWebResponse;
            ////var responseStream = httpResponse.GetResponseStream();
            ////using (var s = new StreamReader(responseStream))
            ////{
            ////    var webPage = s.ReadToEnd();
            ////    Debug.Write("done");
            ////}

            //httpResponse.AsyncWaitHandle.WaitOne();


        }


        private void HttpResponseAvailable(IAsyncResult ar)
        {

            var httpwebRequest = ar.AsyncState as HttpWebRequest;
            var httpResponse = httpwebRequest.EndGetResponse(ar) as HttpWebResponse;

            var response = httpResponse.GetResponseStream();

            using (var s = new StreamReader(response))
            {
                var webpage = s.ReadToEnd();
                Debug.WriteLine("-------------- Farham D0ne -------------");
            }

            //var httpResponse = webRequest.GetResponse() as HttpWebResponse;
            //var responseStream = httpResponse.GetResponseStream();
            //using (var s = new StreamReader(responseStream))
            //{
            //    var webPage = s.ReadToEnd();
            //    Debug.Write("done");
            //}


            //var httpResponse = webRequest.GetResponse() as HttpWebResponse;
            //var responseStream = httpResponse.GetResponseStream();
            //using (var s = new StreamReader(responseStream))
            //{
            //    var webPage = s.ReadToEnd();
            //    Debug.Write("done");
            //}
        }
    }
}
