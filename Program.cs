using System;
using System.Collections.Generic;
using System.Linq;

namespace SearchFight
{
    class Program
    {
        static void Main(string[] args)
        {
            SearchEngineExecutor searchEngineExecutor =  new SearchEngineExecutor();           
            List<SearchEngineResult> searchEngineResults = searchEngineExecutor.GetSearchEngineResults(args);
        
            //Execute search for each argument on Engines
            foreach(string arg in args)
            {
                string keywordLine = string.Format("{0}: ", arg);
                foreach(var searchEngineResult in searchEngineResults.Where(p => p.Keywords == arg))
                {                    
                    keywordLine = string.Concat(keywordLine, string.Format("{0}: {1} ", searchEngineResult.Name, searchEngineResult.Count));
                }
                Console.WriteLine(keywordLine);
            }

            //Winner by engine 
            var winners = from searchEngineResult in searchEngineResults
                            group searchEngineResult by searchEngineResult.Name into g 
                            select g.OrderByDescending(f => f.Count).FirstOrDefault();                            
            winners.ToList().ForEach(winner => Console.WriteLine("{0} Winner: {1} ({2})", winner.Name, winner.Keywords, winner.Count));

            //Winner by Keyword, accross engines
            var winnerByKeyword = from searchEngineResult in searchEngineResults
                                    group searchEngineResult by searchEngineResult.Keywords into g
                                    select new {SearchKeyword = g.Key, SumCount = g.Sum(f => f.Count) };
            var totalWinner = winnerByKeyword.OrderByDescending(f => f.SumCount).FirstOrDefault();
            Console.WriteLine("Total Winner: {0} ({1})", totalWinner.SearchKeyword, totalWinner.SumCount);
        }
    }
}
