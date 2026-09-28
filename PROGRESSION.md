# Progression FOCUS

## Vue d’ensemble

Infrastructure Docker en place. AuthService : skeleton, health, package EF,
et connexion Postgres via User Secrets (sans secret dans Git).
Prochain : DbContext.

## Infra

### Récit : stack locale Docker

- **Statut :** Fait
- **Objectif :** Mettre en place l'infrastructure necessaire pour lancer le stack correctement
- **Fait :** des files dockers rajoutes avec docker compose pour orchestrer tout ca
- **Reste :** Vault Docker plus tard

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
- **Reste :** brancher la chaine via DbContext (EF) ; Vault = plus tard

## Notes perso

### Recit : fichier de progression

- **Statut :** en cours
- **Objectif :** documenter tout ce que je fais
- **Fait :** fichier a la racine ou je documente chaque recit correctement
- **Reste :** documenter chaque recit avant et apres que ca soit fait

## UserService / TeamService / … (quand ça existe)
