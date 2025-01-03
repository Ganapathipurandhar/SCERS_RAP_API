﻿using SCERS_RAP.Type;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCERS_RAP.Services
{
	public class RAPService
	{
		public RPAData RPAData { get; set; }
		private PreLoad pl;
		private WorkService ws;
		private FactorService fs;
		private CalcService cs;
		private LetterService l;

		public RAPService() 
		{
			RPAData = new RPAData();			
		}

		public string Run() 
		{
			var timer = new Stopwatch();
			timer.Start();

			RPAData.PreLoad = AppServices.JsonToObject<PreLoad>(@".\Data\PreLoad.json");			
			postPreLoad();
			AppServices.Print("******************************************************");
			AppServices.Print("Pre Load Data");
			AppServices.Print("******************************************************");
			AppServices.PrintProperty(RPAData.PreLoad);
			ws = new WorkService(RPAData);
			ws.CalculateWork();
			AppServices.Print("******************************************************");
			AppServices.Print("Work Sheet Data");
			AppServices.Print("******************************************************");
			AppServices.PrintProperty(RPAData.Work);
			fs = new FactorService(RPAData);
			fs.CalculateFactor();
			//Save Life Table to CSV File
			AppServices.ListToCsv(RPAData.LifeTables, @".\Output\LifeTable.csv");
			AppServices.Print("******************************************************");
			AppServices.Print("Factor Data");
			AppServices.Print("******************************************************");
			AppServices.PrintProperty(RPAData.Factor);
			AppServices.Print("******************************************************");
			AppServices.Print("Calc Data");
			AppServices.Print("******************************************************");
			cs = new CalcService(RPAData);
			cs.ComputeCalc();
			AppServices.PrintProperty(RPAData.Calc);
			AppServices.Print("******************************************************");
			AppServices.Print("Letter Data");
			AppServices.Print("******************************************************");
			l = new LetterService(RPAData);
			l.BuildLetterData();
			//l.PrintLetter(RPAData.Letter, @".\Data\Template.html");
			HTMLService.MergeObjToTemplate(RPAData.Letter, @".\Data\Template.html", @".\Output\Letter.html");
			AppServices.PrintProperty(RPAData.Letter);
			AppServices.ObjectToJson<RPAData>(RPAData, @".\Output\Output.json");

			timer.Stop();
			TimeSpan elapsedTime = timer.Elapsed;
			AppServices.Print($"Program execution time: {elapsedTime.TotalSeconds} seconds");
			return $"Program execution time: {elapsedTime.TotalSeconds} seconds";
		}

		private void postPreLoad() 
		{
			pl = RPAData.PreLoad;
			//Calculate Age
			calculateAgeAtRetirement(pl.DateOfRetirement, pl.MemberInfo);
			calculateAgeAtRetirement(pl.DateOfRetirement, pl.BeneficiaryInfo);
		}


		private void calculateAgeAtRetirement(DateTime retirementDate, PersonInfo member)
		{
			var totalDays = (retirementDate - member.DOB).TotalDays;
			member.Age = Math.Round((totalDays / 365.25), 2);
			member.Age1by4 = AppServices.Floor(member.Age,0.25);
			member.AgeTrunc = Math.Truncate(member.Age);
		}
		

	}
}
