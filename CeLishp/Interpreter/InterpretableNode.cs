namespace CeLishp.Interpreter
{
    public struct InterpretableNode
    {
        public IInterpretable Content;
        public InterpretableNode[] Children;
    }
}