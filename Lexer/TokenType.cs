namespace KitL.Lexer {

	public enum TokenType {
		PLUS,
		MINUS,
		MUL,
		DIV,

		NUMBER,
		STRING,

		NUMBER_LITERAL,
		STRING_LITERAL,

		LPAREN,
		RPAREN,

		ASSIGN,
		SEMICOLON,
		COLON,

		LET,
		ID,
		PRINT,
		EOF
	}
}