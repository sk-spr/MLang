#nullable enable

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace MLang_Run
{
    public enum vartype
    {
        Number, 
        Character
    }
    class Program
    {
        public static FileStream src; //source file
        private static bool? t; // comparator state
        private static Dictionary<string, int?> vars = new Dictionary<string, int?>(); //variable database
        private static Dictionary<string, vartype> vartypes = new Dictionary<string, vartype>(); //variable type database
        static void Main(string[] args)
        {
            Console.WriteLine("MLang Compiler version 0.1");
            Console.WriteLine("----Skye Sprung 2020----");
            if (args.Length < 1)
            {
                Console.WriteLine("Please pass a source file as argument 1");
                Environment.Exit(-1);
            }
            Console.WriteLine($"Attempting to load {args[0]}");
            try
            {
                src = File.OpenRead(args[0]);
            }  
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Loaded successfully. Source code:");
            var lines = new List<string>(File.ReadLines(args[0]));
            foreach(var line in lines)
                Console.WriteLine(line);
            
            //--------------------------------------------
            //sources
            int indexOfSources = lines.IndexOf("Sources:");
            var sources = lines.Where((string v, int i)=>i>indexOfSources).ToList();
            Console.Write("attempting to parse variables from sources: ");
            foreach(string source in sources)
            {
                vartype temptype = vartype.Number;
                //determine type
                Regex book = new Regex("\"");
                if (book.IsMatch(source))
                    temptype = vartype.Character;
                string name = source.Split(",")[0];
                vars.Add(name, null);
                vartypes.Add(name, temptype);
            }
            Console.Write("Done.\n");

            //---------------------------------------------
            //parsing : preparation
            t = null;
            Console.WriteLine("Attempting to interpret.");
            Console.Write("\nOUTPUT::");
            var instructions = lines.Where((string s, int i) => i < indexOfSources).ToList();
            var inst = new List<string>();
            foreach(var instruction in instructions)
            {
                Debug.WriteLine(instruction);
                var temp = instruction.Split(new char[] { '(', ')' });
                var odds = temp.Where((s, i) => i % 2 != 0);
                foreach (string odd in odds)
                    inst.Add(odd);
            }
            
            //parsing : parsing
            for(int i = 0; i < inst.Count;i++)
            {
                Debug.WriteLine($"parsing instruction {i}");
                string st = inst[i];
                Debug.WriteLine(st);
                var result = Interpret(st);
                switch (result.Item1)
                {
                    case 0:
                        continue;
                    case 1:
                        if (result.Item2 == null)
                            Console.WriteLine("\nNot enough arguments given in chapter reference, skipping.");
                        else
                        {
                            if (inst.Contains(result.Item2))
                            {
                                if (t != null)
                                {
                                    if ((bool)t)
                                        i = inst.IndexOf(result.Item2);
                                } else
                                {
                                    Console.WriteLine("\nYou have not compared anything yet, please use \"Contrast\" before using \"read\"");
                                    Environment.Exit(-1);
                                }
                            }
                            else
                                Console.WriteLine($"\nThis chapter ({result.Item2}) does not seem to exist.");
                        }
                        continue;
                }
            }
            Console.WriteLine("\nDone. Thank you for citing your sources!");
        }
        
        private static (int, string?) Interpret(string instruction)
        {
            if (new Regex(@".*, [0-9]").IsMatch(instruction))
            {
                //TODO: arithmetic operations
                string varname = instruction.Split(",")[0];
                int varval = int.Parse(instruction.Split(", ")[1]);
                //variable assignment
                if (vars.ContainsKey(varname))
                {
                    vars[varname] = varval;
                    return (0, null);
                }
                else
                {
                    exitErr(2,"\nYou seem to be referencing a source that you haven't listed. Please check your sources");
                    return (-1, null);
                }
            }
            else if (new Regex(@"^see ").IsMatch(instruction))
            {
                //IO Print
                string[] split = instruction.Split(" ");
                string varname = split[1];
                if (vars.ContainsKey(varname))
                {
                    switch (vartypes[varname])
                    {
                        case vartype.Character:
                            Console.Write((char)(vars[varname] ?? '_'));
                            return (0, null);
                        case vartype.Number:
                            Console.Write(vars[varname]);
                            return (0, null);
                        default:
                            return (0, null);
                            throw new ArgumentException("\nThis vartype is not supported, how the hell did you do that?");

                    }
                }
            }
            else if(new Regex(@"Contrast").IsMatch(instruction))
            {
                //comparison operation: GT/EQ
                string[] split = instruction.Split(" ");
                string var1 = split[1];
                string var2 = split[3];
                if(vars.ContainsKey(var1) && vars.ContainsKey(var2))
                {
                    t = vars[var1] >= vars[var2];
                    return (0, null);
                }
                else
                {
                    exitErr(2, "\nYou seem to be referencing a source that you haven't listed. Please check your sources");
                    return (-1, null);
                }
            }
            else if (new Regex(@"Compare").IsMatch(instruction))
            {
                //comparison operation: LT
                string[] split = instruction.Split(" ");
                string var1 = split[1];
                string var2 = split[3];
                if (vars.ContainsKey(var1) && vars.ContainsKey(var2))
                {
                    t = vars[var1] < vars[var2];
                    return (0, null);
                }
                else
                {
                    exitErr(2, "\nYou seem to be referencing a source that you haven't listed. Please check your sources");
                    return (-1, null);
                }
            }
            else if(new Regex("read ").IsMatch(instruction))
            {
                var chapname = instruction.Replace("read ", "");
                return (1, chapname);
            } else if(new Regex(@".* [+\-\*\/] .*").IsMatch(instruction))
            {
                //arithmetic operation
                var parts = instruction.Split(new char[] {' ', ','});
                if(parts.Length < 4)
                    return (-1, null);
                string var1 = parts[0];
                int val1 = 0;
                if (vars.ContainsKey(var1))
                    val1 = vars[var1] ?? 0;
                else
                    exitErr(2, "\n This variable does not seem to appear in your sources");
                string operation = parts[1];
                string var2 = parts[2];
                int val2 = 0;
                if (vars.ContainsKey(var2))
                    val2 = vars[var2] ?? 0;
                else
                    exitErr(2, "\n This variable does not seem to appear in your sources");
                string targetvar = parts[4];
                if (!vars.ContainsKey(targetvar))
                    exitErr(2, "\n This variable does not seem to appear in your sources");
                int result = 0;
                
                switch (operation)
                {
                    case "+":
                        result = val1 + val2;
                        break;
                    case "-":
                        result = val1 - val2;
                        break;
                    case "*":
                        result = val1 * val2;
                        break;
                    case "/":
                        result = (int)val1 / val2;
                        break;
                    default:
                        return (0, null);
                        break;
                }
                vars[targetvar] = result;
                return (0, null);
            }
            else
                return (-1, null);
            return (-1, null);
        }
        private static void exitErr(int code, string message)
        {
            Console.WriteLine(message);
            Environment.Exit(code);
        }
    }
    
}
