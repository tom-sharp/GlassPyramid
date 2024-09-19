
namespace GlassPyramid
{
	public class Flows : List<IFlow>, IFlow
	{
		public Flows(IFlow? flow = null)
		{
			if (flow != null) this.Add(flow);
		}

		public double Volume
		{
			get
			{
				double flow = 0;
				foreach (var f in this) flow += f.Volume;
				return flow;
			}
		}

	}
}
