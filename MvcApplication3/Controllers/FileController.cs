using MvcApplication3.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace MvcApplication3.Controllers
{
    public class FileController : ApiController
    {
        public IHttpActionResult Get(string fileName)
        {
            var serverPath = Path.Combine(System.IO.Path.GetTempPath(), fileName);
            var fileInfo = new FileInfo(serverPath);

            return !fileInfo.Exists
                ? (IHttpActionResult)NotFound()
                : new FileResult(fileInfo.FullName);

        }

        public HttpResponseMessage Post()
        {
            var sizeInMb = 5;
            string _fileName = System.IO.Path.GetTempPath() + Guid.NewGuid().ToString() + ".txt";
            const int blockSize = 1024 * 8;
            const int blocksPerMb = (1024 * 1024) / blockSize;
            Random rng = new Random((int)DateTime.Now.Ticks);

            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < blocksPerMb * blockSize; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rng.NextDouble() + 65)));
                builder.Append(ch);
            }

            var data = builder.ToString();

            using (FileStream stream = File.OpenWrite(_fileName))
            {
                // There 
                for (int i = 0; i < sizeInMb; i++)
                {
                    byte[] bytes = new byte[data.Length * sizeof(char)];
                    System.Buffer.BlockCopy(data.ToCharArray(), 0, bytes, 0, bytes.Length);

                    stream.Write(bytes, 0, data.Length);
                }
            }

            return Request.CreateResponse(HttpStatusCode.OK, new { fileName = Path.GetFileName(_fileName) });
        }
    }
}
