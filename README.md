# RealEstateApp.WebApp
# 🏠 RealEstateApp

Plataforma de gestión de propiedades inmobiliarias desarrollada con **ASP.NET Core MVC** y **ASP.NET Core Web API**, siguiendo la **arquitectura Onion** y los patrones **CQRS** y **Mediator**. Conecta clientes, agentes inmobiliarios y administradores en un mismo sistema.

> Proyecto académico desarrollado en el Instituto Tecnológico de Las Américas (ITLA).

---

## ✨ Funcionalidades

### 🌐 Visitantes
- Catálogo de propiedades disponibles, de la más reciente a la más antigua.
- Búsqueda por código de propiedad.
- Filtros combinables por tipo de propiedad, rango de precio, habitaciones y baños.
- Detalle de cada propiedad con galería de imágenes, mejoras y datos de contacto del agente.
- Listado de agentes con buscador por nombre.
- Registro como cliente o agente.

### 👤 Cliente
- Marcar y desmarcar propiedades como **favoritas**.
- **Chat** con el agente responsable de cada propiedad.
- Envío de **ofertas** por una propiedad y seguimiento de su estado (pendiente, aceptada o rechazada).

### 🧑‍💼 Agente
- Gestión de sus propiedades: crear, editar y eliminar, con hasta 4 imágenes y un código único de 6 dígitos.
- Conversaciones con varios clientes por propiedad.
- Respuesta a ofertas: al aceptar una, las demás pendientes se rechazan automáticamente y la propiedad pasa a **vendida**.
- Edición de su perfil.

### 🛡️ Administrador
- Dashboard con indicadores de propiedades, agentes, clientes y desarrolladores.
- Activación, desactivación y eliminación de agentes.
- Mantenimiento de administradores y desarrolladores.
- Mantenimiento de tipos de propiedad, tipos de venta y mejoras.

### 🔌 Web API
- API REST protegida con **JWT** y roles (Administrador y Desarrollador).
- Endpoints de propiedades, agentes, tipos de propiedad, tipos de venta y mejoras.
- Endpoints construidos con **CQRS + MediatR** y validaciones con **FluentValidation** mediante Behaviors.
- Documentación interactiva con **Swagger**.

---

## 🛠️ Tecnologías

| Área | Tecnologías |
|---|---|
| Backend | C#, ASP.NET Core MVC, ASP.NET Core Web API |
| Base de datos | SQL Server, Entity Framework Core (Code First) |
| Seguridad | ASP.NET Identity, JWT |
| Patrones | CQRS, Mediator (MediatR), Repository Pattern |
| Validaciones | FluentValidation, ViewModels con Data Annotations |
| Mapeo | AutoMapper |
| Manejo de errores | Global Exception Handler con Problem Details (RFC 7807) |
| Pruebas | xUnit (pruebas unitarias e integración) |
| Documentación API | Swagger |
| Interfaz | Bootstrap |

---

## 🏗️ Arquitectura

El proyecto sigue la **arquitectura Onion**, organizada en capas:

- **Core / Domain** → Entidades y reglas del dominio.
- **Core / Application** → Lógica de negocio, Commands y Queries (CQRS), DTOs, validaciones y servicios.
- **Infrastructure / Identity** → Autenticación, roles y generación de JWT.
- **Infrastructure / Persistence** → DbContext, repositorios genéricos y migraciones.
- **Infrastructure / Shared** → Servicios compartidos, como el envío de correos.
- **Presentation / WebApp** → Aplicación web MVC.
- **Presentation / WebApi** → API REST.
- **Tests** → Pruebas unitarias de Commands, Queries y servicios, y pruebas de integración de repositorios.

---

## 🚀 Cómo ejecutarlo

### Requisitos
- [.NET SDK](https://dotnet.microsoft.com/download) (versión del proyecto)
- SQL Server
- Visual Studio 2022 (recomendado)

### Pasos

1. **Clona el repositorio**
   ```bash
   git clone https://github.com/cesarvictorinoeip-source/RealEstateApp.git
   ```

2. **Configura el `appsettings.json`** de la WebApp y la WebApi:
   - `ConnectionStrings:DefaultConnection` → tu servidor de SQL Server.
   - Configuración de correo → tu correo y contraseña de aplicación.
   - Configuración de JWT (en la WebApi) → tu propia clave secreta.

3. **Aplica las migraciones** desde la Consola del Administrador de paquetes, seleccionando como proyecto predeterminado las capas de **Persistence** e **Identity**:
   ```powershell
   Update-Database
   ```

4. **Ejecuta el proyecto** de la WebApp (o la WebApi para usar la API).

Al iniciar, el sistema crea automáticamente los roles y los usuarios por defecto.

### Pruebas
Para ejecutar las pruebas automatizadas:
```bash
dotnet test
```
O desde Visual Studio en **Prueba → Ejecutar todas las pruebas**.

### Rutas útiles
- **Swagger:** `/swagger` (en la Web API)

---

## 👨‍💻 Autor

**César Tomás Victorino**
Estudiante de Desarrollo de Software — ITLA

- GitHub: [@cesarvictorinoeip-source](https://github.com/cesarvictorinoeip-source)
