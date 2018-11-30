grammar FA_Language;

/*
 * Parser Rules
 */
conversation
	: sentence
	;

sentence
	:	statement														#STATEMENT
	|	order															#ORDER
	;

statement
	:	declaration														#DECLARATION
	;

order
	:	call
	;

call
	:	WORD ('(' (sentence (',' sentence)*)? ')')?						#WORDCALL
	|	body															#BODYCALL
	;

declaration
	:	WORD ASN func_body												#FUNC_DECLARATION
	|	WORD ASN list_body												#LIST_DECLARATION
	|	WORD ASN tuple_body											#TUPLE_DECLARATION		
	|	WORD ASN num_body												#NUM_DECLARATION
	;

body
	:	func_body
	|	list_body
	|	tuple_body
	|	num_body
	;

func_body
	:	'(' (TYPE WORD (',' TYPE WORD)*)? ')' '->' sentence
	;

list_body
	:	'[' (sentence (',' sentence)*)? ']'	
	;

tuple_body
	:	'('	sentence  (',' sentence)+ ')'
	;


num_body
	:	INT
	|	REAL
	|	IMAG
	|	TYPE
	;

compileUnit
	:	EOF
	;

/*
 * Lexer Rules
 */

fragment BLK
	:	' '
	;

WS
	:	( BLK | '\t' | '\r' | '\n')+ -> channel(HIDDEN)
	;

fragment NUTRAL
	:	('0'..'9')+
	;

fragment INTEGER
	:	('-')? NUTRAL+
	;

fragment FRAC
	:	INTEGER '.' NUTRAL
	;

fragment FLOAT
	:	FRAC
	|	INTEGER
	|	(FRAC | INTEGER) 'e' (FRAC | INTEGER)
	|	(FRAC | INTEGER) 'E' (FRAC | INTEGER)
	;

fragment NON_NUM
	:	('a'..'z' | 'A'..'Z' | '~' | '`' | '!' | '@' | '#' | '$' | '%' | '^' | '&' | '*' | '_' | '+' | '-' | '/' | '\\' | '|' | '>' | '<' | '?' | ':' )
	;

TYPE
	:	'Int'
	|	'Real'
	|	'Imag'
	|	'List'
	|	'Tuple'
	;

ASN
	:	'=>'
	;

INT
	:	INTEGER
	;

REAL
	:	FLOAT
	;

IMAG
	:	FLOAT 'i' FLOAT
	;

WORD
	:	NON_NUM (NON_NUM | ('0'..'9'))*
	|	INT
	|	FLOAT
	|	IMAG
	;