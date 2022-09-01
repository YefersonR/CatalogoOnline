# Proyecto
El proyecto consta de 2 applicaciones web y 1 capa que se encarga de la logica :

Proyecto web parte administrativa se encarga de administrar productos, categorias y usuarios
Proyecto web catalogo online muestra los productos activos y premite crear nuevos productos a los usuarios

Capa Logic 
* DAL : se encarga de la interaccion con la base de datos, contiene los modelos de datos de cada tabla y contiene los repositorios donde se realizan las operaciones a la base de datos

* BLL : se encarga de tomar los datos proporcionados por DAL y procesarlos para las applicaciones web y es el lugar indicado para agregar mas logica la aplicacion. Esta capa contiene los servicios para administrar los metodos que se podran utilizar en la presentacion y los ViewModel para manejar las peticiones del usuario.

Las consultas a la base de datos fueron realizadas en ADODB con stores procedures.
Las peticiones fueron hechas con ajax usando jquery y las validaciones de los formularios fueron hechas con jquery validate.

## Pasos para su implementacion

1.Ejecutar el script de la base de dato.

2.Cambiar el servidor de la base de dato en el ConectionString que se encuentra en la capa Logic>DAL>DBConnection

### Web Administrativa
    * Seleccionar el modulo que quiere utilizar
    * Puede crear un elemento de ese modulo el cual se mostrara en el listado
    * Puede eliminar un elemento y/o modificarlo en un formulario modal

    Nota: debe crear categorias antes que productos para luego poder asignarsela 

### Web Catalogo
    * Ingrese las credenciales del usuario ya creado en la parte administrativa
    * Puede filtrar los productos seleccionando la categoria y presionando el boton filter
    * Puede filtrar los productos escribiendo el nombre y presionando la letra enter
    * Puede crear un producto completando los campos requeridos