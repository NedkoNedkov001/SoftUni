using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server.Forms
{
    public class HtmlForm
    {
        public const string HtmlFormText = @"<form action='/HTML' method='POST'>
    Name: <input type='text' name='Name'/>
    Age: <input type='number' name='Age'/>
    <input type='submit' value='Save'/>
</form>";

    }
}
