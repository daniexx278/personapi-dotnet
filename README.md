# Laboratorio 1 — Implementación de Monolito con Patrón MVC y DAO

Proyecto desarrollado para la asignatura de Arquitectura de Software.

El laboratorio consiste en la implementación de una aplicación monolítica utilizando ASP.NET Core MVC, Entity Framework Core y SQL Server, aplicando el patrón de arquitectura MVC y el patrón DAO/Repository para el acceso a datos.

---

# Tecnologías utilizadas

- ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- SQL Server Express
- SQL Server Management Studio (SSMS)
- Swagger / OpenAPI
- Git y GitHub
- Visual Studio Community 2022

---

# Arquitectura implementada

El proyecto implementa una arquitectura monolítica basada en:

- Patrón MVC (Model - View - Controller)
- Patrón DAO / Repository
- Entity Framework Core Database First
- REST API
- Swagger para documentación y pruebas de endpoints

---

# Modelo de datos

El sistema administra información relacionada con personas, profesiones, estudios y teléfonos.

## Entidades principales

- Persona
- Profesion
- Estudio
- Telefono

## Relaciones

- Una persona puede tener múltiples teléfonos.
- Una persona puede tener múltiples estudios.
- Una profesión puede estar asociada a múltiples estudios.

---

# Funcionalidades implementadas

## CRUD completo MVC

Se implementaron operaciones:

- Crear
- Consultar
- Editar
- Eliminar

para las entidades:

- Personas
- Profesiones
- Estudios
- Teléfonos

---

# API REST

El proyecto incluye controladores REST para consumo mediante API.

---

# Swagger

Swagger fue integrado para:

- Visualizar endpoints
- Probar peticiones HTTP
- Validar respuestas JSON

---

# Estructura del proyecto

```text
personapi-dotnet/
│
├── Controllers/
│   ├── PersonasController.cs
│   ├── PersonasMvcController.cs
│   ├── ProfesionsController.cs
│   ├── ProfesionsMvcController.cs
│   ├── EstudiosController.cs
│   ├── EstudiosMvcController.cs
│   ├── TelefonosController.cs
│   └── TelefonosMvcController.cs
│
├── Interfaces/
│   ├── IPersonaRepository.cs
│   ├── IProfesionRepository.cs
│   ├── IEstudioRepository.cs
│   └── ITelefonoRepository.cs
│
├── Repositories/
│   ├── PersonaRepository.cs
│   ├── ProfesionRepository.cs
│   ├── EstudioRepository.cs
│   └── TelefonoRepository.cs
│
├── Models/
│   └── Entities/
│       ├── Persona.cs
│       ├── Profesion.cs
│       ├── Estudio.cs
│       ├── Telefono.cs
│       └── PersonaDbContext.cs
│
├── Views/
│
├── wwwroot/
│
├── appsettings.json
├── Program.cs
└── personapi-dotnet.csproj
```
---
# Ejecución del proyecto

## Desde Visual Studio

1. Abrir la solución del proyecto.
2. Configurar el proyecto principal como proyecto de inicio.
3. Ejecutar utilizando una de las siguientes opciones:

- IIS Express

o

- HTTPS

---

## Desde terminal

Ejecutar el siguiente comando en la raíz del proyecto:

```bash
dotnet run
```

---

# Acceso a Swagger

Al ejecutar el proyecto, Swagger estará disponible en:

```text
https://localhost:xxxx/swagger
```

---

# Acceso a vistas MVC

Ejemplos de rutas disponibles:

```text
https://localhost:xxxx/PersonasMvc
https://localhost:xxxx/ProfesionsMvc
https://localhost:xxxx/EstudiosMvc
https://localhost:xxxx/TelefonosMvc
```

---

# Patrón DAO / Repository

El acceso a datos fue desacoplado mediante:

- Interfaces
- Repositories
- Inyección de dependencias

Esto permite:

- Separación de responsabilidades
- Mejor mantenibilidad
- Escalabilidad
- Bajo acoplamiento

---

# Despliegue

Se realizaron pruebas de despliegue local utilizando ASP.NET Core MVC y SQL Server Express.

El sistema fue validado correctamente mediante:

- CRUD MVC
- Swagger
- Persistencia SQL Server
- Navegación entre módulos
- Control de versiones

---

# Control de versiones

El proyecto utiliza:

- Git
- GitHub
- Commits versionados
- TAG final de entrega
