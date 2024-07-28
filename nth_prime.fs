10000 constant limit
variable length 2 length !
create primes limit cells allot
\ limit set to 10,000th prime
2 primes !
3 primes cell+ !

: ?prime ( n -- n++ )
\ IF prime push to array
\ ELSE do nothing
length @ 0 do
	dup primes i cells + @ mod 0= if
		1+ unloop exit then
loop
dup primes length @ cells + !	\ push 'n' to end of array
length @ 1+ length !			\ length++
1+ ;							\ n++

: nth_prime ( i -- )
\ IF > 10000 do nothing
\ IF < length read from primes arrayy
\ ELSE calculate nth prime
dup limit > if
	exit then
dup length @ < if
	primes swap 1- cells + @ .
	\ output nth prime
	exit then
primes length @ 1- cells + @ 1+
\ initialize from largest known prime + 1
begin
over length @ > while
	?prime
repeat
drop primes swap 1- cells + @ . ;
\ output nth prime
