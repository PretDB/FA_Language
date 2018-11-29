grammar Calc;

/*
 * Parser Rules
 */

 prog: stat
	   ;
 stat: expr													#EXPR
	   | ID (op='=>') expr									#ASSIGN
	   | ID (op='=>') '(' ( ID (',' ID)* )? ')' '->' expr	#FUNC
	   ;
 expr: term '+' expr										#ADD
	   | term '-' expr										#SUB
	   | term												#SINGLE_TERM
	   ;
 term: factor '*' term										#MULT
	   | factor '/' term									#DIVI
	   | factor												#SINGLE_FACTOR
	   ;
 factor: '(' expr ')'										#PAR
		 | INT												#NUMBER
		 | ID												#VAR
		 | ID '(' ( expr (',' expr)* )? ')'					#FUNC_CALL
		 ;

/*
 * Lexer Rules
 */
ADD: '+'
	 ;
SUB: '-'
	 ;
MUL: '*'
	 ;
DIV: '/'
	 ;
ASN: '=>'
	 ;
INT : ('0'..'9')+
	  ;
ID  : ('a'..'z' | 'A'..'Z')+
	  ;
NEWLINE: '\r' ? '\n'
		 ;
WS
	:	(' ' | '\t' | '\r' | '\n')+ -> channel(HIDDEN)
	;
