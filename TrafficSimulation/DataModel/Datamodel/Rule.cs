///////////////////////////////////////////////////////////
//  Rule.cs
//  Implementation of the Class Rule
//  Generated by Enterprise Architect
//  Created on:      15-Apr-2017 16:36:48
//  Original author: David
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Datamodel {
	public class Rule {

		public Rule(){

		}

		~Rule(){

		}

		public IEnumerable<int> CheckPositionIds
        {
			get;
			set;
		}

		public int Id{
			get;
			set;
		}

		public bool IsDynamicRule{
			get;
			set;
		}

		/// <summary>
		/// -1 = inherit from Position
		/// </summary>
		public int MaxVelocity{
			get;
			set;
		}

		public int PositionId{
			get;
			set;
		}

        /*
		public RuleType RuleType{
			get;
			set;
		}
        */
		public int X{
			get;
			set;
		}

		public int Y{
			get;
			set;
		}

	}//end Rule

}//end namespace Datamodel