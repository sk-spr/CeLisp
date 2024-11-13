using System.Collections.Generic;
using CeLishp.Interpreter;

namespace CeLishp.Parser
{
    public interface ISyntaxProvider
    {
        public SyntaxTree GenerateTree(string source);
        public InterpretableTree ParseTree(SyntaxTree parsedSource, 
            Dictionary<string, INaryFunction> functionInventory,
            Dictionary<string, IInputValue> valueInventory);
    }
}