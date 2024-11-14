namespace CeLishp.Interpreter
{
    /// <summary>
    /// Input value that can be inserted in a tree - provides a value
    /// </summary>
    public interface IInputValue : IInterpretable
    {
        public object GetValue();
    }
    
}