using System;
using System.Collections.Generic;
using CeLishp.Interpreter;
using CeLishp.Interpreter.Implementation;
using CeLishp.Parser;
using CeLishp.Parser.Implementation;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class Tests
    {
        private Dictionary<string, INaryFunction> NaryInventory = new Dictionary<string, INaryFunction>()
        {
            {"+", new NaryAddition()},
            {"-", new NarySubtraction()},
            {"sin", new UnaryTrig(UnaryTrig.UnaryTrigFunction.Sine)},
            {"cos", new UnaryTrig(UnaryTrig.UnaryTrigFunction.Cosine)}
        };
        private Dictionary<string, IInputValue> ValueInventory = new Dictionary<string, IInputValue>()
        {
            {"x", new Constant<float>(1)},
            {"y", new Constant<float>(2)},
            {"z", new Constant<float>(3)}
        };
        [Test]
        public void TwoNumberAddition()
        {
            ISyntaxProvider ls = new SimpleLispSyntax();
            var tree = ls.GenerateTree("(+ 1 2)");
            Console.WriteLine(tree);
            Assert.True(tree.RootNode.content == "+", "tree.RootNode.content == '+'");
            Assert.True(tree.RootNode.Children.Length == 2, $"tree.RootNode.Children.Length == 2, \nwas {tree}");
        }

        [Test]
        public void NestedFunctionTree()
        {
            ISyntaxProvider ls = new SimpleLispSyntax();
            var tree = ls.GenerateTree("(+ 1 (- 2 3))");
            Console.WriteLine(tree);
            Assert.True(tree.RootNode.content == "+", "tree.RootNode.content == '+'");
            var l1 = tree.RootNode.Children;
            Assert.True(l1 != null, "rootNode has children");
            Assert.True(l1.Length == 2, "l1.Length == 2");
        }

        [Test]
        public void AdditionCalculation ()
        {
            ISyntaxProvider ls = new SimpleLispSyntax();
            var tree = ls.GenerateTree("(+ 1 2)");
            Console.WriteLine(tree);
            var exTree = ls.ParseTree(tree, NaryInventory, ValueInventory);
            Console.WriteLine(exTree.RootNode.Children[0].Content);
            var interpreter = new Interpreter(exTree);
            Assert.AreEqual(3.0, (double) interpreter.RunTree<float>(), 0.001);
        }
        [Test]
        public void NestedFunctionCalculation()
        {
            ISyntaxProvider ls = new SimpleLispSyntax();
            var tree = ls.GenerateTree("(+ 1 (- 2.5 3))");
            var exTree = ls.ParseTree(tree, NaryInventory, ValueInventory);
            var interpreter = new Interpreter(exTree);
            Assert.AreEqual(0.5, (double) interpreter.RunTree<float>(), 0.01);
        }

        [Test]
        public void NestedTrig()
        {
            ISyntaxProvider ls = new SimpleLispSyntax();
            var tree = ls.GenerateTree("(sin (cos (+ x y)))");
            var exTree = ls.ParseTree(tree, NaryInventory, ValueInventory);
            var interpreter = new Interpreter(exTree);
            Assert.AreEqual(-0.83602186153, (double) interpreter.RunTree<float>(), 0.001);
        }
    }
}