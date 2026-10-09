# FOCUS

Monorepo FOCUS — application mobile (Kotlin Multiplatform) et microservices .NET.

## Structure

```text
FOCUS-Project/
├── apps/
│   └── mobile/          # Application KMP (Android / iOS)
├── services/            # Microservices .NET (Auth, User, …)
├── Tests/               # Tests unitaires par service
├── infra/               # Docker Compose, configs d'infra
├── PROGRESSION.md       # Suivi des recits / avancement
├── .env.example         # Variables d'environnement (modele)
└── README.md
```

## Prérequis

- Git
- Docker (pour l'infra locale)
- .NET 9 SDK (pour les services)

## Démarrage rapide

1. Copier les variables d'environnement :

   ```bash
   cp .env.example .env
   ```

2. Lancer l'infra locale.

   Pour Auth / User (Postgres suffit) :

   ```bash
   docker compose -f infra/docker-compose.yml --env-file .env up -d postgres
   ```

   Le stack complet (`up -d`) inclut MinIO : images actuellement indisponibles
   sur Docker Hub — details dans `infra/README.md`.

Details ports, schemas Postgres (`auth` / `users`) : voir `infra/README.md`.

## CI

Chaque push et chaque pull request declenchent le workflow **CI**
(lint Markdown / YAML, `dotnet format` sur les projets .NET).
Les branches `main`, `develop` et `staging` exigent un CI vert avant merge.
