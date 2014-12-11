using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Compiler
{
    public struct NodePair
    {
        public int FromNode;
        public string Input;
        
        public NodePair(int FromNode, string Input){
            this.FromNode = FromNode;
            this.Input = Input;
        }
    }

    class Lexical
    {
        /** ATTRIBUTES */
        private const string NO_TRANS_CHAR = "-"; //The character indicating no-transition for a given input (in input DFA table).
        /*private  const int    NO_TRANS_INT  = -1;  /*ABANDONED: The no-transition as represented in the DFA table Dictionary.
                                                    WARNING: MUST BE < 0 (for not mistakenly considered as a transition)*/
        
        private Dictionary<NodePair,int> DFATable = new Dictionary<NodePair,int>();
        private int startNode;
        /*private int[] finalNodes; //The old yaw.*/
        private Dictionary<int,string> finalNodes = new Dictionary<int,string>();
        private string[] inputTypes = null;
        private string[] reservedWords = null;
        private List<string[]> log = new List<string[]>();
        

        /** FUNCTIONS */
        //Constructor
        /// <summary>Create a new object for a lexical analyzer.</summary>
        /// <param name="dfaTablePath">The local path of the plain DFA transitions table.</param>
        public Lexical(string dfaTablePath){
            readDFATable(dfaTablePath);
        }

        //Reading DFA table
        private void readDFATable(string dfaTablePath){
 	        string theFile = System.IO.File.ReadAllText(@dfaTablePath);

            string[] theFileLines = theFile.Split(new String[]{Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            for(int i=0; i<theFileLines.Length; i++){
                string[] theLine = theFileLines[i].Split(new String[]{" "}, StringSplitOptions.RemoveEmptyEntries);
                
                switch(i){
                case 0: //The first line: Read start node.
                    startNode = int.Parse(theLine[0]);
                    break;
                case 1: //Second line: Read final nodes.
                    /*finalNodes = new int[theLine.Length]; //The old yaw.*/
                    theLine = theFileLines[i].Split(new String[]{" - "}, StringSplitOptions.RemoveEmptyEntries);
                    for(int j=0; j<theLine.Length; j++){
                        var tempFinal = theLine[j].Split('|'); //Splitting, where [0]=finalNodeNumber [1]=finalNodeDescription
                        finalNodes[int.Parse(tempFinal[0])] = tempFinal[1];
                    }
                    break;
                case 2:
                    reservedWords = (string[])theLine.Clone();
                    break;
                case 3: //A separator line; ignore.
                    continue;
                case 4: //Fourth line: Getting input types (digit, character, '{', '+', ...etc).
                    inputTypes = (string[])theLine.Clone();
                    break;
                case 5: //A separator line; ignore.
                    continue;
                default: //All other lines: Getting all transitions in the line.
                    for(int index=1; index<theLine.Length; index++){
                        NodePair pair = new NodePair(int.Parse(theLine[0]), inputTypes[index-1]);
                        if(theLine[index]!=NO_TRANS_CHAR){
                            int toNode = int.Parse(theLine[index]);
                            DFATable.Add(pair, toNode);
                        }
                    }
                    break;
                }
            }
        }

        /// <summary>Analyze a piece of code lexically.</summary>
        /// <param name="code">The code to analyze.</param>
        public void analyze(string code){
            log.Clear();
            analyzeStart(code);
        }
        
        private void analyzeStart(string code){
            int currNode = startNode;
            string currStreak = String.Empty;

            //Strat the per-character journey:
            for(int i=0; i<code.Length; /*NO i++ here*/){
                char currChar = code[i];
                string key = getKey(currChar);

                int outNode;
                bool exists = DFATable.TryGetValue(new NodePair(currNode,key), out outNode);
                if(exists){
                    currStreak += currChar;
                    currNode = outNode;
                    i++; //Ready to advance to the next letter.
                }
                else{ //If no more possible transitions in the streak:
                    if(currNode==startNode){ //A character tested with the start node; reject and advance to next letter.
                        rejectStreak(currStreak+currChar);
                        i++;
                    }
                    else //If not, check if acceptable (without the current character).
                        acceptOrReject(currNode, currStreak);

                    currNode = startNode;
                    currStreak = String.Empty;
                }
            }

            if(currStreak!=String.Empty) //If the code doesn't end with a newline or space.
                acceptOrReject(currNode, currStreak);
        }

        public List<string[]> getLog(){
            return log;
        }

        private void acceptOrReject(int currNode, string currStreak){
            if(finalNodes.ContainsKey(currNode))
                acceptStreak(currNode, currStreak);
            else
                rejectStreak(currStreak);
        }

        private void rejectStreak(string streak){
            if(streak!=" " && streak!="\r" && streak!="\n" && streak!=String.Empty)
                log.Add( new string[]{"REJECTED", streak, "--"} );
                //Console.WriteLine("REJECTED: {0}", streak);
        }

        private void acceptStreak(int greatNode, string streak){
            string desc;
            if(reservedWords.Contains(streak.ToLower())) desc="Reserved Word";
            else finalNodes.TryGetValue(greatNode, out desc);
            
            log.Add( new string[]{"Accepted", streak, desc} );
            //Console.WriteLine("Accepted: {0}, {1}", streak, desc);
        }

        private string getKey(char currChar){
            if(isLetter(currChar)) return "letter";
            else if(isDigit(currChar)) return "digit";
            else if(inputTypes.Contains(currChar.ToString())) return currChar.ToString();
            else return "other";
        }

        private bool isLetter(char currChar){
            return Regex.IsMatch(currChar.ToString(), @"[A-Za-z]");
        }

        private bool isDigit(char currChar){
            return Regex.IsMatch(currChar.ToString(), @"[0-9]");
        }
    }
}
