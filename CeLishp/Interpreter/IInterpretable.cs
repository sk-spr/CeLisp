using System;

namespace CeLishp.Interpreter
{
    public interface IInterpretable
    {
        public object Run(IInterpretable input);
    }
    public interface IInterpretable<TO>
    {
        public TO Run<TI>(IInterpretable<TI> inputs);
    }
}