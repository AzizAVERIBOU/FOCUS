# Progression FOCUS

## Vue d’ensemble

Infrastructure Docker : Postgres/Redis OK ; MinIO bloque (images retirees de Docker Hub).
AuthService : skeleton, health, EF, User Secrets, AuthDbContext, entite User,
migration InitialCreate appliquee (table Users).
Prochain : register + hash mot de passe (apres correctifs doc/infra).

## Infra

### Récit : stack locale Docker

- **Statut :** Fait
- **Objectif :** Mettre en place l'infrastructure necessaire pour lancer le stack correctement
- **Fait :** des files dockers rajoutes avec docker compose pour orchestrer tout ca
- **Reste :** Vault Docker plus tard ; images MinIO : basculer vers quay.io ou rebuild (retirees de Docker Hub)

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
- **Fait :** `AuthDbContext` dans Infrastructure/Persistence ; `AddDbContext` + `UseNpgsql` + `GetConnectionString` dans Program.cs (Scoped)
- **Reste :** -

### Récit : Entite User

- **Statut :** fait
- **Objectif :** modeliser l'identite auth minimale sans profil (pas d'adresse)
- **Fait :** `User` dans Domain/Entities (Id Guid, Email, PasswordHash, CreatedAt) ; `DbSet<User> Users` dans AuthDbContext
- **Reste :** -

### Récit : Premiere migration EF

- **Statut :** fait
- **Objectif :** versionner le schema Postgres a partir du modele EF
- **Fait :** `dotnet-ef` + package Design ; `migrations add InitialCreate` ; `database update` → table `Users` + `__EFMigrationsHistory`
- **Reste :** prochaines migrations quand le modele evolue

## Notes perso

### Recit : fichier de progression

- **Statut :** en cours
- **Objectif :** documenter tout ce que je fais
- **Fait :** fichier a la racine ou je documente chaque recit correctement
- **Reste :** documenter chaque recit avant et apres que ca soit fait

## UserService / TeamService / … (quand ça existe)

## Glossaire entretien

- **DI :** le framework fournit les dependances (ex. AuthDbContext) au lieu de `new`
- **Scoped :** une instance par requete HTTP (defaut AddDbContext)
- **Singleton :** une instance pour toute l'app — a eviter pour DbContext
- **Migration :** script versionne qui fait evoluer le schema DB selon le modele EF
- **PasswordHash :** on stocke un hash, jamais le mot de passe en clair
