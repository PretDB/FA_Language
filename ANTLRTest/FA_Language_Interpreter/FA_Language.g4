grammar FA_Language;

/*
 * Parser Rules
 */
conversation
	: sentence															#SENTENCE
	;

sentence
	:	statement														#STATEMENT
	|	order															#ORDER
	;

statement
	:	declaration														#DECLARATION
	;

order
	:	func_call														#FUNC_CALL
	|	var_call														#VAR_CALL
	;

func_call
	:	WORD '(' (sentence)* ')'
	;

var_call
	:	WORD															#SHOW_VAR
	;

declaration
	:	WORD '=>' func_body												#FUNC_DECLARATION
	|	WORD '=>' list_body												#LIST_DECLARATION
	|	WORD '=>' tuple_body											#TUPLE_DECLARATION		
	|	WORD '=>' num_body												#NUM_DECLARATION
	;

func_body
	:	'(' (sentence)* ')' '->' sentence
	;

list_body
	:	'[' (sentence)* ']'	
	;

tuple_body
	:	'('	sentence ',' (',' sentence)+ ')'
	;


num_body
	:	INT																#INT_BODY
	|	REAL															#REAL_BODY
	|	IMAG															#IMAG_BODY
	;

compileUnit
	:	EOF
	;

/*
 * Lexer Rules
 */

WS
	:	' ' -> channel(HIDDEN)
	;

NUTRAL
	:	('0'..'9')+
	;

INT
	:	('-')? NUTRAL
	;

FRAC
	:	(INT) '.' (NUTRAL)
	;

REAL
	:	FRAC
	|	FRAC 'e' FRAC
	|	FRAC 'E' FRAC
	;

IMAG
	:	REAL 'i' REAL
	;

WORD
	:	NON_NUM (NON_NUM | ('0'..'9'))*
	;

NON_NUM
	:	('a'..'z' | 'A'..'Z' | '~' | '`' | '!' | '@' | '#' | '$' | '%' | '^' | '&' | '*' | '_' | '+' | '/' | '\\' | '|' | '>' | '<' | '?' | ':' )
	;