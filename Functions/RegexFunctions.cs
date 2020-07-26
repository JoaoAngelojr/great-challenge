using System.Text;
using System.Text.RegularExpressions;

namespace great_challenge.Functions
{
    public class RegexFunctions
    {
        public string ClearSearchExpression(string expression)
        {
            return Regex.Replace(expression.Trim().ToLower(), @"[^a-zA-Z0-9:,]+", string.Empty);
        }
    }
}