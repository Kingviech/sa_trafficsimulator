///////////////////////////////////////////////////////////
//  IAgentRepository.cs
//  Implementation of the Interface IAgentRepository
//  Generated by Enterprise Architect
//  Created on:      15-Apr-2017 16:36:47
//  Original author: David
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using Datamodel;
namespace Repositories {
	/// <summary>
	/// IAgentRepository
	/// </summary>
	public interface IAgentRepository         {

		/// <summary>
        /// Creates new agent.
        /// </summary>
        /// <param name="agent">Agent to create</param>
        /// <returns>Created agent</returns>
		Datamodel.Agent Create(Agent agent);

		/// <summary>
        /// Delete agent.
        /// </summary>
        /// <param name="agent">Agent to delete</param>
		void Delete(Agent agent);

		/// <summary>
        /// Get Agent by id.
        /// </summary>
        /// <param name="agentId">Id of agent</param>
        /// <returns>Agent or null</returns>
		Datamodel.Agent GetAgent(int agentId);

		/// <summary>
        /// Get agents by position id.
        /// </summary>
        /// <param name="positionIds">Id of position</param>
        /// <returns>List of agents or null</returns>
		IEnumerable<Agent> GetAgentsForPositionIds(int positionIds);

        /// <summary>
        /// Get all agents.
        /// </summary>
        /// <returns>List of agents or null</returns>
        IEnumerable<Agent> GetAllAgents();

		/// <summary>
        /// Updates given agent.
        /// </summary>
        /// <param name="agent">Agent to update</param>
        /// <returns>Updated agent</returns>
		Datamodel.Agent Update(Agent agent);

        /// <summary>
        /// Update a list of agents.
        /// </summary>
        /// <param name="agents">List of agents</param>
        void BulkUpdate(IEnumerable<Agent> agents);
	}//end IAgentRepository

}//end namespace Repositories