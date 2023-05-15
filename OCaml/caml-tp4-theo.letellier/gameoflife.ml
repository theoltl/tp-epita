(*==============================================================================================================*)
(*Appel list_tools et ouverture graphique*)
#use "list_tools.ml";;

#load "graphics.cma" ;;
open Graphics ;;
let open_window size = open_graph (" " ^string_of_int size^"x"^string_of_int (size+20)) ;;
open_window 400;;

(*==============================================================================================================*)
(*Exercice 1 - Bo�te � outils*)

(*D�finitions*)

set_color;;
draw_rect;;
fill_rect;;

let board = [[1; 1; 1; 1; 1; 1; 1; 1; 1; 1];[0; 0; 0; 0; 0; 0; 0; 0; 0; 0];[1; 0; 1; 0; 1; 0; 1; 0; 1; 0];[0; 1; 0; 1; 0; 1; 0; 1; 0; 1];[0; 0; 0; 0; 0; 0; 0; 0; 0; 0];[1; 1; 1; 1; 1; 1; 1; 1; 1; 1];[0; 0; 0; 0; 0; 0; 0; 0; 0; 0];[1; 0; 1; 0; 1; 0; 1; 0; 1; 0];[0; 1; 0; 1; 0; 1; 0; 1; 0; 1];[0; 0; 0; 0; 0; 0; 0; 0; 0; 0]] ;;

let new_cell = 1 ;; (* alive cell *)
let empty = 0 ;;
let is_alive cell = cell <> empty ;;

let grey = rgb 127 127 127;;

(*==============================================================================================================*)
(*Exercice 1 - De la matrice � l'affichage*)

(*Draw_cell*)

let rec draw_cell (x,y) size color =
 set_color color;
  fill_rect (x)(y)(size)(size);
  set_color grey;
  draw_rect x y size size;;


(*--------------------------------------------------------------------------------------------------------*)
(*Draw_board*)

let draw_board board size =
   clear_graph();
  let rec rec_drawboard board size x y =
    match board with
      |[]->()
      |e::l -> let rec dessin y e =
               match e with
                 |a::b when a = 0 -> draw_cell (x,y) size white ; dessin (y+size) b
                 |a::b -> draw_cell (x,y) size black ; dessin (y+size) b;
                 |_ -> rec_drawboard l size (x+size) 100
               in dessin y e
  in rec_drawboard board size 100 100;;


(*==============================================================================================================*)
(*Exercice 2 - Le Jeu*)

(*Exercice 2 - Les r�gles*)

(*rules0*)

let rules0 cell near =
  if cell>1 || cell <0 then invalid_arg "cell doit �tre compris entre 0 et 1"
    else
  match cell with
    |cell when cell = 0 && near = 3 -> 1
    |cell when cell = 1 && (near = 2 || near = 3) -> 1
    |_ -> 0;;

(*--------------------------------------------------------------------------------------------------------*)

(*Count_neighbours*)

let count_neighbours (x,y) board size = 
  let compteur (x,y) =
    if x >= 0 && y >= 0 && x < size && y < size then
      if is_alive (get_cell (x,y) board) = true then 1
      else 0	
    else
      0
  in
  compteur (x+1,y+1) + compteur (x+1,y) + compteur  (x+1,y-1) +  compteur (x,y+1) +  compteur (x,y-1) + compteur (x-1,y+1) + compteur (x-1,y) + compteur (x-1,y-1);;

(*==============================================================================================================*)
(*Exercice 2 - La vie*)

(*seed_life*)

let rec seed_life board size nb_cell =
  match nb_cell with
    | 0 -> board
    | _ -> let (x,y) = (Random.int(size),Random.int(size)) in if (get_cell (x,y) board) = 0 then 
	seed_life (put_cell 1 (x,y) board) size (nb_cell-1)
      else seed_life board size nb_cell;;

(*--------------------------------------------------------------------------------------------------------*)

(*new_board*)

let new_board size nb_cell =
  seed_life (init_board (size,size) 0) size nb_cell;;
  
(*--------------------------------------------------------------------------------------------------------*)

(*next_generations*)


let next_generation board size =
  let rec rec_generation board size b x y =
    match y with
      | y when y = size -> board
      | _ ->  if x = size then rec_generation (board) size (b) (0) (y+1)
	else rec_generation (put_cell (rules0 (get_cell (x,y) board)(count_neighbours (x,y) b size)) (x,y) board) size b (x+1) y	     
   in rec_generation board size board 0 0;;

(*--------------------------------------------------------------------------------------------------------*)

(*game*)

let rec game board size n =
  let cell_size = 10 in
  match n with
    |0 -> draw_board board cell_size
    |_ -> game (next_generation board size) size (n-1);;
      

(*--------------------------------------------------------------------------------------------------------*)

(*new_game*)

let new_game size nb_cell n =
  game (new_board size nb_cell) size n;;


