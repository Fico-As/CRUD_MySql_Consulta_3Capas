using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//agregamos los siguiente para usar las restriciones de los metadatos
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
// para crear este fichero ir a la carpeta modelo clic derecho agregar / clase =PetModel
namespace CRUD_Forms_SQLServer_MVP.Modelo
{
    public class PetModel
    {
        //campos
        private int id;
        private string nombre;
        private string tipo;
        private string color;
        //creamos los campos de forma automatica seleccinando todos los campos
        //clic derecho seleccionar acciones rapidas/encapsular campos (pero usando campos)
        
        //usar las restricciones:
        /* click sobre el proyecto / agregar / referencias -> en la ventana
         * seleccionar framework buscar en el buscados datoan -> System.Component.DataAnnotations
         * marcar el unico resultado y aceptar
         */
        //ahora usamos las restricciones de las anotaciones
        [DisplayName("Id Mascota")]
        public int Id { get => id; set => id = value; }
        [DisplayName("Nombre")]
        [Required(ErrorMessage ="Nombre de la mascota requerido")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="El nombre debe tener entre 3 y 50 caracteres")]
        public string Nombre { get => nombre; set => nombre = value; }
        [DisplayName("Tipo")]
        [Required(ErrorMessage = "El tipo de mascota requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El tipo  debe tener entre 3 y 50 caracteres")]
        public string Tipo { get => tipo; set => tipo = value; }
        [DisplayName("Color")]
        [Required(ErrorMessage = "El Color de la mascota requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El color debe tener entre 3 y 50 caracteres")]
        public string Color { get => color; set => color = value; }
    }
}
