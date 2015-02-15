﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTeam.Data.IDAO;

namespace MyTeam.Data.DAO
{

    public class EvaluationDAO : IEvaluationDAO
    {

        private MyTeamDataEntities _context;

        public EvaluationDAO()
        {
            _context = new MyTeamDataEntities();
        }

        // CREATE ====================================================================
        // addEvaluation
        public void addEvaluation(Evaluation evaluation)
        {
            _context.Evaluations.Add(evaluation);
            _context.SaveChanges();
        }

        // READ ======================================================================
        // getEvaluations
        public IList<Evaluation> getEvaluations()
        {
            IQueryable<Evaluation> _evaluations;
            _evaluations = from evaluation
                          in _context.Evaluations
                     select evaluation;
            return _evaluations.ToList<Evaluation>();
        }

        // getEvaluation
        public Evaluation getEvaluation(int id)
        {
            IQueryable<Evaluation> _evaluation;
            _evaluation = from evaluation
                          in _context.Evaluations
                    where evaluation.PK_EvaluationID == id
                    select evaluation;
            return _evaluation.ToList<Evaluation>().First();
        }

        // UPDATE ====================================================================
        // editEvaluation
        public void editEvaluation(Evaluation evaluation)
        {
            Evaluation record = (from rec
                                 in _context.Evaluations
                                 where rec.PK_EvaluationID == evaluation.PK_EvaluationID
                                 select rec).ToList<Evaluation>().First();
            record.FK_Assessor = evaluation.FK_Assessor;
            record.FK_Task = evaluation.FK_Task;
            _context.SaveChanges();
        }

        // DELETE ====================================================================
        // deleteEvaluation
        public void deleteEvaluation(Evaluation evaluation)
        {
            _context.Evaluations.Remove(evaluation);
            _context.SaveChanges();
        }

    }
}