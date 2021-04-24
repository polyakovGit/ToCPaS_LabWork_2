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
        Identifier, Number, Operator, String, Punctuation, WhiteSpace, Comment
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
                                    (?<Comment>(\/\/)(.+?)(?=[\n\r]|\*\)))", RegexOptions.IgnorePatternWhitespace);
            var matches = regex.GetMatch(inputText);
            int indexMatch = 0;
            foreach (var match in matches)
            {
                if (indexMatch != match.Index)
                    throw new Exception(@"пропущен токен");
                indexMatch += match.Length;
                if (match.Groups[@"Identifier"].Success)
                    yield return new Token(match.Value, TokenType.Identifier);
                else if (match.Groups[@"Number"].Success)
                    yield return new Token(match.Value, TokenType.Number);
                else if (match.Groups[@"Operator"].Success)
                    yield return new Token(match.Value, TokenType.Operator);
                else if (match.Groups[@"String"].Success)
                    yield return new Token(match.Value, TokenType.String);
                else if (match.Groups[@"Punctuation"].Success)
                    yield return new Token(match.Value, TokenType.Punctuation);
                else if (match.Groups[@"WhiteSpace"].Success)
                    yield return new Token(match.Value, TokenType.WhiteSpace);
                else if (match.Groups[@"Comment"].Success)
                    yield return new Token(match.Value, TokenType.Comment);
            }
            if (indexMatch != inputText.Length)
                throw new Exception(@"входной текста отличается от результирующего");
        }
        static void Main(string[] args)//COMM 123
        {
            int mode = 2;
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
            string text = File.ReadAllText(@"../../InputTextFile.txt");
            string regex = File.ReadAllText(@"../../RegExpression.txt");

            char newLine = (char)10;
            var csv = @"Номер	Группа1	Группа2	Группа3	Группа4" + newLine;
            csv += string.Concat(new Regex(regex).GetMatch(text)
            .Select((match, i) =>
            {
                var sb = new StringBuilder();
                sb.Append(@"строка ").Append((i + 1).ToString()).Append(@"	")
                .AppendLine(string.Join(@"	", match.Groups.Cast<Group>().Skip(1)
                .Select((group) => @"""" + group.ToString().Replace(@"""", @"""""") + @"""")));
                return sb.ToString();
            }));
            Console.WriteLine(csv);
            File.WriteAllText(@"../../OutputTextFile.csv", csv, Encoding.Unicode);
        }
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
