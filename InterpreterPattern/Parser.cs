using System;
using System.Collections.Generic;
using System.Text;

namespace InterpreterPattern {
    public class Parser {
        string[] symbols;
        Stack<BooleanExpression> expressionStack;
        BooleanExpression andExpression, orExpression;

        public BooleanExpression Parse(string parseText) {
            orExpression = new VariableExpression("");
            symbols = parseText.Split(' ');
            expressionStack = new Stack<BooleanExpression>();            

            populateExpressionStackWithAndPrecedence();

            processRemainingOrExpressions();

            return orExpression;
        }
        private void populateExpressionStackWithAndPrecedence() {
            expressionStack.Push(getVariableExpression(0));

            for (int i = 0; i < symbols.Length; i++) {
                switch (symbols[i]) {
                    case "and":
                        andExpression = new AndExpression(expressionStack.Pop(), getVariableExpression(++i));
                        expressionStack.Push(andExpression);
                        break;
                    case "or":
                        // don't have to do anything as the final round-up is or'd together
                        break;
                    default:
                        expressionStack.Push(getVariableExpression(i));
                        break;
                }
            }
        }
        private void processRemainingOrExpressions() {
            orExpression = expressionStack.Pop();
            for (int i = 1; i < expressionStack.Count; i++) {
                orExpression = new OrExpression(orExpression, expressionStack.Pop());
            }
        }
        private VariableExpression getVariableExpression(int symbolIndex) {
            return new VariableExpression(symbols[symbolIndex]);
        }
    }
}
