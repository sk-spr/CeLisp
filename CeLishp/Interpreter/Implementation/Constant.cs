namespace CeLishp.Interpreter.Implementation
{
    /// <summary>
    /// Simple <see cref="IInputValue"/> that simply provides a constant value of type T
    /// </summary>
    /// <typeparam name="T">The type of the constant to be provided</typeparam>
    public class Constant<T>(T val) : IInputValue where T : notnull
    {
        /// <summary>
        /// Run the Constant as an <see cref="IInterpretable"/>
        /// </summary>
        /// <param name="input">Inputs. Should be null.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException">Currently throws, as Constants expect to be treated as <see cref="IInputValue"/></exception>
        public object Run(object[] input)
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Get the value of the Constant
        /// </summary>
        /// <returns>Constant's value of type <typeparamref name="T"/></returns>
        public object GetValue()
        {
            return val;
        }
    }
}