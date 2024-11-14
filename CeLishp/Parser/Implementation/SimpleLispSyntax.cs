using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using CeLishp.Interpreter;
using CeLishp.Interpreter.Implementation;

namespace CeLishp.Parser.Implementation
{
    /// <summary>
    /// One possible implementation of a <see cref="ISyntaxProvider"/> providing a simple lisp-like syntax
    /// </summary>
    public class SimpleLispSyntax : ISyntaxProvider
    {
        /// <summary>
        /// Generate a <see cref="SyntaxTree"/> from the given lisp-like input string
        /// </summary>
        /// <param name="source">Source code to be parsed</param>
        /// <returns><see cref="SyntaxTree"/> of the parsed source code</returns>
        public SyntaxTree GenerateTree(string source)
        {
            var tree = new SyntaxTree();
            tree.RootNode = GenerateSubtree(source);
            return tree;
        }


        /// <inheritdoc />
        public InterpretableTree ParseTree(SyntaxTree parsedSource, Dictionary<string, INaryFunction> naryInventory,
            Dictionary<string, IInputValue> valueInventory)
        {
            return new InterpretableTree(){RootNode = ParseSubtree(parsedSource.RootNode, naryInventory, valueInventory)};
        }

        private InterpretableNode ParseSubtree(SyntaxNode startNode, Dictionary<string, INaryFunction> naryInventory,
            Dictionary<string, IInputValue> valueInventory)
        {
            InterpretableNode localRoot = new InterpretableNode();
            float literal = 0f;
            if (float.TryParse(startNode.content, out literal))
                localRoot.Content = new Constant<float>(literal);
            else if (naryInventory.ContainsKey(startNode.content))
            {
                if (startNode.Children == null)
                    throw new Exception("A function must have at least one parameter!");
                localRoot.Content = naryInventory[startNode.content];
                localRoot.Children = startNode.Children.Select(n => ParseSubtree(n, naryInventory, valueInventory))
                    .ToArray();
            }
            else if (valueInventory.ContainsKey(startNode.content))
            {
                if (startNode.Children != null)
                    throw new Exception("A value cannot have parameters!");
                localRoot.Content = valueInventory[startNode.content];
            }
            else
                throw new Exception("Function or value not found");

            return localRoot;
        }

        private SyntaxNode GenerateSubtree(string source)
        {
            var trimmed = source.Trim();
            if (!trimmed.StartsWith("(") || !trimmed.EndsWith(")"))
                throw new ArgumentException($"Source {source} not start and end with (/)");
            trimmed = trimmed.Substring(1, trimmed.Length - 2);
            
            
            var childNodes = new List<SyntaxNode>();
            (string before, string inner, string remainder) res = MatchParenContents(trimmed);
            var exprs = res.before.Split(' ');
            res.remainder = trimmed.Substring(exprs[0].Length);
            while (res.remainder != "")
            {
                var keywords = res.before.Split(' ').ToList();
                keywords.RemoveAll(s => s.All(c => c == ' '));
                keywords.RemoveAt(0);
                foreach (var kw in keywords)
                    childNodes.Add(new SyntaxNode() {Children = null, content = kw});
                if(res.inner != "")
                    childNodes.Add(GenerateSubtree("("+res.inner));
                res = MatchParenContents(res.remainder);
            }
            
            return new SyntaxNode
            {
                Children = childNodes.ToArray(),
                content = exprs[0]
            };
        }

        private (string before, string inner, string remainder) MatchParenContents(string source)
        {
            string before = "";
            while (source.Length > 0 && !source.StartsWith("("))
            {
                before += source[0];
                source = source.Substring(1);
            }
            if (source.Length == 0)
                return (before, "", "");
            var nOpen = 1;
            source = source.Substring(1);
            var content = "";
            while(source.Length > 0 && nOpen > 0)
            {
                if (source[0] == '(')
                    nOpen++;
                else if (source[0] == ')')
                    nOpen--;
                content += source[0];
                source = source.Substring(1);
            }
            

            return (before, content, source);
        }
    }
}