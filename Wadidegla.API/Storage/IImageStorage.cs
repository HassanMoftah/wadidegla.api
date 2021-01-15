using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wadidegla.API.Storage
{
    public interface IImageStorage
    {
         bool AddImage(HttpRequest request,int id);
         string GetFileExtention(HttpRequest request);
    }
}
