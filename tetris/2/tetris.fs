include tetris-pieces.fs
include random.fs

: time ( -- second ) time&date drop drop drop drop drop ;
: random-burn time 1+ 0 do rnd drop loop ; random-burn
: random-piece ( -- rnd ) rnd 61 rshift dup 0= if drop recurse exit then 1- ;
\ random-piece ( -- rnd ) rnd 29 rshift dup 0= if drop recurse exit then 1- ;

variable present-piece random-piece present-piece !

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

: print-piece ( char present-piece -- )
dup 0 = if drop I-piece exit then
dup 1 = if drop J-piece exit then
dup 2 = if drop L-piece exit then
dup 3 = if drop O-piece exit then
dup 4 = if drop S-piece exit then
dup 5 = if drop T-piece exit then
dup 6 = if drop Z-piece exit then ;

: collision ( present-piece -- )
dup 0 = if drop I-collision exit then
dup 1 = if drop J-collision exit then
dup 2 = if drop L-collision exit then
dup 3 = if drop O-collision exit then
dup 4 = if drop S-collision exit then
dup 5 = if drop T-collision exit then
dup 6 = if drop Z-collision exit then ;

\ for 64-bit systems
: random-2 ( -- rnd ) rnd 63 rshift ;
: random-32 ( -- rnd ) rnd 60 rshift ;

\ for 32-bit systems
\ : random-2 ( -- rnd ) rnd 31 rshift ;
\ : random-32 ( -- rnd ) rnd 28 rshift ;

: rot7 ( n0 n1 n2 n3 n4 n5 n6 -- n1 n2 n3 n4 n5 n6 n0 )
>r >r >r >r >r swap r> swap r> swap r> swap r> swap r> swap ;

: fill-bag ( -- n? n? n? n? n? n? n? )
0 7 1 do
	random-2 0= if i swap
	else i then
loop ;

: mixed-bag ( -- n? n? n? n? n? n? n? )
fill-bag random-32 1+ 0 do rot7 2swap loop ;

create pieces-container 14 cells allot

: insert-to-bag ( piece index i -- index )
>r 2dup r> + cells pieces-container + ! nip ;

: refill-bag ( index -- )
>r mixed-bag r> 7 *
7 0 do i insert-to-bag loop drop ;
0 refill-bag 1 refill-bag

: modulo14++ ( index -- index++)
dup 13 = if drop 0 else 1+ then ;

variable bag-index 0 bag-index !

: locate-in-container ( bag-index -- addr )
cells pieces-container + @ ;

: next-piece ( -- )
bag-index @ 6 = if 0 refill-bag then
bag-index @ 13 = if 1 refill-bag then
bag-index @ modulo14++ bag-index !
bag-index @ locate-in-container present-piece ! ;

\ redundant ( : clear-row 10 0 do [char] . over i + cells grid + ! loop drop ; )

: clear-line ( grid-index -- )
-1 swap 1- -do
	grid i cells + @ grid i cells + 12 cells + !
1 -loop ;

: check-line
0 240 0 do \ reset counter for each row
	i 12 mod 0= if drop 0 then
	grid i cells + @ [char] # = if 1+ then
	dup 10 = if i 9 - clear-line drop 0 then
loop drop ;

: reset-position ( -- ) 6 position ! ;
: reset-orientation ( -- ) 0 orientation ! ;

variable carry-count 0 carry-count !

variable holder true holder !

: carry ( -- )
carry-count @ 2 = if exit then
carry-count @ 1+ carry-count !
holder @ true = if present-piece @ holder ! next-piece
else present-piece @ holder @ present-piece ! holder ! then
reset-position reset-orientation ;

: reset-carry-count ( -- ) 0 carry-count ! ;

: check-collision ( position -- ? )
orientation @ present-piece @ collision ;

: up ( -- )
position @ begin
	dup 12 + check-collision if false
	else true then while 12 +
repeat
position ! ;

: print-present-piece ( -- )
[char] # present-piece @ print-piece ;

: down ( -- )
position @ 12 + check-collision if
	print-present-piece check-line next-piece
	reset-position reset-orientation reset-carry-count
else position @ 12 + position ! then ;

: left ( -- )
position @ 1- check-collision if exit
else position @ 1- position ! then ;

: right ( -- )
position @ 1+ check-collision if exit
else position @ 1+ position ! then ;

: orientation++ ( orientation -- orientation++ )
dup 3 = if drop 0 else 1+ then ;

: orientation-- ( orientation -- orientation-- )
dup 0 = if drop 3 else 1- then ;

: check-collision-rotation ( orientation -- ? )
position @ swap present-piece @ collision ;

: +rotate ( -- )
orientation @ orientation++ check-collision-rotation if exit
else orientation @ orientation++ orientation ! then ;

: -rotate ( -- )
orientation @ orientation-- check-collision-rotation if exit
else orientation @ orientation-- orientation ! then ;

: log-key ( -- key )
key? if key else false then ;

: check-key ( key -- )
dup [char] u = if up		drop exit then
dup [char] e = if down		drop exit then
dup [char] n = if left		drop exit then
dup [char] i = if right		drop exit then
dup [char] t = if +rotate	drop exit then
dup [char] s = if -rotate	drop exit then
dup [char] a = if carry		drop exit then
drop ;

: timed
begin
	[char] # present-piece @ print-piece
	page display-char
	[char] . present-piece @ print-piece
	log-key check-key
	cr .s
	cr pieces-container 14 cells dump
	cr bag-index ?
	20 ms
again ;
