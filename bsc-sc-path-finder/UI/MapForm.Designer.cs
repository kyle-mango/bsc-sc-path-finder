namespace bsc_sc_path_finder
{
    partial class MapForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapForm));
            this.Panel_Map = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Btn_ExecuteJob = new System.Windows.Forms.Button();
            this.Btn_LoadMap = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Lbl_RobotStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Lbl_JobList = new System.Windows.Forms.Label();
            this.Cmb_PathFinder = new System.Windows.Forms.ComboBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Panel_Map
            // 
            this.Panel_Map.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(46)))), ((int)(((byte)(40)))));
            this.Panel_Map.Location = new System.Drawing.Point(12, 12);
            this.Panel_Map.Name = "Panel_Map";
            this.Panel_Map.Size = new System.Drawing.Size(640, 640);
            this.Panel_Map.TabIndex = 0;
            this.Panel_Map.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_Map_Paint);
            this.Panel_Map.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Panel_Map_MouseClick);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.Controls.Add(this.Cmb_PathFinder);
            this.panel2.Controls.Add(this.Btn_ExecuteJob);
            this.panel2.Controls.Add(this.Btn_LoadMap);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Location = new System.Drawing.Point(658, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(476, 300);
            this.panel2.TabIndex = 1;
            // 
            // Btn_ExecuteJob
            // 
            this.Btn_ExecuteJob.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(111)))), ((int)(((byte)(52)))));
            this.Btn_ExecuteJob.FlatAppearance.BorderSize = 2;
            this.Btn_ExecuteJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_ExecuteJob.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ExecuteJob.Location = new System.Drawing.Point(348, 241);
            this.Btn_ExecuteJob.Name = "Btn_ExecuteJob";
            this.Btn_ExecuteJob.Size = new System.Drawing.Size(97, 28);
            this.Btn_ExecuteJob.TabIndex = 2;
            this.Btn_ExecuteJob.Text = "Execute Job";
            this.Btn_ExecuteJob.UseVisualStyleBackColor = false;
            // 
            // Btn_LoadMap
            // 
            this.Btn_LoadMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(111)))), ((int)(((byte)(52)))));
            this.Btn_LoadMap.FlatAppearance.BorderSize = 2;
            this.Btn_LoadMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_LoadMap.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_LoadMap.Location = new System.Drawing.Point(256, 241);
            this.Btn_LoadMap.Name = "Btn_LoadMap";
            this.Btn_LoadMap.Size = new System.Drawing.Size(80, 28);
            this.Btn_LoadMap.TabIndex = 1;
            this.Btn_LoadMap.Text = "Load Map";
            this.Btn_LoadMap.UseVisualStyleBackColor = false;
            this.Btn_LoadMap.Click += new System.EventHandler(this.Btn_LoadMap_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(278, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 150);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Lbl_RobotStatus
            // 
            this.Lbl_RobotStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(46)))), ((int)(((byte)(40)))));
            this.Lbl_RobotStatus.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_RobotStatus.ForeColor = System.Drawing.Color.LawnGreen;
            this.Lbl_RobotStatus.Location = new System.Drawing.Point(658, 324);
            this.Lbl_RobotStatus.Name = "Lbl_RobotStatus";
            this.Lbl_RobotStatus.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.Lbl_RobotStatus.Size = new System.Drawing.Size(476, 34);
            this.Lbl_RobotStatus.TabIndex = 2;
            this.Lbl_RobotStatus.Text = "> Awaiting Instructions";
            this.Lbl_RobotStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(46)))), ((int)(((byte)(40)))));
            this.label2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.LawnGreen;
            this.label2.Location = new System.Drawing.Point(658, 358);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.label2.Size = new System.Drawing.Size(476, 38);
            this.label2.TabIndex = 3;
            this.label2.Text = "---------------------- Job List ---------------------- ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_JobList
            // 
            this.Lbl_JobList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(46)))), ((int)(((byte)(40)))));
            this.Lbl_JobList.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_JobList.ForeColor = System.Drawing.Color.LawnGreen;
            this.Lbl_JobList.Location = new System.Drawing.Point(658, 396);
            this.Lbl_JobList.Name = "Lbl_JobList";
            this.Lbl_JobList.Padding = new System.Windows.Forms.Padding(5, 10, 0, 0);
            this.Lbl_JobList.Size = new System.Drawing.Size(476, 256);
            this.Lbl_JobList.TabIndex = 4;
            this.Lbl_JobList.Text = "No items to display";
            // 
            // Cmb_PathFinder
            // 
            this.Cmb_PathFinder.FormattingEnabled = true;
            this.Cmb_PathFinder.Items.AddRange(new object[] {
            "BFS",
            "A*"});
            this.Cmb_PathFinder.Location = new System.Drawing.Point(290, 173);
            this.Cmb_PathFinder.Name = "Cmb_PathFinder";
            this.Cmb_PathFinder.Size = new System.Drawing.Size(121, 21);
            this.Cmb_PathFinder.TabIndex = 5;
            this.Cmb_PathFinder.Text = "A*";
            this.Cmb_PathFinder.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // MapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(196)))), ((int)(((byte)(153)))));
            this.ClientSize = new System.Drawing.Size(1141, 664);
            this.Controls.Add(this.Lbl_JobList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Lbl_RobotStatus);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Panel_Map);
            this.Name = "MapForm";
            this.Text = "Mars Path Finder";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Panel_Map;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Lbl_RobotStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Lbl_JobList;
        private System.Windows.Forms.Button Btn_ExecuteJob;
        private System.Windows.Forms.Button Btn_LoadMap;
        private System.Windows.Forms.ComboBox Cmb_PathFinder;
    }
}

