using System;
using Newtonsoft.Json.Linq;

namespace SearchFight
{
public class BingSearch : SearchEngine
{
    public BingSearch()
    {
        //to-do: Read from config file
        url = "https://api.cognitive.microsoft.com/bingcustomsearch/v7.0/search?q={0}&customconfig=<CUSTOM_CONFIG_ID>";

        //to-do: Read from secret repository
        apiKey = "";
        customApiSearchAttribute = "";
        url = url.Replace("<CUSTOM_CONFIG_ID>", customApiSearchAttribute);
    }

    protected override System.IO.Stream GetWebResponseStream(string keywords)
    {
        System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(string.Format(url, keywords));
        request.Headers.Add("Ocp-Apim-Subscription-Key", apiKey);
        System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
        return response.GetResponseStream();         
    }

    protected override  System.IO.Stream GetFileMockStream(string keywords)
    {
        System.IO.FileStream fileStream = new  System.IO.FileStream("./mock.bing.response.java.json",  System.IO.FileMode.Open);
        return fileStream;       
    }


    protected override long ExtractResultCountFromResult(string searchResult)
    {        
        JObject jsonResponse = ((JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(searchResult));                    
        string resultValue = jsonResponse["webPages"]["totalEstimatedMatches"].ToString();
        return long.Parse(resultValue);

    }
    
}
}
