namespace GraphSketchPad
{
    partial class frmSketchPad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSketchPad));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tstrDrawVertex = new System.Windows.Forms.ToolStripButton();
            this.tstrDrawEdge = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tstUndo = new System.Windows.Forms.ToolStripButton();
            this.tstRedo = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stsMouse = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsVertices = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsEdges = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsGeneric = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.btnColor = new System.Windows.Forms.Button();
            this.btnColor1 = new System.Windows.Forms.Button();
            this.btnColor2 = new System.Windows.Forms.Button();
            this.btnColor3 = new System.Windows.Forms.Button();
            this.btnColor4 = new System.Windows.Forms.Button();
            this.btnColor6 = new System.Windows.Forms.Button();
            this.btnColor9 = new System.Windows.Forms.Button();
            this.btnColor8 = new System.Windows.Forms.Button();
            this.btnColor7 = new System.Windows.Forms.Button();
            this.btnBackToggle = new System.Windows.Forms.Button();
            this.lnkCustom = new System.Windows.Forms.LinkLabel();
            this.chbVertexName = new System.Windows.Forms.CheckBox();
            this.chbVertexDegree = new System.Windows.Forms.CheckBox();
            this.btnDeleteEdges = new System.Windows.Forms.Button();
            this.btnDeleteVertices = new System.Windows.Forms.Button();
            this.btnDeleteLoops = new System.Windows.Forms.Button();
            this.btnShowBridges = new System.Windows.Forms.Button();
            this.lblChecks = new System.Windows.Forms.Label();
            this.lblDHN2 = new System.Windows.Forms.Label();
            this.cboDH_N2 = new System.Windows.Forms.ComboBox();
            this.btnDH_Draw = new System.Windows.Forms.Button();
            this.lblDHn = new System.Windows.Forms.Label();
            this.cboDH_N = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboDH_Type = new System.Windows.Forms.ComboBox();
            this.chbSticky = new System.Windows.Forms.CheckBox();
            this.btnContractEdge = new System.Windows.Forms.Button();
            this.chbDH_Opt1 = new System.Windows.Forms.CheckBox();
            this.btnColor5 = new System.Windows.Forms.Button();
            this.btnColor0 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblDHN3 = new System.Windows.Forms.Label();
            this.cboDH_N3 = new System.Windows.Forms.ComboBox();
            this.btnCurrentK2 = new System.Windows.Forms.Button();
            this.chbDH_K2 = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.rdbGC0 = new System.Windows.Forms.RadioButton();
            this.rdbGC9 = new System.Windows.Forms.RadioButton();
            this.btnColorGraph = new System.Windows.Forms.Button();
            this.rdbGC8 = new System.Windows.Forms.RadioButton();
            this.rdbGC7 = new System.Windows.Forms.RadioButton();
            this.rdbGC6 = new System.Windows.Forms.RadioButton();
            this.rdbGC5 = new System.Windows.Forms.RadioButton();
            this.rdbGC4 = new System.Windows.Forms.RadioButton();
            this.rdbGC3 = new System.Windows.Forms.RadioButton();
            this.rdbGC2 = new System.Windows.Forms.RadioButton();
            this.rdbGC1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chbSimple = new System.Windows.Forms.CheckBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnDoubleAll = new System.Windows.Forms.Button();
            this.btnDoubleSelected = new System.Windows.Forms.Button();
            this.btnSetAll = new System.Windows.Forms.Button();
            this.btnSetSelected = new System.Windows.Forms.Button();
            this.cboWeight = new System.Windows.Forms.ComboBox();
            this.chbWeights = new System.Windows.Forms.CheckBox();
            this.chbEdgeDirection = new System.Windows.Forms.CheckBox();
            this.btnChangeDirection = new System.Windows.Forms.Button();
            this.cboAdjacency = new System.Windows.Forms.CheckBox();
            this.cboIncidence = new System.Windows.Forms.CheckBox();
            this.chbDegreeMatrix = new System.Windows.Forms.CheckBox();
            this.chbIdentityMatrix = new System.Windows.Forms.CheckBox();
            this.txtMatrices = new System.Windows.Forms.TextBox();
            this.chbIncidenceD = new System.Windows.Forms.CheckBox();
            this.chbIncidenceTD = new System.Windows.Forms.CheckBox();
            this.chbLaplacian = new System.Windows.Forms.CheckBox();
            this.chbEigen = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tstrDrawVertex,
            this.tstrDrawEdge,
            this.toolStripSeparator1,
            this.tstUndo,
            this.tstRedo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1384, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tstrDrawVertex
            // 
            this.tstrDrawVertex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tstrDrawVertex.Image = ((System.Drawing.Image)(resources.GetObject("tstrDrawVertex.Image")));
            this.tstrDrawVertex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstrDrawVertex.Name = "tstrDrawVertex";
            this.tstrDrawVertex.Size = new System.Drawing.Size(23, 22);
            this.tstrDrawVertex.Text = "toolStripButton1";
            this.tstrDrawVertex.ToolTipText = "Draw Vertex";
            this.tstrDrawVertex.Click += new System.EventHandler(this.tstrDrawVertex_Click);
            // 
            // tstrDrawEdge
            // 
            this.tstrDrawEdge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tstrDrawEdge.Image = ((System.Drawing.Image)(resources.GetObject("tstrDrawEdge.Image")));
            this.tstrDrawEdge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstrDrawEdge.Name = "tstrDrawEdge";
            this.tstrDrawEdge.Size = new System.Drawing.Size(23, 22);
            this.tstrDrawEdge.Text = "toolStripButton1";
            this.tstrDrawEdge.ToolTipText = "Draw Edge";
            this.tstrDrawEdge.Click += new System.EventHandler(this.tstrDrawEdge_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tstUndo
            // 
            this.tstUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tstUndo.Image = ((System.Drawing.Image)(resources.GetObject("tstUndo.Image")));
            this.tstUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstUndo.Name = "tstUndo";
            this.tstUndo.Size = new System.Drawing.Size(23, 22);
            this.tstUndo.Text = "toolStripButton1";
            this.tstUndo.ToolTipText = "Undo";
            this.tstUndo.Click += new System.EventHandler(this.tstUndo_Click);
            // 
            // tstRedo
            // 
            this.tstRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tstRedo.Image = ((System.Drawing.Image)(resources.GetObject("tstRedo.Image")));
            this.tstRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tstRedo.Name = "tstRedo";
            this.tstRedo.Size = new System.Drawing.Size(23, 22);
            this.tstRedo.Text = "toolStripButton2";
            this.tstRedo.ToolTipText = "Redo";
            this.tstRedo.Click += new System.EventHandler(this.tstRedo_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsMouse,
            this.stsVertices,
            this.stsEdges,
            this.stsGeneric});
            this.statusStrip1.Location = new System.Drawing.Point(0, 616);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1384, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stsMouse
            // 
            this.stsMouse.Name = "stsMouse";
            this.stsMouse.Size = new System.Drawing.Size(26, 17);
            this.stsMouse.Text = "Idle";
            // 
            // stsVertices
            // 
            this.stsVertices.Name = "stsVertices";
            this.stsVertices.Size = new System.Drawing.Size(0, 17);
            // 
            // stsEdges
            // 
            this.stsEdges.Name = "stsEdges";
            this.stsEdges.Size = new System.Drawing.Size(0, 17);
            // 
            // stsGeneric
            // 
            this.stsGeneric.Name = "stsGeneric";
            this.stsGeneric.Size = new System.Drawing.Size(0, 17);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(42, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(603, 557);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(684, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Color:";
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnColor.Location = new System.Drawing.Point(724, 44);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(54, 23);
            this.btnColor.TabIndex = 4;
            this.btnColor.Text = "Active";
            this.btnColor.UseVisualStyleBackColor = false;
            this.btnColor.Click += new System.EventHandler(this.btnVertexColor_Click);
            // 
            // btnColor1
            // 
            this.btnColor1.BackColor = System.Drawing.Color.Red;
            this.btnColor1.Location = new System.Drawing.Point(784, 44);
            this.btnColor1.Name = "btnColor1";
            this.btnColor1.Size = new System.Drawing.Size(25, 23);
            this.btnColor1.TabIndex = 5;
            this.btnColor1.UseVisualStyleBackColor = false;
            this.btnColor1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnColor2
            // 
            this.btnColor2.BackColor = System.Drawing.Color.Blue;
            this.btnColor2.Location = new System.Drawing.Point(810, 44);
            this.btnColor2.Name = "btnColor2";
            this.btnColor2.Size = new System.Drawing.Size(25, 23);
            this.btnColor2.TabIndex = 6;
            this.btnColor2.UseVisualStyleBackColor = false;
            this.btnColor2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnColor3
            // 
            this.btnColor3.BackColor = System.Drawing.Color.Black;
            this.btnColor3.Location = new System.Drawing.Point(836, 44);
            this.btnColor3.Name = "btnColor3";
            this.btnColor3.Size = new System.Drawing.Size(25, 23);
            this.btnColor3.TabIndex = 7;
            this.btnColor3.UseVisualStyleBackColor = false;
            this.btnColor3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnColor4
            // 
            this.btnColor4.BackColor = System.Drawing.Color.White;
            this.btnColor4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnColor4.Location = new System.Drawing.Point(862, 44);
            this.btnColor4.Name = "btnColor4";
            this.btnColor4.Size = new System.Drawing.Size(25, 23);
            this.btnColor4.TabIndex = 8;
            this.btnColor4.UseVisualStyleBackColor = false;
            this.btnColor4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnColor6
            // 
            this.btnColor6.BackColor = System.Drawing.Color.Green;
            this.btnColor6.Location = new System.Drawing.Point(784, 73);
            this.btnColor6.Name = "btnColor6";
            this.btnColor6.Size = new System.Drawing.Size(25, 23);
            this.btnColor6.TabIndex = 9;
            this.btnColor6.UseVisualStyleBackColor = false;
            this.btnColor6.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnColor9
            // 
            this.btnColor9.BackColor = System.Drawing.Color.Yellow;
            this.btnColor9.Location = new System.Drawing.Point(862, 73);
            this.btnColor9.Name = "btnColor9";
            this.btnColor9.Size = new System.Drawing.Size(25, 23);
            this.btnColor9.TabIndex = 12;
            this.btnColor9.UseVisualStyleBackColor = false;
            this.btnColor9.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnColor8
            // 
            this.btnColor8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnColor8.Location = new System.Drawing.Point(836, 73);
            this.btnColor8.Name = "btnColor8";
            this.btnColor8.Size = new System.Drawing.Size(25, 23);
            this.btnColor8.TabIndex = 11;
            this.btnColor8.UseVisualStyleBackColor = false;
            this.btnColor8.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnColor7
            // 
            this.btnColor7.BackColor = System.Drawing.Color.Purple;
            this.btnColor7.Location = new System.Drawing.Point(810, 73);
            this.btnColor7.Name = "btnColor7";
            this.btnColor7.Size = new System.Drawing.Size(25, 23);
            this.btnColor7.TabIndex = 10;
            this.btnColor7.UseVisualStyleBackColor = false;
            this.btnColor7.Click += new System.EventHandler(this.button8_Click);
            // 
            // btnBackToggle
            // 
            this.btnBackToggle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnBackToggle.Location = new System.Drawing.Point(724, 120);
            this.btnBackToggle.Name = "btnBackToggle";
            this.btnBackToggle.Size = new System.Drawing.Size(116, 23);
            this.btnBackToggle.TabIndex = 13;
            this.btnBackToggle.Text = "Toggle Background";
            this.btnBackToggle.UseVisualStyleBackColor = false;
            this.btnBackToggle.Click += new System.EventHandler(this.btnBackToggle_Click);
            // 
            // lnkCustom
            // 
            this.lnkCustom.AutoSize = true;
            this.lnkCustom.Location = new System.Drawing.Point(731, 70);
            this.lnkCustom.Name = "lnkCustom";
            this.lnkCustom.Size = new System.Drawing.Size(42, 13);
            this.lnkCustom.TabIndex = 14;
            this.lnkCustom.TabStop = true;
            this.lnkCustom.Text = "Custom";
            this.lnkCustom.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCustom_LinkClicked);
            // 
            // chbVertexName
            // 
            this.chbVertexName.AutoSize = true;
            this.chbVertexName.Location = new System.Drawing.Point(656, 158);
            this.chbVertexName.Name = "chbVertexName";
            this.chbVertexName.Size = new System.Drawing.Size(117, 17);
            this.chbVertexName.TabIndex = 15;
            this.chbVertexName.Text = "Show Vertex Name";
            this.chbVertexName.UseVisualStyleBackColor = true;
            this.chbVertexName.CheckedChanged += new System.EventHandler(this.chbVertexName_CheckedChanged);
            // 
            // chbVertexDegree
            // 
            this.chbVertexDegree.AutoSize = true;
            this.chbVertexDegree.Location = new System.Drawing.Point(656, 181);
            this.chbVertexDegree.Name = "chbVertexDegree";
            this.chbVertexDegree.Size = new System.Drawing.Size(124, 17);
            this.chbVertexDegree.TabIndex = 16;
            this.chbVertexDegree.Text = "Show Vertex Degree";
            this.chbVertexDegree.UseVisualStyleBackColor = true;
            this.chbVertexDegree.CheckedChanged += new System.EventHandler(this.chbVertexDegree_CheckedChanged);
            // 
            // btnDeleteEdges
            // 
            this.btnDeleteEdges.Location = new System.Drawing.Point(656, 256);
            this.btnDeleteEdges.Name = "btnDeleteEdges";
            this.btnDeleteEdges.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteEdges.TabIndex = 17;
            this.btnDeleteEdges.Text = "Clear Edges";
            this.btnDeleteEdges.UseVisualStyleBackColor = true;
            this.btnDeleteEdges.Click += new System.EventHandler(this.btnDeleteEdges_Click);
            // 
            // btnDeleteVertices
            // 
            this.btnDeleteVertices.Location = new System.Drawing.Point(656, 227);
            this.btnDeleteVertices.Name = "btnDeleteVertices";
            this.btnDeleteVertices.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteVertices.TabIndex = 18;
            this.btnDeleteVertices.Text = "Clear Graph";
            this.btnDeleteVertices.UseVisualStyleBackColor = true;
            this.btnDeleteVertices.Click += new System.EventHandler(this.btnDeleteVertices_Click);
            // 
            // btnDeleteLoops
            // 
            this.btnDeleteLoops.Location = new System.Drawing.Point(656, 285);
            this.btnDeleteLoops.Name = "btnDeleteLoops";
            this.btnDeleteLoops.Size = new System.Drawing.Size(85, 23);
            this.btnDeleteLoops.TabIndex = 19;
            this.btnDeleteLoops.Text = "Clear All Loops";
            this.btnDeleteLoops.UseVisualStyleBackColor = true;
            this.btnDeleteLoops.Click += new System.EventHandler(this.btnDeleteLoops_Click);
            // 
            // btnShowBridges
            // 
            this.btnShowBridges.Location = new System.Drawing.Point(656, 314);
            this.btnShowBridges.Name = "btnShowBridges";
            this.btnShowBridges.Size = new System.Drawing.Size(85, 23);
            this.btnShowBridges.TabIndex = 20;
            this.btnShowBridges.Text = "Show Bridges";
            this.btnShowBridges.UseVisualStyleBackColor = true;
            this.btnShowBridges.Click += new System.EventHandler(this.btnShowBridges_Click);
            // 
            // lblChecks
            // 
            this.lblChecks.AutoSize = true;
            this.lblChecks.Location = new System.Drawing.Point(774, 227);
            this.lblChecks.Name = "lblChecks";
            this.lblChecks.Size = new System.Drawing.Size(35, 13);
            this.lblChecks.TabIndex = 22;
            this.lblChecks.Text = "label2";
            // 
            // lblDHN2
            // 
            this.lblDHN2.AutoSize = true;
            this.lblDHN2.Location = new System.Drawing.Point(207, 7);
            this.lblDHN2.Name = "lblDHN2";
            this.lblDHN2.Size = new System.Drawing.Size(39, 13);
            this.lblDHN2.TabIndex = 7;
            this.lblDHN2.Text = "Part Y:";
            this.lblDHN2.Visible = false;
            // 
            // cboDH_N2
            // 
            this.cboDH_N2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDH_N2.FormattingEnabled = true;
            this.cboDH_N2.Location = new System.Drawing.Point(207, 23);
            this.cboDH_N2.Name = "cboDH_N2";
            this.cboDH_N2.Size = new System.Drawing.Size(46, 21);
            this.cboDH_N2.TabIndex = 6;
            this.cboDH_N2.Visible = false;
            // 
            // btnDH_Draw
            // 
            this.btnDH_Draw.Location = new System.Drawing.Point(6, 67);
            this.btnDH_Draw.Name = "btnDH_Draw";
            this.btnDH_Draw.Size = new System.Drawing.Size(75, 23);
            this.btnDH_Draw.TabIndex = 5;
            this.btnDH_Draw.Text = "Draw";
            this.btnDH_Draw.UseVisualStyleBackColor = true;
            this.btnDH_Draw.Click += new System.EventHandler(this.btnDH_Draw_Click);
            // 
            // lblDHn
            // 
            this.lblDHn.AutoSize = true;
            this.lblDHn.Location = new System.Drawing.Point(142, 7);
            this.lblDHn.Name = "lblDHn";
            this.lblDHn.Size = new System.Drawing.Size(39, 13);
            this.lblDHn.TabIndex = 4;
            this.lblDHn.Text = "Part X:";
            this.lblDHn.Visible = false;
            // 
            // cboDH_N
            // 
            this.cboDH_N.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDH_N.FormattingEnabled = true;
            this.cboDH_N.Location = new System.Drawing.Point(145, 23);
            this.cboDH_N.Name = "cboDH_N";
            this.cboDH_N.Size = new System.Drawing.Size(56, 21);
            this.cboDH_N.TabIndex = 3;
            this.cboDH_N.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type:";
            // 
            // cboDH_Type
            // 
            this.cboDH_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDH_Type.FormattingEnabled = true;
            this.cboDH_Type.Items.AddRange(new object[] {
            "Circle (Cn)",
            "Complete (Kn)"});
            this.cboDH_Type.Location = new System.Drawing.Point(7, 23);
            this.cboDH_Type.Name = "cboDH_Type";
            this.cboDH_Type.Size = new System.Drawing.Size(121, 21);
            this.cboDH_Type.TabIndex = 1;
            this.cboDH_Type.SelectedIndexChanged += new System.EventHandler(this.cboDH_Type_SelectedIndexChanged);
            // 
            // chbSticky
            // 
            this.chbSticky.AutoSize = true;
            this.chbSticky.Location = new System.Drawing.Point(725, 86);
            this.chbSticky.Name = "chbSticky";
            this.chbSticky.Size = new System.Drawing.Size(55, 17);
            this.chbSticky.TabIndex = 25;
            this.chbSticky.Text = "Sticky";
            this.chbSticky.UseVisualStyleBackColor = true;
            // 
            // btnContractEdge
            // 
            this.btnContractEdge.Enabled = false;
            this.btnContractEdge.Location = new System.Drawing.Point(656, 344);
            this.btnContractEdge.Name = "btnContractEdge";
            this.btnContractEdge.Size = new System.Drawing.Size(85, 23);
            this.btnContractEdge.TabIndex = 26;
            this.btnContractEdge.Text = "Contract Edge";
            this.btnContractEdge.UseVisualStyleBackColor = true;
            this.btnContractEdge.Click += new System.EventHandler(this.btnContractEdge_Click);
            // 
            // chbDH_Opt1
            // 
            this.chbDH_Opt1.AutoSize = true;
            this.chbDH_Opt1.Location = new System.Drawing.Point(145, 51);
            this.chbDH_Opt1.Name = "chbDH_Opt1";
            this.chbDH_Opt1.Size = new System.Drawing.Size(59, 17);
            this.chbDH_Opt1.TabIndex = 8;
            this.chbDH_Opt1.Text = "2-Color";
            this.chbDH_Opt1.UseVisualStyleBackColor = true;
            this.chbDH_Opt1.Visible = false;
            // 
            // btnColor5
            // 
            this.btnColor5.BackColor = System.Drawing.Color.SpringGreen;
            this.btnColor5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnColor5.Location = new System.Drawing.Point(888, 44);
            this.btnColor5.Name = "btnColor5";
            this.btnColor5.Size = new System.Drawing.Size(25, 23);
            this.btnColor5.TabIndex = 27;
            this.btnColor5.UseVisualStyleBackColor = false;
            // 
            // btnColor0
            // 
            this.btnColor0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnColor0.Location = new System.Drawing.Point(888, 73);
            this.btnColor0.Name = "btnColor0";
            this.btnColor0.Size = new System.Drawing.Size(25, 23);
            this.btnColor0.TabIndex = 28;
            this.btnColor0.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(656, 373);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(299, 156);
            this.tabControl1.TabIndex = 31;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblDHN3);
            this.tabPage1.Controls.Add(this.cboDH_N3);
            this.tabPage1.Controls.Add(this.btnCurrentK2);
            this.tabPage1.Controls.Add(this.chbDH_K2);
            this.tabPage1.Controls.Add(this.chbDH_Opt1);
            this.tabPage1.Controls.Add(this.cboDH_Type);
            this.tabPage1.Controls.Add(this.lblDHN2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cboDH_N2);
            this.tabPage1.Controls.Add(this.cboDH_N);
            this.tabPage1.Controls.Add(this.btnDH_Draw);
            this.tabPage1.Controls.Add(this.lblDHn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(291, 130);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Draw Helper";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblDHN3
            // 
            this.lblDHN3.AutoSize = true;
            this.lblDHN3.Location = new System.Drawing.Point(207, 53);
            this.lblDHN3.Name = "lblDHN3";
            this.lblDHN3.Size = new System.Drawing.Size(39, 13);
            this.lblDHN3.TabIndex = 12;
            this.lblDHN3.Text = "Part Y:";
            this.lblDHN3.Visible = false;
            // 
            // cboDH_N3
            // 
            this.cboDH_N3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDH_N3.FormattingEnabled = true;
            this.cboDH_N3.Location = new System.Drawing.Point(207, 69);
            this.cboDH_N3.Name = "cboDH_N3";
            this.cboDH_N3.Size = new System.Drawing.Size(46, 21);
            this.cboDH_N3.TabIndex = 11;
            this.cboDH_N3.Visible = false;
            // 
            // btnCurrentK2
            // 
            this.btnCurrentK2.Location = new System.Drawing.Point(6, 101);
            this.btnCurrentK2.Name = "btnCurrentK2";
            this.btnCurrentK2.Size = new System.Drawing.Size(112, 23);
            this.btnCurrentK2.TabIndex = 10;
            this.btnCurrentK2.Text = "Current Graph x K2";
            this.btnCurrentK2.UseVisualStyleBackColor = true;
            this.btnCurrentK2.Click += new System.EventHandler(this.btnCurrentK2_Click);
            // 
            // chbDH_K2
            // 
            this.chbDH_K2.AutoSize = true;
            this.chbDH_K2.Location = new System.Drawing.Point(10, 48);
            this.chbDH_K2.Name = "chbDH_K2";
            this.chbDH_K2.Size = new System.Drawing.Size(64, 17);
            this.chbDH_K2.TabIndex = 9;
            this.chbDH_K2.Text = "G x K_2";
            this.chbDH_K2.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.rdbGC0);
            this.tabPage2.Controls.Add(this.rdbGC9);
            this.tabPage2.Controls.Add(this.btnColorGraph);
            this.tabPage2.Controls.Add(this.rdbGC8);
            this.tabPage2.Controls.Add(this.rdbGC7);
            this.tabPage2.Controls.Add(this.rdbGC6);
            this.tabPage2.Controls.Add(this.rdbGC5);
            this.tabPage2.Controls.Add(this.rdbGC4);
            this.tabPage2.Controls.Add(this.rdbGC3);
            this.tabPage2.Controls.Add(this.rdbGC2);
            this.tabPage2.Controls.Add(this.rdbGC1);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(291, 130);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Graph Coloring";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // rdbGC0
            // 
            this.rdbGC0.AutoSize = true;
            this.rdbGC0.Location = new System.Drawing.Point(163, 43);
            this.rdbGC0.Name = "rdbGC0";
            this.rdbGC0.Size = new System.Drawing.Size(37, 17);
            this.rdbGC0.TabIndex = 11;
            this.rdbGC0.Text = "10";
            this.rdbGC0.UseVisualStyleBackColor = true;
            // 
            // rdbGC9
            // 
            this.rdbGC9.AutoSize = true;
            this.rdbGC9.Location = new System.Drawing.Point(126, 43);
            this.rdbGC9.Name = "rdbGC9";
            this.rdbGC9.Size = new System.Drawing.Size(31, 17);
            this.rdbGC9.TabIndex = 10;
            this.rdbGC9.Text = "9";
            this.rdbGC9.UseVisualStyleBackColor = true;
            // 
            // btnColorGraph
            // 
            this.btnColorGraph.Location = new System.Drawing.Point(64, 66);
            this.btnColorGraph.Name = "btnColorGraph";
            this.btnColorGraph.Size = new System.Drawing.Size(75, 23);
            this.btnColorGraph.TabIndex = 9;
            this.btnColorGraph.Text = "Color Graph";
            this.btnColorGraph.UseVisualStyleBackColor = true;
            this.btnColorGraph.Click += new System.EventHandler(this.btnColorGraph_Click);
            // 
            // rdbGC8
            // 
            this.rdbGC8.AutoSize = true;
            this.rdbGC8.Location = new System.Drawing.Point(89, 43);
            this.rdbGC8.Name = "rdbGC8";
            this.rdbGC8.Size = new System.Drawing.Size(31, 17);
            this.rdbGC8.TabIndex = 8;
            this.rdbGC8.Text = "8";
            this.rdbGC8.UseVisualStyleBackColor = true;
            // 
            // rdbGC7
            // 
            this.rdbGC7.AutoSize = true;
            this.rdbGC7.Location = new System.Drawing.Point(50, 43);
            this.rdbGC7.Name = "rdbGC7";
            this.rdbGC7.Size = new System.Drawing.Size(31, 17);
            this.rdbGC7.TabIndex = 7;
            this.rdbGC7.Text = "7";
            this.rdbGC7.UseVisualStyleBackColor = true;
            // 
            // rdbGC6
            // 
            this.rdbGC6.AutoSize = true;
            this.rdbGC6.Location = new System.Drawing.Point(10, 43);
            this.rdbGC6.Name = "rdbGC6";
            this.rdbGC6.Size = new System.Drawing.Size(31, 17);
            this.rdbGC6.TabIndex = 6;
            this.rdbGC6.Text = "6";
            this.rdbGC6.UseVisualStyleBackColor = true;
            // 
            // rdbGC5
            // 
            this.rdbGC5.AutoSize = true;
            this.rdbGC5.Location = new System.Drawing.Point(163, 20);
            this.rdbGC5.Name = "rdbGC5";
            this.rdbGC5.Size = new System.Drawing.Size(31, 17);
            this.rdbGC5.TabIndex = 5;
            this.rdbGC5.Text = "5";
            this.rdbGC5.UseVisualStyleBackColor = true;
            // 
            // rdbGC4
            // 
            this.rdbGC4.AutoSize = true;
            this.rdbGC4.Location = new System.Drawing.Point(126, 20);
            this.rdbGC4.Name = "rdbGC4";
            this.rdbGC4.Size = new System.Drawing.Size(31, 17);
            this.rdbGC4.TabIndex = 4;
            this.rdbGC4.Text = "4";
            this.rdbGC4.UseVisualStyleBackColor = true;
            // 
            // rdbGC3
            // 
            this.rdbGC3.AutoSize = true;
            this.rdbGC3.Location = new System.Drawing.Point(89, 20);
            this.rdbGC3.Name = "rdbGC3";
            this.rdbGC3.Size = new System.Drawing.Size(31, 17);
            this.rdbGC3.TabIndex = 3;
            this.rdbGC3.Text = "3";
            this.rdbGC3.UseVisualStyleBackColor = true;
            // 
            // rdbGC2
            // 
            this.rdbGC2.AutoSize = true;
            this.rdbGC2.Location = new System.Drawing.Point(50, 20);
            this.rdbGC2.Name = "rdbGC2";
            this.rdbGC2.Size = new System.Drawing.Size(31, 17);
            this.rdbGC2.TabIndex = 2;
            this.rdbGC2.Text = "2";
            this.rdbGC2.UseVisualStyleBackColor = true;
            // 
            // rdbGC1
            // 
            this.rdbGC1.AutoSize = true;
            this.rdbGC1.Checked = true;
            this.rdbGC1.Location = new System.Drawing.Point(10, 20);
            this.rdbGC1.Name = "rdbGC1";
            this.rdbGC1.Size = new System.Drawing.Size(31, 17);
            this.rdbGC1.TabIndex = 1;
            this.rdbGC1.TabStop = true;
            this.rdbGC1.Text = "1";
            this.rdbGC1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "No of Colors:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chbSimple);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(291, 130);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Options";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // chbSimple
            // 
            this.chbSimple.AutoSize = true;
            this.chbSimple.Location = new System.Drawing.Point(7, 7);
            this.chbSimple.Name = "chbSimple";
            this.chbSimple.Size = new System.Drawing.Size(119, 17);
            this.chbSimple.TabIndex = 0;
            this.chbSimple.Text = "Force Simple Graph";
            this.chbSimple.UseVisualStyleBackColor = true;
            this.chbSimple.CheckedChanged += new System.EventHandler(this.chbSimple_CheckedChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnDoubleAll);
            this.tabPage4.Controls.Add(this.btnDoubleSelected);
            this.tabPage4.Controls.Add(this.btnSetAll);
            this.tabPage4.Controls.Add(this.btnSetSelected);
            this.tabPage4.Controls.Add(this.cboWeight);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(291, 130);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Weighted Edges";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnDoubleAll
            // 
            this.btnDoubleAll.Location = new System.Drawing.Point(176, 52);
            this.btnDoubleAll.Name = "btnDoubleAll";
            this.btnDoubleAll.Size = new System.Drawing.Size(75, 23);
            this.btnDoubleAll.TabIndex = 4;
            this.btnDoubleAll.Text = "Double All";
            this.btnDoubleAll.UseVisualStyleBackColor = true;
            this.btnDoubleAll.Click += new System.EventHandler(this.btnDoubleAll_Click);
            // 
            // btnDoubleSelected
            // 
            this.btnDoubleSelected.Location = new System.Drawing.Point(64, 52);
            this.btnDoubleSelected.Name = "btnDoubleSelected";
            this.btnDoubleSelected.Size = new System.Drawing.Size(104, 23);
            this.btnDoubleSelected.TabIndex = 3;
            this.btnDoubleSelected.Text = "Double Selected";
            this.btnDoubleSelected.UseVisualStyleBackColor = true;
            this.btnDoubleSelected.Click += new System.EventHandler(this.btnDoubleSelected_Click);
            // 
            // btnSetAll
            // 
            this.btnSetAll.Location = new System.Drawing.Point(176, 7);
            this.btnSetAll.Name = "btnSetAll";
            this.btnSetAll.Size = new System.Drawing.Size(75, 23);
            this.btnSetAll.TabIndex = 2;
            this.btnSetAll.Text = "Set All";
            this.btnSetAll.UseVisualStyleBackColor = true;
            this.btnSetAll.Click += new System.EventHandler(this.btnSetAll_Click);
            // 
            // btnSetSelected
            // 
            this.btnSetSelected.Location = new System.Drawing.Point(64, 6);
            this.btnSetSelected.Name = "btnSetSelected";
            this.btnSetSelected.Size = new System.Drawing.Size(104, 23);
            this.btnSetSelected.TabIndex = 1;
            this.btnSetSelected.Text = "Set Selected";
            this.btnSetSelected.UseVisualStyleBackColor = true;
            this.btnSetSelected.Click += new System.EventHandler(this.btnSetSelected_Click);
            // 
            // cboWeight
            // 
            this.cboWeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboWeight.FormattingEnabled = true;
            this.cboWeight.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.cboWeight.Location = new System.Drawing.Point(7, 7);
            this.cboWeight.Name = "cboWeight";
            this.cboWeight.Size = new System.Drawing.Size(51, 21);
            this.cboWeight.TabIndex = 0;
            // 
            // chbWeights
            // 
            this.chbWeights.AutoSize = true;
            this.chbWeights.Location = new System.Drawing.Point(656, 204);
            this.chbWeights.Name = "chbWeights";
            this.chbWeights.Size = new System.Drawing.Size(123, 17);
            this.chbWeights.TabIndex = 32;
            this.chbWeights.Text = "Show Edge Weights";
            this.chbWeights.UseVisualStyleBackColor = true;
            this.chbWeights.CheckedChanged += new System.EventHandler(this.chbWeights_CheckedChanged);
            // 
            // chbEdgeDirection
            // 
            this.chbEdgeDirection.AutoSize = true;
            this.chbEdgeDirection.Location = new System.Drawing.Point(805, 204);
            this.chbEdgeDirection.Name = "chbEdgeDirection";
            this.chbEdgeDirection.Size = new System.Drawing.Size(126, 17);
            this.chbEdgeDirection.TabIndex = 33;
            this.chbEdgeDirection.Text = "Show Edge Direction";
            this.chbEdgeDirection.UseVisualStyleBackColor = true;
            this.chbEdgeDirection.CheckedChanged += new System.EventHandler(this.chbEdgeDirection_CheckedChanged);
            // 
            // btnChangeDirection
            // 
            this.btnChangeDirection.Enabled = false;
            this.btnChangeDirection.Location = new System.Drawing.Point(750, 344);
            this.btnChangeDirection.Name = "btnChangeDirection";
            this.btnChangeDirection.Size = new System.Drawing.Size(111, 23);
            this.btnChangeDirection.TabIndex = 34;
            this.btnChangeDirection.Text = "Change Direction";
            this.btnChangeDirection.UseVisualStyleBackColor = true;
            this.btnChangeDirection.Click += new System.EventHandler(this.btnChangeDirection_Click);
            // 
            // cboAdjacency
            // 
            this.cboAdjacency.AutoSize = true;
            this.cboAdjacency.Location = new System.Drawing.Point(969, 8);
            this.cboAdjacency.Name = "cboAdjacency";
            this.cboAdjacency.Size = new System.Drawing.Size(107, 17);
            this.cboAdjacency.TabIndex = 36;
            this.cboAdjacency.Text = "Adjacency Matrix";
            this.cboAdjacency.UseVisualStyleBackColor = true;
            this.cboAdjacency.CheckedChanged += new System.EventHandler(this.cboAdjacency_CheckedChanged);
            // 
            // cboIncidence
            // 
            this.cboIncidence.AutoSize = true;
            this.cboIncidence.Location = new System.Drawing.Point(1087, 8);
            this.cboIncidence.Name = "cboIncidence";
            this.cboIncidence.Size = new System.Drawing.Size(104, 17);
            this.cboIncidence.TabIndex = 37;
            this.cboIncidence.Text = "Incidence Matrix";
            this.cboIncidence.UseVisualStyleBackColor = true;
            this.cboIncidence.CheckedChanged += new System.EventHandler(this.cboIncidence_CheckedChanged);
            // 
            // chbDegreeMatrix
            // 
            this.chbDegreeMatrix.AutoSize = true;
            this.chbDegreeMatrix.Location = new System.Drawing.Point(969, 30);
            this.chbDegreeMatrix.Name = "chbDegreeMatrix";
            this.chbDegreeMatrix.Size = new System.Drawing.Size(92, 17);
            this.chbDegreeMatrix.TabIndex = 38;
            this.chbDegreeMatrix.Text = "Degree Matrix";
            this.chbDegreeMatrix.UseVisualStyleBackColor = true;
            this.chbDegreeMatrix.CheckedChanged += new System.EventHandler(this.chbDegreeMatrix_CheckedChanged);
            // 
            // chbIdentityMatrix
            // 
            this.chbIdentityMatrix.AutoSize = true;
            this.chbIdentityMatrix.Location = new System.Drawing.Point(1087, 30);
            this.chbIdentityMatrix.Name = "chbIdentityMatrix";
            this.chbIdentityMatrix.Size = new System.Drawing.Size(91, 17);
            this.chbIdentityMatrix.TabIndex = 39;
            this.chbIdentityMatrix.Text = "Identity Matrix";
            this.chbIdentityMatrix.UseVisualStyleBackColor = true;
            this.chbIdentityMatrix.CheckedChanged += new System.EventHandler(this.chbIdentityMatrix_CheckedChanged);
            // 
            // txtMatrices
            // 
            this.txtMatrices.AcceptsReturn = true;
            this.txtMatrices.Location = new System.Drawing.Point(967, 99);
            this.txtMatrices.Multiline = true;
            this.txtMatrices.Name = "txtMatrices";
            this.txtMatrices.ReadOnly = true;
            this.txtMatrices.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMatrices.Size = new System.Drawing.Size(403, 502);
            this.txtMatrices.TabIndex = 40;
            this.txtMatrices.WordWrap = false;
            // 
            // chbIncidenceD
            // 
            this.chbIncidenceD.AutoSize = true;
            this.chbIncidenceD.Location = new System.Drawing.Point(969, 53);
            this.chbIncidenceD.Name = "chbIncidenceD";
            this.chbIncidenceD.Size = new System.Drawing.Size(119, 17);
            this.chbIncidenceD.TabIndex = 41;
            this.chbIncidenceD.Text = "Incidence Matrix (>)";
            this.chbIncidenceD.UseVisualStyleBackColor = true;
            this.chbIncidenceD.CheckedChanged += new System.EventHandler(this.chbIncidenceD_CheckedChanged);
            // 
            // chbIncidenceTD
            // 
            this.chbIncidenceTD.AutoSize = true;
            this.chbIncidenceTD.Location = new System.Drawing.Point(1087, 53);
            this.chbIncidenceTD.Name = "chbIncidenceTD";
            this.chbIncidenceTD.Size = new System.Drawing.Size(129, 17);
            this.chbIncidenceTD.TabIndex = 42;
            this.chbIncidenceTD.Text = "Incidence Matrix (>) T";
            this.chbIncidenceTD.UseVisualStyleBackColor = true;
            this.chbIncidenceTD.CheckedChanged += new System.EventHandler(this.chbIncidenceTD_CheckedChanged);
            // 
            // chbLaplacian
            // 
            this.chbLaplacian.AutoSize = true;
            this.chbLaplacian.Location = new System.Drawing.Point(969, 76);
            this.chbLaplacian.Name = "chbLaplacian";
            this.chbLaplacian.Size = new System.Drawing.Size(103, 17);
            this.chbLaplacian.TabIndex = 43;
            this.chbLaplacian.Text = "Laplacian Matrix";
            this.chbLaplacian.UseVisualStyleBackColor = true;
            this.chbLaplacian.CheckedChanged += new System.EventHandler(this.chbLaplacian_CheckedChanged);
            // 
            // chbEigen
            // 
            this.chbEigen.AutoSize = true;
            this.chbEigen.Location = new System.Drawing.Point(1087, 77);
            this.chbEigen.Name = "chbEigen";
            this.chbEigen.Size = new System.Drawing.Size(158, 17);
            this.chbEigen.TabIndex = 44;
            this.chbEigen.Text = "Eigenvalues && Eigenvectors";
            this.chbEigen.UseVisualStyleBackColor = true;
            this.chbEigen.CheckedChanged += new System.EventHandler(this.chbEigen_CheckedChanged);
            // 
            // frmSketchPad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 638);
            this.Controls.Add(this.chbEigen);
            this.Controls.Add(this.chbLaplacian);
            this.Controls.Add(this.chbIncidenceTD);
            this.Controls.Add(this.chbIncidenceD);
            this.Controls.Add(this.txtMatrices);
            this.Controls.Add(this.chbIdentityMatrix);
            this.Controls.Add(this.chbDegreeMatrix);
            this.Controls.Add(this.cboIncidence);
            this.Controls.Add(this.cboAdjacency);
            this.Controls.Add(this.btnChangeDirection);
            this.Controls.Add(this.chbEdgeDirection);
            this.Controls.Add(this.chbWeights);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnColor0);
            this.Controls.Add(this.btnColor5);
            this.Controls.Add(this.btnContractEdge);
            this.Controls.Add(this.chbSticky);
            this.Controls.Add(this.lblChecks);
            this.Controls.Add(this.btnShowBridges);
            this.Controls.Add(this.btnDeleteLoops);
            this.Controls.Add(this.btnDeleteVertices);
            this.Controls.Add(this.btnDeleteEdges);
            this.Controls.Add(this.chbVertexDegree);
            this.Controls.Add(this.chbVertexName);
            this.Controls.Add(this.lnkCustom);
            this.Controls.Add(this.btnBackToggle);
            this.Controls.Add(this.btnColor9);
            this.Controls.Add(this.btnColor8);
            this.Controls.Add(this.btnColor7);
            this.Controls.Add(this.btnColor6);
            this.Controls.Add(this.btnColor4);
            this.Controls.Add(this.btnColor3);
            this.Controls.Add(this.btnColor2);
            this.Controls.Add(this.btnColor1);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.KeyPreview = true;
            this.Name = "frmSketchPad";
            this.Text = "Graph Theory Sketch Pad";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SketchPad_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tstrDrawVertex;
        private System.Windows.Forms.ToolStripButton tstrDrawEdge;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stsMouse;
        private System.Windows.Forms.ToolStripStatusLabel stsVertices;
        private System.Windows.Forms.ToolStripStatusLabel stsGeneric;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripStatusLabel stsEdges;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.Button btnColor1;
        private System.Windows.Forms.Button btnColor2;
        private System.Windows.Forms.Button btnColor3;
        private System.Windows.Forms.Button btnColor4;
        private System.Windows.Forms.Button btnColor6;
        private System.Windows.Forms.Button btnColor9;
        private System.Windows.Forms.Button btnColor8;
        private System.Windows.Forms.Button btnColor7;
        private System.Windows.Forms.Button btnBackToggle;
        private System.Windows.Forms.LinkLabel lnkCustom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tstUndo;
        private System.Windows.Forms.ToolStripButton tstRedo;
        private System.Windows.Forms.CheckBox chbVertexName;
        private System.Windows.Forms.CheckBox chbVertexDegree;
        private System.Windows.Forms.Button btnDeleteEdges;
        private System.Windows.Forms.Button btnDeleteVertices;
        private System.Windows.Forms.Button btnDeleteLoops;
        private System.Windows.Forms.Button btnShowBridges;
        private System.Windows.Forms.Label lblChecks;
        private System.Windows.Forms.Label lblDHn;
        private System.Windows.Forms.ComboBox cboDH_N;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboDH_Type;
        private System.Windows.Forms.Button btnDH_Draw;
        private System.Windows.Forms.CheckBox chbSticky;
        private System.Windows.Forms.Button btnContractEdge;
        private System.Windows.Forms.Label lblDHN2;
        private System.Windows.Forms.ComboBox cboDH_N2;
        private System.Windows.Forms.CheckBox chbDH_Opt1;
        private System.Windows.Forms.Button btnColor5;
        private System.Windows.Forms.Button btnColor0;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RadioButton rdbGC2;
        private System.Windows.Forms.RadioButton rdbGC1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdbGC8;
        private System.Windows.Forms.RadioButton rdbGC7;
        private System.Windows.Forms.RadioButton rdbGC6;
        private System.Windows.Forms.RadioButton rdbGC5;
        private System.Windows.Forms.RadioButton rdbGC4;
        private System.Windows.Forms.RadioButton rdbGC3;
        private System.Windows.Forms.Button btnColorGraph;
        private System.Windows.Forms.RadioButton rdbGC0;
        private System.Windows.Forms.RadioButton rdbGC9;
        private System.Windows.Forms.CheckBox chbDH_K2;
        private System.Windows.Forms.Button btnCurrentK2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox chbSimple;
        private System.Windows.Forms.CheckBox chbWeights;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnDoubleAll;
        private System.Windows.Forms.Button btnDoubleSelected;
        private System.Windows.Forms.Button btnSetAll;
        private System.Windows.Forms.Button btnSetSelected;
        private System.Windows.Forms.ComboBox cboWeight;
        private System.Windows.Forms.CheckBox chbEdgeDirection;
        private System.Windows.Forms.Button btnChangeDirection;
        private System.Windows.Forms.Label lblDHN3;
        private System.Windows.Forms.ComboBox cboDH_N3;
        private System.Windows.Forms.CheckBox cboAdjacency;
        private System.Windows.Forms.CheckBox cboIncidence;
        private System.Windows.Forms.CheckBox chbDegreeMatrix;
        private System.Windows.Forms.CheckBox chbIdentityMatrix;
        private System.Windows.Forms.TextBox txtMatrices;
        private System.Windows.Forms.CheckBox chbIncidenceD;
        private System.Windows.Forms.CheckBox chbIncidenceTD;
        private System.Windows.Forms.CheckBox chbLaplacian;
        private System.Windows.Forms.CheckBox chbEigen;
    }
}

