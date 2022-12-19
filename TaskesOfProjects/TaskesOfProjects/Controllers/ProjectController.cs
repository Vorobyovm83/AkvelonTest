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
    [ApiController]
    public class ProjectController : CommonController
    {
        //Use depending
        private readonly new ProjectsContext _context;
        public ProjectController(ProjectsContext context):base(context)
        {
            _context = context;
        }

        //Work with DB for Project

        //Create Project: [controller]/create
        [Route("[controller]/create")]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateNewProject(Project project)//string ProjectName )
        {
            _context.Projects.Add(project);
            //Done new project create
            return await TrySaveChangesAsync();
        }

        //View Projects: [controller]/view
        [Route("[controller]/view")]
        [HttpGet]
        public async Task<IEnumerable<Project>> ViewAllProject()
        {
            return await _context.Projects.Include(pr => pr.PrTasks).ToListAsync();
        }

        //Edit Project by ProjectId: [controller]/edit
        [Route("[controller]/edit")]
        [HttpPut]
        public async Task<HttpResponseMessage> EditProject(Project project)
        {
            _context.Entry(project).State = EntityState.Modified;
            //Done project update
            return await TrySaveChangesAsync();
        }

        //Delet Project by ProjectId: [controller]/deleteById?ProjectId=
        [Route("[controller]/deleteById")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteProjectById(int ProjectId)
        {
            var ProjectDelet = _context.Projects.Find(ProjectId);
            if (ProjectDelet != null)
            {
                _context.Projects.Remove(ProjectDelet);
                //Done project delete
                return await TrySaveChangesAsync();
            }
            else
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }
        //Delet Project: [controller]/delete
        [Route("[controller]/delete")]
        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteProject(Project project)
        {
            _context.Projects.Remove(project);
            //Done project delete
            return await TrySaveChangesAsync();
        }
        //View all tasks of project by ProjectId: [controller]/viewtasks?ProjectId=
        //if ProjectId isn't exist to return HttpStatusCode.BadRequest
        [Route("[controller]/viewtasks")]
        [HttpGet]
        public async Task<IEnumerable<PrTask>> ViewAllTasksOfProject(int ProjectId)
        {
            var ProjectView = _context.Projects.Find(ProjectId);
            if (ProjectView is null)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null!;
            }
            return await _context.PrTasks.Include(pr => pr.Project).Where(pr => pr.ProjectId == ProjectId).ToListAsync();
        }
    }
}
