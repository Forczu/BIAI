namespace BIAI
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            this.graph = new ZedGraph.ZedGraphControl();
            this.initalLearningRateLabel = new System.Windows.Forms.Label();
            this.trainingIterationsLabel = new System.Windows.Forms.Label();
            this.hiddenLayerCountLabel = new System.Windows.Forms.Label();
            this.neuronCountLabel1 = new System.Windows.Forms.Label();
            this.neuronCountLabel2 = new System.Windows.Forms.Label();
            this.neuronCountLabel3 = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesGroupBox = new System.Windows.Forms.GroupBox();
            this.dailySampleBox = new System.Windows.Forms.NumericUpDown();
            this.dailyButton = new System.Windows.Forms.RadioButton();
            this.weeklyButton = new System.Windows.Forms.RadioButton();
            this.monthlyButton = new System.Windows.Forms.RadioButton();
            this.sampleFormatLabel = new System.Windows.Forms.Label();
            this.filesListBox = new System.Windows.Forms.ListBox();
            this.predictionGroupBox = new System.Windows.Forms.GroupBox();
            this.predictionRespone = new System.Windows.Forms.ListBox();
            this.predictButton = new System.Windows.Forms.Button();
            this.meanSSELabel = new System.Windows.Forms.Label();
            this.meanSSEValue = new System.Windows.Forms.Label();
            this.learningFunctionLabel = new System.Windows.Forms.Label();
            this.functionBox = new System.Windows.Forms.ComboBox();
            this.finalLearningRateLabel = new System.Windows.Forms.Label();
            this.learnGroupBox = new System.Windows.Forms.GroupBox();
            this.finalLearningRateBox = new System.Windows.Forms.NumericUpDown();
            this.initialLearningRateBox = new System.Windows.Forms.NumericUpDown();
            this.structureGroupBox = new System.Windows.Forms.GroupBox();
            this.neuronCountBox3 = new System.Windows.Forms.NumericUpDown();
            this.neuronCountBox2 = new System.Windows.Forms.NumericUpDown();
            this.neuronCountBox1 = new System.Windows.Forms.NumericUpDown();
            this.hiddenLayerCountBox = new System.Windows.Forms.NumericUpDown();
            this.initializationGroupBox = new System.Windows.Forms.GroupBox();
            this.initializerParameter2Box = new System.Windows.Forms.NumericUpDown();
            this.initializerParameter1Box = new System.Windows.Forms.NumericUpDown();
            this.initializerParameter2Label = new System.Windows.Forms.Label();
            this.initializerParameter1Label = new System.Windows.Forms.Label();
            this.initializerLabel = new System.Windows.Forms.Label();
            this.initializerBox = new System.Windows.Forms.ComboBox();
            this.trainGroup = new System.Windows.Forms.GroupBox();
            this.trainingIterationsBox = new System.Windows.Forms.NumericUpDown();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.filesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dailySampleBox)).BeginInit();
            this.predictionGroupBox.SuspendLayout();
            this.learnGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finalLearningRateBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.initialLearningRateBox)).BeginInit();
            this.structureGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuronCountBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuronCountBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuronCountBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hiddenLayerCountBox)).BeginInit();
            this.initializationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.initializerParameter2Box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.initializerParameter1Box)).BeginInit();
            this.trainGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trainingIterationsBox)).BeginInit();
            this.SuspendLayout();
            // 
            // graph
            // 
            this.graph.Location = new System.Drawing.Point(512, 27);
            this.graph.Name = "graph";
            this.graph.ScrollGrace = 0D;
            this.graph.ScrollMaxX = 0D;
            this.graph.ScrollMaxY = 0D;
            this.graph.ScrollMaxY2 = 0D;
            this.graph.ScrollMinX = 0D;
            this.graph.ScrollMinY = 0D;
            this.graph.ScrollMinY2 = 0D;
            this.graph.Size = new System.Drawing.Size(635, 470);
            this.graph.TabIndex = 0;
            // 
            // initalLearningRateLabel
            // 
            this.initalLearningRateLabel.AutoSize = true;
            this.initalLearningRateLabel.Location = new System.Drawing.Point(15, 27);
            this.initalLearningRateLabel.Name = "initalLearningRateLabel";
            this.initalLearningRateLabel.Size = new System.Drawing.Size(101, 13);
            this.initalLearningRateLabel.TabIndex = 1;
            this.initalLearningRateLabel.Text = "Initial Learning Rate";
            // 
            // trainingIterationsLabel
            // 
            this.trainingIterationsLabel.AutoSize = true;
            this.trainingIterationsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.trainingIterationsLabel.Location = new System.Drawing.Point(12, 32);
            this.trainingIterationsLabel.Name = "trainingIterationsLabel";
            this.trainingIterationsLabel.Size = new System.Drawing.Size(91, 13);
            this.trainingIterationsLabel.TabIndex = 5;
            this.trainingIterationsLabel.Text = "Training Iterations";
            // 
            // hiddenLayerCountLabel
            // 
            this.hiddenLayerCountLabel.AutoSize = true;
            this.hiddenLayerCountLabel.Location = new System.Drawing.Point(15, 22);
            this.hiddenLayerCountLabel.Name = "hiddenLayerCountLabel";
            this.hiddenLayerCountLabel.Size = new System.Drawing.Size(101, 13);
            this.hiddenLayerCountLabel.TabIndex = 7;
            this.hiddenLayerCountLabel.Text = "Hidden Layer Count";
            // 
            // neuronCountLabel1
            // 
            this.neuronCountLabel1.AutoSize = true;
            this.neuronCountLabel1.Location = new System.Drawing.Point(15, 48);
            this.neuronCountLabel1.Name = "neuronCountLabel1";
            this.neuronCountLabel1.Size = new System.Drawing.Size(111, 13);
            this.neuronCountLabel1.TabIndex = 9;
            this.neuronCountLabel1.Text = "Layer 1 Neuron Count";
            // 
            // neuronCountLabel2
            // 
            this.neuronCountLabel2.AutoSize = true;
            this.neuronCountLabel2.Location = new System.Drawing.Point(15, 74);
            this.neuronCountLabel2.Name = "neuronCountLabel2";
            this.neuronCountLabel2.Size = new System.Drawing.Size(111, 13);
            this.neuronCountLabel2.TabIndex = 11;
            this.neuronCountLabel2.Text = "Layer 2 Neuron Count";
            // 
            // neuronCountLabel3
            // 
            this.neuronCountLabel3.AutoSize = true;
            this.neuronCountLabel3.Location = new System.Drawing.Point(15, 100);
            this.neuronCountLabel3.Name = "neuronCountLabel3";
            this.neuronCountLabel3.Size = new System.Drawing.Size(111, 13);
            this.neuronCountLabel3.TabIndex = 13;
            this.neuronCountLabel3.Text = "Layer 3 Neuron Count";
            // 
            // startBtn
            // 
            this.startBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startBtn.Location = new System.Drawing.Point(50, 55);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(157, 26);
            this.startBtn.TabIndex = 15;
            this.startBtn.Text = "Train";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1159, 24);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // filesGroupBox
            // 
            this.filesGroupBox.Controls.Add(this.dailySampleBox);
            this.filesGroupBox.Controls.Add(this.dailyButton);
            this.filesGroupBox.Controls.Add(this.weeklyButton);
            this.filesGroupBox.Controls.Add(this.monthlyButton);
            this.filesGroupBox.Controls.Add(this.sampleFormatLabel);
            this.filesGroupBox.Controls.Add(this.filesListBox);
            this.filesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.filesGroupBox.Location = new System.Drawing.Point(270, 27);
            this.filesGroupBox.Name = "filesGroupBox";
            this.filesGroupBox.Size = new System.Drawing.Size(200, 149);
            this.filesGroupBox.TabIndex = 17;
            this.filesGroupBox.TabStop = false;
            this.filesGroupBox.Text = "File for Training";
            // 
            // dailySampleBox
            // 
            this.dailySampleBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dailySampleBox.Location = new System.Drawing.Point(77, 120);
            this.dailySampleBox.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.dailySampleBox.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.dailySampleBox.Name = "dailySampleBox";
            this.dailySampleBox.Size = new System.Drawing.Size(61, 20);
            this.dailySampleBox.TabIndex = 5;
            this.dailySampleBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dailySampleBox.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // dailyButton
            // 
            this.dailyButton.AutoSize = true;
            this.dailyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dailyButton.Location = new System.Drawing.Point(9, 120);
            this.dailyButton.Name = "dailyButton";
            this.dailyButton.Size = new System.Drawing.Size(48, 17);
            this.dailyButton.TabIndex = 4;
            this.dailyButton.TabStop = true;
            this.dailyButton.Text = "Daily";
            this.dailyButton.UseVisualStyleBackColor = true;
            this.dailyButton.CheckedChanged += new System.EventHandler(this.dailyButton_CheckedChanged);
            // 
            // weeklyButton
            // 
            this.weeklyButton.AutoSize = true;
            this.weeklyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.weeklyButton.Location = new System.Drawing.Point(77, 90);
            this.weeklyButton.Name = "weeklyButton";
            this.weeklyButton.Size = new System.Drawing.Size(61, 17);
            this.weeklyButton.TabIndex = 3;
            this.weeklyButton.TabStop = true;
            this.weeklyButton.Text = "Weekly";
            this.weeklyButton.UseVisualStyleBackColor = true;
            // 
            // monthlyButton
            // 
            this.monthlyButton.AutoSize = true;
            this.monthlyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.monthlyButton.Location = new System.Drawing.Point(9, 90);
            this.monthlyButton.Name = "monthlyButton";
            this.monthlyButton.Size = new System.Drawing.Size(62, 17);
            this.monthlyButton.TabIndex = 2;
            this.monthlyButton.TabStop = true;
            this.monthlyButton.Text = "Monthly";
            this.monthlyButton.UseVisualStyleBackColor = true;
            // 
            // sampleFormatLabel
            // 
            this.sampleFormatLabel.AutoSize = true;
            this.sampleFormatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sampleFormatLabel.Location = new System.Drawing.Point(6, 73);
            this.sampleFormatLabel.Name = "sampleFormatLabel";
            this.sampleFormatLabel.Size = new System.Drawing.Size(77, 13);
            this.sampleFormatLabel.TabIndex = 1;
            this.sampleFormatLabel.Text = "Sample Format";
            // 
            // filesListBox
            // 
            this.filesListBox.BackColor = System.Drawing.SystemColors.Control;
            this.filesListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.filesListBox.FormattingEnabled = true;
            this.filesListBox.ItemHeight = 16;
            this.filesListBox.Location = new System.Drawing.Point(6, 22);
            this.filesListBox.Name = "filesListBox";
            this.filesListBox.Size = new System.Drawing.Size(188, 48);
            this.filesListBox.TabIndex = 0;
            // 
            // predictionGroupBox
            // 
            this.predictionGroupBox.Controls.Add(this.predictionRespone);
            this.predictionGroupBox.Controls.Add(this.predictButton);
            this.predictionGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.predictionGroupBox.Location = new System.Drawing.Point(270, 232);
            this.predictionGroupBox.Name = "predictionGroupBox";
            this.predictionGroupBox.Size = new System.Drawing.Size(200, 313);
            this.predictionGroupBox.TabIndex = 18;
            this.predictionGroupBox.TabStop = false;
            this.predictionGroupBox.Text = "Tomorrow prediction";
            // 
            // predictionRespone
            // 
            this.predictionRespone.BackColor = System.Drawing.SystemColors.Control;
            this.predictionRespone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.predictionRespone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.predictionRespone.FormattingEnabled = true;
            this.predictionRespone.ItemHeight = 15;
            this.predictionRespone.Location = new System.Drawing.Point(22, 264);
            this.predictionRespone.Name = "predictionRespone";
            this.predictionRespone.Size = new System.Drawing.Size(157, 45);
            this.predictionRespone.TabIndex = 1;
            // 
            // predictButton
            // 
            this.predictButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.predictButton.Location = new System.Drawing.Point(22, 232);
            this.predictButton.Name = "predictButton";
            this.predictButton.Size = new System.Drawing.Size(157, 26);
            this.predictButton.TabIndex = 19;
            this.predictButton.Text = "Predict away!";
            this.predictButton.UseVisualStyleBackColor = true;
            this.predictButton.Click += new System.EventHandler(this.predictButton_Click);
            // 
            // meanSSELabel
            // 
            this.meanSSELabel.AutoSize = true;
            this.meanSSELabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.meanSSELabel.Location = new System.Drawing.Point(12, 97);
            this.meanSSELabel.Name = "meanSSELabel";
            this.meanSSELabel.Size = new System.Drawing.Size(102, 13);
            this.meanSSELabel.TabIndex = 19;
            this.meanSSELabel.Text = "Mean Sqaured Error";
            // 
            // meanSSEValue
            // 
            this.meanSSEValue.AutoSize = true;
            this.meanSSEValue.Location = new System.Drawing.Point(133, 97);
            this.meanSSEValue.Name = "meanSSEValue";
            this.meanSSEValue.Size = new System.Drawing.Size(0, 15);
            this.meanSSEValue.TabIndex = 20;
            // 
            // learningFunctionLabel
            // 
            this.learningFunctionLabel.AutoSize = true;
            this.learningFunctionLabel.Location = new System.Drawing.Point(15, 79);
            this.learningFunctionLabel.Name = "learningFunctionLabel";
            this.learningFunctionLabel.Size = new System.Drawing.Size(92, 13);
            this.learningFunctionLabel.TabIndex = 21;
            this.learningFunctionLabel.Text = "Learning Function";
            // 
            // functionBox
            // 
            this.functionBox.FormattingEnabled = true;
            this.functionBox.Location = new System.Drawing.Point(139, 76);
            this.functionBox.Name = "functionBox";
            this.functionBox.Size = new System.Drawing.Size(100, 21);
            this.functionBox.TabIndex = 22;
            this.functionBox.SelectedIndexChanged += new System.EventHandler(this.functionBox_SelectedIndexChanged);
            // 
            // finalLearningRateLabel
            // 
            this.finalLearningRateLabel.AutoSize = true;
            this.finalLearningRateLabel.Location = new System.Drawing.Point(15, 53);
            this.finalLearningRateLabel.Name = "finalLearningRateLabel";
            this.finalLearningRateLabel.Size = new System.Drawing.Size(99, 13);
            this.finalLearningRateLabel.TabIndex = 23;
            this.finalLearningRateLabel.Text = "Final Learning Rate";
            // 
            // learnGroupBox
            // 
            this.learnGroupBox.Controls.Add(this.finalLearningRateBox);
            this.learnGroupBox.Controls.Add(this.initialLearningRateBox);
            this.learnGroupBox.Controls.Add(this.initalLearningRateLabel);
            this.learnGroupBox.Controls.Add(this.finalLearningRateLabel);
            this.learnGroupBox.Controls.Add(this.functionBox);
            this.learnGroupBox.Controls.Add(this.learningFunctionLabel);
            this.learnGroupBox.Location = new System.Drawing.Point(8, 27);
            this.learnGroupBox.Name = "learnGroupBox";
            this.learnGroupBox.Size = new System.Drawing.Size(256, 119);
            this.learnGroupBox.TabIndex = 1;
            this.learnGroupBox.TabStop = false;
            this.learnGroupBox.Text = "Network Learn Ability";
            // 
            // finalLearningRateBox
            // 
            this.finalLearningRateBox.DecimalPlaces = 2;
            this.finalLearningRateBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.finalLearningRateBox.Location = new System.Drawing.Point(139, 51);
            this.finalLearningRateBox.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.finalLearningRateBox.Name = "finalLearningRateBox";
            this.finalLearningRateBox.Size = new System.Drawing.Size(100, 20);
            this.finalLearningRateBox.TabIndex = 25;
            this.finalLearningRateBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.finalLearningRateBox.ValueChanged += new System.EventHandler(this.finalLearningRateBox_ValueChanged);
            // 
            // initialLearningRateBox
            // 
            this.initialLearningRateBox.DecimalPlaces = 2;
            this.initialLearningRateBox.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.initialLearningRateBox.Location = new System.Drawing.Point(139, 25);
            this.initialLearningRateBox.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.initialLearningRateBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.initialLearningRateBox.Name = "initialLearningRateBox";
            this.initialLearningRateBox.Size = new System.Drawing.Size(100, 20);
            this.initialLearningRateBox.TabIndex = 24;
            this.initialLearningRateBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.initialLearningRateBox.ValueChanged += new System.EventHandler(this.initialLearningRateBox_ValueChanged);
            // 
            // structureGroupBox
            // 
            this.structureGroupBox.Controls.Add(this.neuronCountBox3);
            this.structureGroupBox.Controls.Add(this.neuronCountBox2);
            this.structureGroupBox.Controls.Add(this.neuronCountBox1);
            this.structureGroupBox.Controls.Add(this.hiddenLayerCountBox);
            this.structureGroupBox.Controls.Add(this.hiddenLayerCountLabel);
            this.structureGroupBox.Controls.Add(this.neuronCountLabel1);
            this.structureGroupBox.Controls.Add(this.neuronCountLabel2);
            this.structureGroupBox.Controls.Add(this.neuronCountLabel3);
            this.structureGroupBox.Location = new System.Drawing.Point(8, 158);
            this.structureGroupBox.Name = "structureGroupBox";
            this.structureGroupBox.Size = new System.Drawing.Size(256, 131);
            this.structureGroupBox.TabIndex = 1;
            this.structureGroupBox.TabStop = false;
            this.structureGroupBox.Text = "Network Structure";
            // 
            // neuronCountBox3
            // 
            this.neuronCountBox3.Location = new System.Drawing.Point(139, 98);
            this.neuronCountBox3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.neuronCountBox3.Name = "neuronCountBox3";
            this.neuronCountBox3.Size = new System.Drawing.Size(100, 20);
            this.neuronCountBox3.TabIndex = 18;
            this.neuronCountBox3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.neuronCountBox3.ValueChanged += new System.EventHandler(this.neuronCountBox3_ValueChanged);
            // 
            // neuronCountBox2
            // 
            this.neuronCountBox2.Location = new System.Drawing.Point(139, 72);
            this.neuronCountBox2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.neuronCountBox2.Name = "neuronCountBox2";
            this.neuronCountBox2.Size = new System.Drawing.Size(100, 20);
            this.neuronCountBox2.TabIndex = 17;
            this.neuronCountBox2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.neuronCountBox2.ValueChanged += new System.EventHandler(this.neuronCountBox2_ValueChanged);
            // 
            // neuronCountBox1
            // 
            this.neuronCountBox1.Location = new System.Drawing.Point(139, 46);
            this.neuronCountBox1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.neuronCountBox1.Name = "neuronCountBox1";
            this.neuronCountBox1.Size = new System.Drawing.Size(100, 20);
            this.neuronCountBox1.TabIndex = 16;
            this.neuronCountBox1.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.neuronCountBox1.ValueChanged += new System.EventHandler(this.neuronCountBox1_ValueChanged);
            // 
            // hiddenLayerCountBox
            // 
            this.hiddenLayerCountBox.Location = new System.Drawing.Point(139, 20);
            this.hiddenLayerCountBox.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.hiddenLayerCountBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hiddenLayerCountBox.Name = "hiddenLayerCountBox";
            this.hiddenLayerCountBox.Size = new System.Drawing.Size(100, 20);
            this.hiddenLayerCountBox.TabIndex = 15;
            this.hiddenLayerCountBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.hiddenLayerCountBox.ValueChanged += new System.EventHandler(this.hiddenLayerCountBox_ValueChanged);
            // 
            // initializationGroupBox
            // 
            this.initializationGroupBox.Controls.Add(this.initializerParameter2Box);
            this.initializationGroupBox.Controls.Add(this.initializerParameter1Box);
            this.initializationGroupBox.Controls.Add(this.initializerParameter2Label);
            this.initializationGroupBox.Controls.Add(this.initializerParameter1Label);
            this.initializationGroupBox.Controls.Add(this.initializerLabel);
            this.initializationGroupBox.Controls.Add(this.initializerBox);
            this.initializationGroupBox.Location = new System.Drawing.Point(8, 295);
            this.initializationGroupBox.Name = "initializationGroupBox";
            this.initializationGroupBox.Size = new System.Drawing.Size(256, 107);
            this.initializationGroupBox.TabIndex = 21;
            this.initializationGroupBox.TabStop = false;
            this.initializationGroupBox.Text = "Network Initialization";
            // 
            // initializerParameter2Box
            // 
            this.initializerParameter2Box.Location = new System.Drawing.Point(139, 79);
            this.initializerParameter2Box.Name = "initializerParameter2Box";
            this.initializerParameter2Box.Size = new System.Drawing.Size(100, 20);
            this.initializerParameter2Box.TabIndex = 29;
            this.initializerParameter2Box.ValueChanged += new System.EventHandler(this.initializerParameter2Box_ValueChanged);
            // 
            // initializerParameter1Box
            // 
            this.initializerParameter1Box.Location = new System.Drawing.Point(139, 53);
            this.initializerParameter1Box.Name = "initializerParameter1Box";
            this.initializerParameter1Box.Size = new System.Drawing.Size(100, 20);
            this.initializerParameter1Box.TabIndex = 19;
            this.initializerParameter1Box.ValueChanged += new System.EventHandler(this.initializerParameter1Box_ValueChanged);
            // 
            // initializerParameter2Label
            // 
            this.initializerParameter2Label.AutoSize = true;
            this.initializerParameter2Label.Location = new System.Drawing.Point(15, 81);
            this.initializerParameter2Label.Name = "initializerParameter2Label";
            this.initializerParameter2Label.Size = new System.Drawing.Size(0, 13);
            this.initializerParameter2Label.TabIndex = 28;
            // 
            // initializerParameter1Label
            // 
            this.initializerParameter1Label.AutoSize = true;
            this.initializerParameter1Label.Location = new System.Drawing.Point(16, 55);
            this.initializerParameter1Label.Name = "initializerParameter1Label";
            this.initializerParameter1Label.Size = new System.Drawing.Size(0, 13);
            this.initializerParameter1Label.TabIndex = 26;
            // 
            // initializerLabel
            // 
            this.initializerLabel.AutoSize = true;
            this.initializerLabel.Location = new System.Drawing.Point(15, 28);
            this.initializerLabel.Name = "initializerLabel";
            this.initializerLabel.Size = new System.Drawing.Size(91, 13);
            this.initializerLabel.TabIndex = 15;
            this.initializerLabel.Text = "Initializer Function";
            // 
            // initializerBox
            // 
            this.initializerBox.FormattingEnabled = true;
            this.initializerBox.Location = new System.Drawing.Point(139, 25);
            this.initializerBox.Name = "initializerBox";
            this.initializerBox.Size = new System.Drawing.Size(101, 21);
            this.initializerBox.TabIndex = 25;
            this.initializerBox.SelectedIndexChanged += new System.EventHandler(this.initializerBox_SelectedIndexChanged);
            // 
            // trainGroup
            // 
            this.trainGroup.Controls.Add(this.trainingIterationsBox);
            this.trainGroup.Controls.Add(this.startBtn);
            this.trainGroup.Controls.Add(this.meanSSELabel);
            this.trainGroup.Controls.Add(this.trainingIterationsLabel);
            this.trainGroup.Controls.Add(this.meanSSEValue);
            this.trainGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.trainGroup.Location = new System.Drawing.Point(12, 409);
            this.trainGroup.Name = "trainGroup";
            this.trainGroup.Size = new System.Drawing.Size(252, 136);
            this.trainGroup.TabIndex = 22;
            this.trainGroup.TabStop = false;
            this.trainGroup.Text = "Network Training";
            // 
            // trainingIterationsBox
            // 
            this.trainingIterationsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.trainingIterationsBox.Location = new System.Drawing.Point(135, 29);
            this.trainingIterationsBox.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.trainingIterationsBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.trainingIterationsBox.Name = "trainingIterationsBox";
            this.trainingIterationsBox.Size = new System.Drawing.Size(100, 20);
            this.trainingIterationsBox.TabIndex = 21;
            this.trainingIterationsBox.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.trainingIterationsBox.ValueChanged += new System.EventHandler(this.trainingIterationsBox_ValueChanged);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 557);
            this.Controls.Add(this.trainGroup);
            this.Controls.Add(this.initializationGroupBox);
            this.Controls.Add(this.structureGroupBox);
            this.Controls.Add(this.learnGroupBox);
            this.Controls.Add(this.predictionGroupBox);
            this.Controls.Add(this.filesGroupBox);
            this.Controls.Add(this.graph);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Przewidywanie kursu walutowego";
            this.Load += new System.EventHandler(this.LoadWindow);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.filesGroupBox.ResumeLayout(false);
            this.filesGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dailySampleBox)).EndInit();
            this.predictionGroupBox.ResumeLayout(false);
            this.learnGroupBox.ResumeLayout(false);
            this.learnGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.finalLearningRateBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.initialLearningRateBox)).EndInit();
            this.structureGroupBox.ResumeLayout(false);
            this.structureGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neuronCountBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuronCountBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.neuronCountBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hiddenLayerCountBox)).EndInit();
            this.initializationGroupBox.ResumeLayout(false);
            this.initializationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.initializerParameter2Box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.initializerParameter1Box)).EndInit();
            this.trainGroup.ResumeLayout(false);
            this.trainGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trainingIterationsBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl graph;
        private System.Windows.Forms.Label initalLearningRateLabel;
        private System.Windows.Forms.Label trainingIterationsLabel;
        private System.Windows.Forms.Label hiddenLayerCountLabel;
        private System.Windows.Forms.Label neuronCountLabel1;
        private System.Windows.Forms.Label neuronCountLabel2;
        private System.Windows.Forms.Label neuronCountLabel3;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.GroupBox filesGroupBox;
        private System.Windows.Forms.ListBox filesListBox;
        private System.Windows.Forms.GroupBox predictionGroupBox;
        private System.Windows.Forms.Button predictButton;
        private System.Windows.Forms.ListBox predictionRespone;
        private System.Windows.Forms.Label meanSSELabel;
        private System.Windows.Forms.Label meanSSEValue;
        private System.Windows.Forms.Label learningFunctionLabel;
        private System.Windows.Forms.ComboBox functionBox;
        private System.Windows.Forms.Label finalLearningRateLabel;
        private System.Windows.Forms.GroupBox learnGroupBox;
        private System.Windows.Forms.GroupBox structureGroupBox;
        private System.Windows.Forms.GroupBox initializationGroupBox;
        private System.Windows.Forms.Label initializerLabel;
        private System.Windows.Forms.ComboBox initializerBox;
        private System.Windows.Forms.Label initializerParameter2Label;
        private System.Windows.Forms.Label initializerParameter1Label;
        private System.Windows.Forms.GroupBox trainGroup;
        private System.Windows.Forms.RadioButton monthlyButton;
        private System.Windows.Forms.Label sampleFormatLabel;
        private System.Windows.Forms.RadioButton dailyButton;
        private System.Windows.Forms.RadioButton weeklyButton;
        private System.Windows.Forms.NumericUpDown dailySampleBox;
        private System.Windows.Forms.NumericUpDown finalLearningRateBox;
        private System.Windows.Forms.NumericUpDown initialLearningRateBox;
        private System.Windows.Forms.NumericUpDown neuronCountBox3;
        private System.Windows.Forms.NumericUpDown neuronCountBox2;
        private System.Windows.Forms.NumericUpDown neuronCountBox1;
        private System.Windows.Forms.NumericUpDown hiddenLayerCountBox;
        private System.Windows.Forms.NumericUpDown trainingIterationsBox;
        private System.Windows.Forms.NumericUpDown initializerParameter2Box;
        private System.Windows.Forms.NumericUpDown initializerParameter1Box;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}

