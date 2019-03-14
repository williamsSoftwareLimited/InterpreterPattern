using InterpreterPattern;
using System;
using Xunit;

namespace XUnitTestInterpreterPattern {
    public class ParserTests {
        private string parseText;

        [Fact]
        public void Constructor() {
            Parser parser = new Parser();
            Assert.NotNull(parser);
        }

        [Fact]
        public void CanProcessSimpleAndTree() {
            Parser parser = new Parser();

            AbstractExpression expression = parser.Parse("x and y");

            //             AndExpression 
            //             /          \
            //VariableExpression  VariableExpression


        }
    }
}
