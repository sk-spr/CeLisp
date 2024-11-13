using System;
using System.Collections.Generic;

namespace CeLishp.Interpreter.Implementation
{
    public class UnaryTrig : INaryFunction
    {
        public enum UnaryTrigFunction
        {
            Sine,
            Cosine,
            Tangent,
            Arcsin,
            Arccos,
            Arctan
        }

        private UnaryTrigFunction ownFunc;

        private static readonly Dictionary<UnaryTrigFunction, Func<float, float>> funcs = new Dictionary<UnaryTrigFunction, Func<float, float>>()
        {
            { UnaryTrigFunction.Sine, f => (float) Math.Sin((double) f)},
            { UnaryTrigFunction.Cosine, f => (float) Math.Cos((double) f)},
            { UnaryTrigFunction.Tangent, f => (float) Math.Tan((double) f)},
            { UnaryTrigFunction.Arcsin, f => (float) Math.Asin((double) f)},
            { UnaryTrigFunction.Arccos, f => (float) Math.Acos((double) f)},
            { UnaryTrigFunction.Arctan, f => (float) Math.Atan((double) f)},
        };

        public UnaryTrig(UnaryTrigFunction func)
        {
            ownFunc = func;
        }
        public object Run(IInterpretable input)
        {
            throw new System.NotImplementedException();
        }

        public object RunNary(object[] inputs)
        {
            if (inputs == null || inputs.Length > 1 || !(inputs[0] is float f))
                throw new ArgumentException("Sine can only work with floats");
            return funcs[ownFunc](f);
        }
    }
}