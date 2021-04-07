# Test Unity pour Smart Tale

## Conditions
* Vous disposez de **48h** afin de réaliser le test demandé à partir du moment où vous démarrez (comprenez bien qu’il s’agit ici de jouer le jeu, si vous prenez le temps que vous voulez afin de réaliser ce projet, l’évaluation de vos compétences sera biaisée et cela se reflétera rapidement une fois en poste)
* Vous pouvez utiliser toutes les ressources gratuites et libres de droit a votre disposition
* La version de Unity à utiliser est la **2017.4.+ LTS**
* Vous devez nous fournir un exécutable **Windows x86_64**
* Vous devez nous fournir le code source via **git**
* Vous n’aurez peut-être pas le temps de finir donc à vous de définir vos priorités et de nous fournir un projet qui vous parait **cohérent avec le temps passé**

## Objectifs
Réaliser un jeu de **Tetris** avec :

* La possibilité de **configurer** et **ajouter** ou **supprimer** les pièces du jeu dans l’éditeur (couleur, forme, …) => Les pièces sont stockées sous formes de prefabs. Chaque prefab a un certain nombre de blocs (non nécessairement fixé à 4 blocs, il est possible d'imaginer des pièces avec plus ou moins de blocs). Chaque bloc a un sprite défini (avec une résolution de 64 pixels par unité pour que le sprite de 64 pixels corresponde à une distance de 1). L'élément **Spawner** dans la scène **Game** contient la liste des pièces qui peuvent être générées. Il est donc possible d'ajouter ou de supprimer des pièces à la volée.
* Un **menu localisé** permettant de :
	* choisir la langue (français ou anglais)
	* choisir un pseudo
	* démarrer une nouvelle partie
	* faire pause pendant une partie
	* abandonner une partie en cours
	* quitter le jeu
	* accéder au Leaderboard
* => Toutes les interfaces sont localisées. Le bouton avec le point d'interrogation sur l'écran de titre ouvre le menu d'aide.
* Un **système de score** qui sera :
	* affiché lors d’une partie
	* enregistré dans le Leaderboard a la fin de chaque partie
* => Le leaderboard est généré lors de la première exécution, et il est possible de le remettre à zéro dans l'application.
* => Pour le build sous Android, dans la scène **Main** l'objet **AdroidHUD** doit être activé, et dans le script **HelpCaption.cs**, la variable **helpForAndroid** doit être sur **true**.

## Règles du jeu
Les règles du jeu sont celles du **Tetris original** : https://fr.wikipedia.org/wiki/Tetris#Syst%C3%A8me_du_jeu