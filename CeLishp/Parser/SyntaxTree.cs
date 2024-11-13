using CeLishp.Interpreter;

namespace CeLishp.Parser
{
    public class SyntaxTree
    {
        public SyntaxNode RootNode;
        public override string ToString()
        {
            return "Tree with root: " + RootNode;
        }
    }
}