using JDoodleHttpClient.Models;
using OnlineCompiler.Models;

namespace OnlineCompiler.Helpers
{
    public static class CompilationFormatter
    {
        public static string RemoveWhiteSpaces(this string result)
        {
            return result.Replace("\n", "").Trim();
        }
    }
}
