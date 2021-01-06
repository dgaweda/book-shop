#### Project for .Net Develeopment 
#### Dariusz Gawęda 2021
#### STUDIES
# Projekt: ASP MVC wymagania

### Punktacja
50 punktów za realizację wszystkich punktów z poniższej specyfikacji.

### Czas
Program należy umieścić w zadanym repozytorium i zaprezentować do końca zajęć 
laboratoryjnych. Pierwszeństwo w oddawaniu zadań mają studenci w większą liczbą 
dotychczas zdobytych punktów.

## Aplikacja realizująca CRUD
Celem jest implementacja aplikacji w technologii ASP MVC (framework lub core),
spełniającej poniższe założenia. Tematyka aplikacji dowolna.


### Modele: 35%

- minimum 2 tabele z relacją jeden-do-wiele 
  i odpowiednią implementacją więzów integralności danych: 10%
- walidacja danych:
    - atrybuty dotyczące ograniczeń danych: 5%
    - własne walidatory danych: 5%
    - walidacja wielopolowa: 5%
- zastosowanie atrybutów modelu, wspomagających generowanie pól w widokach: 10%

### Kontrolery: 30%

- możliwość definiowania w programie użytkowników i przypisywania ich do zdefiniowanych ról 
  oraz powiązanie uprawnień zalogowanych userów z akcjami w kontrolerach: 10%
- wykorzystanie LINQ w akcjach kontrolerów: 10%
- przygotowanie testów jednostkowych akcji w kontrolerach: 10%

### Widoki: 35%
Widoki należy przygotować wykorzystując Razor lub Blazor.
Program powinien zawierać:
- dwa widoki napisane ręcznie, nie powinny dotyczyć widoków CRUD: 5%
- widok częściowy, pozwalający na częściowe odświeżanie strony 
  (zwrócić uwagę na komunikację widoku częściowego z widokiem podstawowym): 10%
- zastosowanie podstawowych helperów oraz 
  definicja dwóch własnych helperów o nietrywialnej funkcjonalności: 10%
- zastosowanie dwóch własnych layoutów stron: 10%

### Extra: 15%

- modyfikacja routingu RESTowego w celu dostosowania do SEO: 5%
- wykorzystanie w programie stanu sesji i aplikacji: 5%
- umieszczenie strony w chmurze (np.: Azure) 
  oraz umiejętność zarządzania i monitorowania zasobami serwera: 5%


----
## Materiały dodatkowe

- [Getting Started with ASP.NET MVC 5](https://docs.microsoft.com/pl-pl/aspnet/mvc/overview/getting-started/introduction/)
- [ASP.NET MVC Pattern](https://dotnet.microsoft.com/apps/aspnet/mvc)
- [Overview of ASP.NET Core MVC](https://docs.microsoft.com/en-gb/aspnet/core/mvc/overview?view=aspnetcore-3.1)
- [CodeProject: Learn MVC Project in 7 days](https://www.codeproject.com/Articles/866143/Learn-MVC-Project-in-days-Day)
- [Yogi Hosting: ASP.NET Core](https://www.yogihosting.com/aspnet-core-introduction/) 
