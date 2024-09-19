
namespace GlassPyramid
{
	public class Pyramid 
	{
		Flows mainflow;
		List<PyramidGlass> glasses;
		IPyramidUI ui;

		public Pyramid(IPyramidUI ui)
		{
			this.ui = ui;
			this.mainflow = new Flows() { ui.MainFlow };
			this.glasses = new List<PyramidGlass>();
		}

		public Flows MainFlow => this.mainflow;

		public void FindFillTime()
		{
			this.BuildPyramid(ui.Rows, ui.GlassVolume);

			var topglass = this.glasses.FirstOrDefault(o => o.Row == 1 && o.Glass == 1);
			var monitorglass = this.glasses.FirstOrDefault(o => o.Row == ui.Rows && o.Glass == ui.Glass);
			if (topglass == null || monitorglass == null)
			{
				ui.ShowResult("Error"); return;
			}

			double timeline = 0;
			while (true)
			{
				var time = topglass.TimeToFilled;
				if (time <= 0) break;
				timeline += time;
				topglass.TimeProgress(timeline);		// advance time
				topglass.TimeProgress(0);               // refresh flows

				ui.ShowProgress($"{timeline:0.000}");
			}
			ui.ShowResult($"Glass {monitorglass.Glass} at row {monitorglass.Row} will be filled after {monitorglass.TimeFilled:0.000} seconds");
		}

		void BuildPyramid(int rows, double glassvolume)
		{
			CreatePyramidGlasses(rows, glassvolume);
			SetupPyramidFlowPath();
		}

		void CreatePyramidGlasses(int rows, double glassvolume)
		{
			int row = 0, glass;
			this.glasses.Clear();

			while (row < rows)
			{
				row++; glass = 1;
				while (glass <= row)
				{
					this.glasses.Add(new PyramidGlass(row, glass++) { Volume = glassvolume });
				}
			}
		}

		void SetupPyramidFlowPath()
		{
			// link flow
			var firstglass = this.glasses.FirstOrDefault(o => o.Row == 1 && o.Glass == 1);
			if (firstglass != null) firstglass.Flow.Add(this.mainflow);

			foreach (var pg in this.glasses)
			{
				pg.AddChild(this.glasses.FirstOrDefault(o => o.Row == pg.Row + 1 && o.Glass == pg.Glass));
				pg.AddChild(this.glasses.FirstOrDefault(o => o.Row == pg.Row + 1 && o.Glass == pg.Glass + 1));
			}
		}

	}



}
