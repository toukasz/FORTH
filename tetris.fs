include tetris-pieces.fs
include random.fs

: grid_blank
252 0 do
	i 12 + 12 mod 0= 
	i 1+ 12 mod 0= +
	i 240 >= +
	if [char] @ grid i cells + !
	else [char] . grid i cells + ! then
loop ;
grid_blank

: display-integer
252 0 do
	i 12 mod 0= if cr then
	grid i cells + ?
loop ;

: display-char
252 0 do
	i 12 mod 0= if cr then
	space grid i cells + @ emit
loop ;

variable ?piece
0 ?piece !

: print-piece ( char ?piece -- )
dup 0= if drop I-piece exit then
dup 1 = if drop J-piece exit then
dup 2 = if drop L-piece exit then
dup 3 = if drop O-piece exit then
dup 4 = if drop S-piece exit then
dup 5 = if drop T-piece exit then
dup 6 = if drop Z-piece exit then ;

: collision ( ?piece -- )
dup 0= if drop I-collision exit then
dup 1 = if drop J-collision exit then
dup 2 = if drop L-collision exit then
dup 3 = if drop O-collision exit then
dup 4 = if drop S-collision exit then
dup 5 = if drop T-collision exit then
dup 6 = if drop Z-collision exit then ;

: random-7 ( -- rnd ) rnd abs 60 rshift dup 7 = if drop recurse then ;
: next-piece random-7 ?piece ! ;

: clear-line ( index -- )
10 0 do \ clear row
	[char] . over i + cells grid + !
loop
-1 swap 1- -do \ push block stack down
	grid i cells + @ grid i cells + 12 cells + !
1 -loop ;

: check-line
0 240 0 do \ reset counter for each row
	i 12 mod 0= if drop 0 then
	grid i cells + @ [char] # = if 1+ then
	dup 10 = if i 9 - clear-line drop 0 then
loop drop ;

variable container
true container !
variable carry-count
0 carry-count !

: carry
carry-count @ 2 = if exit then
carry-count @ 1+ carry-count !
container @ true = if
	?piece @ container ! random-7 ?piece !
else ?piece @ container @ ?piece ! container ! then
6 position ! ;

: up
position @ 12 - position ! ;
: down
position @ 12 + orientation @ ?piece @ collision if
	[char] # ?piece @ print-piece
	6 position ! next-piece check-line
	0 carry-count ! exit
else position @ 12 + position ! then ;
: left
position @ 1- orientation @ ?piece @ collision if exit
else position @ 1- position ! then ;
: right
position @ 1+ orientation @ ?piece @ collision if exit
else position @ 1+ position ! then ;

: orientation++ ( orientation -- orientation++ )
dup 3 = if drop 0 else 1+ then ;
: orientation-- ( orientation -- orientation-- )
dup 0 = if drop 3 else 1- then ;

: +rotate
position @ orientation @ orientation++ ?piece @ collision if exit
else orientation @ orientation++ orientation ! then ;
: -rotate
position @ orientation @ orientation-- ?piece @ collision if exit
else orientation @ orientation-- orientation ! then ;

: log-key ( -- key )
key? if key else false then ;

: check-key ( key -- )
dup [char] u = if up drop exit then
dup [char] e = if down drop exit then
dup [char] n = if left drop exit then
dup [char] i = if right drop exit then
dup [char] t = if +rotate drop exit then
dup [char] s = if -rotate drop exit then
dup [char] a = if carry drop exit then
drop ;

: timed
begin
	[char] # ?piece @ print-piece
	page display-char
	[char] . ?piece @ print-piece
	log-key check-key
	cr .s container ?
	20 ms
again ;
