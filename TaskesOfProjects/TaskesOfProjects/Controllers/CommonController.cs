using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using ProjectsTaskes.Models;
using System.Collections.Generic;
using System.Reflection.Metadata;
using TaskesOfProjects.Data;
using Microsoft.EntityFrameworkCore.Design;
using System.Net;
using System.Text.Json.Serialization;

namespace TaskesOfProjects.Controllers
{
    public class CommonController : ControllerBase
    {
        //Use depending
        internal readonly ProjectsContext _context;
        public CommonController(ProjectsContext context)
        {
            _context = context;
        }

        internal async Task<HttpResponseMessage> TrySaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                //Done saveChanges
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.NotModified);
            }
        }
    }
}
