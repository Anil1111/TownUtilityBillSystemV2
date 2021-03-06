﻿using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TownUtilityBillSystemV2.Models.Exceptions;
using TownUtilityBillSystemV2.Models.MeterModels;

namespace TownUtilityBillSystemV2.Tests
{
	[TestClass]
	public class MeterUnitTest
	{
		[TestMethod]
		[ExpectedException(typeof(InvalidBuildingIdException))]
		public void CheckGetMetersForBuildingWithWrongBuildingId()
		{
			int wrongBuildingid = -1;
			var meterModel = new MeterModel();

			meterModel.GetMetersForBuilding(wrongBuildingid);
		}

		[TestMethod]
		public void CheckGetMetersForBuildingWithCorrectBuildingId_typeTest()
		{
			int correctBuildingid = 100;
			var meterModel = new MeterModel();

			meterModel.GetMetersForBuilding(correctBuildingid);

			Assert.IsInstanceOfType(meterModel.Meters, typeof(List<Meter>));
		}

		[TestMethod]
		public void CheckGetMetersForBuildingWithCorrectBuildingId_nullTest()
		{
			int correctBuildingid = 50;
			var meterModel = new MeterModel();

			meterModel.GetMetersForBuilding(correctBuildingid);

			Assert.IsNotNull(meterModel.Meters);
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidUtilityNameException))]
		public void CheckGetMeterTypesForUtility_throws_Exception()
		{
			string wrongUtilityName = "WrongUtility";
			var meterModel = new MeterTypeModel();

			meterModel.GetMeterTypesForUtility(wrongUtilityName);
		}

		[TestMethod]
		public void CheckGetRandomMeters_For_Return_Instances()
		{
			var meterModel = new MeterModel();

			meterModel.GetRandomMeters();

			Assert.AreNotEqual(0,meterModel.Meters.Count);
		}

		[TestMethod]
		public void CheckGetFoundMeters_With_Correct_City()
		{
			var meterModel = new MeterModel();

			meterModel.GetFoundMeters("Kolding");

			Assert.AreNotEqual(0, meterModel.Meters.Count);
		}

		[TestMethod]
		public void CheckGetFoundMeters_With_Wrong_City()
		{
			var meterModel = new MeterModel();

			meterModel.GetFoundMeters("New York");

			Assert.AreEqual(0, meterModel.Meters.Count);
		}

		[TestMethod]
		public void CheckGetRandomMeters_For_Return_Type()
		{
			var meterModel = new MeterModel();

			meterModel.GetRandomMeters();

			Assert.IsInstanceOfType(meterModel.Meters, typeof(List<Meter>));
		}


	}
}
