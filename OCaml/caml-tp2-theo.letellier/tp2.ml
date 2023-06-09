(*Must Do*)

(*1.1.1 - Build me a line*)


let rec build_line n str =
  match n with
      0 -> "";
    |_ -> str ^ (build_line (n-1) str);;


(*1.1.2 - Draw  me a square*)

let rec square n str  = let rec compteur n str c =
 if n <= c then
   print_string ""
 else
   begin
     print_string (build_line n str);
     print_newline ();
     compteur n str (c+1)
   end
                        in compteur n str  0;;


square 5 "*";;


(*1.1.3 - Draw  me a square - bis*)

let rec build_line2 n (str1,str2) =
  if n < 0 then invalid_arg "n doit etre positif"
  else match n with
      0 -> ""
    |_ ->str1^str2 ^ (build_line2 (n-1) (str1,str2));;

let rec build_line3 n (str1,str2) =
  if n < 0 then invalid_arg "n doit etre positif"
  else match n with
      0 -> ""
    |_ ->str2^str1 ^ (build_line3 (n-1) (str1,str2));;


let rec square2  n (str1,str2) = let rec compteur2 n (str1,str2) c =
 if n = 0 then
   print_string ""
 else
     if n mod 2 = 0 then
     begin
     print_string (build_line2  c (str1,str2));
   print_newline ();
   compteur2(n-1) (str1,str2) c;
           end
     else
       begin
         print_string (build_line3 c (str1,str2));
         print_newline ();
         compteur2 (n-1) (str1,str2) c;
       end
                                 in compteur2 n (str1,str2) n ;;



square2 10 ("*",".");;


(*1.1.4 - Draw  me a triangle*)

let rec triangle n str  = let rec tri n str c =
   if n<c then
     print_string""
   else
     begin
       print_string (build_line c str);
       print_newline();
       tri  n str (c+1);
     end
 in tri n str 0;;

triangle 5 "*";;

(*1.2.1 - Draw me a pyramid*)

let rec pyramid  n (str1, str2)  = let rec pyra n str1 str2 z =
   if n=0 then
     print_string""
   else
     begin
       print_string (build_line (n-1) str1);
       print_string (build_line (z+2) str2);
        print_string (build_line (n-1) str1);
       print_newline();
       pyra (n-1) str1 str2 (z+2)
     end
                                   in pyra n str1 str2  0;;


pyramid 8 ("*",".");;

 (*1.2.2 - Draw me a cross*)

 let cross n(str1,str2) =
  let rec croix a b c =
    if b >= 1 then
      match b with
  b when b = n -> ()
|b -> print_string (build_line (n-b-1) str1);print_string(str2);
  print_string(build_line c str1);print_string(str2);
  print_endline(build_line(n-b-1) str1);(croix a (b+1) (c+2))
    else
      match a with
  a when a = n -> print_string(build_line(n-1)str1);print_string(str2);
    print_endline(build_line(n-1)str1);(croix a 1 1)
|u -> print_string(build_line(a-1)str1);print_string(str2);
  print_string(build_line c str1);print_string(str2);
  print_endline(build_line (a-1)str1);(croix (u+1) 0 (c-2))
  in croix 1 0 (2*n-3);;

 cross 5(" ","O");;



(*FRACTALES*)

(*2.1 Les courbes*)

#load "graphics.cma" ;; (* Charge la bibliotheque *)
open Graphics ;; (* Ouvre le module  *)
open_graph "";; (* Genere une fenetre *)
open_graph " 100x300";; (* 300 largeur et  100 hauteur fenetre *) ;;


(*Mountain*)

let draw_line (x, y) (z, t) =
moveto x y ;
  lineto z t ;;

let draw_line1 (x, y) (z, t) =
set_color blue;moveto x y ;set_color blue; lineto z t ;;

let draw_line2 (x, y) (z, t) = set_color red; moveto x y ;set_color red;lineto z t;;



let rec mountain  n (x,y)(z,t) =
  let milieu = (x+z)/2 in
  let hauteur = (y+t)/2 + Random.int (abs(z-x)/5+20) in
  match n with
      0 -> set_color black;draw_line (x,y) (z,t)
    |n -> mountain (n-1)(milieu,hauteur)(z,t);
      mountain (n-1)(x,y)(milieu,hauteur);;

mountain  5 (30,40)(190,30);;


(*Dragon*)

clear_graph () ;;

let rec dragon n (x,y)(z,t)=
  let u = (x+z)/2+(t-y)/2 in
  let v = (y+t)/2 - (z-x)/2 in
  match n with
      0 -> set_color black;draw_line (x,y)(z,t)
    |n -> dragon(n-1)(x,y)(u,v);
      dragon (n-1)(z,t)(u,v);;

dragon 19 (150 ,150) (350 ,350);;


(*Tentative dragon bonus (changement de couleur)*)


clear_graph () ;;


let rec dragon n (x,y)(z,t)=
  let u = (x+z)/2+(t-y)/2 in
  let v = (y+t)/2 - (z-x)/2 in
  if n  mod 2 = 0 then
    match n with
        0 -> draw_line1 (x,y)(z,t);
      |n -> dragon(n-1)(x,y)(u,v);
        dragon (n-1)(z,t)(u,v)
  else
    match n with
        0 -> draw_line2 (x,y)(z,t);
      |n -> dragon(n-1)(x,y)(u,v);
        dragon (n-1)(z,t)(u,v);;


dragon 19 (150 ,150) (350,350);;

(*Eponge*)

let sponge x y n =
  clear_graph();
  set_color black;
  fill_rect x y n n;
  set_color white;
  let rec spongee x y n i =
    fill_rect(x+n/3)(y+n/3)(n/3)(n/3);
      match i with
  0 -> ()
|_ -> begin
          spongee x y (n/3)(i-1);
  spongee (x+n/3)y(n/3)(i-1);
  spongee (x+2*n/3)y(n/3)(i-1);
  spongee x(y+n/3)(n/3)(i-1);
  spongee x(y+2*n/3)(n/3)(i-1);
  spongee (x+n/3)(y+n/3)(n/3)(i-1);
  spongee (x+n/3)(y+2*n/3)(n/3)(i-1);
  spongee (x+2*n/3)(y+n/3)(n/3)(i-1);
  spongee (x+2*n/3)(y+2*n/3)(n/3)(i-1);
end;
    in
  spongee x y n 4;;

sponge 10 10 243 ;;

(*Bonus personnel : Eponge avec changement de couleur*)

let remplissage w  =  match w  with
  |0-> set_color black
  |1-> set_color white;
  |2-> set_color red;
  |3-> set_color blue;
  |4-> set_color green;
  |5-> set_color cyan;
  |6-> set_color magenta;
  |7-> set_color yellow;
  |_ -> invalid_arg  "Le chiffre doit etre compris entre 0 et 7";;

let contour z = match z with
  |0-> set_color black;
  |1-> set_color white;
  |2-> set_color red;
  |3-> set_color blue;
  |4-> set_color green;
  |5-> set_color cyan;
  |6-> set_color magenta;
  |7-> set_color yellow;
  |_ -> invalid_arg "Le chiffre doit etre compris entre 0 et 7";;

let sponge z w x y n =
  clear_graph();
  contour z;
  fill_rect x y n n;
  remplissage w;
  let rec spongee x y n i =
    fill_rect(x+n/3)(y+n/3)(n/3)(n/3);
      match i with
  0 -> ()
|_ -> begin
          spongee x y (n/3)(i-1);
  spongee (x+n/3)y(n/3)(i-1);
  spongee (x+2*n/3)y(n/3)(i-1);
  spongee x(y+n/3)(n/3)(i-1);
  spongee x(y+2*n/3)(n/3)(i-1);
  spongee (x+n/3)(y+n/3)(n/3)(i-1);
  spongee (x+n/3)(y+2*n/3)(n/3)(i-1);
  spongee (x+2*n/3)(y+n/3)(n/3)(i-1);
  spongee (x+2*n/3)(y+2*n/3)(n/3)(i-1);
end;
    in
  spongee x y n 4;;

sponge 0 1 10 10 243;;



(*Sierpinski triangle*)

let sierpinski n=
  set_color black;
  fill_poly [|(50,50);(300,550);(550,50)|];
  set_color white;
  let rec sierpinski_triangle n c (x,y)(x1,y1)(x2,y2) =
    if n=0
    then ()
    else
      begin
        fill_poly [|(x+(c/2),y);((x1+x)/2,(y1+y)/2);((x2+x1)/2,(y2+y1)/2)|];
        sierpinski_triangle (n-1)(c/2)(x,y)((x1+x)/2,(y1+y)/2)(x+(c/2),y);
        sierpinski_triangle (n-1)(c/2)(x+(c/2),y)((x2+x1)/2,(y2+y1)/2)(x2,y2);
        sierpinski_triangle (n-1)(c/2)((x1+x)/2,(y1+y2)/2)(x1,y1)((x2+x1)/2,(y2+y1)/2)
      end
  in sierpinski_triangle n 500 (50,50) (300,550) (550,50);;

sierpinski 6;;

clear_graph();;
