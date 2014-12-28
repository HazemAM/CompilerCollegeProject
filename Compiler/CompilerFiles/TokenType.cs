using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler
{
    public enum TokenType
    {
        EOF, Error, Comment, NonTerminal, Empty,
        ID, Num, NumFraction,
        If, Then, Else, End, Repeat, Until, Read, Write,
        Assign, Equal, LessThan,MoreThan, Plus, Minus, Times,Division, LeftParentheses, RightParentheses, SemiColon,
        AugmentedMinus, AugmentedPlus, Decrement, Increment
    }
}
