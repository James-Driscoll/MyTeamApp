﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTeam.Data.IDAO;

namespace MyTeam.Data.DAO
{
    public class TeamDAO : ITeamDAO
    {

        // Declare local data context.
        private MyTeamDataEntities _context;

        // CONSTRUCTOR ===============================================================
        public TeamDAO()
        {
            _context = new MyTeamDataEntities();
        }

        // CREATE ====================================================================
        // addTeam : Adds a new team record to the database.
        public void addTeam(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        // READ ======================================================================
        // getTeams : Rreturns a list of all registered teams.
        public IList<Team> getTeams()
        {
            IQueryable<Team> _teams;
            _teams = from team
                     in _context.Teams
                     select team;
            return _teams.ToList<Team>();
        }

        // getStudentTeams :  Returns list of teams that the signed in user is a member of.
        //public IList<Team> getStudentTeams(int studentId) {
        //    IQueryable<Team> _teams;
        //    _teams = from team
        //             in _context.Teams
        //             where
        //                team.FK_Member1 == studentId ||
        //                team.FK_Member2 == studentId ||
        //                team.FK_Member3 == studentId ||
        //                team.FK_Member4 == studentId ||
        //                team.FK_Member5 == studentId ||
        //                team.FK_Member6 == studentId ||
        //                team.FK_Member7 == studentId ||
        //                team.FK_Member8 == studentId ||
        //                team.FK_Member9 == studentId ||
        //                team.FK_Member10 == studentId       
        //             select team;
        //    return _teams.ToList<Team>();
        //}

        // getTeam : Returns a single team.
        public Team getTeam(int id)
        {
            IQueryable<Team> _team;
            _team = from team
                    in _context.Teams
                    where team.Id == id
                    select team;
            return _team.ToList<Team>().First();
        }

        // UPDATE ====================================================================
        // editTeam : Updates one team in the database.
        public void editTeam(Team team)
        {
            Team record = (from rec
                           in _context.Teams
                           where rec.Id == team.Id
                           select rec).ToList<Team>().First();
            record.Name = team.Name;
            _context.SaveChanges();
        }

        // DELETE ====================================================================
        // deleteTeam : Removed one team from the database.
        public void deleteTeam(Team team)
        {
            _context.Teams.Remove(team);
            _context.SaveChanges();
        }

    }

}
