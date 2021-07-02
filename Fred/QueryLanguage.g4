grammar QueryLanguage;
 
query
    : expression
    ;
 
expression
    : STRING #String
    | NUMBER #Number
    | expression 'AND' expression #And
    | expression 'OR' expression  #Or
    | PROPERTY comparison_operator STRING #Predicate
    ;
 
comparison_operator
    : LE
    | GE
    | NE
    | LT
    | GT
    | EQ
    ;

IDENTIFIER : [a-zA-Z_][a-zA-Z_0-9]*;

WS  : (' '|'\t'|'\r'|'\n')+ -> skip;
 

EQ      : '=' '=' ? ;
LE      : '<=' ;
GE      : '>=' ;
NE      : '!=' ;
LT      : '<' ;
GT      : '>' ;
SEP     : '.' ;

STRING : '"' .*? '"';
SIGN
   : ('+' | '-')
   ;
NUMBER  
    : SIGN? ( [0-9]* '.' )? [0-9]+;