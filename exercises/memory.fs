10 constant limit
create array limit cells allot

: !array
limit 0 do
	i array i cells + !
loop ;

: ?array
limit 0 do
	array i cells + ?
loop CR ;

!array
?array

: total
0
limit 0 do
	i + dup array i cells + !
loop
drop ;

total
?array
