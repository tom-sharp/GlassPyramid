using GlassPyramid;

namespace GPWin
{
	partial class Form1 : IPyramidUI
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			tbRows = new TextBox();
			tbGlass = new TextBox();
			lblRows = new Label();
			lblGlass = new Label();
			btnGo = new Button();
			tbResult = new TextBox();
			cbLogProgress = new CheckBox();
			btnClear = new Button();
			lblGlassVolum = new Label();
			tbGlassVolum = new TextBox();
			lblMainFlow = new Label();
			tbMainFlow = new TextBox();
			SuspendLayout();
			// 
			// tbRows
			// 
			tbRows.Location = new Point(683, 18);
			tbRows.Name = "tbRows";
			tbRows.Size = new Size(105, 31);
			tbRows.TabIndex = 0;
			// 
			// tbGlass
			// 
			tbGlass.Location = new Point(683, 55);
			tbGlass.Name = "tbGlass";
			tbGlass.Size = new Size(105, 31);
			tbGlass.TabIndex = 1;
			// 
			// lblRows
			// 
			lblRows.AutoSize = true;
			lblRows.Location = new Point(550, 18);
			lblRows.Name = "lblRows";
			lblRows.Size = new Size(54, 25);
			lblRows.TabIndex = 2;
			lblRows.Text = "Rows";
			// 
			// lblGlass
			// 
			lblGlass.AutoSize = true;
			lblGlass.Location = new Point(550, 53);
			lblGlass.Name = "lblGlass";
			lblGlass.Size = new Size(53, 25);
			lblGlass.TabIndex = 3;
			lblGlass.Text = "Glass";
			// 
			// btnGo
			// 
			btnGo.Location = new Point(640, 259);
			btnGo.Name = "btnGo";
			btnGo.Size = new Size(148, 46);
			btnGo.TabIndex = 4;
			btnGo.Text = "Go";
			btnGo.UseVisualStyleBackColor = true;
			btnGo.Click += btnGo_Click;
			// 
			// tbResult
			// 
			tbResult.Location = new Point(12, 18);
			tbResult.Multiline = true;
			tbResult.Name = "tbResult";
			tbResult.Size = new Size(516, 394);
			tbResult.TabIndex = 5;
			// 
			// cbLogProgress
			// 
			cbLogProgress.AutoSize = true;
			cbLogProgress.Location = new Point(720, 212);
			cbLogProgress.Name = "cbLogProgress";
			cbLogProgress.Size = new Size(68, 29);
			cbLogProgress.TabIndex = 7;
			cbLogProgress.Text = "Log";
			cbLogProgress.UseVisualStyleBackColor = true;
			// 
			// btnClear
			// 
			btnClear.Location = new Point(640, 368);
			btnClear.Name = "btnClear";
			btnClear.Size = new Size(148, 44);
			btnClear.TabIndex = 8;
			btnClear.Text = "Clear";
			btnClear.UseVisualStyleBackColor = true;
			btnClear.Click += btnClear_Click;
			// 
			// lblGlassVolum
			// 
			lblGlassVolum.AutoSize = true;
			lblGlassVolum.Location = new Point(550, 104);
			lblGlassVolum.Name = "lblGlassVolum";
			lblGlassVolum.Size = new Size(118, 25);
			lblGlassVolum.TabIndex = 10;
			lblGlassVolum.Text = "Glass Volume";
			// 
			// tbGlassVolum
			// 
			tbGlassVolum.Location = new Point(683, 106);
			tbGlassVolum.Name = "tbGlassVolum";
			tbGlassVolum.Size = new Size(105, 31);
			tbGlassVolum.TabIndex = 9;
			// 
			// lblMainFlow
			// 
			lblMainFlow.AutoSize = true;
			lblMainFlow.Location = new Point(550, 141);
			lblMainFlow.Name = "lblMainFlow";
			lblMainFlow.Size = new Size(93, 25);
			lblMainFlow.TabIndex = 12;
			lblMainFlow.Text = "Main Flow";
			// 
			// tbMainFlow
			// 
			tbMainFlow.Location = new Point(683, 143);
			tbMainFlow.Name = "tbMainFlow";
			tbMainFlow.Size = new Size(105, 31);
			tbMainFlow.TabIndex = 11;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(lblMainFlow);
			Controls.Add(tbMainFlow);
			Controls.Add(lblGlassVolum);
			Controls.Add(tbGlassVolum);
			Controls.Add(btnClear);
			Controls.Add(cbLogProgress);
			Controls.Add(tbResult);
			Controls.Add(btnGo);
			Controls.Add(lblGlass);
			Controls.Add(lblRows);
			Controls.Add(tbGlass);
			Controls.Add(tbRows);
			Name = "Form1";
			Text = "Form1";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox tbRows;
		private TextBox tbGlass;
		private Label lblRows;
		private Label lblGlass;

		public int Rows { get; set; }
		public int Glass { get; set; }
		public double GlassVolume { get; set; }
		public Flow MainFlow { get; } = new Flow();

		void Setup()
		{
			this.Text = "GlassPyramid";
			this.Rows = 5;
			this.Glass = 5;
			this.GlassVolume = 10;
			this.MainFlow.Volume = 1;

			tbGlass.Text = this.Glass.ToString();
			tbRows.Text = this.Rows.ToString();
			tbGlassVolum.Text = this.GlassVolume.ToString();
			tbMainFlow.Text = this.MainFlow.Volume.ToString();
			tbGlassVolum.Enabled = false;
			tbMainFlow.Enabled = false;
			tbResult.PlaceholderText = "Find out the time taken to fill a glass in a 2D pyramid of\nglasses. Set number of rows the pyramid is buidt on,\nand choose the glass";
		}

		public void ShowProgress(string message)
		{
			if (this.cbLogProgress.Checked)
				this.tbResult.Text = this.tbResult.Text + $"{message}\r\n";
		}

		public void ShowResult(string message)
		{
			this.tbResult.Text = this.tbResult.Text + $"{message}\r\n";
		}

		private Button btnGo;
		private TextBox tbResult;
		private CheckBox cbLogProgress;
		private Button btnClear;
		private Label lblGlassVolum;
		private TextBox tbGlassVolum;
		private Label lblMainFlow;
		private TextBox tbMainFlow;
	}
}
