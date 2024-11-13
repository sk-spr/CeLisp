using System;

namespace CeLishp.Interpreter.Implementation
{
    public class NarySubtraction : INaryFunction
    {
        public object Run(IInterpretable input)
        {
            throw new System.NotImplementedException();
        }

        public object RunNary(object[] inputs)
        {
            float res = 0f;
            if (inputs[0] is int i1)
                res = 2 * i1;
            else if (inputs[0] is float f1)
                res = 2 * f1;
            foreach (var input in inputs)
            {
                if (input is int i)
                    res -= i;
                else if (input is float f)
                    res -= f;
                else
                    throw new Exception("Subtraction arguments must be int or float");
            }

            return res;
        }
    }
}