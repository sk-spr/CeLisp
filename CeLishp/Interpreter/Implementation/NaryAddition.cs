using System;
using System.Linq;

namespace CeLishp.Interpreter.Implementation
{
    public class NaryAddition : INaryFunction
    {
        public object Run(IInterpretable input)
        {
            throw new System.NotImplementedException();
        }

        public object RunNary(object[] inputs)
        {
            if (inputs.Any(x => !(x is float _) && !(x is int _)))
            {
                throw new ArgumentException("Addition only works on float and int");
            }

            float res = 0f;
            foreach (var input in inputs)
            {
                if (input is int i)
                    res += i;
                else if (input is float f)
                    res += f;
            }

            return res;
        }
    }
}