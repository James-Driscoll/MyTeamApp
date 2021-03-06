﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyTeam.Services.IService;
using MyTeam.Data;
using MyTeam.Data.DAO;

namespace MyTeam.Services.Service
{
    
    public class TeamService : ITeamService
    {
        
        private TeamDAO _teamDAO;
        public TeamService()
        {
            _teamDAO = new TeamDAO();
        }

        // CREATE ===================================================================
        // addTeam
        public void addTeam(Team team)
        {
            _teamDAO.addTeam(team);
        }

        // addTeamMember : Adds a new TeamMember record.
        public void addTeamMember(TeamMember teamMember)
        {
            _teamDAO.addTeamMember(teamMember);
        }

        // READ =====================================================================
        // getTeams
        public IList<Team> getTeams()
        {
            return _teamDAO.getTeams();
        }

        // getStudentTeams : Returns list of teams that the signed in user is a member of.
        public IList<Team> getStudentTeams(string id)
        {
            return _teamDAO.getStudentTeams(id);
        }

        // getTeamMembers : Returns an IList of all members that are part of a particular team.
        public IList<TeamMember> getTeamMembers(int id)
        {
            return _teamDAO.getTeamMembers(id);
        }

        // getTeam
        public Team getTeam(int id)
        {
            return _teamDAO.getTeam(id);
        }

        // UPDATE ===================================================================
        // editTeam
        public void editTeam(Team team)
        {
            _teamDAO.editTeam(team);
        }

        // DELETE ===================================================================
        // deleteTeam
        public void deleteTeam(Team team)
        {
            _teamDAO.deleteTeam(team);
        }

    }

}
