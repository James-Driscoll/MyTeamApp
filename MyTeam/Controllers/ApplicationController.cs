﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTeam.Data;
using MyTeam.Services;

namespace MyTeam.Controllers
{
    
    public abstract class ApplicationController : Controller
    {

        // Declare services.
        public MyTeam.Services.Service.EvaluationService _evaluationService;
        public MyTeam.Services.Service.ProjectService _projectService;
        public MyTeam.Services.Service.TeamService _teamService;
        public MyTeam.Services.Service.UserService _userService;
        public MyTeam.Services.Service.WorkTaskService _worktaskService;

        public Dictionary<int, string> _teamDictionary;

        // CONSTRUCTOR ==============================================================
        public ApplicationController()
        {
            _evaluationService = new MyTeam.Services.Service.EvaluationService();
            _projectService = new MyTeam.Services.Service.ProjectService();
            _teamService = new MyTeam.Services.Service.TeamService();
            _userService = new MyTeam.Services.Service.UserService();
            _worktaskService = new MyTeam.Services.Service.WorkTaskService();

            ViewBag.statuses = _teamService.getTeams();

            var statusList = new SelectList(new[] 
            {
                new { ID = "Not Started", Name = "Not Started" },
                new { ID = "Started", Name = "Started" },
                new { ID = "Getting There", Name = "Getting There" },
                new { ID = "Nealy Done", Name = "Nealy Done" },
                new { ID = "Finished", Name = "Finished" }
            },
            "ID", "Name", 1);

            ViewData["statusList"] = statusList;

        }

    }

}
