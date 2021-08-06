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
        /*Identifier*/Identifier/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/Number/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/Operator/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/String/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/Punctuation/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/WhiteSpace/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/Comment/*WhiteSpace*/
    /*Punctuation*/}/*WhiteSpace*/

    /*Identifier*/class/*WhiteSpace*/ /*Identifier*/Token/*WhiteSpace*/
    /*Punctuation*/{/*WhiteSpace*/
        /*Identifier*/public/*WhiteSpace*/ /*Identifier*/string/*WhiteSpace*/ /*Identifier*/Lexeme/*WhiteSpace*/ /*Punctuation*/{/*WhiteSpace*/ /*Identifier*/get/*Punctuation*/;/*WhiteSpace*/ /*Punctuation*/}/*WhiteSpace*/
        /*Identifier*/public/*WhiteSpace*/ /*Identifier*/TokenType/*WhiteSpace*/ /*Identifier*/Type/*WhiteSpace*/ /*Punctuation*/{/*WhiteSpace*/ /*Identifier*/get/*Punctuation*/;/*WhiteSpace*/ /*Punctuation*/}/*WhiteSpace*/

        /*Identifier*/public/*WhiteSpace*/ /*Identifier*/Token/*Punctuation*/(/*Identifier*/string/*WhiteSpace*/ /*Identifier*/lexeme/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/TokenType/*WhiteSpace*/ /*Identifier*/type/*Punctuation*/)/*WhiteSpace*/
        /*Punctuation*/{/*WhiteSpace*/
            /*Identifier*/Lexeme/*WhiteSpace*/ /*Operator*/=/*WhiteSpace*/ /*Identifier*/lexeme/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/Type/*WhiteSpace*/ /*Operator*/=/*WhiteSpace*/ /*Identifier*/type/*Punctuation*/;/*WhiteSpace*/
        /*Punctuation*/}/*WhiteSpace*/
    /*Punctuation*/}/*WhiteSpace*/
    /*Identifier*/class/*WhiteSpace*/ /*Identifier*/Program/*WhiteSpace*/
    /*Punctuation*/{/*WhiteSpace*/
        /*Identifier*/static/*WhiteSpace*/ /*Identifier*/IEnumerable/*Punctuation*/</*Identifier*/Token/*Punctuation*/>/*WhiteSpace*/ /*Identifier*/GetTokens/*Punctuation*/(/*Identifier*/string/*WhiteSpace*/ /*Identifier*/inputText/*Punctuation*/)/*WhiteSpace*/
        /*Punctuation*/{/*WhiteSpace*/
            /*Identifier*/var/*WhiteSpace*/ /*Identifier*/regex/*WhiteSpace*/ /*Operator*/=/*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/Regex/*Punctuation*/(/*String*/@"(?<Identifier>[a-zA-Z_][a-zA-Z_0-9]*)|
                                    (?<Number>[0-9]+)|
                                    (?<Operator>\!\=|\+\=|\=\>|\=\<|\+|\=|\-|\*)|
                                    (?<String>\@""(""""|[^""])*"")|
                                    (?<Punctuation>\.|\(|\)|\{|\}|\[|\]|\;|\<|\>|\,|\:)|
                                    (?<WhiteSpace>[\ \t\r\n]+)|
                                    (?<Comment>(//)(.*?)(?=[\n\r])|((/\*)(.*?)(\*/)))"/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/RegexOptions/*Punctuation*/./*Identifier*/IgnorePatternWhitespace/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/var/*WhiteSpace*/ /*Identifier*/matches/*WhiteSpace*/ /*Operator*/=/*WhiteSpace*/ /*Identifier*/regex/*Punctuation*/./*Identifier*/GetMatch/*Punctuation*/(/*Identifier*/inputText/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/int/*WhiteSpace*/ /*Identifier*/indexMatch/*WhiteSpace*/ /*Operator*/=/*WhiteSpace*/ /*Number*/0/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/foreach/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/var/*WhiteSpace*/ /*Identifier*/match/*WhiteSpace*/ /*Identifier*/in/*WhiteSpace*/ /*Identifier*/matches/*Punctuation*/)/*WhiteSpace*/
            /*Punctuation*/{/*WhiteSpace*/
                /*Identifier*/if/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/indexMatch/*WhiteSpace*/ /*Operator*/!=/*WhiteSpace*/ /*Identifier*/match/*Punctuation*/./*Identifier*/Index/*Punctuation*/)/*WhiteSpace*/
                    /*Identifier*/throw/*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/Exception/*Punctuation*/(/*String*/@"пропущен токен"/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
                /*Identifier*/indexMatch/*WhiteSpace*/ /*Operator*/+=/*WhiteSpace*/ /*Identifier*/match/*Punctuation*/./*Identifier*/Length/*Punctuation*/;/*WhiteSpace*/
                /*Identifier*/if/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Groups/*Punctuation*/[/*String*/@"Identifier"/*Punctuation*/]/*Punctuation*/./*Identifier*/Success/*Punctuation*/)/*WhiteSpace*/
                    /*Identifier*/yield/*WhiteSpace*/ /*Identifier*/return/*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/Token/*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Value/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/TokenType/*Punctuation*/./*Identifier*/Identifier/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
                /*Identifier*/else/*WhiteSpace*/ /*Identifier*/if/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Groups/*Punctuation*/[/*String*/@"Number"/*Punctuation*/]/*Punctuation*/./*Identifier*/Success/*Punctuation*/)/*WhiteSpace*/
                    /*Identifier*/yield/*WhiteSpace*/ /*Identifier*/return/*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/Token/*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Value/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/TokenType/*Punctuation*/./*Identifier*/Number/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
                /*Identifier*/else/*WhiteSpace*/ /*Identifier*/if/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Groups/*Punctuation*/[/*String*/@"Operator"/*Punctuation*/]/*Punctuation*/./*Identifier*/Success/*Punctuation*/)/*WhiteSpace*/
                    /*Identifier*/yield/*WhiteSpace*/ /*Identifier*/return/*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/Token/*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Value/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/TokenType/*Punctuation*/./*Identifier*/Operator/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
                /*Identifier*/else/*WhiteSpace*/ /*Identifier*/if/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Groups/*Punctuation*/[/*String*/@"String"/*Punctuation*/]/*Punctuation*/./*Identifier*/Success/*Punctuation*/)/*WhiteSpace*/
                    /*Identifier*/yield/*WhiteSpace*/ /*Identifier*/return/*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/Token/*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Value/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/TokenType/*Punctuation*/./*Identifier*/String/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
                /*Identifier*/else/*WhiteSpace*/ /*Identifier*/if/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Groups/*Punctuation*/[/*String*/@"Punctuation"/*Punctuation*/]/*Punctuation*/./*Identifier*/Success/*Punctuation*/)/*WhiteSpace*/
                    /*Identifier*/yield/*WhiteSpace*/ /*Identifier*/return/*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/Token/*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Value/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/TokenType/*Punctuation*/./*Identifier*/Punctuation/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
                /*Identifier*/else/*WhiteSpace*/ /*Identifier*/if/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Groups/*Punctuation*/[/*String*/@"WhiteSpace"/*Punctuation*/]/*Punctuation*/./*Identifier*/Success/*Punctuation*/)/*WhiteSpace*/
                    /*Identifier*/yield/*WhiteSpace*/ /*Identifier*/return/*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/Token/*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Value/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/TokenType/*Punctuation*/./*Identifier*/WhiteSpace/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
                /*Identifier*/else/*WhiteSpace*/ /*Identifier*/if/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Groups/*Punctuation*/[/*String*/@"Comment"/*Punctuation*/]/*Punctuation*/./*Identifier*/Success/*Punctuation*/)/*WhiteSpace*/
                    /*Identifier*/yield/*WhiteSpace*/ /*Identifier*/return/*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/Token/*Punctuation*/(/*Identifier*/match/*Punctuation*/./*Identifier*/Value/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/TokenType/*Punctuation*/./*Identifier*/Comment/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
            /*Punctuation*/}/*WhiteSpace*/
            /*Identifier*/if/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/indexMatch/*WhiteSpace*/ /*Operator*/!=/*WhiteSpace*/ /*Identifier*/inputText/*Punctuation*/./*Identifier*/Length/*Punctuation*/)/*WhiteSpace*/
                /*Identifier*/throw/*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/Exception/*Punctuation*/(/*String*/@"входной текста отличается от результирующего"/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
        /*Punctuation*/}/*WhiteSpace*/
        /*Identifier*/static/*WhiteSpace*/ /*Identifier*/void/*WhiteSpace*/ /*Identifier*/Main/*Punctuation*/(/*Identifier*/string/*Punctuation*/[/*Punctuation*/]/*WhiteSpace*/ /*Identifier*/args/*Punctuation*/)/*Comment*///COMM 123/*WhiteSpace*/
        /*Punctuation*/{/*WhiteSpace*/
            /*Identifier*/int/*WhiteSpace*/ /*Identifier*/mode/*WhiteSpace*/ /*Operator*/=/*WhiteSpace*/ /*Number*/0/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/var/*WhiteSpace*/ /*Identifier*/inputText/*WhiteSpace*/ /*Operator*/=/*WhiteSpace*/ /*Identifier*/File/*Punctuation*/./*Identifier*/ReadAllText/*Punctuation*/(/*String*/@"../../Program.cs"/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/var/*WhiteSpace*/ /*Identifier*/sb/*WhiteSpace*/ /*Operator*/=/*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/StringBuilder/*Punctuation*/(/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
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
            /*Identifier*/string/*WhiteSpace*/ /*Identifier*/text/*WhiteSpace*/ /*Operator*/=/*WhiteSpace*/ /*Identifier*/File/*Punctuation*/./*Identifier*/ReadAllText/*Punctuation*/(/*String*/@"../../InputTextFile.txt"/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/string/*WhiteSpace*/ /*Identifier*/regex/*WhiteSpace*/ /*Operator*/=/*WhiteSpace*/ /*Identifier*/File/*Punctuation*/./*Identifier*/ReadAllText/*Punctuation*/(/*String*/@"../../RegExpression.txt"/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/

            /*Identifier*/char/*WhiteSpace*/ /*Identifier*/newLine/*WhiteSpace*/ /*Operator*/=/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/char/*Punctuation*/)/*Number*/10/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/var/*WhiteSpace*/ /*Identifier*/csv/*WhiteSpace*/ /*Operator*/=/*WhiteSpace*/ /*String*/@"Номер	Группа1	Группа2	Группа3	Группа4"/*WhiteSpace*/ /*Operator*/+/*WhiteSpace*/ /*Identifier*/newLine/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/csv/*WhiteSpace*/ /*Operator*/+=/*WhiteSpace*/ /*Identifier*/string/*Punctuation*/./*Identifier*/Concat/*Punctuation*/(/*Identifier*/new/*WhiteSpace*/ /*Identifier*/Regex/*Punctuation*/(/*Identifier*/regex/*Punctuation*/)/*Punctuation*/./*Identifier*/GetMatch/*Punctuation*/(/*Identifier*/text/*Punctuation*/)/*WhiteSpace*/
            /*Punctuation*/./*Identifier*/Select/*Punctuation*/(/*Punctuation*/(/*Identifier*/match/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/i/*Punctuation*/)/*WhiteSpace*/ /*Operator*/=>/*WhiteSpace*/
            /*Punctuation*/{/*WhiteSpace*/
                /*Identifier*/var/*WhiteSpace*/ /*Identifier*/sb/*WhiteSpace*/ /*Operator*/=/*WhiteSpace*/ /*Identifier*/new/*WhiteSpace*/ /*Identifier*/StringBuilder/*Punctuation*/(/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
                /*Identifier*/sb/*Punctuation*/./*Identifier*/Append/*Punctuation*/(/*String*/@"строка "/*Punctuation*/)/*Punctuation*/./*Identifier*/Append/*Punctuation*/(/*Punctuation*/(/*Identifier*/i/*WhiteSpace*/ /*Operator*/+/*WhiteSpace*/ /*Number*/1/*Punctuation*/)/*Punctuation*/./*Identifier*/ToString/*Punctuation*/(/*Punctuation*/)/*Punctuation*/)/*Punctuation*/./*Identifier*/Append/*Punctuation*/(/*String*/@"	"/*Punctuation*/)/*WhiteSpace*/
                /*Punctuation*/./*Identifier*/AppendLine/*Punctuation*/(/*Identifier*/string/*Punctuation*/./*Identifier*/Join/*Punctuation*/(/*String*/@"	"/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/match/*Punctuation*/./*Identifier*/Groups/*Punctuation*/./*Identifier*/Cast/*Punctuation*/</*Identifier*/Group/*Punctuation*/>/*Punctuation*/(/*Punctuation*/)/*Punctuation*/./*Identifier*/Skip/*Punctuation*/(/*Number*/1/*Punctuation*/)/*WhiteSpace*/
                /*Punctuation*/./*Identifier*/Select/*Punctuation*/(/*Punctuation*/(/*Identifier*/group/*Punctuation*/)/*WhiteSpace*/ /*Operator*/=>/*WhiteSpace*/ /*String*/@""""/*WhiteSpace*/ /*Operator*/+/*WhiteSpace*/ /*Identifier*/group/*Punctuation*/./*Identifier*/ToString/*Punctuation*/(/*Punctuation*/)/*Punctuation*/./*Identifier*/Replace/*Punctuation*/(/*String*/@""""/*Punctuation*/,/*WhiteSpace*/ /*String*/@""""""/*Punctuation*/)/*WhiteSpace*/ /*Operator*/+/*WhiteSpace*/ /*String*/@""""/*Punctuation*/)/*Punctuation*/)/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
                /*Identifier*/return/*WhiteSpace*/ /*Identifier*/sb/*Punctuation*/./*Identifier*/ToString/*Punctuation*/(/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
            /*Punctuation*/}/*Punctuation*/)/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/Console/*Punctuation*/./*Identifier*/WriteLine/*Punctuation*/(/*Identifier*/csv/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
            /*Identifier*/File/*Punctuation*/./*Identifier*/WriteAllText/*Punctuation*/(/*String*/@"../../OutputTextFile.csv"/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/csv/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/Encoding/*Punctuation*/./*Identifier*/Unicode/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/
        /*Punctuation*/}/*WhiteSpace*/
    /*Punctuation*/}/*WhiteSpace*/
    /*Identifier*/static/*WhiteSpace*/ /*Identifier*/class/*WhiteSpace*/ /*Identifier*/MatchToken/*WhiteSpace*/
    /*Punctuation*/{/*WhiteSpace*/
        /*Identifier*/public/*WhiteSpace*/ /*Identifier*/static/*WhiteSpace*/ /*Identifier*/IEnumerable/*Punctuation*/</*Identifier*/Match/*Punctuation*/>/*WhiteSpace*/ /*Identifier*/GetMatch/*Punctuation*/(/*Identifier*/this/*WhiteSpace*/ /*Identifier*/Regex/*WhiteSpace*/ /*Identifier*/regex/*Punctuation*/,/*WhiteSpace*/ /*Identifier*/string/*WhiteSpace*/ /*Identifier*/inputText/*Punctuation*/)/*WhiteSpace*/
        /*Punctuation*/{/*WhiteSpace*/
            /*Identifier*/for/*WhiteSpace*/ /*Punctuation*/(/*Identifier*/var/*WhiteSpace*/ /*Identifier*/match/*WhiteSpace*/ /*Operator*/=/*WhiteSpace*/ /*Identifier*/regex/*Punctuation*/./*Identifier*/Match/*Punctuation*/(/*Identifier*/inputText/*Punctuation*/)/*Punctuation*/;/*WhiteSpace*/ /*Identifier*/match/*Punctuation*/./*Identifier*/Success/*Punctuation*/;/*WhiteSpace*/ /*Identifier*/match/*WhiteSpace*/ /*Operator*/=/*WhiteSpace*/ /*Identifier*/match/*Punctuation*/./*Identifier*/NextMatch/*Punctuation*/(/*Punctuation*/)/*Punctuation*/)/*WhiteSpace*/
                /*Identifier*/yield/*WhiteSpace*/ /*Identifier*/return/*WhiteSpace*/ /*Identifier*/match/*Punctuation*/;/*WhiteSpace*/
        /*Punctuation*/}/*WhiteSpace*/
    /*Punctuation*/}/*WhiteSpace*/
/*Punctuation*/}/*WhiteSpace*/
