using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Compiler
{
    class Syntax
    {
        List<string> nonTerminals;
        Queue<Token> input;
        SortedList<int,Rule> rules;
        SortedList<string,NonTerm> table;
        const string LL1Table = "..\\..\\LL1.txt";
        string msg;
        int column;
        int line;
        bool errorFree;
        Stack<string> errors;
        public Syntax(List<Token>input)
        {
            this.input = new Queue<Token>();
            foreach(Token t in input)
                this.input.Enqueue(t);
            rules = new SortedList<int, Rule>();
            table = new SortedList<string, NonTerm>();
            errors = new Stack<string>();
            errorFree = true;
            column = 1;
            line = 1;
            readTxt();
            Parse();
        }

        private void Parse()
        {
            Stack<Token> progStack = new Stack<Token>();
            progStack.Push(new Token(TokenType.EOF, "$"));
            progStack.Push(new Token(TokenType.NonTerminal,"prog"));
            List<Token> accepted = new List<Token>();
            
            while (input.Count != 0 || progStack.Count != 0)
            {
                
                Token first = input.Dequeue();
                Token top = progStack.Pop();
                if (top.type == first.type)
                {
                    accepted.Add(first);
                    if (top.type == TokenType.SemiColon)
                    {
                        line++;
                        column=1;
                    }
                }
                else if (top.type == TokenType.NonTerminal)
                {
                    int rule = getRule(first.type, top.value);
                    updateStack(top, first, rule, ref progStack, ref input);

                }
                else
                {
                    errors.Push("expected: " + top.type.ToString() + "at line: " +line.ToString()+"at character: "+ column.ToString()+"\n");
                    errorFree = false;
                }
                column++;
            }
             if (errorFree)
                msg = "accepted";
             else
                 msg = "accepted with errors";
        }

        private void updateStack(Token top,Token first,int rule,ref Stack<Token> progStack,ref Queue<Token>inp)
        {
            if (rule != 0)
            {
                Rule r = rules[rule];
                foreach (Token t in r.to)
                    progStack.Push(t);
            }           
            else
            {
                errorFree = false;
                Token temp=first;
                NonTerm t = table[top.value];
                 while (inp.Count!=0)
                 {
                     errors.Push("error at line :" + line.ToString() + "at character: " + column.ToString() + " removing :" + first.value + " from input to continue" + "\n");
                      temp = inp.Dequeue();
                      if (t.followSet[top.value].Contains(temp.type.ToString()))
                          return;
                 }
                //might need to add code here to handle if stack is empty
            }
        }


       

        private int getRule(TokenType tokenType, string name)
        {
            NonTerm t= table[name];
            return t.content[tokenType.ToString()];
        }

        private void readTxt()
        {
            StreamReader sr = new StreamReader(LL1Table);
            string line = sr.ReadLine();
            nonTerminals=line.Split(',').ToList<string>();
            string[] rule;
            line = sr.ReadLine();

            //reading rules from file
            //after rules finish # to sperate them from table
            int count = 1;
            while (!line.StartsWith("#"))
            {
                //splitting  rule number from other rule stuff
                //rule ex; 1|prog-st stsq'
                rule = line.Split('|');
                int num = int.Parse(rule[0]);
                rule = rule[1].Split('-');
                string left=rule[0];
                rule=rule[1].Split(' ');
                int len = rule.Length;
                Token[] tk = new Token[len];
                for (int i = 0; i < len; i++)
                {
                    TokenType temp;
                    if(nonTerminals.Contains(rule[i]))
                        temp=TokenType.NonTerminal;
                    else
                        temp=(TokenType)Enum.Parse(typeof(TokenType),rule[i]);
                    tk[i] = new Token(temp, rule[i]);
                }
                Token t = new Token(TokenType.NonTerminal, left);
                rules.Add(count,new Rule(count,t, tk));
                line = sr.ReadLine();
            }

            //reading table content
            //row ex: prog - - 1 -.....
            line = sr.ReadLine();
            string[] terms=line.Split(' ');
            string[] row;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                row = line.Split(' ');
                count = 1;
                bool done = false;
                string[] follows=null;
                NonTerm temp= new NonTerm(row[0]);
                foreach (string term in terms)
                {
                    if (row[count].StartsWith("-"))
                    {
                        if (!done)
                        {
                            follows = row[count].Split('/');
                            follows.CopyTo(follows, 1);
                            done = true;
                        }
                        
                        temp.AddContent(term, 0);
                        temp.addFollow(term, follows);
                        
                    }
                    else
                        temp.AddContent(term, int.Parse(row[count]));
                    count++; 
                }
                table.Add(temp.name,temp);

            }
            sr.Close();
        }
    }
}
