using System.Collections.Generic;
using CeLishp.Interpreter;

namespace CeLishp.Parser
{
    /// <summary>
    /// Provides syntax parsing functionality - a concrete implementation defines the syntactic layout of the language.
    /// </summary>
    public interface ISyntaxProvider
    {
        /// <summary>
        /// Generate a <see cref="SyntaxTree"/> from the given input string
        /// </summary>
        /// <param name="source">Source code to be parsed</param>
        /// <returns><see cref="SyntaxTree"/> of the parsed source code</returns>
        public SyntaxTree GenerateTree(string source);
        /// <summary>
        /// Parse a SyntaxTree and generate an <see cref="InterpretableTree"/> that can be run by an <see cref="Interpreter"/>
        /// </summary>
        /// <param name="parsedSource">The <see cref="SyntaxTree"/> to be converted</param>
        /// <param name="functionInventory">A dictionary containing the function names and their corresponding <see cref="INaryFunction"/></param>
        /// <param name="valueInventory">A dictionary containing value names as they would appear in the <see cref="SyntaxTree"/> and their corresponding <see cref="IInputValue"/></param>
        /// <returns><see cref="InterpretableTree"/> that can be run</returns>
        public InterpretableTree ParseTree(SyntaxTree parsedSource, 
            Dictionary<string, INaryFunction> functionInventory,
            Dictionary<string, IInputValue> valueInventory);
    }
}