# Vývoj a spuštění

## Systémové požadavky na vývoj

- docker
- git

Projekt používá .NET 8.0, je tedy třeba si na lokálním počítači nainstalovat SDK,
které obsahuje i CLI tool dotnet. .NET SDK lze stáhnout například zde: https://dotnet.microsoft.com/en-us/download/dotnet/8.0

## Docker compose

Projekt obsahuje soubor `docker-compose.yml`, který obsahuje definice pro služby, které tento projekt potřebuje.

Pro spuštění těchto služeb v dockeru je nutné spustit příkaz:
### Development
```bash
docker compose up
```
případně
```bash
docker compose up -d
```
pro spuštění na pozadí.

### Production
```bash
docker compose -f .\docker-compose-production.yml up
```
případně
```bash
docker compose -f .\docker-compose-production.yml up -d
```
pro spuštění na pozadí.

> [!NOTE]
> Starší verze dockeru nemusí příkaz `compose` obsahovat, v takovém případě stačí nahradit `docker compose` za `docker-compose`.

