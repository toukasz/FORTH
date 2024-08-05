\ Chapter 5

\ */ ( n1 n2 n3 - n4 )
\ multiplies then divides 
\ e.g. n1 is total, n2 is percentage, n3 is 100
\ => n3 is number within percentage of total

: r% 100 */ ;

: loop2 ( -- ) 100 0 do i . 2 +loop ;

: box ( width height -- )
CR
0 do
	dup 0 do
		[char] # emit space
	loop
	CR
loop
drop
;

: \box ( width height -- )
CR
0 do
	i 0<> if
		i 0 do
			space space
		loop
	then
	dup 0 do
		[char] # emit space
	loop
	CR
loop
drop
;

: /box ( width height -- )
CR
0 do
	dup 1- i <> if
		dup 1- i do
			space space
		loop
	then
	dup 0 do
		[char] # emit space
	loop
	CR
loop
drop
;

: hashes ( number -- )
0 do [char] # emit loop ;

: row ( height index -- )
2dup - spaces dup 2* 1- hashes - spaces ;
: diamond ( height -- )
dup 1 +do cr dup i row 1 +loop
0 over -do cr dup i row 1 -loop drop ;

: diamonds ( width number -- )
0 do dup diamond loop drop ;

: interest ( cash -- )
\ cash on stack in dollars
\ interest rate at 6% per year
\ stop if 2000 dollar goal is reached
\ stop if 20 years has passed
100 *
21 1 do	
	106 100 */
	i over 2000 100 * >= if
		CR ." in " . ." year(s), you make: $"
		100 / . unloop exit then	
	CR ." in " . ." years(s), you make: $"
	dup 100 / .
loop
;

: ** ( n1 n2 -- n3 )
\ exponent
over -rot
1 do
	over *
loop
nip
;

: N-MAX ( -- ) \ look for signed integer (upper) limit
2
begin
dup 2* dup 0<> while
	nip
repeat
drop 1+ negate .
;

: MS  ( u -- )  DROP ;  \ if your system doesn't have MS
: BEEP   ." BEEP "  7 EMIT ;  \ not ANS but works on many systems
: DELAY   500 MS ;
: RING   BEEP DELAY BEEP DELAY BEEP ;
