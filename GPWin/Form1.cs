using GlassPyramid;

namespace GPWin
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			Setup();
		}

		private void btnGo_Click(object sender, EventArgs e)
		{
			int parseInt;
			if (int.TryParse(tbGlass.Text, out parseInt)) this.Glass = parseInt;
			else this.Glass = 0;
			if (int.TryParse(tbRows.Text, out parseInt)) this.Rows = parseInt;
			else this.Rows = 0;

			new Pyramid(mainflow: new Flow() { Volume = this.MainFlow }).FindFillTime(this);

		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			this.tbResult.Text = "";
		}
	}
}
