using System;
using System.Linq;

namespace CeLishp.Interpreter
{
    public class Interpreter
    {
        private InterpretableTree Interpretables;

        public Interpreter(InterpretableTree tree)
        {
            Interpretables = tree;
        }

        public T RunTree<T>()
        {
            var result = RunRecursively(Interpretables.RootNode);
            if (result is T rt)
                return rt;
            throw new Exception("Top level function did not return expected type!");
        }

        private object RunRecursively(InterpretableNode startNode)
        {
            object[] inputs;

            if (startNode.Content is INaryFunction fun)
            {
                if (startNode.Children == null)
                    throw new Exception("Functions must have inputs!");
                inputs = startNode.Children.Select(RunRecursively).ToArray();
                return fun.RunNary(inputs);
            }

            if (startNode.Content is IInputValue val)
            {
                return val.GetValue();
            }

            if (startNode.Children != null)
                return startNode.Content.Run(startNode.Children.Select(x => x.Content).ToArray<object>());
            return startNode.Content.Run(null);
        }
    }
}