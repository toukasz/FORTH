include tetris-pieces.fs

: l-wall ( i -- ? ) 12 + 12 mod 0= ;
: r-wall ( i -- ? ) 1+ 12 mod 0= ;
: ground ( i -- ? ) 240 >= ;

: borders ( i -- ? )
dup l-wall swap dup r-wall swap ground + + ;

: @grid! ( i -- ) [char] @ swap cells grid + ! ;
: .grid! ( i -- ) [char] . swap cells grid + ! ;

: grid-setup ( -- )
252 0 do i borders if
	i @grid! else i .grid! then
loop ; grid-setup

: display-integer ( -- )
252 0 do
	i 12 mod 0= if cr then
	grid i cells + ?
loop ;

: display-char ( -- )
252 0 do
	i 12 mod 0= if cr then
	space grid i cells + @ emit
loop ;

: print-piece ( char piece-type -- )
dup 0 = if drop I-piece exit then
dup 1 = if drop J-piece exit then
dup 2 = if drop L-piece exit then
dup 3 = if drop O-piece exit then
dup 4 = if drop S-piece exit then
dup 5 = if drop T-piece exit then
dup 6 = if drop Z-piece exit then ;

: collision ( piece-type -- )
dup 0 = if drop I-collision exit then
dup 1 = if drop J-collision exit then
dup 2 = if drop L-collision exit then
dup 3 = if drop O-collision exit then
dup 4 = if drop S-collision exit then
dup 5 = if drop T-collision exit then
dup 6 = if drop Z-collision exit then ;

: random-2 ( -- rnd ) rnd 63 rshift ;
: random-32 ( -- rnd ) rnd 60 rshift ;
: rot7 ( n0 n1 n2 n3 n4 n5 n6 -- n1 n2 n3 n4 n5 n6 n0 )
>r >r >r >r >r swap r> swap r> swap r> swap r> swap r> swap ;
: fill-bag ( -- n0 n1 n2 n3 n4 n5 n6 n7 ) 
7 0 do i 0= if i else random-2 0= if i swap else i then then loop ;
: mixed-bag ( -- n? n? n? n? n? n? n? )
fill-bag random-32 1+ 0 do rot7 2swap loop ;
: populate ( index -- )
>r mixed-bag r> 7 *
7 0 do
	2dup i + cells pieces-container + ! nip
loop drop ;
0 populate 1 populate

: next-piece
pieces-index @ 6 = if 0 populate then
pieces-index @ 13 = if 1 populate then
pieces-index @ dup 1+ 14 = if drop 0 else 1+ then
dup cells pieces-container + @ piece-type !
pieces-index ! ;

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

: carry
carry-count @ 2 = if exit then
carry-count @ 1+ carry-count !
container @ true = if
	piece-type @ container ! random-piece piece-type !
else piece-type @ container @ piece-type ! container ! then
6 position ! ;

: up
position @ 12 - position ! ;
: down
position @ 12 + orientation @ piece-type @ collision if
	[char] # piece-type @ print-piece
	6 position ! next-piece check-line
	0 carry-count ! exit
else position @ 12 + position ! then ;
: left
position @ 1- orientation @ piece-type @ collision if exit
else position @ 1- position ! then ;
: right
position @ 1+ orientation @ piece-type @ collision if exit
else position @ 1+ position ! then ;

: orientation++ ( orientation -- orientation++ )
dup 3 = if drop 0 else 1+ then ;
: orientation-- ( orientation -- orientation-- )
dup 0 = if drop 3 else 1- then ;

: +rotate
position @ orientation @ orientation++ piece-type @ collision if exit
else orientation @ orientation++ orientation ! then ;
: -rotate
position @ orientation @ orientation-- piece-type @ collision if exit
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
	[char] # piece-type @ print-piece
	page display-char
	[char] . piece-type @ print-piece
	log-key check-key
	cr .s container ?
	cr pieces-container 14 cells dump
	cr pieces-index ?
	20 ms
again ;
