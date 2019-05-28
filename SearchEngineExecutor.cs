using System;
using System.Collections.Generic;

namespace SearchFight
{
public class SearchEngineExecutor
{

    private List<SearchEngine> GetSearchEngines()
    {
        //To-do: read this from config and make it a factory, instatiating depending on type of search
        List<SearchEngine> list = new List<SearchEngine>();
        list.Add(new GoogleSearch());
        list.Add(new BingSearch());
        return list;
    }

    public List<SearchEngineResult> GetSearchEngineResults(string[] keywordArray)
    {
        List<SearchEngineResult> returnValue = new  List<SearchEngineResult>();
        List<SearchEngine> searchEngineList = GetSearchEngines();       

        foreach(string keyword in keywordArray)
        {
            foreach (SearchEngine searchEngine in searchEngineList)
            {
                SearchEngineResult searchEngineResult = new SearchEngineResult();
                searchEngineResult.Name = searchEngine.GetType().ToString();
                searchEngineResult.Keywords = keyword;
                searchEngineResult.Count = searchEngine.SearchCount(keyword);
                returnValue.Add(searchEngineResult);
            }
        }
        return returnValue;
    }
}
}