include clock_digits.fs

: line ( number row -- )
over 0 = if 0d drop exit then
over 1 = if 1d drop exit then
over 2 = if 2d drop exit then
over 3 = if 3d drop exit then
over 4 = if 4d drop exit then
over 5 = if 5d drop exit then
over 6 = if 6d drop exit then
over 7 = if 7d drop exit then
over 8 = if 8d drop exit then
over 9 = if 9d drop exit then ;

: n0 ( number -- n0 )
begin dup 10 >= while 10 - repeat ;
: n1 ( number -- n1 )
10 / ;

: time
begin
page
6 0 do
	time&date
	cr
	2 i line
	0 i line
	2000 -
	dup n1 i line
	n0 i line
	i /d
	dup n1 i line
	n0 i line
	i /d
	dup n1 i line
	n0 i line
	drop drop drop
loop
6 0 do
	time&date
	drop drop drop
	cr
	_d
	dup n1 i line
	n0 i line
	i :d
	dup n1 i line
	n0 i line
	i :d
	dup n1 i line 
	n0 i line
	_d
loop
\ 7 emit
1000 ms
again ;
