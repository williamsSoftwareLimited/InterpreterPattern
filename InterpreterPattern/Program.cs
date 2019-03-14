using System;
using System.Collections.Generic;

namespace InterpreterPattern
{
    class Program
    {
        static void Main(string[] args) {
            BooleanExpression booleanExpression;
            Context context = new Context();
            VariableExpression x = new VariableExpression("X");
            VariableExpression y = new VariableExpression("Y");
            VariableExpression z = new VariableExpression("Z");

            context.Assign(x, true);
            context.Assign(y, false);
            context.Assign(z, true);

            Console.WriteLine($"Where X={x.Evaluate(context)}, Y={y.Evaluate(context)} and Z={z.Evaluate(context)}.");
            // make the abstract syntax tree (manually)
            booleanExpression = new AndExpression(x, new OrExpression(y, z));
            Console.WriteLine($"The outcome of X and (Y or Z) is {booleanExpression.Evaluate(context)}");

            booleanExpression = new AndExpression(x, new AndExpression(y, new OrExpression(x, z)));
            Console.WriteLine($"The outcome of X and (Y and (X OR Z)) is {booleanExpression.Evaluate(context)}");

            Console.ReadKey();
        }
    }
}
