using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Veterinary.Web.Helpers
{
    public class ImageHelper : IImageHelper
    {
        public async Task<string> UploadImageAsync(IFormFile imageFile)
        {
            //para que el nombre de la imagen no se cruce se crea un gid

            var guid = Guid.NewGuid().ToString();
            var file = $"{guid}.jpg";

            var path = Path.Combine(
               Directory.GetCurrentDirectory(),
               "wwwroot\\images\\Pets",
               file);

            //copiar del local al servidor
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }

            return path = $"~/images/Pets/{file}";
        }
    }
}
