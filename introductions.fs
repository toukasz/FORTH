\ CHAPTER 1
( Large letter F )
: star		[char] # emit ;
: stars		0 do star loop ;
: margin	cr 30 spaces ;
: blip		margin star ;
: bar		margin 5 stars ;
: F			bar blip bar blip blip cr ;
F

( Print string )
: greet		." Hello, I speak Forth" SPACE ;

( Problem 1 )
: gift ." chocolates" ;
: giver ." Steven" ;
: thanks ." Dear " giver ." , thanks for the " gift [char] . emit ;

( Problem 2 )
: ten.less 10 - ;

( Problem 3 )
: giver ." Bob" ;
\ ^^ does not update the "thanks" definition as it comes before this re-definition
\ the words are *sequentially* compiled


\ CHAPTER 2
: 4rev ( 1 2 3 4 -- 4 3 2 1 )
swap rot >r rot r> swap ;
\ swap 2swap swap

: 3over ( 1 2 3 -- 1 2 3 1 )
>r over r> swap ;

: 3dup ( 1 2 3 -- 1 2 3 1 2 3 )
3over 3over 3over ;

: exp1 ( c a b -- result )
\ a^2 + ab + c
over * -rot dup * + + ;

: exp2 ( a b -- result )
\ (a - b)/(a + b)
2dup - -rot + / ;

: convicted-of	0 ;
: arson			10 + ;
: homicide		20 + ;
: bookmaking	2 + ;
: tax-evasion	5 + ;
: will-serve	. ;
\ convicted-of arson homicide tax-evasion will-serve

: egg.cartons ( n --- n1 n2 ) 
\ n = no. of eggs expected to be laid today
\ n1 = how many cartons filled with dozen eggs
\ n2 = left over eggs
0 swap
begin
dup 12 >= while
	12 -
	swap 1+ swap
repeat
swap
CR ." number of cartons: " .
CR ." left over eggs: " .
;

: egg.cartons2 ( n --- n1 n2 )
12 /MOD
CR ." cartons: " .
CR ." left over eggs: " .
;

\ MARKER <name> will let you save the current system state
\ e.g. forget all the words defined & redefined after that point


\ Chapter 4.

\ < > for regular comparison
\ u< u> for unsigned comparison

: artichoke ( n -- )
\ TRUE if either 'n' is negative or multiple of 10
dup 0 < swap 10 mod 0= + dup . if
	." is artichoke!"
else ." not artichoke!" then
;

: card ( n -- )
21 >= if
	." ALCOHOLIC BEVERAGES PERMITTED"
else ." UNDER AGE" then
;

: sign.test ( n -- )
dup 0> if
	." POSITIVE" then
dup 0< if
	." NEGATIVE" then
dup 0= if 
	." ZERO" then
drop
;

: stars ( n -- )
begin
dup 0 > while
	1-
	space [char] * emit
repeat
;

: within ( n lo-limit hi-limit -- )
\ return TRUE only if 'n' is within lo-lomit and hi-limit
>r over r> <= >r >= r> + -2 = if
	." within!"
else 
	." out of bounds!"
then
;

\ word PAGE clears the terminal screen
: clear PAGE ;

: guess ( m n -- m )
\ n = guessing number
\ m = secret number
over 2dup > if
	." TOO HIGH" then
2dup < if
	." TOO LOW" then
= if
	." CORRECT!" then
;

: speller ( n -- )
\ spits out number within -4 to 4, inclusive
CR
dup 4 > over -4 < + if
	." out of range!"
	drop exit then
dup 0< if
	." negative" space
	-1 * then
dup 0= if
	." zero" then
dup 1 = if
	." one" then
dup 2 = if
	." two" then
dup 3 = if
	." three" then
dup 4 = if
	." four" then
drop
;

: trap { n g1 g2 -- n }
n g1 = n g2 = + -2 = if
	." YOU GOT IT!" exit then
n g1 g2 within n
;


\ Chapter 5

: exp3 ( a b c -- )
\ -ab/c => a b c / * -1 *
/ * -1 * ;

: fexp3 ( a b c -- )
\ -ab/c, using floating points
\ inputs needs to be on the floating point stack
f/ f* -1e f* ;

: max4 ( a b c d -- )
\ print the largest value
3 0 do
	2dup > if
		drop
	else
		nip then
loop
.
;

: F>C ( f -- )
\ Fahrenheit to Celsius
\ C = ( F - 32 ) / 1.8 =>
\ F 32e f- 1.8e f/
32e f- 1.8e f/ f. ;

\ Quickie Operators
\ 1+, 1-
\ 2*, 2/ (arithmetic left & right shift)
