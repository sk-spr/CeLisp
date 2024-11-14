namespace CeLishp.Interpreter
{
    /// <summary>
    /// <see cref="IInterpretable"/> that provides a function taking one or more inputs.
    /// </summary>
    public interface INaryFunction : IInterpretable
    {
        /// <summary>
        /// Run the function and return the result
        /// </summary>
        /// <param name="inputs">The input values to be operated on</param>
        /// <returns>The result of the given function over the given inputs.</returns>
        public object RunNary(object[] inputs);
    }
}