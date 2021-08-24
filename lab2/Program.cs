//COMM123 

/*text*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace lab2
{
    enum TokenType
    {
        Identifier,
        Number,
        String,
        Punctuation,
        WhiteSpace,
        Comment,
    }

    class Token
    {
        public string Lexeme { get; }
        public TokenType Type { get; }

        public Token(string lexeme, TokenType type)
        {
            Lexeme = lexeme;
            Type = type;
        }
    }
    class Program
    {
        static IEnumerable<Token> GetTokens(string inputText)
        {
            var regex = new Regex(@"(?<Identifier>[a-zA-Z_][a-zA-Z_0-9]*)|
                                    (?<Number>[0-9]+)|
                                    (?<Operator>\!\=|\+\=|\=\>|\=\<|\+|\=|\-|\*)|
                                    (?<String>\@""(""""|[^""])*"")|
                                    (?<Punctuation>\.|\(|\)|\{|\}|\[|\]|\;|\<|\>|\,|\:)|
                                    (?<WhiteSpace>[\ \t\r\n]+)|
                                    (?<Comment>(//)(.*?)(?=[\n\r])|((/\*)(.*?)(\*/)))", RegexOptions.IgnorePatternWhitespace);
            var matches = regex.GetMatch(inputText);
            int indexMatch = 0;
            foreach (var match in matches)
            {
                if (indexMatch != match.Index)
                {
                    throw new Exception(@"пропущен токен");
                }
                indexMatch = match.Index + match.Length;
                if (match.Groups[@"Identifier"].Success)
                {
                    yield return new Token(match.Value, TokenType.Identifier);
                }
                else if (match.Groups[@"Number"].Success)
                {
                    yield return new Token(match.Value, TokenType.Number);
                }
                else if (match.Groups[@"String"].Success)
                {
                    yield return new Token(match.Value, TokenType.String);
                }
                else if (match.Groups[@"Punctuation"].Success)
                {
                    yield return new Token(match.Value, TokenType.Punctuation);
                }
                else if (match.Groups[@"WhiteSpace"].Success)
                {
                    yield return new Token(match.Value, TokenType.WhiteSpace);
                }
                else if (match.Groups[@"Comment"].Success)
                {
                    yield return new Token(match.Value, TokenType.Comment);
                }
            }
            if (indexMatch != inputText.Length)
            {
                throw new Exception(@"входной текст отличается от результирующего");
            }
        }
        static void Main(string[] args)
        {
            int mode = 0;
            var inputText = File.ReadAllText(@"../../Program.cs");
            var sb = new StringBuilder();
            foreach (var token in GetTokens(inputText))
            {
                switch (mode)
                {
                    case 0:
                        sb.Append(@"/*").Append(token.Type).Append(@"*/").Append(token.Lexeme);
                        break;
                    case 1:
                        sb.Append(token.Lexeme).Append(@" ");
                        break;
                    case 2:
                        sb.Append(token.Lexeme);
                        break;
                }
            }
            Console.WriteLine(sb.ToString());
            File.WriteAllText(@"../../../lab2Out/Program.cs", sb.ToString());
        }

        static void _Main(string[] args)
        {
            string regex = File.ReadAllText(@"../../RegExpression.txt");
            string text = File.ReadAllText(@"../../InputTextFile.txt");
            List<string> output = new List<string>();
            output.Add(EscapeCsvValue(@"Номер") + @";"
            + EscapeCsvValue(@"Группа 1") + @";"
            + EscapeCsvValue(@"Группа 2") + @";"
            + EscapeCsvValue(@"Группа 3") + @";"
            + EscapeCsvValue(@"Группа 4"));
            var rx = new Regex(regex);
            int i = 0;
            foreach (Match match in rx.Matches(text))
            {
                output.Add(EscapeCsvValue(@"строка ") + ++i + @";" +
                EscapeCsvValue(match.Groups[1].Value) + @";" +
                EscapeCsvValue(match.Groups[2].Value) + @";" +
                EscapeCsvValue(match.Groups[3].Value) + @";" +
                EscapeCsvValue(match.Groups[4].Value));
            }
            File.WriteAllLines(@"..\..\OutputTextFile.csv", output, Encoding.Default);
        }
        static string EscapeCsvValue(string s) => @"""" + s.Replace(@"""", @"""""") + @"""";
    }
    static class MatchToken
    {
        public static IEnumerable<Match> GetMatch(this Regex regex, string inputText)
        {
            for (var match = regex.Match(inputText); match.Success; match = match.NextMatch())
                yield return match;
        }
    }
}
