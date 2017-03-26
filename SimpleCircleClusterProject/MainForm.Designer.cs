namespace SimpleCircleClusterProject
{
	partial class MainForm
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.formToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.linesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mainPanel = new System.Windows.Forms.Panel();
			this.intersectionPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1089, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem1,
            this.processToolStripMenuItem,
            this.clearToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// loadToolStripMenuItem1
			// 
			this.loadToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.formToolStripMenuItem});
			this.loadToolStripMenuItem1.Name = "loadToolStripMenuItem1";
			this.loadToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
			this.loadToolStripMenuItem1.Text = "Load";
			// 
			// fileToolStripMenuItem1
			// 
			this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
			this.fileToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
			this.fileToolStripMenuItem1.Text = "File";
			// 
			// formToolStripMenuItem
			// 
			this.formToolStripMenuItem.Name = "formToolStripMenuItem";
			this.formToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
			this.formToolStripMenuItem.Text = "Form";
			// 
			// processToolStripMenuItem
			// 
			this.processToolStripMenuItem.Name = "processToolStripMenuItem";
			this.processToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.processToolStripMenuItem.Text = "Process";
			this.processToolStripMenuItem.Click += new System.EventHandler(this.processToolStripMenuItem_Click);
			// 
			// clearToolStripMenuItem
			// 
			this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
			this.clearToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.clearToolStripMenuItem.Text = "Clear";
			this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circleToolStripMenuItem,
            this.linesToolStripMenuItem,
            this.intersectionPointToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "View";
			// 
			// circleToolStripMenuItem
			// 
			this.circleToolStripMenuItem.Name = "circleToolStripMenuItem";
			this.circleToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.circleToolStripMenuItem.Text = "Circle";
			this.circleToolStripMenuItem.Click += new System.EventHandler(this.circleToolStripMenuItem_Click);
			// 
			// linesToolStripMenuItem
			// 
			this.linesToolStripMenuItem.Name = "linesToolStripMenuItem";
			this.linesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.linesToolStripMenuItem.Text = "Lines";
			this.linesToolStripMenuItem.Click += new System.EventHandler(this.linesToolStripMenuItem_Click);
			// 
			// mainPanel
			// 
			this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainPanel.Location = new System.Drawing.Point(0, 24);
			this.mainPanel.Name = "mainPanel";
			this.mainPanel.Size = new System.Drawing.Size(1089, 490);
			this.mainPanel.TabIndex = 1;
			// 
			// intersectionPointToolStripMenuItem
			// 
			this.intersectionPointToolStripMenuItem.Name = "intersectionPointToolStripMenuItem";
			this.intersectionPointToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.intersectionPointToolStripMenuItem.Text = "IntersectionPoint";
			this.intersectionPointToolStripMenuItem.Click += new System.EventHandler(this.intersectionPointToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1089, 514);
			this.Controls.Add(this.mainPanel);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem formToolStripMenuItem;
		private System.Windows.Forms.Panel mainPanel;
		private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem circleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem linesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem intersectionPointToolStripMenuItem;
	}
}

