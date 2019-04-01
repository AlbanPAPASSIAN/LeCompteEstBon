# LeCompteEstBon

## Table des matière
1. Introduction
2. Acteur du projet
4. Règle du jeu
5. Organisation du code
6. Mode d'emploi

## Introduction
Réalisation du jeu **le comte est bon** en console, en **C#**.
L’objectif est de créer une version du compte est bon, l’une des composantes du jeu télévisé « Des chiffres et des lettres » et de permettre aux utilisateurs de pouvoir lancer une partie via un menu simple et ergonomique.

## Acteur du projet
Alban PAPASSIAN, étudiants en 3ème année d’étude en informatique à Ynov Campus Aix-en-Provence.

## Règle du jeu
Vous disposez de 5 nombres et vous devez obtenir le nombre cible, en combinant ces 5 nombres avec les 4 opérations élémentaires (+, -, *, /) : addition, soustraction, multiplication et division. Chaque nombre ne peut être utilisé qu'une seule fois, vous ne pouvez combiner que des nombres positifs et entiers.

## Organisation du code

Le programme est séparé en 4 différentes classe :
- Game
- Result
- Bag
- Player

La classe **Game** représente le jeu en lui-meme. C'est dans cette classe que l'algorithme en lui meme est effectué.

On retrouve dans la classe **Result** les éléments nécéssaire au bon déroulement du jeu, a savoir : le nombre cible, ainsi que les nombres disponibles pour les calculs.

La classe **Bag** représente le sac dans lequel sont présent les nombres disponibles.

La classe **Player** définie quant à elle l'utilisateur du programme.

![LeCompteEstBon](https://i.imgur.com/YI6ORR6.png)

## Mode d'emploi

Lors de l’exécution, l’utilisateur arrive sur le menu de l’application.

D’ici, il à pour choix de lancer la partie, ou de découvrir les règles du jeu.

![LeCompteEstBon1](https://i.imgur.com/ePUcasq.png)

### Le jeu

Une fois la partie lancée, on voie affiché le nombre cible, avec l’ensembles des nombres disponibles à utiliser pour le trouver.

L’utilisateur peux ainsi saisir les calcules qu’il souhaite effectuer, sous la forme « 1 + 1 » (les espaces ne sont pas pris en compte).

![LeCompteEstBon2](https://i.imgur.com/zDonwJA.png)

