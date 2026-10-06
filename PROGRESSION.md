# Progression FOCUS

## Vue d’ensemble

Infrastructure Docker : Postgres/Redis OK ; MinIO bloque (Hub / Quay).
Une seule DB `focus` avec schemas `auth` et `users`.
AuthService + UserService : skeleton, health, EF, User Secrets, DbContext, migrations.
Contrat erreurs API : ProblemDetails active sur les deux Apis (.NET).
Prochain : register Auth + hash mot de passe.

## Infra

### Récit : stack locale Docker

- **Statut :** Fait
- **Objectif :** Mettre en place l'infrastructure necessaire pour lancer le stack correctement
- **Fait :** des files dockers rajoutes avec docker compose pour orchestrer tout ca ; demarrage partiel Postgres documente
- **Reste :** Vault Docker plus tard ; workaround postgres seul ; Quay 401 anonyme ; S3 local = carte plus tard

### Recit : S3 local

- **Statut :** a faire
- **Objectif :** stockage objet S3-compatible local (remplacer MinIO community)
- **Fait :** constat Hub retire + Quay 401 anonyme ; Auth n'en a pas besoin aujourd'hui
- **Reste :** evaluer Garage / LocalStack / autre ; documenter ports ; fermer ticket MinIO

### Recit : Schemas Postgres (1 DB, N services)

- **Statut :** fait
- **Objectif :** isoler Auth et User sans multiplier les instances Postgres (cout deploy)
- **Fait :** schema `users` (UserService) ; migration Auth `MoveToAuthSchema` → `auth.Users` ; meme Database=`focus`
- **Reste :** documenter schemas dans infra/README si pas deja fait

## AuthService

### Récit : Skeleton Clean Architecture + tests

- **Statut :** fait
- **Objectif :** mettre en place la structure de la clean architecture
- **Fait :** couches Api / Application / Domain / Infrastructure + tests dans Tests/
- **Reste :** -

### Récit : endpoint santé

- **Statut :** fait
- **Objectif :** verifier que l'api fonctionne sans logique metier
- **Fait :** `HealthController`, `GET /health` → `{ status: "OK" }`
- **Reste :** -

### Récit : Package EF/Npgsql

- **Statut :** fait
- **Objectif :** ajouter le package EF/Npgsql compatible net9.0
- **Fait :** package Npgsql.EntityFrameworkCore.PostgreSQL 9.0.4 sur Infrastructure ; aligne net9.0
- **Reste :** -

### Récit : Config connexion Postgres (sans secret dans Git)

- **Statut :** fait
- **Objectif :** configurer la connexion Postgre sans secrets dans git
- **Fait :** chaine retiree de launchSettings (GitGuardian) ; User Secrets init + set `ConnectionStrings:DefaultConnection` (base focus) ; `UserSecretsId` dans le csproj Api
- **Reste :** Vault = plus tard

### Récit : Mise en place du DbContext

- **Statut :** fait
- **Objectif :** creer AuthDbContext et le brancher a Postgres via DI
- **Fait :** `AuthDbContext` dans Infrastructure/Persistence ; `AddDbContext` + `UseNpgsql` + `GetConnectionString` dans Program.cs (Scoped) ; `HasDefaultSchema("auth")`
- **Reste :** -

### Récit : Entite User (compte)

- **Statut :** fait
- **Objectif :** modeliser l'identite auth minimale sans profil (pas d'adresse)
- **Fait :** `User` dans Domain/Entities (Id Guid, Email, PasswordHash, CreatedAt) ; `DbSet<User> Users` dans AuthDbContext
- **Reste :** -

### Récit : Premiere migration EF

- **Statut :** fait
- **Objectif :** versionner le schema Postgres a partir du modele EF
- **Fait :** `dotnet-ef` + package Design ; `migrations add InitialCreate` ; `database update` → table Users ; puis `MoveToAuthSchema` → `auth.Users`
- **Reste :** prochaines migrations quand le modele evolue

## UserService

### Recit : Skeleton Clean Architecture + tests

- **Statut :** fait
- **Objectif :** reproduire la structure Auth pour valider la comprehension
- **Fait :** Api / Application / Domain / Infrastructure + `UserService.sln` ; tests dans `Tests/UserService.UnitTests`
- **Reste :** -

### Recit : endpoint sante

- **Statut :** fait
- **Objectif :** smoke test Api UserService
- **Fait :** `HealthController`, `GET /api/health` → `OK`
- **Reste :** -

### Recit : Package EF/Npgsql

- **Statut :** fait
- **Objectif :** brancher EF Core sur Postgres (Infrastructure)
- **Fait :** Npgsql.EntityFrameworkCore.PostgreSQL 9.0.4 sur Infrastructure
- **Reste :** -

### Recit : Config connexion Postgres (User Secrets)

- **Statut :** fait
- **Objectif :** connection string hors Git, meme DB focus
- **Fait :** User Secrets Api ; `ConnectionStrings:DefaultConnection` → Database=focus
- **Reste :** -

### Recit : Entite profil User

- **Statut :** fait
- **Objectif :** profil sans mot de passe, lie au compte Auth
- **Fait :** `AuthUserId` (PK), `FirstName?`, `LastName?` ; pas de PasswordHash
- **Reste :** sync profil apres register Auth (plus tard)

### Recit : UserDbContext + migration schema users

- **Statut :** fait
- **Objectif :** persister le profil dans le schema `users`
- **Fait :** `UserDbContext` + DI ; `HasDefaultSchema("users")` ; `HasKey(AuthUserId)` ; migration InitialCreate → `users.Users`
- **Reste :** -

## Contrat API (transverse)

### Recit : Format erreurs ProblemDetails

- **Statut :** fait
- **Objectif :** meme forme JSON d'erreur sur les Apis .NET (status HTTP + body standard)
- **Fait :** `AddProblemDetails()` dans AuthService.Api et UserService.Api ; demo Auth `ErrorController` + `return Problem(...)` (404) ; verifie au navigateur
- **Reste :** handler d'exceptions global plus tard ; retirer ou isoler la demo ErrorController ; recopier demo User si besoin

## Notes perso

### Recit : fichier de progression

- **Statut :** en cours
- **Objectif :** documenter tout ce que je fais
- **Fait :** fichier a la racine ou je documente chaque recit correctement
- **Reste :** documenter chaque recit avant et apres que ca soit fait

## TeamService / CardService / mobile (quand ca existe)

## Glossaire entretien

- **DI :** le framework fournit les dependances (ex. AuthDbContext) au lieu de `new`
- **Scoped :** une instance par requete HTTP (defaut AddDbContext)
- **Singleton :** une instance pour toute l'app — a eviter pour DbContext
- **Migration :** script versionne qui fait evoluer le schema DB selon le modele EF
- **PasswordHash :** on stocke un hash, jamais le mot de passe en clair
- **Schema Postgres :** isolation logique multi-services sur une seule instance DB
- **AuthUserId :** cle de lien profil UserService ↔ compte AuthService
- **ProblemDetails :** contrat d'erreur HTTP standard (RFC 7807) fourni par ASP.NET
