# wayni-backend-test

Aplicación MVC en capas con un CRUD de Usuarios.
Los usuarios tienen las siguientes propiedades:

- Nombre: string, requerido
- Apellido: string, requerido
- DNI: string, requerido, único, de 8 caracteres

Se documentaron los posibles errores de negocio existentes mediante el uso del tipo `Result` y `Option`, y definiendo errores 
personalizados como `DNIDuplicatedError` entre otros.

Se usó tailwindcss para generar los estilos CSS de la interfaz de la aplicación.

## Despliegue con Docker Compose

Levantar la aplicación es muy facíl con Docker Compose, debes tener docker engine y docker compose instalados.

```bash
docker compose up --build
```

Esto levantará los siguientes servicios:

- userscrud-app: Servidor HTTP en .NET 8.0 (Principal)
- mysql: Base de datos utilizada
- postcss: Servicio en background que genera los estilos CSS de manera automatica (tailwindcss, etc)

Luego de levantar los servicios, se realizarán las migraciones a la base de datos de manera automatica.

## Estructura del proyecto

El proyecto backend cuenta con 4 capas:

- Domain: Describe la logica del negocio y las entidades
- Infrastructure: Implementa la base de datos, migraciones, repositorios, etc
- Application: Contiene los procesos de negocio como el CRUD
- WebUI: Maneja la interfaz de usuario a través de un modelo MVC sobre un servidor HTTP

## Despliegue manual

En caso de no contar con Docker o Docker Compose, se puede desplegar la aplicación de manera manual.
Necesita contar con .NET 8.0, MySQL 8.0 y Node >= 16.0.0

- Levante MySQL con usuario y contraseña `root` en el puerto `3306`
- Ejecute el proceso de Postcss con el comando `cd UsersCRUD.WebUI/wwwroot/ && npm run watch:tailwind`
- Modifique la cadena de conexión de la base de datos en `appsettings.json`, cambie el servidor de `mysql` a `localhost` o `.`
- Levante el servidor http con el comando `dotnet run --project=UsersCRUD.WebUI`
