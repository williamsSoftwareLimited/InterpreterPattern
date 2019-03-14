using System;
using System.Collections.Generic;
using System.Text;

namespace InterpreterPattern
{
    public class OrExpression : BooleanExpression {
        private BooleanExpression operand1;
        private BooleanExpression operand2;

        public OrExpression(BooleanExpression operand1, BooleanExpression operand2) {
            this.operand1 = operand1;
            this.operand2 = operand2;
        }

        public override bool Evaluate(Context context) {
            return operand1.Evaluate(context) || operand2.Evaluate(context);
        }
    }
}
