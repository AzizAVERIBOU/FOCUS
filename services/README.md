# Microservices .NET

Chaque service suit une Clean Architecture :
Api / Application / Domain / Infrastructure.

## Services

| Service       | Role                                 | Etat     |
|---------------|--------------------------------------|----------|
| `AuthService` | Compte, auth (register/login a venir)| En cours |
| `UserService` | Profil utilisateur (`AuthUserId`)    | En cours |

Les tests unitaires vivent sous `Tests/` a la racine du monorepo
(ex. `Tests/AuthService.UnitTests`).

Base partagee Postgres `focus`, schemas separes : voir `infra/README.md`.
