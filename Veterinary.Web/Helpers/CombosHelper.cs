//Los helpers son como librerias
//5

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Veterinary.Web.Data;

namespace Veterinary.Web.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _dataContext;//con esta variable y constructor se llama a la base

        //crear constructor
        public CombosHelper(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IEnumerable<SelectListItem> GetComboPetTypes()
        {
            //debe devolver una lista
            //creo objeto este es un metodo antiguo
            //var list = new List<SelectListItem>();
            //foreach (var petType in _dataContext.PetTypes)
            //{
            //    list.Add(new SelectListItem
            //    {
            //        Text = petType.Name,
            //        Value = $"{petType.Id}"
            //    });
            //}

            // metodo nuevo mediante linq para convertir una coleccion en otra coleccion

            var list = _dataContext.PetTypes.Select(pt => new SelectListItem
            {
                Text = pt.Name,
                Value = $"{pt.Id}"
            }).OrderBy(pt => pt.Text)
            .ToList();


            list.Insert(0, new SelectListItem
            {
                Text = "Select a pet type...",
                Value = "0"
            });

            return list;

        }

        public IEnumerable<SelectListItem> GetComboServiceTypes()
        {
            var list = _dataContext.ServiceTypes.Select(st => new SelectListItem
            {
                Text = st.Name,
                Value = $"{st.Id}"
            }).OrderBy(st => st.Text)
         .ToList();


            list.Insert(0, new SelectListItem
            {
                Text = "Select a service type...",
                Value = "0"
            });

            return list;
        }
    }
}
