using CeLishp.Interpreter;

namespace CeLishp.Parser
{
    /// <summary>
    /// Syntax tree representing a parsed formula
    /// </summary>
    public class SyntaxTree
    {
        /// <summary>
        /// The root node of the tree
        /// </summary>
        public SyntaxNode RootNode;
        public override string ToString()
        {
            return "Tree with root: " + RootNode;
        }
    }
}