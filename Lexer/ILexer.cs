using System;
using System.Collections.Generic;

namespace KitL.Lexer {
	public interface ILexer {
		List<IToken> tokenize(string input);
	}
}