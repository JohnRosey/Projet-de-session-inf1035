# Projet de session Phase 1:

 **Membres de l'équipe :**

 - GANSONRE ISMAEL
 - ALEX CORRIVEAU
 - WINNER MAZONZIKA PINDI
 - SAWADOGO KEVINE
 - LOUKELO HARLEZE

#  Spécifications générales

Voici les grandes lignes de ce que notre application devra contenir :

-   Une interface graphique d'une grille 9x9 où l'ont peut insérer des chiffres à différents endroits.
-   Un système qui vérifie si l'état actuel Sudoku est valide ou non.
-   Une fonctionnalité de sauvegarde et chargement d'une grille.

## S : Principe de responsabilité unique:

![image](https://user-images.githubusercontent.com/46062396/140238172-9cb7b15d-8fe2-460c-b6ce-d86ee955c347.png)

**Explication:**
> `Window_PreviewKeyDown` qui se trouve dans `MainWindow.xaml.cs` le fait d'appuyer sur les touches fléchées d'un bouton déclenche l'événement PreviewKeyDown. Cette classe possède une responsabilité unique.

## O : Principe Ouvert/Fermé
![image](https://user-images.githubusercontent.com/78938041/140396893-c655d1f8-b374-47e3-899d-fd7fa07ab398.png)

**Explication :**
> Dans notre classe SudokCell, on utilise plusieur creteur différents pour nous permettre d'avoir un même objet que nous gardons tout nos paramètres sans avoir à les modifier quand nous voulons ajouter de nouvelle fonctionnalité ou de nouveau parametre. La redéfinition de nos constructeur nous donne le droit d'avoir un nouveau créateur avec des nouveaux paramètre sans modifier les parametre déjà mis en place. Dans ce cas, il est donc fermer à la modification mais ouvert à l'amélioration de notre code.

## L: Principe de Substitution de Liskov
![image](https://github.com/wflageol-uqtr/projet-de-session-marvelteam/blob/main/Projet%20de%20session/Sudoku/.cr/images/Capture111.PNG)

**Explication :**
> Notre classe SudokuCell herite de la classe CellNote qui vas gerer l'ecriture des notes.
## I : Principe de Ségrégation d'Interface
![Capture](https://user-images.githubusercontent.com/90834225/140390006-eb8b5bc7-6042-4eaa-8854-50294651859e.PNG)
![Capture2](https://user-images.githubusercontent.com/90834225/140390036-8d0cd5ec-75a9-4dd8-8a09-4b7a17964414.PNG)

**Explication :**
> Afin de respecter le principe de ségrégation d’interface, nous avons créé les classes SudokuCell et GameControl. La classe SudokuCell regroupe toutes les méthodes qui s’occuperont de la structure de chaque cellule. La GameControl compte à elle, regroupent les méthodes qui vont perdre de sauvegarder la grille.
## D : Principe d'injection de dépendance
![image](https://user-images.githubusercontent.com/78938041/140388932-ecfc0682-7a89-4117-ba6b-5f0d6ec99462.png)

**Explication :**
> On utilise le principe d'injection de dépendance dans ce constructeur ou on attribut dynamiquement un array d'objet a l'attribut
au lieu de faire un new object.En attribuant dynamiquement nos liens entre les objet on limite moin notre code pour des changements et ca nous permet de moduler 
la creation de notre classe pour accepter plusieurs cas. Dans notre constructeur nous avons plusieurs model diferent selon les arguments qui sont envoyer en parametre
ce qui nous donne de la libertiner.

# GRASP
 ## Spécialiste de l'information:
![image](https://user-images.githubusercontent.com/46062396/140400774-982939a8-db5f-445a-8f61-48a98b6646cf.png)

**Explication:**
>`void SetAvailableCharacters(`)  se trouvant dans `MainWindow.xaml.cs`  délégue la responsabilité de valider les caractères valides pour un jeu de Sudoku de :(1 a 9) , qui sera afficher par la suite dans les Cellules.
## Créateur
![image](https://user-images.githubusercontent.com/78938041/140410092-7f45a030-6a4c-431c-a19b-6128d4598ad9.png)

explication:Notre Classe GameControl est une classe qui contient un array d'ojet et qui en fait la gestion et la création
Notre classe peut est considérer comme un patron graspe créateur parce qu'il fait la gestion des objet et de leur paramettre et il contient tout les donées nécessaire a leurs création.

# Projet de session Phase 2 :

**Membres de l'équipe :**

 - GANSONRE ISMAEL
 - ALEX CORRIVEAU
 - WINNER MAZONZIKA PINDI
 - SAWADOGO KEVINE
 - LOUKELO HARLEZE

# Spécification générale

Voici les grandes lignes de ce que notre application devra contenir :
- Ajouter une fonctionnalité undo-redo à votre logiciel.
- Permettre d'ajouter une couleur différente à chaque case parmi 9 couleurs fournies.
- Permettre d'effectuer des changements sur plusieurs cases à la fois.
- La fonctionnalité undo-redo devra être testée unitairement.
- Votre code devra faire usage de trois (3) patrons de conceptions GoF différents, tels que vu dans les notes de cours et en classe.
- Effectuer les corrections sur les éléments manquants dans votre implémentation de la phase 1 (s'il y a lieu).

# Implémentation de la fonctionnalités undo-redo

Nous avons utilisé le patron de conception Command afin d'implémenter les fonctionnalités undo-redo. Ce patron a pour but d'encapsuler dans un objet des opérations qui pourront
être invoqué au moment réquis dans un contexte donné dans notre cas, les opérations sont le undo et le redo.
Pour se faire, premièrement nous avons crée une classe abstraite qui représente le concept abstrait de la command.

![image](https://user-images.githubusercontent.com/90834225/145438536-f14b7d9b-6b33-4fe3-ad75-02e7aea5f249.png)

Ensuite, nous allons implémenter la Command.

![image](https://user-images.githubusercontent.com/90834225/145440184-05d52013-2481-454b-87a5-9eb0c1b24c12.png)

Dans notre classe Invoquer, nous avous crée deux piles : la prémière "undoStack" les commandes en place et prêt à être annulées et la seconde "redoStack" qui contiendra les 
commandes à refaire.

![image](https://user-images.githubusercontent.com/90834225/145441758-7905ae48-c9ad-4423-88ec-1e4db1fe4541.png)


# Implémentation de la fonctionnalités Color et Colorisation Multiple
## Color
Lorsqu’une case est sélectionnée, on lui récupère et stocke dans selectedSquare grâce a levent gotFocus de notre textBox.

![image](https://github.com/wflageol-uqtr/projet-de-session-marvelteam/blob/main/Projet%20de%20session/Sudoku/.cr/images/Sudoku%20-%20Microsoft%20Visual%20Studio%202021-12-09%2014_43_48.png)

Ce qu’il faut faire en suite c’est de choisir la couleur via notre menu, sélectionner la couleur qu’on désire et cliquez sur Choose et la nôtre cellule colorier. La manière dont cela fonctionne est que une qu’on déclenche l’événement onClick de notre bouton choose, on récupère la couleur sélectionner et on stocke dans selectedcolor puis vérifie si on est en sélection multiple ce qui n’est pas le ca et on colore la case en changeant le background de la cellule correspond a la cellule qui a le focus avec la méthode GetSquareSelectedEqualToSquare()

![image](https://github.com/wflageol-uqtr/projet-de-session-marvelteam/blob/main/Projet%20de%20session/Sudoku/.cr/images/Sudoku%20-%20Microsoft%20Visual%20Studio%202021-12-09%2014_30_17.png)

## Colorisation Multiple

Premierement on clique sur Mutiple SelectionEn sélection multiple chaque fois qu’une case a le focus elle est ajoute dans une liste, une fois la couleur choisit et on clique sur choose, on se retrouve donc dans le onCLick évent de choose, on entre dans le if dont la condition dépend la valeur booléen qui désigne si on est en sélection multiple. Une fois à l’intérieur une boucle passe à travers chaque élément de notre liste de case sélectionner et les colories.

![image](https://github.com/wflageol-uqtr/projet-de-session-marvelteam/blob/main/Projet%20de%20session/Sudoku/.cr/images/Sudoku%20-%20Microsoft%20Visual%20Studio%202021-12-09%2015_36_16.png)

![image](https://github.com/wflageol-uqtr/projet-de-session-marvelteam/blob/main/Projet%20de%20session/Sudoku/.cr/images/Sudoku%20-%20Microsoft%20Visual%20Studio%202021-12-09%2014_42_14.png)

![image](https://github.com/wflageol-uqtr/projet-de-session-marvelteam/blob/main/Projet%20de%20session/Sudoku/.cr/images/Sudoku%20-%20Microsoft%20Visual%20Studio%202021-12-09%2014_30_17.png)

## Patron : Prototype
Le patron de conception prototype nous premet donne aux objets une methode de clonage qui permet a l'objet de donner une copie de lui meme.
Le clonage de notre prototype nous permet d'avoir une copie d'un objet sans donner reference aux meme sous classe.
Dans notre code nous avons utiliser le principe de clonage pour creer des copie de notre sudoku pour les utiliser dans le undo et redo afin d'avoir une copie 
qui ne reference pas les memes objet mais bien une toute nouvelle grille complete.

![image](https://user-images.githubusercontent.com/78938041/145478899-88dea703-5c27-4117-9556-edf61340fd93.png)

Dans cete image on peut voir que on utilise le clone d'une cellule pour ensuite l'envoyer dans une commande pour nos methodes und redo.

![image](https://user-images.githubusercontent.com/78938041/145479144-db3ac515-96b1-4f4e-9e2a-b6adf6c5dddf.png)
![image](https://user-images.githubusercontent.com/78938041/145479388-5432f4c6-cd82-414b-bd0b-b01ba17224ed.png)

La methode clone() devrais etre semblable dans tout les objets car on crée un nouvel objet avec notre prototype comme source.
| Tâche                              | Responsable |
| ---                                | ---         |
| Interface graphique (phase 1)      | alex ,ISMAEL       |
| Notation spéciales (phase 1)       | alex,ISMAEL        |
| Système de vérification (phase 1)  | alex ,kevine,Harleze       |
| Sauvegarde et chargement (phase 1) | alex        |
| Tests unitaires (phase 1)          | alex ,     |
| Rapport (phase 1)                  | alex,winner ,kevine, Harleze       |
| Undo/Redo (phase 2)                | alex,winner,ISMAEL     |
| Couleurs (phase 2)                 | kevine, Harleze ,ISMAEL            |
| Sélection multiple (phase 2)       | alex ,kevine,Harleze       |
| Tests unitaires (phase 2)          |             |
| Rapport (phase 2)                  | alex,winner,Kevine,Harleze,ISMAEL      |
