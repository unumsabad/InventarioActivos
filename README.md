# Inventario de Activos - API

API REST para gestionar activos tecnológicos (computadores, discos, licencias), hecha como proyecto de aprendizaje de .NET.

## Tecnologías
- C# y .NET 10 (ASP.NET Core Web API)
- Entity Framework Core (Code First, migraciones)
- SQL Server Express

## Funcionalidades
- CRUD completo de activos (GET, POST, PUT, DELETE)
- Inyección de dependencias
- Métodos asíncronos (async/await)
- Códigos de estado HTTP correctos (200, 201, 204, 400, 404)

## Cómo ejecutarlo
1. Instalar .NET SDK 10 y SQL Server Express
2. Clonar el repositorio
3. Ajustar la cadena de conexión en `appsettings.json`
4. Ejecutar `dotnet ef database update`
5. Ejecutar `dotnet run`

## Contexto
Este proyecto está inspirado en el sistema de inventario de activos tecnológicos que desarrollé con React, Node.js y MySQL. Lo construí para aprender .NET, con apoyo de guías y herramientas de IA, y lo voy a seguir mejorando (capa de servicios, DTOs y pruebas).
