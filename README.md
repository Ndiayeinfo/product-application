API REST .NET 8 pour la gestion de produits : CRUD via Entity Framework Core sur SQL Server, modèle Product et migrations incluses. Documentation Swagger et configuration CORS pour intégration avec une application Angular (http://localhost:4200). Extensible, déployable et prête pour tests.


# ProductApplication

## Description du projet

`ProductApplication` est une API REST construite avec `ASP.NET Core` (.NET 8) pour gérer un catalogue de produits. Elle fournit des endpoints CRUD simples pour créer, lire, mettre à jour et supprimer des produits. Le backend est conçu pour être consommé par une application cliente (par exemple une application Angular) et expose une documentation interactive via `Swagger` en environnement de développement.

### Fonctionnalités principales

- Endpoints CRUD pour les entités `Product`.
- Persistance via `Entity Framework Core` et `SQL Server`.
- Documentation API avec `Swagger`.
- Configuration CORS prête pour une application Angular (politique `AllowAngularApp`).
- Architecture simple et modulaire pour faciliter l'extension.

### Architecture & composants

- `Controllers` : contient `ProductController` exposant les routes de l'API.
- `Data` : contient `AppDbContext` (contexte EF Core) et la configuration de la base de données.
- `Model` : classes de domaine (par ex. `Product`).
- `Program.cs` : configuration des services, CORS, Swagger et pipeline HTTP.

### Stack technique

- .NET 8 / C# 12
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger (Swashbuckle)

### Prérequis

- .NET 8 SDK
- SQL Server (ou une instance accessible)
- (Optionnel) Node.js + Angular CLI si vous utilisez une UI Angular

## Démarrage rapide

Suivez ces étapes pour configurer et lancer l'application localement.

1) Configurer la chaîne de connexion

Ouvrez `appsettings.json` et ajustez `DefaultConnection` :

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=ProductDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

2) Installer l'outil EF Core (si nécessaire)

```bash
dotnet tool install --global dotnet-ef
```
    
3) Restaurer et construire

```bash
dotnet restore
dotnet build
```

4) Générer et appliquer les migrations

```bash
dotnet ef migrations add InitialCreate --project ../ProductPersistence/ProductPersistence.csproj --startup-project ../ProductApi/ProductApi.csproj
dotnet ef database update --project ../ProductPersistence/ProductPersistence.csproj --startup-project ../ProductApi/ProductApi.csproj
```

5) Lancer l'application

```bash
dotnet run --project ../ProductApi/ProductApi.csproj
```

L'API sera disponible sur `https://localhost:7125` (ou un autre port si spécifié).

## Documentation technique

### Endpoints principaux

- `GET  api/Product/getAllProduct` — Récupère tous les produits.
- `POST api/Product/AddProduct` — Ajoute un nouveau produit (passez l'objet `Product` en JSON dans le body).
- `PUT  api/Product/UpdateProduct/{id}` — Met à jour le produit identifié par `{id}`.
- `DELETE api/Product/DeleteProduct/{id}` — Supprime le produit identifié par `{id}`.

> Note : Les routes sont définies dans `ProductController` et suivent le pattern `api/[controller]`.

### CORS

- Politique nommée : `AllowAngularApp`.
- Origine par défaut configurée pour `http://localhost:4200`.
- Assurez-vous d'appeler `app.UseCors("AllowAngularApp")` dans le pipeline HTTP et d'enregistrer la politique via `builder.Services.AddCors(...)` avant `builder.Build()`.

### Tests

- Aucun test unitaire inclus pour l'instant — il est recommandé d'ajouter des tests d'intégration pour les endpoints et des tests unitaires pour la logique métier.

### Contribuer

- Forkez le dépôt, créez une branche feature/bugfix et envoyez une pull request.
- Respectez les conventions de code et ajoutez des tests pour les nouvelles fonctionnalités.

## License

Ce projet est sous licence MIT. Voir le fichier `LICENSE` pour plus de détails.

---

*Remarque: Ce README est un modèle et peut devoir être ajusté en fonction des détails spécifiques et des exigences du projet.*

- En développement, Swagger est disponible à `https://localhost:5001/swagger` ou `http://localhost:5000/swagger` selon la configuration.
- La politique CORS `AllowAngularApp` autorise par défaut `http://localhost:4200`.

### Exécution depuis Visual Studio

- Ouvrez la solution dans Visual Studio 2022 et lancez en mode Debug (F5) ou Without Debug (Ctrl+F5).

### Dépannage rapide

- Erreur de connexion SQL : vérifiez la chaîne de connexion, que SQL Server est démarré et que l'utilisateur a les droits.
- `dotnet ef` introuvable : installez `dotnet-ef` ou utilisez les outils EF de Visual Studio.

- Conflits de migration : utilisez `dotnet ef migrations remove` pour annuler une migration non souhaitée ou résolvez les conflits manuellement.
