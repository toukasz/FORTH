: time
	begin
	page
	time&date
	. . . . . .
	1000 ms
	again
;

: 0d ( row -- )
	dup 0 = if
." ..####.." . exit then
dup 1 = if
." .##..##." . exit then
dup 2 = if
." .######." . exit then
dup 3 = if
." .##..##." . exit then
dup 4 = if
." ..####.." . exit then
dup 5 = if
." ........" . exit then ;

: 1d ( row -- )
dup 0 = if
." ...##..." exit then
dup 1 = if
." ..###..." exit then
dup 2 = if
." ...##..." exit then
dup 3 = if
." ...##..." exit then
dup 4 = if
." .######." exit then
dup 5 = if
." ........" exit then ;
