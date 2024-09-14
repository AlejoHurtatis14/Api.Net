### Versiones

  - ASP.Net Version 8

### Docs Clonar de Proyecto

  - Abrir proyecto en Microsoft Visual Studio preferiblemente
  - Ir a `Herramientas` -> `Administrador de paquetes NuGet` -> `Consola del Administrador de paquetes`
  - Agregamos la migración de la base de datos con `Add-Migration DataProductsDesired`
  - Actualizamos la base de datos con los modelos `Update-Database`
  - Corremos el proyecto desde el boton `https` del IDE
  - Abrira una ventana en el navegador con la ruta `https://localhost:7039/swagger/index.html` para ver la documentación

### Docs Api

  Si obtiene un error con la base de datos ejecute:
  - `Update-Database -Migration 0`
  - `Remove-Migration`
  - Finalmente realice las migraciones nuevamente para iniciar la base de datos.

### Docs Api

- Consultar listado de categorías de productos (GET)

  `https://localhost:7039/api/category`

  Se obtienen las categorias de los productos creadas por defecto.

- Consultar listado de productos (GET)

  `https://localhost:7039/api/products`

  Obtenemos todos los productos registrados

- Consultar detalle de un producto (GET)

  `https://localhost:7039/api/products/{id}`

  Obtener la información de un solo productos

- Agregar un producto como "producto deseado" (POST)

  `https://localhost:7039/api/desired-product`

  Agregamos un producto a la lista de deseados solo enviando el id del usuario y el id del producto

- Eliminar un producto deseado (DELETE)

  `https://localhost:7039/api/desired-product/{id}`

  Eliminamos un producto de la lista de deseados

- Consultar listado de productos deseados de un usuario  (GET)

  `https://localhost:7039/api/desired-product/{id}`

  Obtenemos los productos deseados de un usuario en especifico
