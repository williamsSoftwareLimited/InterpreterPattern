using System.Collections.Generic;
using System;

namespace InterpreterPattern {
    public class Context {

        Dictionary<string, bool> variableExpressions;

        public Context() {
            variableExpressions=new Dictionary<string, bool>();
        }
        public bool Lookup(string variableName) {
            return variableExpressions[variableName];
        }
        public void Assign(VariableExpression variableExpression, bool b) {
            if (variableExpressions.ContainsKey(variableExpression.getName())) {
                variableExpressions[variableExpression.getName()] = b;
            } else {
                variableExpressions.Add(variableExpression.getName(), b);
            }
        }
    }
}