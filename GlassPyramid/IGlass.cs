
namespace GlassPyramid
{

	public interface IGlass
	{
		public double Volume { get; }
		public double VolumeFilled { get; }
		public Flows Flow { get; }
		public double TimeToFilled { get; }
		public double TimeFilled { get; }

	}



}
