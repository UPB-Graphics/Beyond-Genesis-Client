Pîrciulescu Valentina, Sisteme avansate de securitate

Generarea procedurală a unui orășel

Orașul este compus din case, drumuri și copaci. De asemenenea, pe străzi se
găsesc elemente (mâncare și bănuți) ce pot fi colectate. Atât casele, pomi,
cât și elementele colectibile sunt poziționare aleatoriu cu ajutorul unui
algoritm bine definit. 
Scriptul pentru generarea procedurală a orășelului conține 4 liste cu obiecte 
de tip GameObject, listele conțin prefabricate, iar dimensiunea și conținutul 
lor poate varia. 
Algoritmul de creare al orășelului constă în generarea a două numere întregi 
aleatoare ce reprezintă dimensiunile orașului, iar apoi sunt plasate pe hartă
elementele componente ținând cont de reguli (fiecare tip de element are un
număr maxim de apariții în oraș, în funcție de dimensiunile acestuia). 
Orașul poate fi văzut din două perspectivă, schimbarea perspectivei se face
folosind tasta C.
Suprafața pe care se află orașul este de tip NavMeshSurface astfel încât la 
finalul generării se apelează metoda surface.BuildNavMesh() pentru a delimita
zonele pe unde se pot deplasa personajele. 

Orașul din perspectiva jucătorului
![alt text][https://github.com/vpirciulescu/images/blob/master/Screenshot%20from%202022-02-18%2021-05-12.png]

Orașul din perspectiva persoanei a III-a (1)
![alt text][https://github.com/vpirciulescu/images/blob/master/Screenshot%20from%202022-02-18%2021-06-08.png]

Orașul din perspectiva persoanei a III-a (2)
![alt text][https://github.com/vpirciulescu/images/blob/master/Screenshot%20from%202022-02-18%2021-09-26.png]

