namespace Compiler
{
    public struct Token
    {
        TokenType type;
        string value;

        public Token(TokenType type, string value){
            this.type = type;
            this.value = value;
        }
    }

    public enum TokenType
    {
        EOF,
        ID, Num, NumFraction,
        If, Then, Else, End, Repeat, Until, Read, Write,
        Assign, Equal, LessThan, Plus, Minus, Times, LeftParentheses, RightParentheses, SemiColon,
        AugmentedMinus, AugmentedPlus, Decrement, Increment
    }
}
