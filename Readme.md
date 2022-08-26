# Proyecto
Proyecto web que se encarga de administrar productos y categorias

El proyecto consta de 3 capas :

*Capa DataLayer se encarga de la interaccion con la base de datos, contiene los modelos de datos de cada tabla y contiene los repositorios donde se realizan las operaciones a la base de datos

*Capa BusinessLayer se encarga de tomar los datos proporcionados por capa DataLayer y procesarlos para la capa de presentacion y en caso de agregar mas logica a la aplicacion este seria el lugar indicado para hacerlo. Esta capa contiene los servicios para administrar los metodos que se podran utilizar en la presentacion y los ViewModel para manejar las peticiones del usuario.

*Capa Presentacion(CatalogoOnline) se encarga de la interaccion con el usuario. Consta de 1 controlador para cada entidad con los metodos que seran proporcionados al usuario y las vistas para determinar la forma en que se mostraran los datos al usuario.

Los servicios contienes todas las funcionalidades CRUD para cada entidad o modulos pero en la pagina web solo contiene interaccion con los productos y un apartado para crear categorias. La pagina web contiene un listado de todos los productos, un buscador de productos, un filtrado por categoria y un apartado para crear productos y categorias.

Las consultas a la base de datos fueron realizadas en ADODB con stores procedures.

Las peticiones fueron hechas con ajax usando jquery y las validaciones de los formularios fueron hechas con jquery validate.

## Uso

1.Ejecutar el script de la base de dato.

2.Iniciar el programa

3.Crear categorias para poder asignarselas a los productos

4.Crear productos con los campos requeridos

* Para usar el buscador escriba el nombre del producto que desea buscar y presione enter

* Para filtar por categoria debe seleccionar la categoria y presionar el boton filter 

