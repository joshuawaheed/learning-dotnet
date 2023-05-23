using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;

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

            var comments = JsonConvert.DeserializeObject<IEnumerable<Comment>>(stringResultTest);

            foreach (var comment in comments)
            {
                Console.WriteLine("Name: {0}", comment.Name);
                Console.WriteLine("Id: {0}", comment.Id);
                Console.WriteLine("PostId: {0}", comment.PostId);
                Console.WriteLine("Email: {0}", comment.Email);
                Console.WriteLine("Body: {0}", comment.Body);
                Console.WriteLine();
            }
            
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

    public class Comment
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
