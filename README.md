# AirportManagement

Ce projet est une introduction à l'utilisation de .NET, structuré en plusieurs parties : core, ui.web, infrastructure et ui.console. L'objectif est de montrer comment organiser un projet en couches pour une meilleure maintenabilité et évolutivité.

## Structure du Projet

La solution est organisée comme suit :

- `Core` : Contient la logique métier et les entités de domaine.
- `Infrastructure` : Contient les implémentations des services, la gestion de la base de données et les repositories.
- `UI.Web` : Contient l'application web ASP.NET Core.
- `UI.Console` : Contient l'application console .NET.

## Prérequis

Avant de commencer, assurez-vous d'avoir les éléments suivants installés sur votre machine :

<ul>
    <li><a href="https://dotnet.microsoft.com/download">.NET SDK 6.0 ou plus</a></li>
    <li>Un IDE tel que <a href="https://visualstudio.microsoft.com/">Visual Studio</a> ou <a href="https://code.visualstudio.com/">Visual Studio Code</a></li>
</ul>

## Installation

1. Clonez le dépôt :

    ```bash
    git clone https://github.com/nasreddineelmadhkour/AirportManagement.git
    cd AirportManagement
    ```

2. Restaurez les packages NuGet :

    ```bash
    dotnet restore
    ```

3. Compilez la solution :

    ```bash
    dotnet build
    ```

## Exécution

Pour exécuter les différentes parties de la solution, utilisez les commandes suivantes :

### UI.Web

Pour lancer l'application web ASP.NET Core :

```bash
cd src/UI.Web
dotnet run
