﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SCERS_RAP.Type
{
	/// <summary>
	/// 1994 Group Annuity Mortality Table (also known as the UP-94 Mortality Table) for males
	/// 1981 General Disability Mortality Table
	/// 1994 Group Annuity Mortality Table(also known as the UP-94 Mortality Table)
	/// 1981 Safety Disability Mortality Table
	/// GAM: Group Annuity Mortality Table 
	/// https://www.soa.org/globalassets/assets/library/research/transactions-of-society-of-actuaries/1990-95/1995/january/tsa95v4722.pdf
	/// Page 22 : 1994 Group Annuity Mortality Table(also known as the UP-94 Mortality Table) for males
	/// I couldn't find 1981 General Disability Mortality Table
	/// </summary>
	public class DisGAM
	{
		private int age;		
		private double disGenqx;
		private double disSafeqx;

		public int Age { get => age; set => age = value; }		
		public double DisGenqx { get => disGenqx; set => disGenqx = value; }
		public double DisSafeqx { get => disSafeqx; set => disSafeqx = value; }
	}
}
