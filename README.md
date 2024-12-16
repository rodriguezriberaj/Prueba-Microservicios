# Proyecto de Microservicios con DDD y CQRS

Este proyecto consta de dos microservicios diseñados siguiendo el enfoque **Domain-Driven Design (DDD)** y el patrón **CQRS (Command Query Responsibility Segregation)**. Se ha estructurado para mantener el dominio aislado de las dependencias externas, asegurando un diseño robusto y escalable.

---

## 📁 **Estructura del Proyecto**

- **Microservicio Client**  
  Encargado de gestionar las entidades y operaciones relacionadas con los clientes.  

- **Microservicio Movement Account**  
  Maneja las operaciones y movimientos relacionados con las cuentas.  

- **Proyecto Shared**  
  Contiene el código base y las implementaciones relacionadas con la mensajería mediante colas. Este proyecto genera un paquete NuGet reutilizable.  

- **Paquete NuGet (Generado por Shared)**  
  Librería compartida que encapsula funcionalidades comunes, como la integración con RabbitMQ.  

---

## 📝 **Descripción del Proyecto**

Este proyecto ha sido desarrollado bajo el enfoque **DDD**, separando claramente el dominio del resto de las capas y manteniendo la lógica de negocio independiente. 

Se utiliza el patrón **CQRS** para diferenciar las operaciones de lectura (**Queries**) y las operaciones de escritura (**Commands**).  

Los **Casos de Uso** se encuentran en la capa de aplicación, organizados de forma modular y acorde con las responsabilidades del sistema.

Cada **Microservicio** tiene su propia Base de Datos y se crean automáticamente.

---

## ▶️ **Instrucciones para Ejecutar el Proyecto**

1. **Configurar la Cadena de Conexión**  
   Modifique la cadena de conexión de la base de datos en caso de que sea necesario. Por defecto, está configurada para usar `localhost`.

2. **Ejecutar RabbitMQ**  
   Ejecute el servidor RabbitMQ utilizando Docker. Use el siguiente comando:  
   ```bash
   docker run -d --hostname rabbitmq-host --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
   
3. En la carpeta de proyecto de API de cada microservicio  ejecutar dotnet run.
4. En cada carpeta raíz de microservcio existe un archivo json de postman para probar las apis
