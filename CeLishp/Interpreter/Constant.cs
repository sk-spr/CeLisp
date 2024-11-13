namespace CeLishp.Interpreter
{
    public class Constant<T> : IInputValue
    {
        private T v;
        public Constant(T val)
        {
            v = val;
        }
        public object Run(IInterpretable input)
        {
            throw new System.NotImplementedException();
        }

        public object GetValue()
        {
            return v;
        }
    }
}