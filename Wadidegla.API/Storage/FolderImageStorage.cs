using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Wadidegla.API.Storage
{
    public class FolderImageStorage : IImageStorage
    {
        public bool AddImage(HttpRequest request,int id)
        {
            try
            {


                var image = request.Form.Files["Image"];
                string ImagName = $"{id}{Path.GetExtension(image.FileName)}";
                string ImageLocation = Path.Combine(Directory.GetCurrentDirectory(), "ProductImages") + "/" + ImagName;
                if (File.Exists(ImageLocation))
                    File.Delete(ImageLocation);
                using (var stream = new FileStream(ImageLocation, FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public string GetFileExtention(HttpRequest request)
        {
            try
            {


                var image = request.Form.Files["Image"];
                return Path.GetExtension(image.FileName);
            }
            catch
            {
                return null;
            }
        }
    }
}
