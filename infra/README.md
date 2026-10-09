# Infrastructure

Docker Compose et configs pour l'environnement local / déploiement.

## Démarrer

Depuis la racine du repo :

```bash
cp .env.example .env
docker compose -f infra/docker-compose.yml --env-file .env up -d
```

## Demarrage partiel (Auth / DB)

AuthService n'a besoin que de Postgres :

```bash
docker compose -f infra/docker-compose.yml --env-file .env up -d postgres
```

## Base de donnees / schemas

Une seule instance Postgres, database `focus` (variables `.env`) :

- schema `auth` → tables AuthService (ex. `auth.Users`)
- schema `users` → tables UserService (ex. `users.Users`)

Chaque service a son DbContext et ses migrations EF.
Pas de jointures SQL cross-schema entre services (isolation logique, un seul cout d'instance).

## Ports

| Service       | Conteneur            | Port hôte | Port conteneur | Usage                   |
|---------------|----------------------|-----------|----------------|-------------------------|
| PostgreSQL    | `focus_postgres`     | 5432      | 5432           | Base de données         |
| Redis         | `focus_redis`        | 6379      | 6379           | Cache / files d'attente |
| MinIO API     | `focus_minio_server` | 9000      | 9000           | Stockage objet (S3)     |
| MinIO Console | `focus_minio_server` | 9001      | 9001           | Interface web           |

Vérifier que les services tournent :

```bash
docker compose -f infra/docker-compose.yml --env-file .env ps
```

## MinIO / S3 local

Images `minio/*` retirees de Docker Hub. Quay : 401 en pull anonyme.
Ne pas lancer le stack complet sans besoin S3. Suite = carte / recit "S3 local".
