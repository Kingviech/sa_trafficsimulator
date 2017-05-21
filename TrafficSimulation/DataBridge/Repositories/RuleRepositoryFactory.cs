///////////////////////////////////////////////////////////
//  RuleRepositoryFactory.cs
//  Implementation of the Class RuleRepositoryFactory
//  Generated by Enterprise Architect
//  Created on:      15-Apr-2017 16:36:48
//  Original author: David
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Repositories;
using DataBridge;
using DataBridge.Services;

namespace Repositories {
	public abstract class RuleRepositoryFactory {

		public static IRuleRepository CreateRepository()
        {
            return new RuleService();
        }

	}//end RuleRepositoryFactory

}//end namespace Repositories