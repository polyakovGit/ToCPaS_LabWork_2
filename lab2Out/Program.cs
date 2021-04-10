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
    static class MatchToken
    {
        public static IEnumerable<Match> GetMatch(this Regex regex, string inputText)
        {
            for (var match = regex.Match(inputText); match.Success; match = match.NextMatch())
                yield return match;
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
            foreach (var match in matches)
            {
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
        }
        static void Main(string[] args)//COMM 123
        {
            var inputText = File.ReadAllText(@"../../Program.cs");
            var sb = new StringBuilder();
            foreach (var token in GetTokens(inputText))
            {
                sb.Append(token.Lexeme);
            }
            Console.WriteLine(sb.ToString());
            File.WriteAllText(@"../../../lab2Out/Program.cs", sb.ToString());
        }
    }
}
