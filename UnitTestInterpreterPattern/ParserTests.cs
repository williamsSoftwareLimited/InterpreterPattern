using InterpreterPattern;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestInterpreterPattern {
    [TestClass]
    public class ParserTests {
        Parser parser;
        private Context context;

        [TestInitialize]
        public void setup() {
            parser = new Parser();
            context = new Context();
            context.Assign(new VariableExpression("x"), true);
            context.Assign(new VariableExpression("y"), true);
            context.Assign(new VariableExpression("z"), true);
        }

        [TestMethod]
        public void Constructor() {
            Assert.IsNotNull(parser);
        }
        [TestMethod]
        public void ReturnsAndExpressionForSimpleAndTree() {
            BooleanExpression expression = parser.Parse("x and y");
            //             AndExpression 
            //             /          \
            //VariableExpression  VariableExpression
            Assert.IsInstanceOfType(expression, typeof(AndExpression));
        }
        [TestMethod]
        public void ReturnsOrExpressionForSimpleOrTree() {
            BooleanExpression expression = parser.Parse("x or y");
            //             OrExpression 
            //             /          \
            //VariableExpression  VariableExpression
            Assert.IsInstanceOfType(expression, typeof(OrExpression));
        }
        [TestMethod]
        public void CanProcessThreeAndsWithOneFalse() {
            BooleanExpression expression = parser.Parse("x and y and z");
            context.Assign(new VariableExpression("z"), false);

            Assert.IsFalse(expression.Evaluate(context));
        }
        [TestMethod]
        public void CanProcessThreeOrsWithOneFalse() {
            BooleanExpression expression = parser.Parse("x or y or z");
            context.Assign(new VariableExpression("z"), false);

            Assert.IsTrue(expression.Evaluate(context));
        }
        [TestMethod]
        public void CheckAndPrecedence() {
            BooleanExpression expression = parser.Parse("x and y or x and z");
            context.Assign(new VariableExpression("x"), false);

            Assert.IsFalse(expression.Evaluate(context));
        }

        [TestMethod]
        public void CheckOrExpressionAtRootFor3Symbols() {
            BooleanExpression expression = parser.Parse("y or x and z");

            Assert.IsInstanceOfType(expression, typeof(OrExpression));
        }

        [TestMethod]
        public void CheckOrExpressionAtRootFor4Symbols() {
            BooleanExpression expression = parser.Parse("x and y or x and z");

            Assert.IsInstanceOfType(expression, typeof(OrExpression));
        }

    }
}
