using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Forms
{
    public class DownloadForm
    {
        public const string DownloadFormText = @"<form action='/Content' method='POST'>
                <input type='submit' value='Download Sites Content' />
            </form>";

        public const string FileName = "content.txt";
    }
}
