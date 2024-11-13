namespace CeLishp.Interpreter
{
    public interface INaryFunction : IInterpretable
    {
        public object RunNary(object[] inputs);
    }
}