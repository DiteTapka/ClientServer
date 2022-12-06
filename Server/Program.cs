using System.Text.Json.Serialization;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using JsonConverter = Newtonsoft.Json.JsonConverter;


class Program
{
    public static void Main(string[] args)
    {
        var httpListner = new HttpListener();
        httpListner.Prefixes.Add("http://localhost:5213/");
        httpListner.Start();
        var list = new ContactList(50);
        while (true)
        {
            var reqContext = httpListner.GetContext();
            var request = reqContext.Request;
            var responseValue = "";
                if (request.Url.PathAndQuery == "/Issue")
            {
                
                    switch (request.HttpMethod)
                {
                    case "GET":
                        reqContext.Response.StatusCode = 200;
                        var _list = JsonConvert.SerializeObject(list.GetContacts());
                        responseValue = _list;
                        break;
                    case "POST":
                        reqContext.Response.StatusCode = 200;

                            responseValue = "ADD_NEW_CONTACT";
                            break;
                    case "DELETE":
                        reqContext.Response.StatusCode = 200;
                            responseValue = "REMOVE_CONTACT";
                            
                            break;
                    default:
                        reqContext.Response.StatusCode = 500;
                        responseValue = "Problem";
                            break;

                    }
            }

            reqContext.Response.StatusCode = 200;//ok
            var stream = reqContext.Response.OutputStream;
            
            var bytes = Encoding.UTF8.GetBytes(responseValue);
            stream.Write(bytes, 0, bytes.Length);
            reqContext.Response.Close();

        }


        httpListner.Stop();
        httpListner.Close();
    }
}




