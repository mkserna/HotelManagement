# Prueba de Desempeño Módulo .NET

## Información General

**Team Leader:** Javier Cómbita Téllez  
**Grupo:** Bernners Lee

Esta prueba de desempeño tiene como objetivo desarrollar una API RESTful que permita a un hotel gestionar sus reservas de manera eficaz, con un enfoque en las funcionalidades para los empleados.

## Reglas de la Prueba

- **Comunicación:** Está prohibido hablar o comunicarse de cualquier forma con otros estudiantes durante el examen.
- **Integridad Académica:** Cualquier forma de trampa, incluido el plagio, copia o uso de material no autorizado, resultará en una calificación de cero en el examen y puede llevar a sanciones adicionales según las políticas de RIWI.
- **Idioma:** Todo el código debe ser 100% en inglés, incluyendo los comentarios. La única excepción es la información en los registros de la base de datos.
- **Tecnologías Permitidas:**
  - CLI de .NET
  - Visual Studio Code
  - Git
  - GitHub
  - IA bajo los lineamientos descritos en el documento "Reglamento sobre el uso de IA".
- **Material Permitido:** Solo se permite material de apoyo como diapositivas, ejercicios realizados en clase y notas del cuaderno. Se permite acceso a:
  - [Riwi.io Medellín](https://github.com)
  - [Guía de C#: lenguaje administrado de .NET](https://learn.microsoft.com/es-es/dotnet/csharp/)
  - [Documentación de .NET](https://learn.microsoft.com/es-es/dotnet/)

## Entrega

Una vez finalizada la prueba, se debe subir una carpeta comprimida a la plataforma Moodle, nombrada como `PruebaNET_NombreApellido del coder`, que debe contener:
- La carpeta con el contenido del proyecto en formato `.zip`.
- Un README bien estructurado (este archivo), que incluya toda la información relevante del proyecto y el enlace al repositorio de GitHub.

La hora máxima de entrega es a las 14:00 horas. Las pruebas enviadas después de esta hora NO serán consideradas.

## Introducción

En el competitivo sector de la hotelería, la gestión eficiente de reservas es esencial para ofrecer un servicio de calidad. Esta prueba de desempeño busca desarrollar una API RESTful que permita a un hotel gestionar sus reservas de manera eficaz, enfocándose en las funcionalidades para los empleados.

### Objetivos Clave

- **Gestión de Reservas:** Permitir a empleados y huéspedes crear, consultar, actualizar y eliminar reservas.
- **Disponibilidad de Habitaciones:** Facilitar la consulta de habitaciones disponibles y sus tipos para tomar decisiones informadas.
- **Detalles de Huéspedes:** Proporcionar información de los huéspedes para mejorar la atención.
- **Interfaz en Swagger:** Garantizar una experiencia intuitiva y bien documentada para facilitar el uso de la API.

## Requisitos de la API

1. **Introducción API:** Implementar una página de bienvenida en la ruta base de la API mediante middleware. Si no se hace, la API debe cargar directamente la interfaz de Swagger al iniciar.
   
2. **Base de Datos con MySQL:** Utilizar MySQL como motor de base de datos y configurar migraciones para la creación de la base de datos desde el código. La estructura de la base de datos debe coincidir con el modelo proporcionado.
   
3. **Variables de Entorno:** Implementar la configuración del acceso a la base de datos y otras configuraciones sensibles mediante variables de entorno.
   
4. **Población de Datos:** Crear datos semilla para la entidad `RoomType` con al menos cuatro tipos de habitación predefinidos:
   - **Habitación Simple:** 
     - Descripción: Una acogedora habitación básica con una cama individual.
     - Capacidad: 1 persona
     - Precio: $50/noche
   - **Habitación Doble:** 
     - Descripción: Ofrece flexibilidad con dos camas individuales o una cama doble.
     - Capacidad: 2 personas
     - Precio: $80/noche
   - **Suite:** 
     - Descripción: Espaciosa y lujosa, con una cama king size y una sala de estar separada.
     - Capacidad: 2 personas
     - Precio: $150/noche
   - **Habitación Familiar:** 
     - Descripción: Diseñada para familias, con espacio adicional y varias camas.
     - Capacidad: 4 personas
     - Precio: $200/noche

   El hotel cuenta con un total de 5 pisos y 50 habitaciones disponibles.

5. **JWT (JSON Web Tokens) para Autenticación:** Integrar un sistema de autenticación con JWT para proteger los endpoints sensibles.

6. **Estructura de Controladores:** Aplicar el principio de Responsabilidad Única (S de SOLID) organizando los controladores según las operaciones HTTP.

7. **Uso de DTOs:** Implementar DTOs para asegurar que las entidades del dominio no se expongan directamente a los usuarios.

8. **Validación de Datos:** Incluir validaciones de datos usando DataAnnotations o Fluent API.

9. **Relaciones entre Entidades:** Crear y gestionar las siguientes entidades:
   - `Room`
   - `Booking`
   - `Guest`
   - `RoomType`
   - `Employee`

10. **Repositorio y Servicios:** Aplicar el patrón de repositorios y servicios para manejar la lógica de negocio y el acceso a la base de datos.

11. **Documentación con Swagger:** Documentar todos los endpoints utilizando Swagger.

## Endpoints

Implementar un total de 16 endpoints:

### Endpoints Desbloqueados (Sin Seguridad)
1. `POST /api/v1/auth/login`
2. `GET /api/v1/rooms/available`
3. `GET /api/v1/room_types`
4. `GET /api/v1/room_types/{id}`
5. `GET /api/v1/rooms/status`
6. `POST /api/v1/guest`

### Endpoints Protegidos (Requieren Autenticación JWT)
1. `GET /api/v1/bookings/search/{identification_number}`
2. `GET /api/v1/bookings/{id}`
3. `POST /api/v1/bookings`
4. `DELETE /api/v1/bookings/{id}`
5. `GET /api/v1/rooms`
6. `GET /api/v1/rooms/{id}`
7. `GET /api/v1/guests`
8. `GET /api/v1/guests/{id}`
9. `DELETE /api/v1/guests/{id}`
10. `GET /api/v1/guests/search/{keyword}`
11. `PUT /api/v1/guests/{id}`
12. `GET /api/v1/rooms/occupied`

## Enlace al Repositorio de GitHub

[Enlace al repositorio](https://github.com/tu_usuario/tu_repositorio)

