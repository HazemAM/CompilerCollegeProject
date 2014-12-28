namespace Compiler
{
    public class Token
    {
        public readonly TokenType type;
        public readonly string value;

        public Token(TokenType type, string value){
            this.type = type;
            this.value = value;
        }
    }

    
}
