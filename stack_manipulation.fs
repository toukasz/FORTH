\ STACK MANIPULATION
: HELLO ( -- ) CR ." Hello!" ;

: 3rev ( w1 w2 w3 -- w3 w2 w1 )
  swap rot ;

: rmdb ( w1 w2 w3 -- w1 w3 w3 )
  swap drop dup ;

: swap2 ( w1 w2 w3 -- w2 w1 w3 )
  rot rot swap rot ;

: 4rev ( w1 w2 w3 w4 -- w4 w3 w2 w1 )
  swap 2swap swap ;

: 3dup ( w1 w2 w3 -- w1 w2 w3 w1 w2 w3 )
  rot dup 2swap rot rot dup 2swap rot rot dup 2swap rot ;

: 3drop ( w1 w2 w3 -- )
  drop drop drop ;

: inc ( w1 w2 w3 -- w1 w2 w3 w4 )
  dup 1 + ;

: drop2 ( w1 w2 w3 -- w1 w3 )
  swap drop ;

: pow3 ( n -- n ^ 3 )
  dup dup * * ;

: pow4 ( n -- n ^ 4 )
  dup dup dup * * * ;

: exp1 ( a b -- [a-b][a+1] )
  over swap - swap 1 + * ;

: nipper ( w1 w2 w3 -- w1 w3 )
  swap drop ;

: tucker ( w1 w2 -- w2 w1 w2 )
  dup rot rot ;

: negative ( a -- -a )
  -1 * ;

: modder ( a -- mod of a )
  swap tuck swap tuck / * - ;

: /modder ( a -- /mod of a )
  swap tuck swap tuck mod rot rot / ;

: swap ( x1 x2 -- x2 x1 )
  { a b } b a ;

: 2over2 ( x1 x2 x3 x4 -- x1 x2 x3 x4 x1 x2)
  { a b c d -- you can insert a comment here } a b c d a b ;

: max { n1 n2 -- n3 }
  n1 n2 > if n1
  else n2
  endif ;

: pow5 { n -- n^5 }
  n dup dup dup dup * * * * ;

: abs ( n -- |n| )
  dup 0 < if negate
  endif ;

: min ( n1 n2 -- n )
  2dup < if drop
  else nip
  then ; 

: minner \ without "else" part
  2dup > if swap then drop ; 

: isEven ( n1 n2 -- n )
  dup 2 mod 0 = 
  if . ." is even!"
  else . ." is odd!"
  then ;

: endless ( -- )
  0 begin dup . 1+ again ;

: fibonacci ( n1 n2 -- n1 n2 n1+n2 ) 
  0 1 
  begin
  2dup + dup .
  dup 100 > until ;

: factors
dup
begin
2dup mod 0 = IF
. ELSE drop THEN
1-
dup 0 > while
repeat ;
