// Define a grammar
grammar GDMQL;



query
    : statement*
    ;
 
statement
    : SELECT (ASTERISK | IDENTIFIER (COMMA IDENTIFIER )* ) from where?
    ;
    
select
    :

from
    : FROM IDENTIFIER (COMMA IDENTIFIER)*
    ;

where
    :  expression
    ;

expression
    : expression 'AND' expression  # AndExpression
    | expression 'OR' expression   # OrExpression
    | IDENTIFIER comparison_operator value  # ComparisonExpression
    ;

predicate 
    : IDENTIFIER comparison_operator value
    ;



/*
expression
    : expression booleanOperator expression 
    | OPENPAREN expression CLOSEPAREN       
    | IDENTIFIER comparison_operator value  
    ;
*/

booleanOperator
    : AND
    | OR
    ;

comparison_operator
    : LE
    | GE
    | NE
    | LT
    | GT
    | EQ
    ;

value
   : INT          # IntegerValue
   | DOUBLE       # DoubleValue
   | STRING       # StringValue      
   | PLACEHOLDER  # PlaceHolderValue
   ;



SELECT: 'SELECT';
FROM: 'FROM';
WHERE: 'WHERE';

IDENTIFIER : [a-zA-Z_][a-zA-Z_0-9]*  
;

STRING : '\'' [a-zA-Z_][a-zA-Z_0-9]* '\''
;

COMMA : ',';
ASTERISK : '*';

EQ      : '=' '=' ? ;
LE      : '<=' ;
GE      : '>=' ;
NE      : '!=' ;
LT      : '<' ;
GT      : '>' ;
SEP     : '.' ;

OPENPAREN: '(';
CLOSEPAREN: ')'; 

AND     : 'AND' ;
OR      : 'OR' ;
INT     : '-'? [0-9]+ ;
DOUBLE  : '-'? [0-9]+'.'[0-9]+ ;
PLACEHOLDER : '{'[0-9]+'}' ;

WS  : (' '|'\t'|'\r'|'\n')+ -> skip;
 
SIGN
   : ('+' | '-')
   ;
NUMBER  
    : SIGN? ( [0-9]* '.' )? [0-9]+;



