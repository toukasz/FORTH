: ^ ( n u -- m )
\ m = n ^ u
  over swap
  1 DO
    over *
  LOOP
  nip ;

: FACTORIAL ( n -- n! )
  1 swap
  1+ 1 DO
    i *
  LOOP ;

: UP ( n1 n2 n3 -- )
\ n1 = step, n2 = limit, n3 = start
  +DO
  i .
  dup +LOOP
  drop ;

: DOWN ( n1 n2 n3 -- )
\ n1 = step, n2 = limit, n3 = start
  -DO
  i .
  dup -LOOP
  drop ;

: FIBONACCI ( n --- m )
\ m = value of fibonacci at nth 
  0 1 rot
  1 DO
    2dup + rot drop
  LOOP
  nip ;

: CRASH ( n -- )
\ crashes the program!
  0 >r ;

\ EXIT exits the current definition
\ LEAVE leaves the innermost loop

: countdown ( n -- )
  begin
  CR dup .
  dup 0= if
    exit then
  1-
  again ;

\ RECURSE for recursive definitions

: PLUS1
DUP .
1+ DUP 100 > IF
	DROP EXIT THEN
RECURSE ;

: plus2 recursive
dup .
2 + dup 100 > if
	drop exit then
plus2 ;

\ I sincerely apologize for this series of terrible, terrible names.
\ I guess naming "words" really is the hardest thing in programming.

: fibo
rot dup 1 = IF
	drop . drop
	EXIT THEN
1- rot rot
swap over +
RECURSE ;

: fiboinit
0 1 fibo ;

: fibon { n a b -- }
n 1- dup 0= if
	b . exit then
b a b +
recurse ;

: fiboninit
0 1 fibon ;

: foo ( n1 n2 -- )
 .s
 >r .s
 r@ .
 >r .s
 r@ .
 r> .
 r@ .
 r> . ;

\ The "return stack" is also avaliable for use
: 4reverse ( x1 x2 x3 x4 -- x4 x3 x2 x1 )
swap rot >r rot r> swap ;
