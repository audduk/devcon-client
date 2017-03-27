using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace devcon_client.Helpers
{
  public static class RequestHelper
  {
        public static async Task<string> MakePostRequest(string url, string data, string cookie, bool isJson = true)
    {
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
      if (isJson)
        request.ContentType = "application/json";
      else
        request.ContentType = "application/x-www-form-urlencoded";
      request.Method = "POST";
      request.Headers["Cookie"] = cookie;
      var stream = await request.GetRequestStreamAsync();
      using (var writer = new StreamWriter(stream))
      {
        writer.Write(data);
        writer.Flush();
        writer.Dispose();
      }

      var response = await request.GetResponseAsync();
      var respStream = response.GetResponseStream();


      using (StreamReader sr = new StreamReader(respStream))
      {
        //Need to return this response 
        return sr.ReadToEnd();
      }
    }
  }
}
