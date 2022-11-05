namespace OnlineCompiler.Models
{
    public class CompilationRequestContract
    {
        public string Script { get; set; }
        public string Language { get; set; }
        public string VersionIndex { get; set; }
    }
}
