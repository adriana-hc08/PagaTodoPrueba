SISTEMA DE GESTIÓN DE TAREAS - DOCUMENTACIÓN

DESCRIPCIÓN
Sistema de gestión de tareas desarrollado en ASP.NET Core MVC con arquitectura en capas.

ARQUITECTURA
Utilice la arquitectura N capas para poder mejorar la organización, escalabilidad y mantenimiento del software, en donde hice uso de las siguientes capas
- SL: Capa de Servicios (Servicio de APIREST)
- PL: Capa de Presentación(Controller y Vistas)
- BL: Capa de Negocios (Lógica de negocio)
- DL: Capa de Datos (Repositorios + Entity Framework)
- ML: Capa de Modelos (Modelos compartidos)

PATRONES IMPLEMENTADOS
1. Repository Pattern - Abstrae el acceso a datos
2. Unit of Work - Maneja transacciones
3. Dependency Injection - Reduce acoplamiento

PRERREQUISITOS
- .NET Core 8.0 SDK
- SQL Server 
- Visual Studio 2022 

🛠️ INSTALACIÓN

1. CLONAR REPOSITORIO

git clone [https://github.com/adriana-hc08/PagaTodoPrueba]


2. CONFIGURAR BASE DE DATOS
Para poder realizar las diferentes acciones del Sistema es necesario cambiar la cadena de conexión en el appsettings tanto del SL como la del PL la parte del appsettings es connectionString en donde le tiene que cambiar la cadena para que funcione correctamente


3. Comandos a ejecutar para la migración

Una vez realizados los cambios de la cadena de conexión ejecutar los siguientes comandos

Add-Migration InicialCreate -StartupProject PL -Project DL
Update-Database

4. Ejecutar el programa

