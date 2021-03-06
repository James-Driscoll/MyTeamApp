﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTeam.Data.IDAO;
using System.ComponentModel.DataAnnotations;

namespace MyTeam.Data.DAO
{
    
    public class ProjectDAO : IProjectDAO
    {

        private MyTeamDataEntities _context;

        public ProjectDAO()
        {
            _context = new MyTeamDataEntities();
        }

        // CREATE ====================================================================
        // addProject
        public void addProject(Project project)
        {
            project.Status = "Not Started";
            project.PercentageCompleted = 0;

            project.StartDate = DateTime.Today;
            DateTime now = DateTime.Now;
            DateTime due = project.EndDate ?? DateTime.Now;
            TimeSpan ts = due - now;
            project.Duration = Math.Abs(ts.Days);

            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        // READ ======================================================================
        // getProjects
        public IList<Project> getProjects(int id)
        {
            IQueryable<Project> _projects;
            _projects = from project
                        in _context.Projects
                        where project.FK_Team == id
                        select project;
            return _projects.ToList<Project>();
        }

        // getProject
        public Project getProject(int id)
        {
            IQueryable<Project> _project;
            _project = from project
                       in _context.Projects
                       where project.Id == id
                       select project;
            return _project.ToList<Project>().First();
        }

        // UPDATE ====================================================================
        // editProject
        public void editProject(Project project)
        {
            Project record = (from rec
                              in _context.Projects
                              where rec.Id == project.Id
                              select rec).ToList<Project>().First();
            record.FK_Team = project.FK_Team;
            record.Title = project.Title;
            record.Description = project.Description;
            record.Status = project.Status;
            record.PercentageCompleted = project.PercentageCompleted;
            record.EndDate = project.EndDate;

            DateTime start = record.StartDate;
            DateTime due = project.EndDate ?? DateTime.Now;
            TimeSpan ts = due - start;
            record.Duration = Math.Abs(ts.Days);

            _context.SaveChanges();
        }

        // DELETE ====================================================================
        // deleteProject
        public void deleteProject(Project project)
        {
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }

    }

}

