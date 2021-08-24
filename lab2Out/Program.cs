/*Comment*///COMM123 /*WhiteSpace*/

/*Comment*//*text*//*WhiteSpace*/

/*Identifier*/using/*WhiteSpace*/ /*Identifier*/System/*Punctuation*/;/*WhiteSpace*/
/*Identifier*/using/*WhiteSpace*/ /*Identifier*/System/*Punctuation*/./*Identifier*/Collections/*Punctuation*/./*Identifier*/Generic/*Punctuation*/;/*WhiteSpace*/
/*Identifier*/using/*WhiteSpace*/ /*Identifier*/System/*Punctuation*/./*Identifier*/Linq/*Punctuation*/;/*WhiteSpace*/
/*Identifier*/using/*WhiteSpace*/ /*Identifier*/System/*Punctuation*/./*Identifier*/Text/*Punctuation*/;/*WhiteSpace*/
/*Identifier*/using/*WhiteSpace*/ /*Identifier*/System/*Punctuation*/./*Identifier*/Threading/*Punctuation*/./*Identifier*/Tasks/*Punctuation*/;/*WhiteSpace*/
/*Identifier*/using/*WhiteSpace*/ /*Identifier*/System/*Punctuation*/./*Identifier*/IO/*Punctuation*/;/*WhiteSpace*/
/*Identifier*/using/*WhiteSpace*/ /*Identifier*/System/*Punctuation*/./*Identifier*/Text/*Punctuation*/./*Identifier*/RegularExpressions/*Punctuation*/;/*WhiteSpace*/

/*Identifier*/namespace/*WhiteSpace*/ /*Identifier*/lab2/*WhiteSpace*/
/*Punctuation*/{/*WhiteSpace*/
    /*Identifier*/enum/*WhiteSpace*/ /*Identifier*/TokenType/*WhiteSpace*/
    /*Punctuation*/{/*WhiteSpace*/
        /*Identifier*/Identifier/*Punctuation*/,/*WhiteSpace*/
        /*Identifier*/Number/*Punctuation*/,/*WhiteSpace*/
        /*Identifier*/String/*Punctuation*/,/*WhiteSpace*/
        /*Identifier*/Punctuation/*Punctuation*/,/*WhiteSpace*/
        /*Identifier*/WhiteSpace/*Punctuation*/,/*WhiteSpace*/
        /*Identifier*/Comment/*Punctuation*/,/*WhiteSpace*/
    /*Punctuation*/}/*WhiteSpace*/

    /*Identifier*/class/*WhiteSpace*/ /*Identifier*/Token/*WhiteSpace*/
    /*Punctuation*/{/*WhiteSpace*/
        /*Identifier*/public/*WhiteSpace*/ /*Identifier*/string/*WhiteSpace*/ /*Identifier*/Lexeme/*WhiteSpace*/ /*Punctuation*/{/*WhiteSpace*/ /*Identifier*/get/*Punctuation*/;/*WhiteSpace*/ /*Punctuation*/}/*WhiteSpace*/
        /*Identifier*/public/*WhiteSpace*/ /*Identifier*/TokenType/*WhiteSpace*/ /*Identifier*/Type/*WhiteSpace*/ /*Punctuation*/{/*WhiteSpace*/ /*Identifier*/get/*Punctuation*/;/*WhiteSpace*/ /*Punctuation*/}/*WhiteSpace*/

        /*Identifier*/public/*WhiteSpace*/ /*Identifier*/Token/*Punctuation*/(/*Identifier*/string/*WhiteSpace*/ /*Identifier*/lexeme/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/TokenType/*WhiteSpace*/ /*Identifier*/type/*Punctuation*/)/*WhiteSpace*/
        /*Punctuation*/{/*WhiteSpace*/
            /*Identifier*/Lexeme/*WhiteSpace*/ /*WhiteSpace*/ /*Identifier*/lexeme/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/Type/*WhiteSpace*/ /*WhiteSpace*/ /*Identifier*/type/*Punctuation*/;/*WhiteSpace*/
        /*Punctuation*/}/*WhiteSpace*/
    /*Punctuation*/}/*WhiteSpace*/
    /*Identifier*/class/*WhiteSpace*/ /*Identifier*/Program/*WhiteSpace*/
    /*Punctuation*/{/*WhiteSpace*/
        /*Identifier*/static/*WhiteSpace*/ /*Identifier*/IEnumerable/*Punctuation*/</*Identifier*/Token/*Punctuation*/>/*WhiteSpace*/ /*Identifier*/GetTokens/*Punctuation*/(/*Identifier*/string/*WhiteSpace*/ /*Identifier*/inputText/*Punctuation*/)/*WhiteSpace*/
        /*Punctuation*/{/*WhiteSpace*/
            /*Identifier*/var/*WhiteSpace*/ /*Identifier*/regex/*WhiteSpace*/ /*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/Regex/*Punctuation*/(/*String*/@"(?<Identifier>[a-zA-Z_][a-zA-Z_0-9]*)|
                                    (?<Number>[0-9]+)|
                                    (?<Operator>\!\=|\+\=|\=\>|\=\<|\+|\=|\-|\*)|
                                    (?<String>\@""(""""|[^""])*"")|
                                    (?<Punctuation>\.|\(|\)|\{|\}|\[|\]|\;|\<|\>|\,|\:)|
                                    (?<WhiteSpace>[\ \t\r\n]+)|
                                    (?<Comment>(//)(.*?)(?=[\n\r])|((/\*)(.*?)(\*/)))"/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/RegexOptions/*Punctuation*/./*Identifier*/IgnorePatternWhitespace/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/var/*WhiteSpace*/ /*Identifier*/matches/*WhiteSpace*/ /*WhiteSpace*/ /*Identifier*/regex/*Punctuation*/./*Identifier*/GetMatch/*Punctuation*/(/*Identifier*/inputText/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/int/*WhiteSpace*/ /*Identifier*/indexMatch/*WhiteSpace*/ /*WhiteSpace*/ /*Number*/0/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/foreach/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/var/*WhiteSpace*/ /*Identifier*/match/*WhiteSpace*/ /*Identifier*/in/*WhiteSpace*/ /*Identifier*/matches/*Punctuation*/)/*WhiteSpace*/
            /*Punctuation*/{/*WhiteSpace*/
                /*Identifier*/if/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/indexMatch/*WhiteSpace*/ /*WhiteSpace*/ /*Identifier*/match/*Punctuation*/./*Identifier*/Index/*Punctuation*/)/*WhiteSpace*/
                /*Punctuation*/{/*WhiteSpace*/
                    /*Identifier*/throw/*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/Exception/*Punctuation*/(/*String*/@"пропущен токен"/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
                /*Punctuation*/}/*WhiteSpace*/
                /*Identifier*/indexMatch/*WhiteSpace*/ /*WhiteSpace*/ /*Identifier*/match/*Punctuation*/./*Identifier*/Index/*WhiteSpace*/ /*WhiteSpace*/ /*Identifier*/match/*Punctuation*/./*Identifier*/Length/*Punctuation*/;/*WhiteSpace*/
                /*Identifier*/if/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Groups/*Punctuation*/[/*String*/@"Identifier"/*Punctuation*/]/*Punctuation*/./*Identifier*/Success/*Punctuation*/)/*WhiteSpace*/
                /*Punctuation*/{/*WhiteSpace*/
                    /*Identifier*/yield/*WhiteSpace*/ /*Identifier*/return/*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/Token/*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Value/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/TokenType/*Punctuation*/./*Identifier*/Identifier/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
                /*Punctuation*/}/*WhiteSpace*/
                /*Identifier*/else/*WhiteSpace*/ /*Identifier*/if/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Groups/*Punctuation*/[/*String*/@"Number"/*Punctuation*/]/*Punctuation*/./*Identifier*/Success/*Punctuation*/)/*WhiteSpace*/
                /*Punctuation*/{/*WhiteSpace*/
                    /*Identifier*/yield/*WhiteSpace*/ /*Identifier*/return/*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/Token/*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Value/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/TokenType/*Punctuation*/./*Identifier*/Number/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
                /*Punctuation*/}/*WhiteSpace*/
                /*Identifier*/else/*WhiteSpace*/ /*Identifier*/if/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Groups/*Punctuation*/[/*String*/@"String"/*Punctuation*/]/*Punctuation*/./*Identifier*/Success/*Punctuation*/)/*WhiteSpace*/
                /*Punctuation*/{/*WhiteSpace*/
                    /*Identifier*/yield/*WhiteSpace*/ /*Identifier*/return/*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/Token/*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Value/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/TokenType/*Punctuation*/./*Identifier*/String/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
                /*Punctuation*/}/*WhiteSpace*/
                /*Identifier*/else/*WhiteSpace*/ /*Identifier*/if/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Groups/*Punctuation*/[/*String*/@"Punctuation"/*Punctuation*/]/*Punctuation*/./*Identifier*/Success/*Punctuation*/)/*WhiteSpace*/
                /*Punctuation*/{/*WhiteSpace*/
                    /*Identifier*/yield/*WhiteSpace*/ /*Identifier*/return/*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/Token/*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Value/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/TokenType/*Punctuation*/./*Identifier*/Punctuation/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
                /*Punctuation*/}/*WhiteSpace*/
                /*Identifier*/else/*WhiteSpace*/ /*Identifier*/if/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Groups/*Punctuation*/[/*String*/@"WhiteSpace"/*Punctuation*/]/*Punctuation*/./*Identifier*/Success/*Punctuation*/)/*WhiteSpace*/
                /*Punctuation*/{/*WhiteSpace*/
                    /*Identifier*/yield/*WhiteSpace*/ /*Identifier*/return/*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/Token/*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Value/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/TokenType/*Punctuation*/./*Identifier*/WhiteSpace/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
                /*Punctuation*/}/*WhiteSpace*/
                /*Identifier*/else/*WhiteSpace*/ /*Identifier*/if/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Groups/*Punctuation*/[/*String*/@"Comment"/*Punctuation*/]/*Punctuation*/./*Identifier*/Success/*Punctuation*/)/*WhiteSpace*/
                /*Punctuation*/{/*WhiteSpace*/
                    /*Identifier*/yield/*WhiteSpace*/ /*Identifier*/return/*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/Token/*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Value/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/TokenType/*Punctuation*/./*Identifier*/Comment/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
                /*Punctuation*/}/*WhiteSpace*/
            /*Punctuation*/}/*WhiteSpace*/
            /*Identifier*/if/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/indexMatch/*WhiteSpace*/ /*WhiteSpace*/ /*Identifier*/inputText/*Punctuation*/./*Identifier*/Length/*Punctuation*/)/*WhiteSpace*/
            /*Punctuation*/{/*WhiteSpace*/
                /*Identifier*/throw/*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/Exception/*Punctuation*/(/*String*/@"входной текст отличается от результирующего"/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
            /*Punctuation*/}/*WhiteSpace*/
        /*Punctuation*/}/*WhiteSpace*/
        /*Identifier*/static/*WhiteSpace*/ /*Identifier*/void/*WhiteSpace*/ /*Identifier*/Main/*Punctuation*/(/*Identifier*/string/*Punctuation*/[/*Punctuation*/]/*WhiteSpace*/ /*Identifier*/args/*Punctuation*/)/*WhiteSpace*/
        /*Punctuation*/{/*WhiteSpace*/
            /*Identifier*/int/*WhiteSpace*/ /*Identifier*/mode/*WhiteSpace*/ /*WhiteSpace*/ /*Number*/0/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/var/*WhiteSpace*/ /*Identifier*/inputText/*WhiteSpace*/ /*WhiteSpace*/ /*Identifier*/File/*Punctuation*/./*Identifier*/ReadAllText/*Punctuation*/(/*String*/@"../../Program.cs"/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/var/*WhiteSpace*/ /*Identifier*/sb/*WhiteSpace*/ /*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/StringBuilder/*Punctuation*/(/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/foreach/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/var/*WhiteSpace*/ /*Identifier*/token/*WhiteSpace*/ /*Identifier*/in/*WhiteSpace*/ /*Identifier*/GetTokens/*Punctuation*/(/*Identifier*/inputText/*Punctuation*/)/*Punctuation*/)/*WhiteSpace*/
            /*Punctuation*/{/*WhiteSpace*/
                /*Identifier*/switch/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/mode/*Punctuation*/)/*WhiteSpace*/
                /*Punctuation*/{/*WhiteSpace*/
                    /*Identifier*/case/*WhiteSpace*/ /*Number*/0/*Punctuation*/:/*WhiteSpace*/
                        /*Identifier*/sb/*Punctuation*/./*Identifier*/Append/*Punctuation*/(/*String*/@"/*"/*Punctuation*/)/*Punctuation*/./*Identifier*/Append/*Punctuation*/(/*Identifier*/token/*Punctuation*/./*Identifier*/Type/*Punctuation*/)/*Punctuation*/./*Identifier*/Append/*Punctuation*/(/*String*/@"*/"/*Punctuation*/)/*Punctuation*/./*Identifier*/Append/*Punctuation*/(/*Identifier*/token/*Punctuation*/./*Identifier*/Lexeme/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
                        /*Identifier*/break/*Punctuation*/;/*WhiteSpace*/
                    /*Identifier*/case/*WhiteSpace*/ /*Number*/1/*Punctuation*/:/*WhiteSpace*/
                        /*Identifier*/sb/*Punctuation*/./*Identifier*/Append/*Punctuation*/(/*Identifier*/token/*Punctuation*/./*Identifier*/Lexeme/*Punctuation*/)/*Punctuation*/./*Identifier*/Append/*Punctuation*/(/*String*/@" "/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
                        /*Identifier*/break/*Punctuation*/;/*WhiteSpace*/
                    /*Identifier*/case/*WhiteSpace*/ /*Number*/2/*Punctuation*/:/*WhiteSpace*/
                        /*Identifier*/sb/*Punctuation*/./*Identifier*/Append/*Punctuation*/(/*Identifier*/token/*Punctuation*/./*Identifier*/Lexeme/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
                        /*Identifier*/break/*Punctuation*/;/*WhiteSpace*/
                /*Punctuation*/}/*WhiteSpace*/
            /*Punctuation*/}/*WhiteSpace*/
            /*Identifier*/Console/*Punctuation*/./*Identifier*/WriteLine/*Punctuation*/(/*Identifier*/sb/*Punctuation*/./*Identifier*/ToString/*Punctuation*/(/*Punctuation*/)/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/File/*Punctuation*/./*Identifier*/WriteAllText/*Punctuation*/(/*String*/@"../../../lab2Out/Program.cs"/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/sb/*Punctuation*/./*Identifier*/ToString/*Punctuation*/(/*Punctuation*/)/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
        /*Punctuation*/}/*WhiteSpace*/

        /*Identifier*/static/*WhiteSpace*/ /*Identifier*/void/*WhiteSpace*/ /*Identifier*/_Main/*Punctuation*/(/*Identifier*/string/*Punctuation*/[/*Punctuation*/]/*WhiteSpace*/ /*Identifier*/args/*Punctuation*/)/*WhiteSpace*/
        /*Punctuation*/{/*WhiteSpace*/
            /*Identifier*/string/*WhiteSpace*/ /*Identifier*/regex/*WhiteSpace*/ /*WhiteSpace*/ /*Identifier*/File/*Punctuation*/./*Identifier*/ReadAllText/*Punctuation*/(/*String*/@"../../RegExpression.txt"/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/string/*WhiteSpace*/ /*Identifier*/text/*WhiteSpace*/ /*WhiteSpace*/ /*Identifier*/File/*Punctuation*/./*Identifier*/ReadAllText/*Punctuation*/(/*String*/@"../../InputTextFile.txt"/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/List/*Punctuation*/</*Identifier*/string/*Punctuation*/>/*WhiteSpace*/ /*Identifier*/output/*WhiteSpace*/ /*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/List/*Punctuation*/</*Identifier*/string/*Punctuation*/>/*Punctuation*/(/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/output/*Punctuation*/./*Identifier*/Add/*Punctuation*/(/*Identifier*/EscapeCsvValue/*Punctuation*/(/*String*/@"Номер"/*Punctuation*/)/*WhiteSpace*/ /*WhiteSpace*/ /*String*/@";"/*WhiteSpace*/
            /*WhiteSpace*/ /*Identifier*/EscapeCsvValue/*Punctuation*/(/*String*/@"Группа 1"/*Punctuation*/)/*WhiteSpace*/ /*WhiteSpace*/ /*String*/@";"/*WhiteSpace*/
            /*WhiteSpace*/ /*Identifier*/EscapeCsvValue/*Punctuation*/(/*String*/@"Группа 2"/*Punctuation*/)/*WhiteSpace*/ /*WhiteSpace*/ /*String*/@";"/*WhiteSpace*/
            /*WhiteSpace*/ /*Identifier*/EscapeCsvValue/*Punctuation*/(/*String*/@"Группа 3"/*Punctuation*/)/*WhiteSpace*/ /*WhiteSpace*/ /*String*/@";"/*WhiteSpace*/
            /*WhiteSpace*/ /*Identifier*/EscapeCsvValue/*Punctuation*/(/*String*/@"Группа 4"/*Punctuation*/)/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/var/*WhiteSpace*/ /*Identifier*/rx/*WhiteSpace*/ /*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/Regex/*Punctuation*/(/*Identifier*/regex/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/int/*WhiteSpace*/ /*Identifier*/i/*WhiteSpace*/ /*WhiteSpace*/ /*Number*/0/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/foreach/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/Match/*WhiteSpace*/ /*Identifier*/match/*WhiteSpace*/ /*Identifier*/in/*WhiteSpace*/ /*Identifier*/rx/*Punctuation*/./*Identifier*/Matches/*Punctuation*/(/*Identifier*/text/*Punctuation*/)/*Punctuation*/)/*WhiteSpace*/
            /*Punctuation*/{/*WhiteSpace*/
                /*Identifier*/output/*Punctuation*/./*Identifier*/Add/*Punctuation*/(/*Identifier*/EscapeCsvValue/*Punctuation*/(/*String*/@"строка "/*Punctuation*/)/*WhiteSpace*/ /*WhiteSpace*/ /*Identifier*/i/*WhiteSpace*/ /*WhiteSpace*/ /*String*/@";"/*WhiteSpace*/ /*WhiteSpace*/
                /*Identifier*/EscapeCsvValue/*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Groups/*Punctuation*/[/*Number*/1/*Punctuation*/]/*Punctuation*/./*Identifier*/Value/*Punctuation*/)/*WhiteSpace*/ /*WhiteSpace*/ /*String*/@";"/*WhiteSpace*/ /*WhiteSpace*/
                /*Identifier*/EscapeCsvValue/*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Groups/*Punctuation*/[/*Number*/2/*Punctuation*/]/*Punctuation*/./*Identifier*/Value/*Punctuation*/)/*WhiteSpace*/ /*WhiteSpace*/ /*String*/@";"/*WhiteSpace*/ /*WhiteSpace*/
                /*Identifier*/EscapeCsvValue/*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Groups/*Punctuation*/[/*Number*/3/*Punctuation*/]/*Punctuation*/./*Identifier*/Value/*Punctuation*/)/*WhiteSpace*/ /*WhiteSpace*/ /*String*/@";"/*WhiteSpace*/ /*WhiteSpace*/
                /*Identifier*/EscapeCsvValue/*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Groups/*Punctuation*/[/*Number*/4/*Punctuation*/]/*Punctuation*/./*Identifier*/Value/*Punctuation*/)/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
            /*Punctuation*/}/*WhiteSpace*/
            /*Identifier*/File/*Punctuation*/./*Identifier*/WriteAllLines/*Punctuation*/(/*String*/@"..\..\OutputTextFile.csv"/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/output/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/Encoding/*Punctuation*/./*Identifier*/Default/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
        /*Punctuation*/}/*WhiteSpace*/
        /*Identifier*/static/*WhiteSpace*/ /*Identifier*/string/*WhiteSpace*/ /*Identifier*/EscapeCsvValue/*Punctuation*/(/*Identifier*/string/*WhiteSpace*/ /*Identifier*/s/*Punctuation*/)/*WhiteSpace*/ /*WhiteSpace*/ /*String*/@""""/*WhiteSpace*/ /*WhiteSpace*/ /*Identifier*/s/*Punctuation*/./*Identifier*/Replace/*Punctuation*/(/*String*/@""""/*Punctuation*/,/*WhiteSpace*/ /*String*/@""""""/*Punctuation*/)/*WhiteSpace*/ /*WhiteSpace*/ /*String*/@""""/*Punctuation*/;/*WhiteSpace*/
    /*Punctuation*/}/*WhiteSpace*/
    /*Identifier*/static/*WhiteSpace*/ /*Identifier*/class/*WhiteSpace*/ /*Identifier*/MatchToken/*WhiteSpace*/
    /*Punctuation*/{/*WhiteSpace*/
        /*Identifier*/public/*WhiteSpace*/ /*Identifier*/static/*WhiteSpace*/ /*Identifier*/IEnumerable/*Punctuation*/</*Identifier*/Match/*Punctuation*/>/*WhiteSpace*/ /*Identifier*/GetMatch/*Punctuation*/(/*Identifier*/this/*WhiteSpace*/ /*Identifier*/Regex/*WhiteSpace*/ /*Identifier*/regex/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/string/*WhiteSpace*/ /*Identifier*/inputText/*Punctuation*/)/*WhiteSpace*/
        /*Punctuation*/{/*WhiteSpace*/
            /*Identifier*/for/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/var/*WhiteSpace*/ /*Identifier*/match/*WhiteSpace*/ /*WhiteSpace*/ /*Identifier*/regex/*Punctuation*/./*Identifier*/Match/*Punctuation*/(/*Identifier*/inputText/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/ /*Identifier*/match/*Punctuation*/./*Identifier*/Success/*Punctuation*/;/*WhiteSpace*/ /*Identifier*/match/*WhiteSpace*/ /*WhiteSpace*/ /*Identifier*/match/*Punctuation*/./*Identifier*/NextMatch/*Punctuation*/(/*Punctuation*/)/*Punctuation*/)/*WhiteSpace*/
                /*Identifier*/yield/*WhiteSpace*/ /*Identifier*/return/*WhiteSpace*/ /*Identifier*/match/*Punctuation*/;/*WhiteSpace*/
        /*Punctuation*/}/*WhiteSpace*/
    /*Punctuation*/}/*WhiteSpace*/
/*Punctuation*/}/*WhiteSpace*/
