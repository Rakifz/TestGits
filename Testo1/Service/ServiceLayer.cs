using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Microsoft.

namespace TestoGits1.Service
{
    public class ServiceLayer
    {
        private ILogger<ServiceLayer> _logger;
        List<char> result = new List<char>();
        public ServiceLayer (ILogger<ServiceLayer> logger)
        {
            _logger = logger;
        }

        public List<char> Reveresed (char[] input)
        {
            
            result.Add(_ReverseTheInput(input.ToArray(), 0));
            return result;
        }

        private char _ReverseTheInput (char[] input,int index)
        {
            char _char=new char();
            try
            {
                if (input[index + 1] != null)
                {
                    result.Add( _ReverseTheInput(input, index + 1));
                }
            }
            catch(IndexOutOfRangeException ex)
            {
                _logger.LogDebug("reach end of index");

            }
            _char = input[index];
            return _char;
        }
        
        public int ConsecutiveOnes(List<int> input)
        {
            int count=0;
            List<int> numOnes=new List<int>();
            input.Add(0);//as exit
            foreach(var entry in input)
            {
                if (entry == 1)
                {
                    count++;
                }
                else
                {
                    numOnes.Add(count);
                    count = 0;
                }
            }

            return numOnes.Max();
        }


        int stateOpen = 0;
        string instantNo = "";
        public string PerfectlyBalanced(string input)
        {
            string approve = "";
           

            var trimmed = _trim(input);
            _IsThisBalanced(trimmed);
            

            if (stateOpen==0)
            {
                approve= "YES";
            }
            else
            {
                approve= "No";
            }
            return approve;
        }

        private string _trim(string input)
        {
            var trimmed = input;
            int i = 0;
            var check = new char();
            try
            {
                while (true){
                    if (trimmed[i] == '(' && trimmed[i + 1] == ')')
                    {
                        check = trimmed[i];
                        trimmed = trimmed.Substring(2, trimmed.Length - 2);
                    }
                    else if (trimmed[i] == '[' && trimmed[i + 1] == ']')
                    {
                        check = trimmed[i];
                        trimmed = trimmed.Substring(2, trimmed.Length - 2);
                    }
                    else if (trimmed[i] == '{' && trimmed[i + 1] == '}')
                    {
                        check = trimmed[i];
                        trimmed = trimmed.Substring(2, trimmed.Length - 2);
                    }
                    else 
                    { 
                        break;
                    }
                    //i += 2;
                }
            }catch(Exception ex) { }
            return trimmed;
        }
        

        private void _IsThisBalanced(string input)
        {
            
                if (input.Length > 0)
                {
                    try
                    {
                        string NewInput = "";
                        char ch = input[0];
                        //foreach (var ch in input)
                        //{
                        if (ch == '(')
                        {
                            stateOpen++;
                            NewInput = _stingUntilClosing(input.Substring(1), '(');

                        }
                        if (ch == '[')
                        {
                            stateOpen++;
                        NewInput = _stingUntilClosing(input.Substring(1), '[');

                    }
                        if (ch == '{')
                        {
                            stateOpen++;
                            NewInput = _stingUntilClosing(input.Substring(1), '{');

                        }

                        if (ch == ')')
                        {
                            stateOpen--;

                        }
                        if (ch == ']')
                        {
                            stateOpen--;
                        }
                        if (ch == '}')
                        {
                            stateOpen--;

                        }
                        //}
                        if (string.IsNullOrEmpty(instantNo))
                        {
                            _IsThisBalanced(NewInput);
                        }
                        //break;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message.ToString());
                    }
                }
            
        }
        string sisa = "";
        private string _stingUntilClosing(string input,char opening)
        {
            string str = new string(input.Reverse().ToArray());
            string res = "";
            int End = -1;
            if (opening=='(')
            {
                End= str.IndexOf(')');
               
            }
            if (opening=='{')
            {
                End = str.IndexOf('}');
                
            }
            if (opening == '[')
            {
                End = str.IndexOf(']');

            }
            if (End == 0&& str.Length==1)
            {
                res = "";
                stateOpen--;

            }else
            if (End == 0)
            {
                res = input.Substring(0, input.Length-1 - End);
                stateOpen--;                
            }
            else
            if (End > 0)
            {
                res = input.Substring(0, input.Length - 1 - End);
                sisa = input.Substring(input.Length - End, input.Length -(input.Length - End));
               
                stateOpen--;
                _IsThisBalanced(sisa);
            }
            else
            {
                instantNo = "No";               
            }
            return res;

        }

    }
}
