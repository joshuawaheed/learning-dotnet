using System;
using System.IO;
using System.Net;

namespace CallExternalAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Get();
        }

        private static void Get()
        {
            string stringUrlTest = string.Format("http://jsonplaceholder.typicode.com/posts/1/comments");

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
    }
}
