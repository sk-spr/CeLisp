using System;
using System.Linq;

namespace CeLishp.Interpreter.Implementation
{
    /// <summary>
    /// Addition function taking a variable number of inputs.
    /// </summary>
    public class NaryAddition : INaryFunction
    {
        /// <summary>
        /// Run the function as an <see cref="IInterpretable"/>
        /// </summary>
        /// <param name="input">Inputs to the addition function</param>
        /// <returns>Nothing</returns>
        /// <exception cref="NotImplementedException">Throws since <see cref="NaryAddition"/> expects to be run as a <see cref="INaryFunction"/></exception>
        public object Run(object[] input)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Run the addition function
        /// </summary>
        /// <param name="inputs">Inputs to be summed, must be floats or ints</param>
        /// <returns>Result as float</returns>
        /// <exception cref="ArgumentException">If any arguments are not float or int, the function throws.</exception>
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