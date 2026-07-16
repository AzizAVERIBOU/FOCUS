# FOCUS

Monorepo FOCUS — application mobile (Kotlin Multiplatform) et microservices .NET.

## Structure

```
FOCUS-Project/
├── apps/
│   └── mobile/          # Application KMP (Android / iOS)
├── services/            # Microservices .NET
├── infra/               # Docker Compose, configs d'infra
├── .env.example         # Variables d'environnement (modèle)
└── README.md
```

## Prérequis

## Démarrage rapide

1. Copier les variables d'environnement :

```bash
cp .env.example .env
```

2. Lancer l'infra locale :

```bash
docker compose -f infra/docker-compose.yml up -d
```
