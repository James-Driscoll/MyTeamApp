﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyTeam.Data;
using MyTeam.Services;
using MyTeam.Services.Service;

namespace MyTeam.Controllers
{
    public class WorkTaskController : Controller
    {
        
        // Declare a local work task service.
        private WorkTaskService _worktaskService;

        // Declare a local evaluation service.
        private EvaluationService _evaluationService;

        public WorkTaskController()
        {
            _worktaskService = new WorkTaskService();
            _evaluationService = new EvaluationService();
        }

        // CREATE ===================================================================
        // addWorkTask
        [HttpGet]
        public ActionResult addWorkTask(string FK_Project)
        {
            return View();
        }

        [HttpPost]
        public ActionResult addWorkTask(WorkTask worktask)
        {
            View();
            _worktaskService.addWorkTask(worktask);
            return RedirectToAction("getWorkTasks", "WorkTask");
        }

        // addEvaluation
        [HttpGet]
        public ActionResult addEvaluation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addEvaluation(Evaluation evaluation)
        {
            View();
            _evaluationService.addEvaluation(evaluation);
            return RedirectToAction("getWorkTasks", "WorkTask");
        }


        // READ =====================================================================
        // getWorkTasks
        public ActionResult getWorkTasks(int project)
        {
            return View(_worktaskService.getWorkTasks(project));
        }

        // getWorkTask
        public ActionResult getWorkTask(int id)
        {
            return View(_worktaskService.getWorkTask(id));
        }


        // UPDATE ===================================================================
        // editWorkTask
        [HttpGet]
        public ActionResult editWorkTask(int id)
        {
            WorkTask record = _worktaskService.getWorkTask(id);
            return View(record);
        }

        [HttpPost]
        public ActionResult editWorkTask(WorkTask worktask)
        {
            try
            {
                _worktaskService.editWorkTask(worktask);
                return RedirectToAction("getProjects", "Project");
            }
            catch
            {
                return View();
            }
        }


        // DELETE ===================================================================
        // deleteWorkTask
        [HttpGet]
        public ActionResult deleteWorkTask(int id)
        {
            WorkTask WorkTask = _worktaskService.getWorkTask(id);
            return View(WorkTask);
        }

        [HttpPost]
        public ActionResult deleteWorkTask(WorkTask worktask, int id)
        {
            try
            {
                WorkTask _worktask = _worktaskService.getWorkTask(id);
                _worktaskService.deleteWorkTask(_worktask);
                return RedirectToAction("getProjects", "Project");
            }
            catch
            {
                return View();
            }
        }

    }

}
