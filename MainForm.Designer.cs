namespace ComputerConstructor
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
            this.components = new System.ComponentModel.Container();
            this.btStartProgram = new System.Windows.Forms.Button();
            this.MainRefresh = new System.Windows.Forms.Timer(this.components);
            this.CheckEnd = new System.Windows.Forms.Timer(this.components);
            this.btnComp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btStartProgram
            // 
            this.btStartProgram.Location = new System.Drawing.Point(12, 12);
            this.btStartProgram.Name = "btStartProgram";
            this.btStartProgram.Size = new System.Drawing.Size(75, 23);
            this.btStartProgram.TabIndex = 0;
            this.btStartProgram.Text = "Start";
            this.btStartProgram.UseVisualStyleBackColor = true;
            this.btStartProgram.Click += new System.EventHandler(this.BtStartProgram_Click);
            // 
            // MainRefresh
            // 
            this.MainRefresh.Enabled = true;
            this.MainRefresh.Interval = 5;
            this.MainRefresh.Tick += new System.EventHandler(this.MainRefresh_Tick);
            // 
            // CheckEnd
            // 
            this.CheckEnd.Enabled = true;
            this.CheckEnd.Interval = 800;
            this.CheckEnd.Tick += new System.EventHandler(this.CheckEnd_Tick);
            // 
            // btnComp
            // 
            this.btnComp.Location = new System.Drawing.Point(12, 41);
            this.btnComp.Name = "btnComp";
            this.btnComp.Size = new System.Drawing.Size(75, 23);
            this.btnComp.TabIndex = 2;
            this.btnComp.Text = "CheckComp";
            this.btnComp.UseVisualStyleBackColor = true;
            this.btnComp.Visible = false;
            this.btnComp.Click += new System.EventHandler(this.btnComp_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnComp);
            this.Controls.Add(this.btStartProgram);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btStartProgram;
        private System.Windows.Forms.Timer MainRefresh;
        private System.Windows.Forms.Timer CheckEnd;
        private System.Windows.Forms.Button btnComp;
    }
}

