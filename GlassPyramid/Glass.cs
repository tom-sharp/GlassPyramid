
namespace GlassPyramid
{

	class Glass : IGlass
	{
		double timebase = 0;
		public Glass()
		{
			this.Volume = 0;
			this.VolumeFilled = 0;
			this.Flow = new Flows();
		}

		public double Volume { get; set; }
		public double VolumeFilled { get; set; }
		public Flows Flow { get; }
		public double TimeFilled => this.VolumeFilled == this.Volume ? this.timebase : 0;

		public virtual double TimeToFilled 
		{ 
			get 
			{
				if (this.TimeFilled > 0) return 0;
				if (this.Flow.Volume == 0) return -1;
				return (this.Volume - this.VolumeFilled) / this.Flow.Volume;
			} 
		}

		public virtual void TimeProgress(double elapsedtime)
		{
			{
				if (elapsedtime <= this.timebase|| this.TimeFilled > 0) return;
				double fillvolume = (elapsedtime - this.timebase) * this.Flow.Volume;
				this.VolumeFilled += fillvolume;
				if (this.Volume - this.VolumeFilled < 0.00000001) this.VolumeFilled = this.Volume;
				this.timebase = elapsedtime;
			}
		}


	}


}
