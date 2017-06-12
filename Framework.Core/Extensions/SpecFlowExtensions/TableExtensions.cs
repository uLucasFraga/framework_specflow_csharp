using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Framework.Core.Extensions.SpecFlowExtensions
{
    public static class TableExtensions
    {
        public static Dictionary<string, string> ToDictionary(this Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary.Add(row.Keys.ToArray()[0], row.Values.ToArray()[0]);
                dictionary.Add(row.Keys.ToArray()[1], row.Values.ToArray()[1]);
            }
            return dictionary;
        }

        public static string GetFirst(this Table table)
        {
            return table.Rows.First().Values.First();
        }

        public static string GetByOrder(this Table table, int order)
        {
            return table.Rows[order].Values.First();
        }
    }
}
