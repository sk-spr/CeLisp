using System;
using System.Collections.Generic;

namespace CeLishp.Interpreter.Implementation
{
    /// <summary>
    /// Unary trigonometry functions.
    /// </summary>
    public class UnaryTrig : INaryFunction
    {
        /// <summary>
        /// The supported operations
        /// </summary>
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
        /// <summary>
        /// Create a new UnaryTrig <see cref="INaryFunction"/> of the given trigonometric function
        /// </summary>
        /// <param name="func">The function which should be performed when running</param>
        public UnaryTrig(UnaryTrigFunction func)
        {
            ownFunc = func;
        }
        /// <summary>
        /// Run the function as an <see cref="IInterpretable"/>.
        /// </summary>
        /// <param name="input">Input values</param>
        /// <returns>Nothing</returns>
        /// <exception cref="NotImplementedException">Always throws since <see cref="UnaryTrig"/> expects to be run as an <see cref="INaryFunction"/></exception>
        public object Run(object[] input)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Run the function as an <see cref="INaryFunction"/>
        /// </summary>
        /// <param name="inputs">Input value. Must be exactly one float, in radians.</param>
        /// <returns>The result of the chosen trigonometric function on the input value.</returns>
        /// <exception cref="ArgumentException">Throws if there is not exactly one argument of type float provided.</exception>
        public object RunNary(object[] inputs)
        {
            if (inputs == null || inputs.Length > 1 || !(inputs[0] is float f))
                throw new ArgumentException("Sine can only work with floats");
            return funcs[ownFunc](f);
        }
    }
}