using System;

namespace SearchFight
{
public class SearchEngine
{
    protected string url;
    protected string apiKey;
    protected string customApiSearchAttribute; 

    
    protected virtual System.IO.Stream GetFileMockStream(string keywords)
    {
        return null;
    }
    protected virtual System.IO.Stream GetWebResponseStream(string keywords)
    {
        return null;
    }

    protected virtual long ExtractResultCountFromResult(string searchResult)
    {
        return -1;
    }

    public virtual long SearchCount(string keywords)
    {
        string response = GetSearchResults(keywords);
        return ExtractResultCountFromResult(response);        
        //return new Random().Next(0, 50);
    }

    public string GetSearchResults(string keywords)
    {
        string responseString = "";
        System.IO.Stream responseStream;     
        //responseStream = GetFileMockStream(keywords);        
        responseStream = GetWebResponseStream(keywords);        
        try
        {            
            System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream);
            responseString = streamReader.ReadToEnd();
        }
        finally
        {
            responseStream.Dispose();
        }        
        return responseString;
    }

}
}