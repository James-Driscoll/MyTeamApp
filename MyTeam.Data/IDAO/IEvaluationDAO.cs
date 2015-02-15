﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeam.Data.IDAO
{
    
    interface IEvaluationDAO
    {
        
        // CREATE ====================================================================
        // addEvaluation
        void addEvaluation(Evaluation evaluation);

        // READ ======================================================================
        // getEvaluations
        IList<Evaluation> getEvaluations();

        // getEvaluation
        Evaluation getEvaluation(int id);

        // UPDATE ====================================================================
        // editEvaluation
        void editEvaluation(Evaluation evaluation);

        // DELETE ====================================================================
        // deleteEvaluation
        void deleteEvaluation(Evaluation evaluation);

    }

}
