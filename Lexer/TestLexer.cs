using System;
using System.Collections.Generic;

namespace KitL.Lexer {
	public class TestLexer {
		public static void Main(string[] args) {
			ILexer lexer = new LexerImplementation();
			List<IToken> tokens = lexer.tokenize("print(Hello World)");

			foreach (IToken token in tokens) {
				Console.WriteLine(token);
			}
		}
	}
}