///////////////////////////////////////////////////////////
//  MapRepositoryFactory.cs
//  Implementation of the Class MapRepositoryFactory
//  Generated by Enterprise Architect
//  Created on:      15-Apr-2017 16:36:48
//  Original author: David
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using Repositories;
using DataBridge.Services;

namespace Repositories {
	public abstract class MapRepositoryFactory {

		public static IMapRepository CreateRepository(){

			return new MockedMapService();
		}

	}//end MapRepositoryFactory

}//end namespace Repositories