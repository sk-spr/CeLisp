using System;

namespace CeLishp.Interpreter
{
    /// <summary>
    /// Base interface for interpretable elements
    /// </summary>
    public interface IInterpretable
    {
        /// <summary>
        /// Run the interpretable over the given inputs
        /// </summary>
        /// <param name="input">The inputs to the interpretable. Can be null.</param>
        /// <returns>The result of the operation</returns>
        public object Run(object[] input);
    }
}