namespace CeLishp.Interpreter
{
    /// <summary>
    /// Struct representing a node in an <see cref="InterpretableTree"/>
    /// </summary>
    public struct InterpretableNode
    {
        /// <summary>
        /// The <see cref="IInterpretable"/> at the root of the node
        /// </summary>
        public IInterpretable Content;
        /// <summary>
        /// The children of the node, can be null e.g. for input values.
        /// </summary>
        public InterpretableNode[] Children;
    }
}