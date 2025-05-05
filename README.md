# Store
Mój projekt na zaliczenie

    Zasadnicza kwestia nie wiem co należy zrobić z bazą danych, gdyż stoi ona u mnie. Gdy klonowałem repozytorium na inny komputer bez niej nie da sie uruchomić aplikacji, chyba że podepnie się własną lecz wtedy nie będzie widać produktów które dodałem a wg. zasad zaliczenia mieliśmy ich dodać 5-10.
  
    Wiem, że z perspektywy klienta ta strona jest bez sensu, gdyż klient nie powinien usuwać, czy edytować produktów. Aby usunąć te funkcje, wystarczyłoby w widoku Index.cshtml usunąć np te linijki z akcjami:
    
                    <a asp-action="Edit" asp-route-id="@item.ID">Edytuj</a> |
                    <a asp-action="Delete" asp-route-id="@item.ID">Usuń</a> |

                    
    Nie zrobiłem tego mimo, że to proste by w widoczny sposób pokazać, że ta funkcja istnieje(oczywiście gdyby na wersji produkcyjnej coś takiego zrobić to byłoby samobójstwo). Ze względu na to, że nie było to konieczne w poleceniu stworzenia projektu, nie wchodziłem w temat jak sprawić by np. tylko dany użytkownik(np. admin) mógł dodawać, usuwać i edytować produkty.
    Także mogłem nie dodawać na stronie głównej zbędnych funkcji np. dodaj produkt, edytuj, usuń a samemu dodawać produkty np. przez adres<strong> https: //localhost:7267/Sklep/Add </strong>analogicznie edytować lub usuwać o czym nie wiedziałby klient lecz tego nie zrobiłem.



    W razie pytań proszę o kontakt przez Teams lub mailowo. Mój email to:<strong> s10568wo@ms.wwsi.edu.pl</strong>

