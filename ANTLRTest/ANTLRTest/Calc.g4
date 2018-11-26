grammar Calc;

/*
 * Parser Rules
 */

 prog: stat
	   ;
 stat: expr
	   ;
 expr: term (op=('+' | '-') term)*        #ADDSUB
	   ;
 term: factor (op=('*' | '/') factor)*    #MUTDIV
	   ;
 factor: '(' expr ')'                  #PAR
		 | INT                         #NUMBER
		 | ID                          #VAR
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
INT : ('0'..'9')+
	  ;
ID  : ('a'..'z' | 'A'..'Z')+
	  ;
NEWLINE: '\r' ? '\n'
		 ;
WS
	:	(' ' | '\t' | '\r' | '\n')+ -> channel(HIDDEN)
	;
