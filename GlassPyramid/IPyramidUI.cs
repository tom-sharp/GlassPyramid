

namespace GlassPyramid
{

	public interface IPyramidUI
	{
		public int Rows { get; set; }
		public int Glass { get; set; }
		public double GlassVolume { get; set; }
		public double MainFlow { get; set; }
		public void ShowProgress(string message);
		public void ShowResult(string message);

	}

}
