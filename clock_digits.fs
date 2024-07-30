: 0d ( row -- )
	dup 0 = if
." ..####.." drop exit then
dup 1 = if
." .##..##." drop exit then
dup 2 = if
." .######." drop exit then
dup 3 = if
." .##..##." drop exit then
dup 4 = if
." ..####.." drop exit then
dup 5 = if
." ........" drop exit then ;

: 1d ( row -- )
dup 0 = if
." ...##..." drop exit then
dup 1 = if
." ..###..." drop exit then
dup 2 = if
." ...##..." drop exit then
dup 3 = if
." ...##..." drop exit then
dup 4 = if
." .######." drop exit then
dup 5 = if
." ........" drop exit then ;

: 2d ( row -- )
dup 0 = if
." ..####.." drop exit then
dup 1 = if
." .....##." drop exit then
dup 2 = if
." ..####.." drop exit then
dup 3 = if
." .##....." drop exit then
dup 4 = if
." .######." drop exit then
dup 5 = if
." ........" drop exit then ;

: 3d ( row -- )
dup 0 = if
." .######." drop exit then
dup 1 = if
." ....##.." drop exit then
dup 2 = if
." ...###.." drop exit then
dup 3 = if
." .....##." drop exit then
dup 4 = if
." .#####.." drop exit then
dup 5 = if
." ........" drop exit then ;

: 4d ( row -- )
dup 0 = if
." .....##." drop exit then
dup 1 = if
." .##..##." drop exit then
dup 2 = if
." .######." drop exit then
dup 3 = if
." .....##." drop exit then
dup 4 = if
." .....##." drop exit then
dup 5 = if
." ........" drop exit then ;

: 5d ( row -- )
dup 0 = if
." .######." drop exit then
dup 1 = if
." .##....." drop exit then
dup 2 = if
." ..####.." drop exit then
dup 3 = if
." .....##." drop exit then
dup 4 = if
." .#####.." drop exit then
dup 5 = if
." ........" drop exit then ;

: 6d ( row -- )
dup 0 = if
." ...##..." drop exit then
dup 1 = if
." ..##...." drop exit then
dup 2 = if
." .#####.." drop exit then
dup 3 = if
." .##..##." drop exit then
dup 4 = if
." ..####.." drop exit then
dup 5 = if
." ........" drop exit then ;

: 7d ( row -- )
dup 0 = if
." .######." drop exit then
dup 1 = if
." ....##.." drop exit then
dup 2 = if
." ...##..." drop exit then
dup 3 = if
." ..##...." drop exit then
dup 4 = if
." .##....." drop exit then
dup 5 = if
." ........" drop exit then ;

: 8d ( row -- )
dup 0 = if
." ..####.." drop exit then
dup 1 = if
." .##..##." drop exit then
dup 2 = if
." ..####.." drop exit then
dup 3 = if
." .##..##." drop exit then
dup 4 = if
." ..####.." drop exit then
dup 5 = if
." ........" drop exit then ;

: 9d ( row -- )
dup 0 = if
." ..####.." drop exit then
dup 1 = if
." .##..##." drop exit then
dup 2 = if
." ..####.." drop exit then
dup 3 = if
." ...##..." drop exit then
dup 4 = if
." ..##...." drop exit then
dup 5 = if
." ........" drop exit then ;

: :d ( row -- )
dup 0 = if
." ........" drop exit then
dup 1 = if
." ...##..." drop exit then
dup 2 = if
." ........" drop exit then
dup 3 = if
." ...##..." drop exit then
dup 4 = if
." ........" drop exit then
dup 5 = if
." ........" drop exit then ;

: /d ( row -- )
dup 0 = if
." .....##." drop exit then
dup 1 = if
." ....##.." drop exit then
dup 2 = if
." ...##..." drop exit then
dup 3 = if
." ..##...." drop exit then
dup 4 = if
." .##....." drop exit then
dup 5 = if
." ........" drop exit then ;

: _d ( -- )
." ........" ;
