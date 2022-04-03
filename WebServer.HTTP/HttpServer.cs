using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WebServer.HTTP
{
    public class HttpServer : IHttpServer
    {
     
        IDictionary<string,Func<HttpRequest,HttpResponse>> routeTable
            = new Dictionary<string,Func<HttpRequest, HttpResponse>>();
        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action)
        {
            if (routeTable.ContainsKey(path))
            {
                routeTable[path] = action;
            }
            else
            {
                routeTable.Add(path, action);
            }
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
                if (this.routeTable.ContainsKey(request.Path))
                {
                    var action=this.routeTable[request.Path];
                    response = action(request);
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