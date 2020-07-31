using System;
using System.IO;
using System.Net;

namespace CallExternalAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Post();
        }

        private static void Get()
        {
            string stringUrlTest = string.Format("https://jsonplaceholder.typicode.com/posts/1/comments");

            WebRequest requestObject = WebRequest.Create(stringUrlTest);

            requestObject.Method = "GET";

            HttpWebResponse responseObject = null;

            responseObject = (HttpWebResponse)requestObject.GetResponse();

            string stringResultTest = null;

            using (Stream stream = responseObject.GetResponseStream())
            {
                StreamReader streamReader = new StreamReader(stream);
                stringResultTest = streamReader.ReadToEnd();
                streamReader.Close();
            }

            Console.WriteLine(stringResultTest);
            Console.Read();
        }

        private static void Post()
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            
            string stringUrlTest = string.Format(url);

            WebRequest requestObject = WebRequest.Create(stringUrlTest);

            requestObject.Method = "POST";

            requestObject.ContentType = "application/json";

            string postData = "{" +
                "\"title\": \"joshuaWaheedTestTitle\"," +
                "\"body\": \"joshuaWaheedTestBody\"," +
                "\"userId\": \"50\"" +
            "}";

            using (var streamWriter = new StreamWriter(requestObject.GetRequestStream()))
            {
                streamWriter.Write(postData);
                streamWriter.Flush();
                streamWriter.Close();

                var responseObject = requestObject.GetResponse();

                string stringResultTest = null;

                using (Stream stream = responseObject.GetResponseStream())
                {
                    StreamReader streamReader = new StreamReader(stream);
                    stringResultTest = streamReader.ReadToEnd();
                    streamReader.Close();
                }

                Console.WriteLine(stringResultTest);
                Console.Read();
            }
        }
    }
}
