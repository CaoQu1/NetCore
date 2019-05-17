using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NetCore
{
    public abstract class HttpResponse
    {
        public abstract Stream OutputStream { get; }
        public abstract string ContentType { get; set; }
        public abstract int StatusCode { get; set; }
        public void WriteFile(string fileName, string contentType)
        {
            if (File.Exists(fileName))
            {
                byte[] content = File.ReadAllBytes(fileName);
                this.ContentType = contentType;
                this.OutputStream.Write(content, 0, content.Length);
            }
            this.StatusCode = 404;
        }
    }
}
