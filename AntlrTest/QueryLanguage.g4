grammar QueryLanguage;
 


statement
    : select from where? join*
    ;
 
select
    : SELECT (ASTERISK | column (COMMA column )* ) 
    ;
    
from
    : FROM table (COMMA table)*
    ;

join
    : joinType JOIN table ON joinPredicate
    ;

joinType
    : 'INNER'?
    | 'LEFT OUTER'?
    | 'RIGHT OUTER'?
    | 'FULL OUTER'?
    ;

joinPredicate
    : column EQ column
    ;

where
    : WHERE expression
    ;

expression
    : 
      expression 'AND' expression #And
    | expression 'OR' expression  #Or
    | LPAREN expression RPAREN #BracketExpression
    | column comparison_operator value #Predicate
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
   : INT          #IntegerValue
   | DOUBLE       #DoubleValue
   | string_literal  #StringLiteralValue      
   | PLACEHOLDER  #PlaceHolderValue
   ;

SELECT : 'SELECT';
FROM : 'FROM';
WHERE : 'WHERE';
ON : 'ON';
JOIN : 'JOIN';
COMMA : ',';
LPAREN : '(';
RPAREN : ')';
ASTERISK : '*';

string_literal : '\'' STRING '\'';
column: STRING ('.' STRING)*;
table: STRING;

WS  : (' '|'\t'|'\r'|'\n')+ -> skip;

INT     : '-'? [0-9]+ ;
DOUBLE  : '-'? [0-9]+'.'[0-9]+ ;
STRING: [a-zA-Z_0-9]+;
PLACEHOLDER : '{'[0-9]+'}' ;
 

EQ      : '=' '=' ? ;
LE      : '<=' ;
GE      : '>=' ;
NE      : '!=' ;
LT      : '<' ;
GT      : '>' ;
SEP     : '.' ;


SIGN
   : ('+' | '-')
   ;
NUMBER  
    : SIGN? ( [0-9]* '.' )? [0-9]+;