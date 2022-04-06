using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WebServer.HTTP
{
    public class HttpServer : IHttpServer
    {
        List<Route> routeTable;
        public HttpServer(List<Route> routes)
        {
            routeTable = routes;
        }

        
       

        public async Task StartAsync(int port)
        {
           TcpListener tcpListener =
                new TcpListener(IPAddress.Loopback,port);
            tcpListener.Start();
            while (true)
            {
              var tcpClient= await tcpListener.AcceptTcpClientAsync();
               ProcessClientAsync(tcpClient); 
                
            }

        }

        private async Task ProcessClientAsync(TcpClient tcpListener)
        {

            using (NetworkStream stream = tcpListener.GetStream())
            {
                List<byte> data = new List<byte>();
               
                byte[] buffer = new byte[4096];
                int position = 0;
                
                while (true)
                {
                    int count=
                        await stream.ReadAsync(buffer,position,buffer.Length);
                    position += count;
                    if (count < buffer.Length)
                    {
                        var bufferWithData=new byte[count];
                        Array.Copy(buffer, bufferWithData, count);
                        data.AddRange(bufferWithData);
                        break;
                    }
                    else
                    {
                        data.AddRange(buffer);
                    }
              
                  
                }
                //byte[]=>string
               var requestAsString=Encoding.UTF8.GetString(data.ToArray());
                var request = new HttpRequest(requestAsString);
                
                Console.WriteLine(requestAsString);
                HttpResponse response;
                var route = this.routeTable.FirstOrDefault(x => string.Compare(x.Path,request.Path,true) == 0);
                if (route!=null)
                {
                    response = route.Action(request);
                   
                }
                else
                {
                    //Not Found
                    response = new HttpResponse("text/html", new byte[0], HttpStatusCode.NotFound);
                }
                var responseHtml = "<h1>Welcome!</h1>";
                var responseBody = Encoding.UTF8.GetBytes(responseHtml);
                
                response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString())
                {HttpOnly=true,MaxAge=60*24*60*60 });
             


                var responseHeader = Encoding.UTF8.GetBytes(response.ToString());
                await stream.WriteAsync(responseHeader);
                await stream.WriteAsync(response.Body);
               
            }
            tcpListener.Close();
        }
    }
}