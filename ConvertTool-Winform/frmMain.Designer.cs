namespace ConvertTool_Winform
{
    partial class frmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.status = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel_main = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.基础配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_sourceConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_targetConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_generateConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_generate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_quit = new System.Windows.Forms.ToolStripMenuItem();
            this.status.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.status.Location = new System.Drawing.Point(0, 400);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(419, 25);
            this.status.TabIndex = 1;
            this.status.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(144, 20);
            this.toolStripStatusLabel1.Text = "版权所有，违版必究";
            // 
            // panel_main
            // 
            this.panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_main.Location = new System.Drawing.Point(0, 31);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(419, 369);
            this.panel_main.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基础配置ToolStripMenuItem,
            this.tsmi_generate,
            this.tsmi_quit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(419, 31);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 基础配置ToolStripMenuItem
            // 
            this.基础配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_sourceConfig,
            this.tsmi_targetConfig,
            this.tsmi_generateConfig});
            this.基础配置ToolStripMenuItem.Name = "基础配置ToolStripMenuItem";
            this.基础配置ToolStripMenuItem.Size = new System.Drawing.Size(90, 27);
            this.基础配置ToolStripMenuItem.Text = "基础配置";
            // 
            // tsmi_sourceConfig
            // 
            this.tsmi_sourceConfig.Name = "tsmi_sourceConfig";
            this.tsmi_sourceConfig.Size = new System.Drawing.Size(205, 28);
            this.tsmi_sourceConfig.Text = "源数据库配置";
            this.tsmi_sourceConfig.Click += new System.EventHandler(this.tsmi_sourceConfig_Click);
            // 
            // tsmi_targetConfig
            // 
            this.tsmi_targetConfig.Name = "tsmi_targetConfig";
            this.tsmi_targetConfig.Size = new System.Drawing.Size(205, 28);
            this.tsmi_targetConfig.Text = "目标数据库配置";
            this.tsmi_targetConfig.Click += new System.EventHandler(this.tsmi_targetConfig_Click);
            // 
            // tsmi_generateConfig
            // 
            this.tsmi_generateConfig.Name = "tsmi_generateConfig";
            this.tsmi_generateConfig.Size = new System.Drawing.Size(205, 28);
            this.tsmi_generateConfig.Text = "生成配置";
            this.tsmi_generateConfig.Click += new System.EventHandler(this.tsmi_generateConfig_Click);
            // 
            // tsmi_generate
            // 
            this.tsmi_generate.Name = "tsmi_generate";
            this.tsmi_generate.Size = new System.Drawing.Size(56, 27);
            this.tsmi_generate.Text = "生成";
            this.tsmi_generate.Click += new System.EventHandler(this.tsmi_generate_Click);
            // 
            // tsmi_quit
            // 
            this.tsmi_quit.Name = "tsmi_quit";
            this.tsmi_quit.Size = new System.Drawing.Size(56, 27);
            this.tsmi_quit.Text = "退出";
            this.tsmi_quit.Click += new System.EventHandler(this.tsmi_quit_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(419, 425);
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "转换工具主界面";
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 基础配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_sourceConfig;
        private System.Windows.Forms.ToolStripMenuItem tsmi_targetConfig;
        private System.Windows.Forms.ToolStripMenuItem tsmi_generate;
        private System.Windows.Forms.ToolStripMenuItem tsmi_quit;
        private System.Windows.Forms.ToolStripMenuItem tsmi_generateConfig;
    }
}

