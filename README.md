# Proyecto de Gestión de Tareas

Este proyecto es una API de gestión de tareas desarrollada con .NET Core 8. Permite a los usuarios crear, leer, actualizar y eliminar tareas, así como asociarlas a usuarios específicos.

## Características

- CRUD completo para tareas
- Autenticación y autorización de usuarios
- Asociación de tareas a usuarios
- Filtrado de tareas por usuario
- Implementación de DTOs para una transferencia de datos eficiente
- Uso de Entity Framework Core para la persistencia de datos

## Requisitos previos

- .NET 8.0 SDK
- SQL Server (o tu base de datos preferida compatible con Entity Framework Core)
- Visual Studio 2022 o Visual Studio Code (opcional, pero recomendado)

## Configuración del proyecto

1. Clona el repositorio:
   ```
   git clone https://github.com/tu-usuario/tu-repositorio.git
   ```

2. Navega al directorio del proyecto:
   ```
   cd tu-repositorio
   ```

3. Restaura las dependencias:
   ```
   dotnet restore
   ```

4. Actualiza la cadena de conexión en `appsettings.json` con los detalles de tu base de datos.

5. Aplica las migraciones para crear la base de datos:
   ```
   dotnet ef database update
   ```

## Ejecución del proyecto

1. Compila el proyecto:
   ```
   dotnet build
   ```

2. Ejecuta la aplicación:
   ```
   dotnet run
   ```

3. La API estará disponible en `https://localhost:5001` (o el puerto que hayas configurado).

## Uso de la API

### Endpoints principales

- `GET /api/tareas`: Obtiene todas las tareas
- `GET /api/tareas/{id}`: Obtiene una tarea específica
- `POST /api/tareas`: Crea una nueva tarea
- `PUT /api/tareas/{id}`: Actualiza una tarea existente
- `DELETE /api/tareas/{id}`: Elimina una tarea

### Autenticación

La API utiliza autenticación basada en JWT. Para obtener un token:

1. Registra un usuario en `POST /api/auth/register`
2. Inicia sesión en `POST /api/auth/login` para obtener un token
3. Incluye el token en el encabezado `Authorization` de tus solicitudes como `Bearer {tu-token}`

## Estructura del proyecto

- `Controllers/`: Contiene los controladores de la API
- `Models/`: Define las entidades del dominio
- `DTOs/`: Objetos de transferencia de datos
- `Services/`: Lógica de negocio
- `Data/`: Contexto de Entity Framework y configuraciones
- `Migrations/`: Migraciones de Entity Framework Core

## Contribución

Las contribuciones son bienvenidas. Por favor, abre un issue para discutir cambios mayores antes de crear un pull request.

## Licencia

[MIT](https://choosealicense.com/licenses/mit/)
