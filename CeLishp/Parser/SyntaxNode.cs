using System.Linq;

namespace CeLishp.Parser
{
    /// <summary>
    /// A node in a syntax tree: Contains a function/keyword/literal and an optional list of child nodes.
    /// </summary>
    public struct SyntaxNode
    {
        /// <summary>
        /// Child nodes
        /// </summary>
        public SyntaxNode[] Children;
        /// <summary>
        /// The content of the node i.e. the syntactic element - function, literal, or value
        /// </summary>
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