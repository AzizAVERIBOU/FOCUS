# Infrastructure

Docker Compose et configs pour l'environnement local / déploiement.

## Démarrer

Depuis la racine du repo :

```bash
cp .env.example .env
docker compose -f infra/docker-compose.yml --env-file .env up -d
```
