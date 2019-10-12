# Laboratory 1

# 1. Construiti vectorii x si y care sa contina numerele 7.4, 9.3, 5,
#  12 si -7.3, 2, 9, -4.9, respective.
x <- c(7.4, 9.3, 5, 12)
y <- c(-7.3, 2, 9, -4.9)

# 2. Calculati vectorul v care sa aiba elemente obtinute dupa formula 2x+3y+1.
v <-2*x+3*y+1

# 3.  Calculati pentru v lungimea, minimul, maximul, suma, produsul,
#media si deviatia standard ale elementelor sale. 

l <- length(v)
min <- min(v)
max <- max(v)
sum <- sum(v)
prod <- prod(v)
mean <- mean(v)
stdDev <- sum((v-mean(v))^2)/(length(v)-1)

# 4.  Sortati vectorii x si y
sortX <- sort(x)
sortY <- sort(y)

# 5. Generati un vector de tip secvential de la -10 la 10 care sa aiba elementele din 0.5 in 0.5.
vectSeq <- seq(-10, 10, by = 0.5)

# 6.  Generati un vector cu marci de masini.
cars <- c('BMW', 'Audi', 'Opel')

# 7. Fie n = 10, comparati secventele 1:n-1 si 1:(n-1).
n <- 10
n <- n[1:n-1]
n <- n[1:(n-1)]

# 8. Generati un vector logic prin compararea elementelor din x cu 8.
temp <- x > 8

# 9. Folosind un vector index, selectati din y intr-un vector z numai elementele pozitive.
z <- y[y>0]

# 10.Aflati elementul de pe pozitia 3 din vectorul v.
poz <-v[3]

# 11. Folosind un vector index, selectati din x intr-un vector z primele 3 elemente.
z <- x[1:3]

#12. Folosind un vector index, construiti din x un vector z excluzand primele 3 elemente ale sale.
index <- x[-(1:3)]

#13.  Inlocuiti elementele negative din y cu 0.
replace <- replace(y, y<0, 0)

#14. Generati un vector de preturi pentru 4 tipuri de haine, atasati un vector
# cu hainele corespunzatoare si apoi scrieti o interogare prin care sa se
# calculeze pretul total pe care trebuie sa il plateasca un client pentru doua
# haine alese.

prices <- c(14.99, 450, 23.56, 7.89)
clothes <- c("Tricou", 'Geaca de piele', 'Esarfa', 'Sosete')
stateF <- factor(clothes)

totPrice <- tapply(prices, stateF, sum)

#15. Definitiun vector de numere intregi x si schimbati-l intr-un vector caracter y care sa
#contina stringul asociat fiecaruia (fiecare numar intre ghilimele).
#Transformati-l apoila locin intregidispusiintr-un vector z.
x <- c(1, 23, 14, 11, 7, 28, 13)
y <- as.character(x)
z <- as.numeric(y)

#16. Construiti un vector de 3 numere intregi. Apoi adaugati numarul 3 pe pozitia a 4-a.
#Scurtati-l ulterior la primele 2 pozitii.
vect <- c(1, 23, 14)
append(vect, 3, 3)
vect <- vect[1:2]

#17. Avand un vector de tip caracter cu obiectele 'unu', 'doi' si 'trei', creati un vector factor din acesta 
#si afisati vectorul nou si nivelurile sale.

vector <- c('unu', 'doi', 'trei')
vectorF <- factor(vector)
print(vectorF)

#18. La un concurs de informatica participa trei licee notate prin 'unu', 'doi' si 'trei'.
#De la fiecare liceu participa mai multi elevi care obtin note dupa urmatorii vectori:
#  elevi <- c('unu', 'unu', 'trei', 'doi', 'trei', 'unu', 'doi', 'doi', 'trei', 'unu')
#  note <- c(7, 3, 9, 10, 9, 8, 5, 2, 7, 9)
# Transformati vectorul elevi intr-unul factor si calculati media notelor elevilor de la fiecare liceu.

elevi <- c('unu', 'unu', 'trei', 'doi', 'trei', 'unu', 'doi', 'doi', 'trei', 'unu')
note <- c(7, 3, 9, 10, 9, 8, 5, 2, 7, 9)
eleviF <- factor(elevi)
meanNote <- tapply(note, eleviF, mean)

#19. ??? Creati o matrice 2 x 3. Extrageti prima coloana a sa. Extrageti a doua linie. 
# Extrageti elementul de pe pozitia (2, 3). Inlocuiti primele doua elemente de pe linia
# a 2-a cu 0.

x <- array(1:6, dim=c(2,3))
secondLine <- x[2, ]
elem <- x[2,3]
elem1<- secondLine[1:2]
replace <- replace(x, elem1, 0)

#20. Creati un vector de lungime 3 si o matrice 3 x 2 si uniti-le pe coloana. Idem cu un vector
#de lungime 2 si aceeasi matrice cu unire pe linie.
vector <- c(1, 2, 3)
a <- array(2:7, dim = c(3, 2))

# Vector unit pe coloana cu matricea a
res <- cbind(vector, a)

vect <- c(1, 2)

# Vect unit pe linie cu matricea a
result <-rbind(vect, a)

#21. Uniti pe coloana doua matrice de 2 x 3 si 2 x 4.
a <- array(1:6, dim = c(2, 3))
b <- array(7:14, dim = c(2, 4))

rez <- cbind(a, b)

#22. Uniti pe linie doua matrice 2 x 2 si 3 x 2.
c <- array(1:4, dim = c(2, 2))
d <- array(5:10, dim = c(3, 2))

rezultat <- rbind(c, d)

#23. Construiti doua liste cu urmatoarele componente: numele si prenumele cate unui student,
#anul nasterii si un vector cu doua componente - media notelor de studiu si nota de la licenta.
#??? Adaugati ulterior la fiecare inca o componenta care sa specifice firma la
#care s-a angajat dupa alsolvire.
#??? Concatenati apoi cele doua liste.
#??? Calculati media finala (intre note studii si nota licenta) pentru fiecare
#dintre cei doi studenti.

#24.  Creati un fisier .data cu urmatorul cap de tabel (marca, motor, combustibil, an, km, pret)
#privind datele mai multor masini de la un parc auto.
        #??? Creati apoi un data frame care sa importe in R datele din fisier.
        #??? Gasiti apoi pretul minim si maxim si caracteristicile masinilor
        #corespunzatoare.

