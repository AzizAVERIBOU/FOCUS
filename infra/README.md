# Infrastructure

Docker Compose et configs pour l'environnement local / déploiement.

## Démarrer

Depuis la racine du repo :

```bash
cp .env.example .env
docker compose -f infra/docker-compose.yml --env-file .env up -d
```

## Ports

| Service    | Conteneur         | Port hôte | Port conteneur | Usage              |
|------------|-------------------|-----------|----------------|--------------------|
| PostgreSQL | `focus_postgres`  | 5432      | 5432           | Base de données    |
| Redis      | `focus_redis`     | 6379      | 6379           | Cache / files d'attente |
| MinIO API     | `focus_minio_server` | 9000 | 9000 | Stockage objet (S3) |
| MinIO Console | `focus_minio_server` | 9001 | 9001 | Interface web       |

Vérifier que les services tournent :

```bash
docker compose -f infra/docker-compose.yml --env-file .env ps
```
