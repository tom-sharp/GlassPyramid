using GlassPyramid;

namespace GlassPyramid.Test
{
	[TestClass]
	public class PyramidGlassTest
	{
		[TestMethod]
		public void init_defaultInit_default()
		{
			int expectedrow = 1;
			int expectedglass = 2;
			double expectedglassvolume = 0;
			double expectedglassvolumefilled = 0;
			double expectedflowvolume = 0;
			double expectedtimefilled = 0;
			double expectedtimetofilled = -1;


			var g = new PyramidGlass(rowid: expectedrow, glassid: expectedglass);


			int actualrow = g.Row;
			int actualglass = g.Glass;
			double actualglassvolume = g.Volume;
			double actualglassvolumefilled = g.VolumeFilled;
			double actualflowvolume = g.Flow.Volume;
			double actualtimefilled = g.TimeFilled;
			double actualtimetofilled = g.TimeToFilled;


			Assert.AreEqual(expectedrow, actualrow);
			Assert.AreEqual(expectedglass, actualglass);
			Assert.AreEqual(expectedglassvolume, actualglassvolume);
			Assert.AreEqual(expectedglassvolumefilled, actualglassvolumefilled);
			Assert.AreEqual(expectedflowvolume, actualflowvolume);
			Assert.AreEqual(expectedtimefilled, actualtimefilled);
			Assert.AreEqual(expectedtimetofilled, actualtimetofilled);

		}

		[TestMethod]
		public void Init_SetGlassVolume_SetGlassVolume()
		{
			double expectedglassvolume = 10;
			double expectedglassvolumefilled = 0;
			double expectedflowvolume = 0;
			double expectedtimefilled = 0;
			double expectedtimetofilled = -1;

			var g = new PyramidGlass(rowid: 1, glassid: 1);
			g.Volume = expectedglassvolume;

			double actualglassvolume = g.Volume;
			double actualglassvolumefilled = g.VolumeFilled;
			double actualflowvolume = g.Flow.Volume;
			double actualtimefilled = g.TimeFilled;
			double actualtimetofilled = g.TimeToFilled;


			Assert.AreEqual(expectedglassvolume, actualglassvolume);
			Assert.AreEqual(expectedglassvolumefilled, actualglassvolumefilled);
			Assert.AreEqual(expectedflowvolume, actualflowvolume);
			Assert.AreEqual(expectedtimefilled, actualtimefilled);
			Assert.AreEqual(expectedtimetofilled, actualtimetofilled);

		}


		[TestMethod]
		public void Init_AddFlow_FilltimeCanbeCalulated()
		{
			double expectedglassvolumefilled = 0;
			double expectedflowvolume = 1;
			double expectedtimefilled = 0;
			double expectedtimetofilled = 10;

			var g = new PyramidGlass(rowid: 1, glassid: 1);
			g.Volume = 10;
			g.Flow.Add(new Flow() { Volume = expectedflowvolume });

			double actualglassvolumefilled = g.VolumeFilled;
			double actualflowvolume = g.Flow.Volume;
			double actualtimefilled = g.TimeFilled;
			double actualtimetofilled = g.TimeToFilled;


			Assert.AreEqual(expectedglassvolumefilled, actualglassvolumefilled);
			Assert.AreEqual(expectedflowvolume, actualflowvolume);
			Assert.AreEqual(expectedtimefilled, actualtimefilled);
			Assert.AreEqual(expectedtimetofilled, actualtimetofilled);

		}

		[TestMethod]
		public void Flow_AddMultipleFlows_ShorterTimeToFilled()
		{
			double expectedflowvolume1 = 1;
			double expectedflowvolume2 = 4;
			double expectedtimetofilled1 = 10;
			double expectedtimetofilled2 = 2.5;

			var g = new PyramidGlass(rowid: 1, glassid: 1);
			g.Volume = 10;
			g.Flow.Add(new Flow() { Volume = expectedflowvolume1 });

			double actualflowvolume1 = g.Flow.Volume;
			double actualtimetofilled1 = g.TimeToFilled;

			g.Flow.Add(new Flow() { Volume = expectedflowvolume1 });
			g.Flow.Add(new Flow() { Volume = expectedflowvolume1 });
			g.Flow.Add(new Flow() { Volume = expectedflowvolume1 });

			double actualflowvolume2 = g.Flow.Volume;
			double actualtimetofilled2 = g.TimeToFilled;

			Assert.AreEqual(expectedflowvolume1, actualflowvolume1);
			Assert.AreEqual(expectedflowvolume2, actualflowvolume2);
			Assert.AreEqual(expectedtimetofilled1, actualtimetofilled1);
			Assert.AreEqual(expectedtimetofilled2, actualtimetofilled2);

		}


		[TestMethod]
		public void Flow_IncreaseFlows_ShorterTimeToFilled()
		{
			double expectedflowvolume1 = 1;
			double expectedflowvolume2 = 4;
			double expectedtimetofilled1 = 10;
			double expectedtimetofilled2 = 2.5;

			var g = new PyramidGlass(rowid: 1, glassid: 1);
			g.Volume = 10;

			var flow = new Flow() { Volume = expectedflowvolume1 };
			g.Flow.Add(flow);

			double actualflowvolume1 = g.Flow.Volume;
			double actualtimetofilled1 = g.TimeToFilled;

			flow.Volume = 4;

			double actualflowvolume2 = g.Flow.Volume;
			double actualtimetofilled2 = g.TimeToFilled;

			Assert.AreEqual(expectedflowvolume1, actualflowvolume1);
			Assert.AreEqual(expectedflowvolume2, actualflowvolume2);
			Assert.AreEqual(expectedtimetofilled1, actualtimetofilled1);
			Assert.AreEqual(expectedtimetofilled2, actualtimetofilled2);

		}


		[TestMethod]
		public void ProgressTime_Progress30percentToFill_GlassPartlyFilled()
		{
			double expectedglassvolumefilled = 3;
			double expectedflowvolume = 1;
			double expectedtimefilled = 0;
			double expectedtimetofilled = 7;

			var g = new PyramidGlass(rowid: 1, glassid: 1);
			g.Volume = 10;
			g.Flow.Add(new Flow() { Volume = expectedflowvolume });
			g.TimeProgress(elapsedtime: 3);

			double actualglassvolumefilled = g.VolumeFilled;
			double actualflowvolume = g.Flow.Volume;
			double actualtimefilled = g.TimeFilled;
			double actualtimetofilled = g.TimeToFilled;


			Assert.AreEqual(expectedglassvolumefilled, actualglassvolumefilled);
			Assert.AreEqual(expectedflowvolume, actualflowvolume);
			Assert.AreEqual(expectedtimefilled, actualtimefilled);
			Assert.AreEqual(expectedtimetofilled, actualtimetofilled);

		}


		[TestMethod]
		public void ProgressTime_ProgressToFill_GlassFilled()
		{
			double expectedglassvolumefilled = 10;
			double expectedtimefilled = 10;
			double expectedtimetofilled = 0;

			var g = new PyramidGlass(rowid: 1, glassid: 1);
			g.Volume = 10;
			g.Flow.Add(new Flow() { Volume = 1 });
			g.TimeProgress(elapsedtime: g.TimeToFilled);

			double actualglassvolumefilled = g.VolumeFilled;
			double actualtimefilled = g.TimeFilled;
			double actualtimetofilled = g.TimeToFilled;


			Assert.AreEqual(expectedglassvolumefilled, actualglassvolumefilled);
			Assert.AreEqual(expectedtimefilled, actualtimefilled);
			Assert.AreEqual(expectedtimetofilled, actualtimetofilled);

		}


	}
}