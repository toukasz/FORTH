include random.fs

: time ( -- secound ) time&date drop drop drop drop drop ;
: random-burn time 1+ 0 do rnd drop loop ; random-burn
: random-piece ( -- rnd ) rnd 61 rshift dup 0= if drop recurse exit then 1- ;

create grid 252 cells allot
variable position 126 position !
variable orientation 0 orientation !
variable piece-type random-piece piece-type !
variable container true container !
variable carry-count 0 carry-count !
create pieces-container 14 cells allot
variable pieces-index 0 pieces-index !

\ PRINT
: I-piece ( char -- )
orientation @ 0= if
	dup grid position @ cells + !
	dup grid position @ 1- cells + !
	dup grid position @ 1+ cells + !
	grid position @ 2 + cells + !
	exit then
orientation @ 1 = if
	dup grid position @ cells + !
	dup grid position @ 12 - cells + !
	dup grid position @ 12 + cells + !
	grid position @ 24 + cells + !
	exit then
orientation @ 2 = if
	dup grid position @ cells + !
	dup grid position @ 1+ cells + !
	dup grid position @ 1- cells + !
	grid position @ 2 - cells + !
	exit then
orientation @ 3 = if
	dup grid position @ cells + !
	dup grid position @ 12 + cells + !
	dup grid position @ 12 - cells + !
	grid position @ 24 - cells + !
	exit then ;

: J-piece ( char -- )
orientation @ 0= if
	dup grid position @ cells + !
	dup grid position @ 1+ cells + !
	dup grid position @ 1- cells + !
	grid position @ 13 - cells + !
	exit then
orientation @ 1 = if
	dup grid position @ cells + !
	dup grid position @ 12 + cells + !
	dup grid position @ 12 - cells + !
	grid position @ 11 - cells + !
	exit then
orientation @ 2 = if
	dup grid position @ cells + !
	dup grid position @ 1- cells + !
	dup grid position @ 1+ cells + !
	grid position @ 13 + cells + !
	exit then
orientation @ 3 = if
	dup grid position @ cells + !
	dup grid position @ 12 - cells + !
	dup grid position @ 12 + cells + !
	grid position @ 11 + cells + !
	exit then ;

: L-piece ( char -- )
orientation @ 0= if
	dup grid position @ cells + !
	dup grid position @ 1- cells + !
	dup grid position @ 1+ cells + !
	grid position @ 11 - cells + !
	exit then
orientation @ 1 = if
	dup grid position @ cells + !
	dup grid position @ 12 - cells + !
	dup grid position @ 12 + cells + !
	grid position @ 13 + cells + !
	exit then
orientation @ 2 = if
	dup grid position @ cells + !
	dup grid position @ 1+ cells + !
	dup grid position @ 1- cells + !
	grid position @ 11 + cells + !
	exit then
orientation @ 3 = if
	dup grid position @ cells + !
	dup grid position @ 12 + cells + !
	dup grid position @ 12 - cells + !
	grid position @ 13 - cells + !
	exit then ;

: O-piece ( char -- )
orientation @ 0= if
	dup grid position @ cells + !
	dup grid position @ 1+ cells + !
	dup grid position @ 12 - cells + !
	grid position @ 11 - cells + !
	exit then
orientation @ 1 = if
	dup grid position @ cells + !
	dup grid position @ 1 + cells + !
	dup grid position @ 12 + cells + !
	grid position @ 13 + cells + !
	exit then
orientation @ 2 = if
	dup grid position @ cells + !
	dup grid position @ 1- cells + !
	dup grid position @ 12 + cells + !
	grid position @ 11 + cells + !
	exit then
orientation @ 3 = if
	dup grid position @ cells + !
	dup grid position @ 1 - cells + !
	dup grid position @ 12 - cells + !
	grid position @ 13 - cells + !
	exit then ;

: S-piece ( char -- )
orientation @ 0= if
	dup grid position @ cells + !
	dup grid position @ 1- cells + !
	dup grid position @ 12 - cells + !
	grid position @ 11 - cells + !
	exit then
orientation @ 1 = if
	dup grid position @ cells + !
	dup grid position @ 12 - cells + !
	dup grid position @ 1+ cells + !
	grid position @ 13 + cells + !
	exit then
orientation @ 2 = if
	dup grid position @ cells + !
	dup grid position @ 1+ cells + !
	dup grid position @ 12 + cells + !
	grid position @ 11 + cells + !
	exit then
orientation @ 3 = if
	dup grid position @ cells + !
	dup grid position @ 12 + cells + !
	dup grid position @ 1- cells + !
	grid position @ 13 - cells + !
	exit then ;

: T-piece ( char -- )
orientation @ 0= if
	dup grid position @ cells + !
	dup grid position @ 1+ cells + !
	dup grid position @ 1- cells + !
	grid position @ 12 - cells + !
	exit then
orientation @ 1 = if
	dup grid position @ cells + !
	dup grid position @ 12 - cells + !
	dup grid position @ 12 + cells + !
	grid position @ 1+ cells + !
	exit then
orientation @ 2 = if
	dup grid position @ cells + !
	dup grid position @ 1+ cells + !
	dup grid position @ 1- cells + !
	grid position @ 12 + cells + !
	exit then
orientation @ 3 = if
	dup grid position @ cells + !
	dup grid position @ 12 + cells + !
	dup grid position @ 12 - cells + !
	grid position @ 1- cells + !
	exit then ;

: Z-piece ( char -- )
orientation @ 0= if
	dup grid position @ cells + !
	dup grid position @ 1+ cells + !
	dup grid position @ 12 - cells + !
	grid position @ 13 - cells + !
	exit then
orientation @ 1 = if
	dup grid position @ cells + !
	dup grid position @ 12 + cells + !
	dup grid position @ 1+ cells + !
	grid position @ 11 - cells + !
	exit then
orientation @ 2 = if
	dup grid position @ cells + !
	dup grid position @ 1- cells + !
	dup grid position @ 12 + cells + !
	grid position @ 13 + cells + !
	exit then
orientation @ 3 = if
	dup grid position @ cells + !
	dup grid position @ 12 - cells + !
	dup grid position @ 1- cells + !
	grid position @ 11 + cells + !
	exit then ;

\ COLLISION DETECTION
: I-collision ( position orientation -- collision )
dup 0= if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 1- cells + @ [char] . <> if drop true exit then
	grid over 1+ cells + @ [char] . <> if drop true exit then
	grid over 2 + cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 1 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 12 - cells + @ [char] . <> if drop true exit then
	grid over 12 + cells + @ [char] . <> if drop true exit then
	grid over 24 + cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 2 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 1+ cells + @ [char] . <> if drop true exit then
	grid over 1- cells + @ [char] . <> if drop true exit then
	grid over 2 - cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 3 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 12 + cells + @ [char] . <> if drop true exit then
	grid over 12 - cells + @ [char] . <> if drop true exit then
	grid over 24 - cells + @ [char] . <> if drop true exit then
	drop false exit then ;

: J-collision ( position orientation -- collision )
dup 0= if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 1+ cells + @ [char] . <> if drop true exit then
	grid over 1- cells + @ [char] . <> if drop true exit then
	grid over 13 - cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 1 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 12 + cells + @ [char] . <> if drop true exit then
	grid over 12 - cells + @ [char] . <> if drop true exit then
	grid over 11 - cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 2 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 1- cells + @ [char] . <> if drop true exit then
	grid over 1+ cells + @ [char] . <> if drop true exit then
	grid over 13 + cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 3 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 12 - cells + @ [char] . <> if drop true exit then
	grid over 12 + cells + @ [char] . <> if drop true exit then
	grid over 11 + cells + @ [char] . <> if drop true exit then
	drop false exit then ;

: L-collision ( position orientation -- collision )
dup 0= if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 1- cells + @ [char] . <> if drop true exit then
	grid over 1+ cells + @ [char] . <> if drop true exit then
	grid over 11 - cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 1 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 12 - cells + @ [char] . <> if drop true exit then
	grid over 12 + cells + @ [char] . <> if drop true exit then
	grid over 13 + cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 2 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 1+ cells + @ [char] . <> if drop true exit then
	grid over 1- cells + @ [char] . <> if drop true exit then
	grid over 11 + cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 3 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 12 + cells + @ [char] . <> if drop true exit then
	grid over 12 - cells + @ [char] . <> if drop true exit then
	grid over 13 - cells + @ [char] . <> if drop true exit then
	drop false exit then ;

: O-collision ( position orientation -- collision )
dup 0= if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 1+ cells + @ [char] . <> if drop true exit then
	grid over 12 - cells + @ [char] . <> if drop true exit then
	grid over 11 - cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 1 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 1 + cells + @ [char] . <> if drop true exit then
	grid over 12 + cells + @ [char] . <> if drop true exit then
	grid over 13 + cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 2 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 1- cells + @ [char] . <> if drop true exit then
	grid over 12 + cells + @ [char] . <> if drop true exit then
	grid over 11 + cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 3 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 1 - cells + @ [char] . <> if drop true exit then
	grid over 12 - cells + @ [char] . <> if drop true exit then
	grid over 13 - cells + @ [char] . <> if drop true exit then
	drop false exit then ;

: S-collision ( position orientation -- collision )
dup 0= if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 1- cells + @ [char] . <> if drop true exit then
	grid over 12 - cells + @ [char] . <> if drop true exit then
	grid over 11 - cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 1 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 12 - cells + @ [char] . <> if drop true exit then
	grid over 1+ cells + @ [char] . <> if drop true exit then
	grid over 13 + cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 2 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 1+ cells + @ [char] . <> if drop true exit then
	grid over 12 + cells + @ [char] . <> if drop true exit then
	grid over 11 + cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 3 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 12 + cells + @ [char] . <> if drop true exit then
	grid over 1- cells + @ [char] . <> if drop true exit then
	grid over 13 - cells + @ [char] . <> if drop true exit then
	drop false exit then ;

: T-collision ( position orientation -- collision )
dup 0= if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 1+ cells + @ [char] . <> if drop true exit then
	grid over 1- cells + @ [char] . <> if drop true exit then
	grid over 12 - cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 1 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 12 - cells + @ [char] . <> if drop true exit then
	grid over 12 + cells + @ [char] . <> if drop true exit then
	grid over 1+ cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 2 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 1+ cells + @ [char] . <> if drop true exit then
	grid over 1- cells + @ [char] . <> if drop true exit then
	grid over 12 + cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 3 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 12 + cells + @ [char] . <> if drop true exit then
	grid over 12 - cells + @ [char] . <> if drop true exit then
	grid over 1- cells + @ [char] . <> if drop true exit then
	drop false exit then ;

: Z-collision ( position orientation -- collision )
dup 0= if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 1+ cells + @ [char] . <> if drop true exit then
	grid over 12 - cells + @ [char] . <> if drop true exit then
	grid over 13 - cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 1 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 12 + cells + @ [char] . <> if drop true exit then
	grid over 1+ cells + @ [char] . <> if drop true exit then
	grid over 11 - cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 2 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 1- cells + @ [char] . <> if drop true exit then
	grid over 12 + cells + @ [char] . <> if drop true exit then
	grid over 13 + cells + @ [char] . <> if drop true exit then
	drop false exit then
dup 3 = if
	drop
	grid over cells + @ [char] . <> if drop true exit then
	grid over 12 - cells + @ [char] . <> if drop true exit then
	grid over 1- cells + @ [char] . <> if drop true exit then
	grid over 11 + cells + @ [char] . <> if drop true exit then
	drop false exit then ;
