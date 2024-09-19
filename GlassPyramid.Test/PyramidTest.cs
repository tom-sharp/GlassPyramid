using GlassPyramid;

namespace GlassPyramid.Test
{

	public class MockUI : IPyramidUI
	{
        public MockUI()
        {
			MainFlow = new() { Volume = 1 };
			Rows = 5;
			Glass = 1;
			GlassVolume = 10;
			ProgressCounter = 0;
			ResultCounter = 0;
		}

        public int Rows { get; set; }
		public int Glass { get; set; }
		public double GlassVolume { get; set; }
		public Flow MainFlow { get; }
		public int ProgressCounter { get; set; }
		public int ResultCounter { get; set; }
        public void ShowProgress(string message)
		{
			ProgressCounter++;
		}

		public void ShowResult(string message)
		{
			ResultCounter++;
		}
	}


	[TestClass]
	public class PyramidTest
	{
		[TestMethod]
		public void pyramid_oneglass_result()
		{
			var ui = new MockUI();
			var p = new Pyramid(ui);

			ui.Rows = 1;
			ui.Glass = 1;
			p.FindFillTime();

			int expectedprogresscounter = 1;
			int expectedresultcounter = 1;

			int actualprogresscounter = ui.ProgressCounter;
			int actualresultcounter = ui.ResultCounter;

			Assert.AreEqual(expectedprogresscounter, actualprogresscounter);
			Assert.AreEqual(expectedresultcounter, actualresultcounter);

		}

	}
}
