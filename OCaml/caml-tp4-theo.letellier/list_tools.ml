(*1.1.1 lenght*)

let rec length list =
  if list = [] then 0
  else
    let e::l=list in
    1+length l;;

(*1.1.2 append*)

let append l1 l2 =
  if l2 = [] then l1
  else let rec append_rec = function
    []-> l2
    |e::l ->e::append_rec l
in append_rec l1;;


(*1.1.3 coupleSize*)


let rec coupleSize l =
  match l with
      [] -> 0
    |e::f -> let (x,_) = e in x+coupleSize f;;


(*1.1.4 nth*)


let rec nth n i = 
  if n>=0 then
    match i with
      |e::l when n=0 -> e
      |e::l -> nth (n-1) l
      |	[]-> invalid_arg "n doit être plus petit"
  else
    failwith "n doit être superieur ou égal à 0";;



(*1.1.5 search_pos*)


let rec search_pos n liste = match liste with
    e::l when n=e -> 0
  |e::l -> 1+search_pos n l
  |_ -> failwith "search_pos not found";;


(*1.1.6 sum_digits*)

let rec sum_digits n =
  if n>0 then (n mod 10)+sum_digits(n/10)
  else 0;;


(*1.1.7 common*)

let common (list1,list2) =
  let rec rec_common liste1 liste2= match liste1 with
    [] -> 0
  |e::l -> match liste2 with
      [] -> rec_common l list2
      |a::b -> if a = e then e else rec_common liste1 b
  in rec_common list1 list2;;



(*1.1.8 prefix*)

let rec prefix (l1,l2) = match (l1,l2) with
  |([],[]) -> true
  |(e::l,f::m) when e<>f -> false
  |(e::l,f::m) when e=f -> prefix (l,m)
  |_ -> true;;


(*--------------------------------------------------------------*)


(*1.2 Construire*)

(*1.2.1 - init_list*)

let rec init_list n z =
  if n < 0 then invalid_arg "n doit etre positif"
  else
    match n with
      |0->[]
      |_-> z::init_list(n-1)z;;


(*1.2.2 - put_list*)

let rec put_list v i liste =
  if i<0 then invalid_arg "i doit etre positif"
  else match liste with
    |e::l when i=0 -> v::l
    |e::l -> e::put_list v (i-1) l
    |_ -> [];;


(*--------------------------------------------------------------*)



(*1.3.1 - init_board*)


let rec init_list n x =
  if n < 0 then invalid_arg "n doit etre positif"
  else
    match n with
      |0->[]
      |_-> x::init_list(n-1)x;;

let init_board (l,c) x =
  init_list l (init_list c x) ;;



(*1.3.2 - get_cell*)

let rec nth n i =
  if n>=0 then
    match i with
      |e::l when n=0 -> e
      |e::l -> nth (n-1) l
      |[]-> invalid_arg "n doit être plus petit"
  else
    failwith "n doit être superieur ou égal à 0";;

let get_cell (x, y) board =
  nth y (nth x board) ;;


(*1.3.3 - put_cell*)

let rec nth n i =
  if n>=0 then
    match i with
      |e::l when n=0 -> e
      |e::l -> nth (n-1) l
      |[]-> invalid_arg "n doit être plus petit"
  else
    failwith "n doit être superieur ou égal à 0";;

let rec put_list v i liste =
  if i<0 then invalid_arg "i doit etre positif"
  else match liste with
    |e::l when i=0 -> v::l
    |e::l -> e::put_list v (i-1) l
    |_ -> [];;

let put_cell v (x,y) board =
  put_list (put_list v y (nth x board)) x board;;




