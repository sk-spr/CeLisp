namespace CeLishp.Interpreter
{
    public interface IInputValue : IInterpretable
    {
        public object GetValue();
    }
    public interface IInputValue<T> : IInputValue
    {
        public new T GetValue();
    }
    
}