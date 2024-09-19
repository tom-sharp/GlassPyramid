
namespace GlassPyramid
{
	class PyramidGlass : Glass, IPyramidGlass
	{
		Flow seedflow;
		List<PyramidGlass> seedglasses;
		
		public PyramidGlass(int rowid, int glassid)
		{
			this.Row = rowid;
			this.Glass = glassid;
			this.seedflow = new Flow();
			this.seedglasses = new List<PyramidGlass>();
		}

		public int Row { get; }
		public int Glass { get; }

		public void AddChild(PyramidGlass? glass) 
		{
			if (glass != null) 
			{
				this.seedglasses.Add(glass);
				glass.Flow.Add(this.seedflow);
			}
		}

		public override void TimeProgress(double elapsedtime)
		{
			if (elapsedtime <= 0)
			{
				// refresh flows
				if (this.TimeFilled > 0 && this.seedglasses.Count > 0)
				{
					double dividestreams = this.seedglasses.Count;
					this.seedflow.Volume = this.Flow.Volume / dividestreams;
				}
			}
			else base.TimeProgress(elapsedtime);

			foreach (var glass in seedglasses)
			{
				glass.TimeProgress(elapsedtime);
			}
		}


		public override double TimeToFilled
		{
			get
			{
				double time = base.TimeToFilled;
				if (time < 0) return time;

				foreach (var glass in seedglasses)
				{
					double childtime = glass.TimeToFilled;
					if (childtime > 0)
					{
						if (time == 0) time = childtime;
						else if (time > childtime) time = childtime;
					}
				}

				return time;

			}
		}


	}


}
