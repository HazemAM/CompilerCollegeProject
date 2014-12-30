using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Compiler
{
    enum NodeType
    {
        Statements,
        If,
        Then,
        Else,
        Add,
        Sub,
        Mul,
        Divide,
        Assign,
        Equal,
        GreaterThan,
        LessThan,
        Exp,
        factor,
        SimpleExp,
        TermMul,
        Term,
        Read,
        Write,
        Repeat,
        Until,
        Number,
        ID,
        Prg, stsqc, st, ifStmt, ifc, repeatSt, assignSt, readSt, writeSt, exp, Ec, Cop, Smpexp, Smpexpc, addOp, term, termc, mulOp, 
    }
}
