using System;
using Newtonsoft.Json.Linq;

namespace SearchFight
{
public class GoogleSearch : SearchEngine
{
    public GoogleSearch()
    {
        url = "https://www.googleapis.com/customsearch/v1?q={0}&cx={1}&key={2}";
        apiKey = "AIzaSyC00JTgZqL9Mmy4cBcFTfxDxm9m1KDrVng";
        customApiSearchAttribute = "010922800395368098669:vntth_c10be";
    }

    protected override System.IO.Stream GetWebResponseStream(string keywords)
    {
        System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(string.Format(url, keywords, customApiSearchAttribute, apiKey));
        System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
        return response.GetResponseStream();
    }

    protected override System.IO.Stream GetFileMockStream(string keywords)
    {
        System.IO.FileStream fileStream = new  System.IO.FileStream("./mock.google.response.java.json",  System.IO.FileMode.Open);
        return fileStream;       
    }


    protected override long ExtractResultCountFromResult(string searchResult)
    {
        JObject jsonResponse = ((JObject)Newtonsoft.Json.JsonConvert.DeserializeObject(searchResult));                    
        string resultValue = jsonResponse["searchInformation"]["totalResults"].ToString();
        return long.Parse(resultValue);
    }    
}
}