using System;
using System.Collections.Generic;
using System.Text;

namespace KitL.Lexer {
public class LexerImplementation : ILexer {
	private string? input;
	private int pos;
	private char? current;

	public List<IToken> tokenize(string input) {
		this.input = input;
		this.pos = 0;
		this.current = input.Length > 0 ? input[0] : (char?)null;

		List<IToken> tokens = new List<IToken>();

		while (current != null) {
			if (char.IsWhiteSpace(current.Value)) {
				skipWhiteSpaces();
			} else if (current == '+') {
				tokens.Add(new TokenImplementation(TokenType.PLUS, "+"));
				advance();
			} else if (current == '-') {
				tokens.Add(new TokenImplementation(TokenType.MINUS, "-"));
				advance();
			} else if (current == '*') {
				tokens.Add(new TokenImplementation(TokenType.MUL, "*"));
				advance();
			} else if (current == '/') {
				tokens.Add(new TokenImplementation(TokenType.DIV, "/"));
				advance();
			} else if (current == '=') {
				tokens.Add(new TokenImplementation(TokenType.ASSIGN, "="));
				advance();
			} else if (current == ';') {
				tokens.Add(new TokenImplementation(TokenType.SEMICOLON, ";"));
				advance();
			} else if (current == '(') {
				tokens.Add(new TokenImplementation(TokenType.LPAREN, "("));
				advance();
			} else if (current == ')') {
				tokens.Add(new TokenImplementation(TokenType.RPAREN, ")"));
				advance();
			} else if (current == ':') {
				tokens.Add(new TokenImplementation(TokenType.COLON, ":"));
				advance();
			} else if (char.IsDigit(current.Value)) {
				tokens.Add(new TokenImplementation(TokenType.NUMBER_LITERAL, integer()));
			} else if (current == '"' || current == '\'') {
				tokens.Add(new TokenImplementation(TokenType.STRING_LITERAL, consumeString(current.Value)));
			} else if (char.IsLetter(current.Value)) {
				tokens.Add(idOrKeyword());
			} else {
				throw new Exception("Unknown token: " + current);
			}
		}

		tokens.Add(new TokenImplementation(TokenType.EOF, ""));
		return tokens;
	}

	private void advance() {
		pos++;
		if (pos >= input.Length) {
			current = null;
		} else {
			current = input[pos];
		}
	}

	private void skipWhiteSpaces() {
		while (current != null && char.IsWhiteSpace(current.Value)) {
			advance();
		}
	}

	private string consumeString(char type) {
		var stringBuilder = new StringBuilder();
		advance();
		while (current != null && current != type) {
			stringBuilder.Append(current.Value);
			advance();
		}
		advance();
		return stringBuilder.ToString();
	}

	private TokenImplementation idOrKeyword() {
		var stringBuilder = new StringBuilder();
		while (current != null && char.IsLetterOrDigit(current.Value)) {
			stringBuilder.Append(current.Value);
			advance();
		}

		string result = stringBuilder.ToString();

		if (result == "let") return new TokenImplementation(TokenType.LET, result);
		if (result == "print") return new TokenImplementation(TokenType.PRINT, result);
		if (result == "num") return new TokenImplementation(TokenType.NUMBER, result);
		if (result == "txt") return new TokenImplementation(TokenType.STRING, result);
		return new TokenImplementation(TokenType.ID, result);
	}

	private string integer() {
		var result = new StringBuilder();
		while (current != null && char.IsDigit(current.Value)) {
			result.Append(current.Value);
			advance();
		}
		return result.ToString();
	}
}
}
