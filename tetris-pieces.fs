create grid 252 cells allot

variable position
126 position !
variable orientation
0 orientation !

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
