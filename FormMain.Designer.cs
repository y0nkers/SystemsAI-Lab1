namespace MovingTheBalls
{
    partial class FormMain
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
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.panelGamefield = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox14 = new System.Windows.Forms.PictureBox();
            this.pictureBox15 = new System.Windows.Forms.PictureBox();
            this.pictureBox16 = new System.Windows.Forms.PictureBox();
            this.pictureBoxObjective = new System.Windows.Forms.PictureBox();
            this.buttonLeft4 = new System.Windows.Forms.Button();
            this.buttonLeft3 = new System.Windows.Forms.Button();
            this.buttonLeft2 = new System.Windows.Forms.Button();
            this.buttonLeft1 = new System.Windows.Forms.Button();
            this.buttonTop4 = new System.Windows.Forms.Button();
            this.buttonTop3 = new System.Windows.Forms.Button();
            this.buttonTop2 = new System.Windows.Forms.Button();
            this.buttonTop1 = new System.Windows.Forms.Button();
            this.labelObjective = new System.Windows.Forms.Label();
            this.pictureBoxWin = new System.Windows.Forms.PictureBox();
            this.labelWin = new System.Windows.Forms.Label();
            this.buttonBFS = new System.Windows.Forms.Button();
            this.labelSolution = new System.Windows.Forms.Label();
            this.buttonSolve = new System.Windows.Forms.Button();
            this.buttonBidirectionalSearch = new System.Windows.Forms.Button();
            this.labelGCost = new System.Windows.Forms.Label();
            this.labelHCost = new System.Windows.Forms.Label();
            this.buttonHeuristicSearch = new System.Windows.Forms.Button();
            this.textBoxSolutionStats = new System.Windows.Forms.TextBox();
            this.panelGamefield.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxObjective)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWin)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonShuffle.Location = new System.Drawing.Point(712, 11);
            this.buttonShuffle.Margin = new System.Windows.Forms.Padding(2);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(120, 50);
            this.buttonShuffle.TabIndex = 32;
            this.buttonShuffle.Text = "Shuffle field";
            this.buttonShuffle.UseVisualStyleBackColor = true;
            this.buttonShuffle.Click += new System.EventHandler(this.ButtonShuffle_Click);
            // 
            // panelGamefield
            // 
            this.panelGamefield.Controls.Add(this.pictureBox1);
            this.panelGamefield.Controls.Add(this.pictureBox2);
            this.panelGamefield.Controls.Add(this.pictureBox3);
            this.panelGamefield.Controls.Add(this.pictureBox4);
            this.panelGamefield.Controls.Add(this.pictureBox5);
            this.panelGamefield.Controls.Add(this.pictureBox6);
            this.panelGamefield.Controls.Add(this.pictureBox7);
            this.panelGamefield.Controls.Add(this.pictureBox8);
            this.panelGamefield.Controls.Add(this.pictureBox9);
            this.panelGamefield.Controls.Add(this.pictureBox10);
            this.panelGamefield.Controls.Add(this.pictureBox11);
            this.panelGamefield.Controls.Add(this.pictureBox12);
            this.panelGamefield.Controls.Add(this.pictureBox13);
            this.panelGamefield.Controls.Add(this.pictureBox14);
            this.panelGamefield.Controls.Add(this.pictureBox15);
            this.panelGamefield.Controls.Add(this.pictureBox16);
            this.panelGamefield.Location = new System.Drawing.Point(84, 82);
            this.panelGamefield.Margin = new System.Windows.Forms.Padding(2);
            this.panelGamefield.Name = "panelGamefield";
            this.panelGamefield.Size = new System.Drawing.Size(372, 399);
            this.panelGamefield.TabIndex = 34;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(4, 2);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(88, 93);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(96, 2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(88, 93);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Location = new System.Drawing.Point(189, 2);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(88, 93);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Location = new System.Drawing.Point(282, 2);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(88, 93);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 3;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Location = new System.Drawing.Point(4, 103);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(88, 93);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Location = new System.Drawing.Point(96, 103);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(88, 93);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Location = new System.Drawing.Point(188, 103);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(88, 93);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.Location = new System.Drawing.Point(281, 103);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(88, 93);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 7;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox9.Location = new System.Drawing.Point(4, 202);
            this.pictureBox9.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(88, 93);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 8;
            this.pictureBox9.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox10.Location = new System.Drawing.Point(96, 202);
            this.pictureBox10.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(88, 93);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 9;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox11.Location = new System.Drawing.Point(188, 202);
            this.pictureBox11.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(88, 93);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 10;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox12.Location = new System.Drawing.Point(281, 202);
            this.pictureBox12.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(88, 93);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 11;
            this.pictureBox12.TabStop = false;
            // 
            // pictureBox13
            // 
            this.pictureBox13.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox13.Location = new System.Drawing.Point(4, 301);
            this.pictureBox13.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(88, 93);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox13.TabIndex = 12;
            this.pictureBox13.TabStop = false;
            // 
            // pictureBox14
            // 
            this.pictureBox14.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox14.Location = new System.Drawing.Point(96, 301);
            this.pictureBox14.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox14.Name = "pictureBox14";
            this.pictureBox14.Size = new System.Drawing.Size(88, 93);
            this.pictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox14.TabIndex = 13;
            this.pictureBox14.TabStop = false;
            // 
            // pictureBox15
            // 
            this.pictureBox15.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox15.Location = new System.Drawing.Point(188, 301);
            this.pictureBox15.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox15.Name = "pictureBox15";
            this.pictureBox15.Size = new System.Drawing.Size(88, 93);
            this.pictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox15.TabIndex = 14;
            this.pictureBox15.TabStop = false;
            // 
            // pictureBox16
            // 
            this.pictureBox16.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox16.Location = new System.Drawing.Point(281, 301);
            this.pictureBox16.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox16.Name = "pictureBox16";
            this.pictureBox16.Size = new System.Drawing.Size(88, 93);
            this.pictureBox16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox16.TabIndex = 15;
            this.pictureBox16.TabStop = false;
            // 
            // pictureBoxObjective
            // 
            this.pictureBoxObjective.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBoxObjective.Image = global::MovingTheBalls.Properties.Resources.objective;
            this.pictureBoxObjective.Location = new System.Drawing.Point(676, 358);
            this.pictureBoxObjective.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxObjective.Name = "pictureBoxObjective";
            this.pictureBoxObjective.Size = new System.Drawing.Size(156, 123);
            this.pictureBoxObjective.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxObjective.TabIndex = 35;
            this.pictureBoxObjective.TabStop = false;
            // 
            // buttonLeft4
            // 
            this.buttonLeft4.Image = global::MovingTheBalls.Properties.Resources.buttonLeft;
            this.buttonLeft4.Location = new System.Drawing.Point(13, 380);
            this.buttonLeft4.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLeft4.Name = "buttonLeft4";
            this.buttonLeft4.Size = new System.Drawing.Size(66, 93);
            this.buttonLeft4.TabIndex = 31;
            this.buttonLeft4.UseVisualStyleBackColor = true;
            this.buttonLeft4.Click += new System.EventHandler(this.MovementHandler);
            this.buttonLeft4.MouseLeave += new System.EventHandler(this.ButtonLeftLeaveHover);
            this.buttonLeft4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonLeftHover);
            // 
            // buttonLeft3
            // 
            this.buttonLeft3.Image = global::MovingTheBalls.Properties.Resources.buttonLeft;
            this.buttonLeft3.Location = new System.Drawing.Point(13, 280);
            this.buttonLeft3.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLeft3.Name = "buttonLeft3";
            this.buttonLeft3.Size = new System.Drawing.Size(66, 93);
            this.buttonLeft3.TabIndex = 30;
            this.buttonLeft3.UseVisualStyleBackColor = true;
            this.buttonLeft3.Click += new System.EventHandler(this.MovementHandler);
            this.buttonLeft3.MouseLeave += new System.EventHandler(this.ButtonLeftLeaveHover);
            this.buttonLeft3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonLeftHover);
            // 
            // buttonLeft2
            // 
            this.buttonLeft2.Image = global::MovingTheBalls.Properties.Resources.buttonLeft;
            this.buttonLeft2.Location = new System.Drawing.Point(13, 181);
            this.buttonLeft2.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLeft2.Name = "buttonLeft2";
            this.buttonLeft2.Size = new System.Drawing.Size(66, 93);
            this.buttonLeft2.TabIndex = 29;
            this.buttonLeft2.UseVisualStyleBackColor = true;
            this.buttonLeft2.Click += new System.EventHandler(this.MovementHandler);
            this.buttonLeft2.MouseLeave += new System.EventHandler(this.ButtonLeftLeaveHover);
            this.buttonLeft2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonLeftHover);
            // 
            // buttonLeft1
            // 
            this.buttonLeft1.Image = global::MovingTheBalls.Properties.Resources.buttonLeft;
            this.buttonLeft1.Location = new System.Drawing.Point(13, 82);
            this.buttonLeft1.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLeft1.Name = "buttonLeft1";
            this.buttonLeft1.Size = new System.Drawing.Size(66, 93);
            this.buttonLeft1.TabIndex = 28;
            this.buttonLeft1.UseVisualStyleBackColor = true;
            this.buttonLeft1.Click += new System.EventHandler(this.MovementHandler);
            this.buttonLeft1.MouseLeave += new System.EventHandler(this.ButtonLeftLeaveHover);
            this.buttonLeft1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonLeftHover);
            // 
            // buttonTop4
            // 
            this.buttonTop4.BackColor = System.Drawing.Color.Transparent;
            this.buttonTop4.Image = global::MovingTheBalls.Properties.Resources.buttonTop;
            this.buttonTop4.Location = new System.Drawing.Point(362, 13);
            this.buttonTop4.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTop4.Name = "buttonTop4";
            this.buttonTop4.Size = new System.Drawing.Size(88, 63);
            this.buttonTop4.TabIndex = 19;
            this.buttonTop4.UseVisualStyleBackColor = false;
            this.buttonTop4.Click += new System.EventHandler(this.MovementHandler);
            this.buttonTop4.MouseLeave += new System.EventHandler(this.ButtonTopLeaveHover);
            this.buttonTop4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonTopHover);
            // 
            // buttonTop3
            // 
            this.buttonTop3.BackColor = System.Drawing.Color.Transparent;
            this.buttonTop3.Image = global::MovingTheBalls.Properties.Resources.buttonTop;
            this.buttonTop3.Location = new System.Drawing.Point(270, 13);
            this.buttonTop3.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTop3.Name = "buttonTop3";
            this.buttonTop3.Size = new System.Drawing.Size(88, 63);
            this.buttonTop3.TabIndex = 18;
            this.buttonTop3.UseVisualStyleBackColor = false;
            this.buttonTop3.Click += new System.EventHandler(this.MovementHandler);
            this.buttonTop3.MouseLeave += new System.EventHandler(this.ButtonTopLeaveHover);
            this.buttonTop3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonTopHover);
            // 
            // buttonTop2
            // 
            this.buttonTop2.BackColor = System.Drawing.Color.Transparent;
            this.buttonTop2.Image = global::MovingTheBalls.Properties.Resources.buttonTop;
            this.buttonTop2.Location = new System.Drawing.Point(177, 13);
            this.buttonTop2.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTop2.Name = "buttonTop2";
            this.buttonTop2.Size = new System.Drawing.Size(88, 63);
            this.buttonTop2.TabIndex = 17;
            this.buttonTop2.UseVisualStyleBackColor = false;
            this.buttonTop2.Click += new System.EventHandler(this.MovementHandler);
            this.buttonTop2.MouseLeave += new System.EventHandler(this.ButtonTopLeaveHover);
            this.buttonTop2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonTopHover);
            // 
            // buttonTop1
            // 
            this.buttonTop1.BackColor = System.Drawing.Color.Transparent;
            this.buttonTop1.Image = global::MovingTheBalls.Properties.Resources.buttonTop;
            this.buttonTop1.Location = new System.Drawing.Point(84, 13);
            this.buttonTop1.Margin = new System.Windows.Forms.Padding(2);
            this.buttonTop1.Name = "buttonTop1";
            this.buttonTop1.Size = new System.Drawing.Size(88, 63);
            this.buttonTop1.TabIndex = 16;
            this.buttonTop1.UseVisualStyleBackColor = false;
            this.buttonTop1.Click += new System.EventHandler(this.MovementHandler);
            this.buttonTop1.MouseLeave += new System.EventHandler(this.ButtonTopLeaveHover);
            this.buttonTop1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ButtonTopHover);
            // 
            // labelObjective
            // 
            this.labelObjective.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelObjective.AutoSize = true;
            this.labelObjective.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelObjective.Location = new System.Drawing.Point(676, 331);
            this.labelObjective.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelObjective.Name = "labelObjective";
            this.labelObjective.Size = new System.Drawing.Size(146, 24);
            this.labelObjective.TabIndex = 36;
            this.labelObjective.Text = "Game objective:";
            // 
            // pictureBoxWin
            // 
            this.pictureBoxWin.Location = new System.Drawing.Point(470, 428);
            this.pictureBoxWin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBoxWin.Name = "pictureBoxWin";
            this.pictureBoxWin.Size = new System.Drawing.Size(131, 53);
            this.pictureBoxWin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxWin.TabIndex = 37;
            this.pictureBoxWin.TabStop = false;
            // 
            // labelWin
            // 
            this.labelWin.AutoSize = true;
            this.labelWin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelWin.Location = new System.Drawing.Point(470, 396);
            this.labelWin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelWin.Name = "labelWin";
            this.labelWin.Size = new System.Drawing.Size(0, 20);
            this.labelWin.TabIndex = 38;
            // 
            // buttonBFS
            // 
            this.buttonBFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonBFS.Location = new System.Drawing.Point(471, 11);
            this.buttonBFS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonBFS.Name = "buttonBFS";
            this.buttonBFS.Size = new System.Drawing.Size(120, 50);
            this.buttonBFS.TabIndex = 39;
            this.buttonBFS.Text = "Breadth-first search";
            this.buttonBFS.UseVisualStyleBackColor = true;
            this.buttonBFS.Click += new System.EventHandler(this.AlgorithmHandler);
            // 
            // labelSolution
            // 
            this.labelSolution.AutoSize = true;
            this.labelSolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSolution.Location = new System.Drawing.Point(712, 70);
            this.labelSolution.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSolution.Name = "labelSolution";
            this.labelSolution.Size = new System.Drawing.Size(0, 20);
            this.labelSolution.TabIndex = 40;
            // 
            // buttonSolve
            // 
            this.buttonSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSolve.Location = new System.Drawing.Point(712, 93);
            this.buttonSolve.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(120, 50);
            this.buttonSolve.TabIndex = 41;
            this.buttonSolve.Text = "Solve";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Visible = false;
            this.buttonSolve.Click += new System.EventHandler(this.ButtonSolve_Click);
            // 
            // buttonBidirectionalSearch
            // 
            this.buttonBidirectionalSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonBidirectionalSearch.Location = new System.Drawing.Point(471, 67);
            this.buttonBidirectionalSearch.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonBidirectionalSearch.Name = "buttonBidirectionalSearch";
            this.buttonBidirectionalSearch.Size = new System.Drawing.Size(120, 50);
            this.buttonBidirectionalSearch.TabIndex = 42;
            this.buttonBidirectionalSearch.Text = "Bidirectional search";
            this.buttonBidirectionalSearch.UseVisualStyleBackColor = true;
            this.buttonBidirectionalSearch.Click += new System.EventHandler(this.AlgorithmHandler);
            // 
            // labelGCost
            // 
            this.labelGCost.AutoSize = true;
            this.labelGCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelGCost.Location = new System.Drawing.Point(597, 123);
            this.labelGCost.Name = "labelGCost";
            this.labelGCost.Size = new System.Drawing.Size(0, 20);
            this.labelGCost.TabIndex = 43;
            // 
            // labelHCost
            // 
            this.labelHCost.AutoSize = true;
            this.labelHCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelHCost.Location = new System.Drawing.Point(597, 153);
            this.labelHCost.Name = "labelHCost";
            this.labelHCost.Size = new System.Drawing.Size(0, 20);
            this.labelHCost.TabIndex = 44;
            // 
            // buttonHeuristicSearch
            // 
            this.buttonHeuristicSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonHeuristicSearch.Location = new System.Drawing.Point(471, 123);
            this.buttonHeuristicSearch.Name = "buttonHeuristicSearch";
            this.buttonHeuristicSearch.Size = new System.Drawing.Size(120, 50);
            this.buttonHeuristicSearch.TabIndex = 45;
            this.buttonHeuristicSearch.Text = "Heurestic Search A*";
            this.buttonHeuristicSearch.UseVisualStyleBackColor = true;
            this.buttonHeuristicSearch.Click += new System.EventHandler(this.AlgorithmHandler);
            // 
            // textBoxSolutionStats
            // 
            this.textBoxSolutionStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.textBoxSolutionStats.Location = new System.Drawing.Point(471, 185);
            this.textBoxSolutionStats.Multiline = true;
            this.textBoxSolutionStats.Name = "textBoxSolutionStats";
            this.textBoxSolutionStats.ReadOnly = true;
            this.textBoxSolutionStats.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxSolutionStats.Size = new System.Drawing.Size(361, 143);
            this.textBoxSolutionStats.TabIndex = 46;
            this.textBoxSolutionStats.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 490);
            this.Controls.Add(this.textBoxSolutionStats);
            this.Controls.Add(this.buttonHeuristicSearch);
            this.Controls.Add(this.labelHCost);
            this.Controls.Add(this.labelGCost);
            this.Controls.Add(this.buttonBidirectionalSearch);
            this.Controls.Add(this.buttonSolve);
            this.Controls.Add(this.labelSolution);
            this.Controls.Add(this.buttonBFS);
            this.Controls.Add(this.labelWin);
            this.Controls.Add(this.pictureBoxWin);
            this.Controls.Add(this.labelObjective);
            this.Controls.Add(this.pictureBoxObjective);
            this.Controls.Add(this.panelGamefield);
            this.Controls.Add(this.buttonShuffle);
            this.Controls.Add(this.buttonLeft4);
            this.Controls.Add(this.buttonLeft3);
            this.Controls.Add(this.buttonLeft2);
            this.Controls.Add(this.buttonLeft1);
            this.Controls.Add(this.buttonTop4);
            this.Controls.Add(this.buttonTop3);
            this.Controls.Add(this.buttonTop2);
            this.Controls.Add(this.buttonTop1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(864, 533);
            this.MinimumSize = new System.Drawing.Size(864, 533);
            this.Name = "FormMain";
            this.Text = "Move Balloons";
            this.panelGamefield.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxObjective)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.PictureBox pictureBox14;
        private System.Windows.Forms.PictureBox pictureBox15;
        private System.Windows.Forms.PictureBox pictureBox16;
        private System.Windows.Forms.Button buttonTop1;
        private System.Windows.Forms.Button buttonTop2;
        private System.Windows.Forms.Button buttonTop3;
        private System.Windows.Forms.Button buttonTop4;
        private System.Windows.Forms.Button buttonLeft1;
        private System.Windows.Forms.Button buttonLeft2;
        private System.Windows.Forms.Button buttonLeft3;
        private System.Windows.Forms.Button buttonLeft4;
        private System.Windows.Forms.Button buttonShuffle;
        private System.Windows.Forms.Panel panelGamefield;
        private System.Windows.Forms.PictureBox pictureBoxObjective;
        private System.Windows.Forms.Label labelObjective;
        private System.Windows.Forms.PictureBox pictureBoxWin;
        private System.Windows.Forms.Label labelWin;
        private System.Windows.Forms.Button buttonBFS;
        private System.Windows.Forms.Button buttonBidirectionalSearch;
        private Label labelGCost;
        private Label labelHCost;
        private Button buttonHeuristicSearch;
        private Button buttonSolve;
        private Label labelSolution;
        private TextBox textBoxSolutionStats;
    }
}