// See https://aka.ms/new-console-template for more information

using BasicWebServer.Demo.Controllers;
using BasicWebServer.Server;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.Forms;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Responses;
using System.Text;
using System.Web;


await new HttpServer(routes => routes
    .MapControllers())
    .Start();
