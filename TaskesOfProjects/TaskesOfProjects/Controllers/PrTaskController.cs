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

namespace TaskesOfProjects.Controllers
{
    [ApiController]
    public class PrTaskController : CommonController
    {
        //Use depending
        private readonly new ProjectsContext _context;
        public PrTaskController(ProjectsContext context):base(context)
        {
            _context = context;
        }

        //Work with DB for PrTask

        //Create PrTask: [controller]/create
        [Route("[controller]/create")]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateNewPrTask(PrTask prTask)
        {
            _context.PrTasks.Add(prTask);
            //Done new prTask create
            return await TrySaveChangesAsync();
        }

        //View PrTask: [controller]/view
        [Route("[controller]/view")]
        [HttpGet]
        public async Task<IEnumerable<PrTask>> ViewAllPrTasks()
        {
            return await _context.PrTasks.ToListAsync();
        }

        //Edit PrTask: [controller]/edit
        [Route("[controller]/edit")]
        [HttpPut]
        public async Task<HttpResponseMessage> EditPrTask(PrTask prTask)
        {
            _context.Entry(prTask).State = EntityState.Modified;
            //Done project update
            return await TrySaveChangesAsync();
        }

        //Delet PrTask by PrTaskId: [controller]/delete?PrTaskId=
        [Route("[controller]/deleteById")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeletePrTaskById(int PrTaskId)
        {
            var PrTaskDelet = _context.PrTasks.Find(PrTaskId);
            if (PrTaskDelet != null)
            {
                _context.PrTasks.Remove(PrTaskDelet);
                //Done prTask delete
                return await TrySaveChangesAsync();
            }
            else
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
        //Delet PrTask: [controller]/delete
        [Route("[controller]/delete")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeletePrTask(PrTask prTask)
        {
            _context.PrTasks.Remove(prTask);
            //Done prTask delete
            return await TrySaveChangesAsync();
        }

    }
}
