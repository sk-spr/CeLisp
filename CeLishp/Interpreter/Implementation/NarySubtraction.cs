using System;

namespace CeLishp.Interpreter.Implementation
{
    /// <summary>
    /// Subtraction function taking two or more arguments.
    /// </summary>
    public class NarySubtraction : INaryFunction
    {
        public object Run(object[] input)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Run the subtraction function on the given arguments
        /// </summary>
        /// <param name="inputs">At least two float or int parameters. All arguments after the first are subtracted from the first.</param>
        /// <returns>float of all following arguments subtracted from the first.</returns>
        /// <exception cref="ArgumentException">Throws if any arguments are non-float and non-int or if there is less than two provided.</exception>
        public object RunNary(object[] inputs)
        {
            if (inputs == null || inputs.Length < 2)
                throw new ArgumentException("At least two Inputs must be provided");
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
                    throw new ArgumentException("Subtraction arguments must be int or float");
            }

            return res;
        }
    }
}