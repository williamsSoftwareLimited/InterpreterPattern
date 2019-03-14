using System;
using System.Collections.Generic;
using System.Text;

namespace InterpreterPattern
{
    public abstract class BooleanExpression // AbstractExpression
    {
        public abstract bool Evaluate(Context context);

    }
}
