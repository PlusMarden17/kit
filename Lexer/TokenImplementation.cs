namespace KitL.Lexer {
	public class TokenImplementation : IToken {
		private readonly TokenType type;
		private readonly string? value;

		public TokenImplementation(TokenType tokenType, string value) {
			this.type = tokenType;
			this.value = value;
		}

		public TokenType Type { get { return type; } }
		public string? Value { get { return value; } }

		public override string ToString() {
			return $"[{this.type}: {this.value}]";
		}
	}
}