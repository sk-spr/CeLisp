using System.Linq;

namespace CeLishp.Parser
{
    public struct SyntaxNode
    {
        public SyntaxNode[] Children;
        public string content;
        public override string ToString()
        {
            var childStrings = Children?.Select(c => 
                c.ToString()
                    .Split('\n')
                    .Aggregate("", (a,b) => a + (a == "" ? "" : "\n") + "\t" + b));
            return $"SyntaxNode {content}" + childStrings?.Aggregate("", (a,b) => a + "\n" + b);
        }
    }
}