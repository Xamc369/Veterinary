//1. PASO CREO UN MODELO DE LA ENTIDAD PET
//2. LLENAR LOS CAMPOS DE LA MASCOTA HEREDA DE LA CLASE PET O DE LA ENTIDAD PET
//3. IR A CONTROLADOR Y CREAR UN DETALLE PARA PET(COPIO DE ARRIBA Y CAMIO A ADDPET ESTA EN
//OWNERCONTROLLER)
//4. CREAMOS LA CLASE COMBOHELPER PARA PODER DE AHI SACAR LOS COMBOS CON CLICK DERECHO EN PLUBLIC CLASS COMBOHELPER
//SE PUEDE CREAR LA INTERFAZ ACCIONES Y REFACTORIZACIONES EXTRAER INTERFAZ Y CREAR

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Veterinary.Web.Data.Entities;

namespace Veterinary.Web.Models
{
    public class PetViewModel: Pet
    {
        //a. Propiedad de tipo id
        public int OwnerId { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory")]
        [Display(Name ="Pet Type")]
        //NOTACION: los valores validos del 1 no desde cero para que cero sea seleccionar
        [Range(1, int.MaxValue, ErrorMessage ="You must select a pet type.")]

        //b. es la propiedad de la relacion con la tabla pet type
        public int PetTypeId { get; set; }

        [Display(Name ="Image")]

        //c. seleccione un objeto de tipo iformfile el archivo que yo selecciono
        //permite seleccionar un nombre que no se repita
        public IFormFile ImageFile { get; set; }

        //d. Lista de mascotas, origen de datos para el combo box, valor que almacena y valor que muestra
        public IEnumerable<SelectListItem> PetTypes { get; set; }

    }
}
