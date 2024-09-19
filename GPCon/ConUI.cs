using GlassPyramid;



namespace GPCon
{

	public class ConUI : IPyramidUI
	{
		public ConUI()
		{
			Rows = 5;
			Glass = 5;
			GlassVolume = 10;
			MainFlow = 1;
		}

		public int Rows { get; set; }
		public int Glass { get; set; }
		public double GlassVolume { get; set; }
		public double MainFlow { get; set; }


		public bool UserInput()
		{
			int parseInt = 0;
			while (parseInt == 0)
			{
				Console.Write($"\nHow many rows, 0 to exit <{this.Rows}> ? ");
				var inp = Console.ReadLine();
				if (inp != null && inp.Length > 0)
				{
					if (int.TryParse(inp, out parseInt) && parseInt >= 0)
					{
						this.Rows = parseInt;
					}
					else parseInt = 0;
				}
				else parseInt = this.Rows;

				if (this.Rows == 0) return false;

				if (parseInt > 0)
				{
					Console.Write($"\nWhich glass 1-{this.Rows} <{this.Glass}> ? ");
					inp = Console.ReadLine();
					if (inp != null && inp.Length > 0)
					{
						if (int.TryParse(inp, out parseInt) && parseInt > 0 && parseInt <= this.Rows)
						{
							this.Glass = parseInt;
						}
						else parseInt = 0;
					}
					else parseInt = this.Glass;
				}

			}
			return true;
		}

		public void ShowProgress(string message)
		{
			Console.WriteLine(message);
		}

		public void ShowResult(string message)
		{
			Console.WriteLine(message);
		}

		public void Start()
		{
			Console.Clear();
			Console.WriteLine($"Pyramid; {this.Rows} rows of glasses, finding time for glass {this.Glass} in bottom row");
		}
		public void End()
		{
		}


	}


}

