namespace InterpreterPattern {
    public class VariableExpression : BooleanExpression { //Nonterminal
        private string variableName;

        public VariableExpression(string variableName) {
            this.variableName=variableName;
        }

        public string getName (){
            return variableName;
        }

        public override bool Evaluate(Context context) {
            return context.Lookup(variableName);
        }

    }
}