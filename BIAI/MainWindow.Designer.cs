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
            this.initialLearningRateBox = new System.Windows.Forms.TextBox();
            this.trainingIterationsBox = new System.Windows.Forms.TextBox();
            this.trainingIterationsLabel = new System.Windows.Forms.Label();
            this.hiddenLayerCountBox = new System.Windows.Forms.TextBox();
            this.hiddenLayerCountLabel = new System.Windows.Forms.Label();
            this.neuronCountBox1 = new System.Windows.Forms.TextBox();
            this.neuronCountLabel1 = new System.Windows.Forms.Label();
            this.neuronCountBox2 = new System.Windows.Forms.TextBox();
            this.neuronCountLabel2 = new System.Windows.Forms.Label();
            this.neuronCountBox3 = new System.Windows.Forms.TextBox();
            this.neuronCountLabel3 = new System.Windows.Forms.Label();
            this.startBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesGroupBox = new System.Windows.Forms.GroupBox();
            this.dailyButton = new System.Windows.Forms.RadioButton();
            this.weeklyButton = new System.Windows.Forms.RadioButton();
            this.monthlyButton = new System.Windows.Forms.RadioButton();
            this.sampleFormatLabel = new System.Windows.Forms.Label();
            this.filesListBox = new System.Windows.Forms.ListBox();
            this.predictionGroupBox = new System.Windows.Forms.GroupBox();
            this.rsiDaysBox = new System.Windows.Forms.ComboBox();
            this.rsiValueLabel = new System.Windows.Forms.Label();
            this.rsiDaysLabel = new System.Windows.Forms.Label();
            this.RSItextBox = new System.Windows.Forms.TextBox();
            this.RSILabel = new System.Windows.Forms.Label();
            this.todayValuesLabel = new System.Windows.Forms.Label();
            this.predictionRespone = new System.Windows.Forms.ListBox();
            this.closeTextBox = new System.Windows.Forms.TextBox();
            this.closeLabel = new System.Windows.Forms.Label();
            this.highLabel = new System.Windows.Forms.Label();
            this.highTextBox = new System.Windows.Forms.TextBox();
            this.lowTextBox = new System.Windows.Forms.TextBox();
            this.predictButton = new System.Windows.Forms.Button();
            this.lowLabel = new System.Windows.Forms.Label();
            this.openLabel = new System.Windows.Forms.Label();
            this.openTextBox = new System.Windows.Forms.TextBox();
            this.meanSSELabel = new System.Windows.Forms.Label();
            this.meanSSEValue = new System.Windows.Forms.Label();
            this.learningFunctionLabel = new System.Windows.Forms.Label();
            this.functionBox = new System.Windows.Forms.ComboBox();
            this.finalLearningRateBox = new System.Windows.Forms.TextBox();
            this.finalLearningRateLabel = new System.Windows.Forms.Label();
            this.learnGroupBox = new System.Windows.Forms.GroupBox();
            this.structureGroupBox = new System.Windows.Forms.GroupBox();
            this.initializationGroupBox = new System.Windows.Forms.GroupBox();
            this.initializerParameter2Box = new System.Windows.Forms.TextBox();
            this.initializerParameter2Label = new System.Windows.Forms.Label();
            this.initializerParameter1Box = new System.Windows.Forms.TextBox();
            this.initializerParameter1Label = new System.Windows.Forms.Label();
            this.initializerLabel = new System.Windows.Forms.Label();
            this.initializerBox = new System.Windows.Forms.ComboBox();
            this.trainGroup = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.filesGroupBox.SuspendLayout();
            this.predictionGroupBox.SuspendLayout();
            this.learnGroupBox.SuspendLayout();
            this.structureGroupBox.SuspendLayout();
            this.initializationGroupBox.SuspendLayout();
            this.trainGroup.SuspendLayout();
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
            // initialLearningRateBox
            // 
            this.initialLearningRateBox.Location = new System.Drawing.Point(139, 24);
            this.initialLearningRateBox.Name = "initialLearningRateBox";
            this.initialLearningRateBox.Size = new System.Drawing.Size(100, 20);
            this.initialLearningRateBox.TabIndex = 2;
            // 
            // trainingIterationsBox
            // 
            this.trainingIterationsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.trainingIterationsBox.Location = new System.Drawing.Point(135, 29);
            this.trainingIterationsBox.Name = "trainingIterationsBox";
            this.trainingIterationsBox.Size = new System.Drawing.Size(100, 20);
            this.trainingIterationsBox.TabIndex = 6;
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
            // hiddenLayerCountBox
            // 
            this.hiddenLayerCountBox.Location = new System.Drawing.Point(139, 19);
            this.hiddenLayerCountBox.Name = "hiddenLayerCountBox";
            this.hiddenLayerCountBox.Size = new System.Drawing.Size(100, 20);
            this.hiddenLayerCountBox.TabIndex = 8;
            this.hiddenLayerCountBox.TextChanged += new System.EventHandler(this.hiddenLayerCountBox_TextChanged);
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
            // neuronCountBox1
            // 
            this.neuronCountBox1.Location = new System.Drawing.Point(140, 45);
            this.neuronCountBox1.Name = "neuronCountBox1";
            this.neuronCountBox1.Size = new System.Drawing.Size(100, 20);
            this.neuronCountBox1.TabIndex = 10;
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
            // neuronCountBox2
            // 
            this.neuronCountBox2.Location = new System.Drawing.Point(140, 71);
            this.neuronCountBox2.Name = "neuronCountBox2";
            this.neuronCountBox2.Size = new System.Drawing.Size(100, 20);
            this.neuronCountBox2.TabIndex = 12;
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
            // neuronCountBox3
            // 
            this.neuronCountBox3.Location = new System.Drawing.Point(140, 97);
            this.neuronCountBox3.Name = "neuronCountBox3";
            this.neuronCountBox3.Size = new System.Drawing.Size(100, 20);
            this.neuronCountBox3.TabIndex = 14;
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
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // filesGroupBox
            // 
            this.filesGroupBox.Controls.Add(this.dailyButton);
            this.filesGroupBox.Controls.Add(this.weeklyButton);
            this.filesGroupBox.Controls.Add(this.monthlyButton);
            this.filesGroupBox.Controls.Add(this.sampleFormatLabel);
            this.filesGroupBox.Controls.Add(this.filesListBox);
            this.filesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.filesGroupBox.Location = new System.Drawing.Point(270, 27);
            this.filesGroupBox.Name = "filesGroupBox";
            this.filesGroupBox.Size = new System.Drawing.Size(200, 119);
            this.filesGroupBox.TabIndex = 17;
            this.filesGroupBox.TabStop = false;
            this.filesGroupBox.Text = "File for Training";
            // 
            // dailyButton
            // 
            this.dailyButton.AutoSize = true;
            this.dailyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dailyButton.Location = new System.Drawing.Point(146, 90);
            this.dailyButton.Name = "dailyButton";
            this.dailyButton.Size = new System.Drawing.Size(48, 17);
            this.dailyButton.TabIndex = 4;
            this.dailyButton.TabStop = true;
            this.dailyButton.Text = "Daily";
            this.dailyButton.UseVisualStyleBackColor = true;
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
            this.predictionGroupBox.Controls.Add(this.rsiDaysBox);
            this.predictionGroupBox.Controls.Add(this.rsiValueLabel);
            this.predictionGroupBox.Controls.Add(this.rsiDaysLabel);
            this.predictionGroupBox.Controls.Add(this.RSItextBox);
            this.predictionGroupBox.Controls.Add(this.RSILabel);
            this.predictionGroupBox.Controls.Add(this.todayValuesLabel);
            this.predictionGroupBox.Controls.Add(this.predictionRespone);
            this.predictionGroupBox.Controls.Add(this.closeTextBox);
            this.predictionGroupBox.Controls.Add(this.closeLabel);
            this.predictionGroupBox.Controls.Add(this.highLabel);
            this.predictionGroupBox.Controls.Add(this.highTextBox);
            this.predictionGroupBox.Controls.Add(this.lowTextBox);
            this.predictionGroupBox.Controls.Add(this.predictButton);
            this.predictionGroupBox.Controls.Add(this.lowLabel);
            this.predictionGroupBox.Controls.Add(this.openLabel);
            this.predictionGroupBox.Controls.Add(this.openTextBox);
            this.predictionGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.predictionGroupBox.Location = new System.Drawing.Point(270, 232);
            this.predictionGroupBox.Name = "predictionGroupBox";
            this.predictionGroupBox.Size = new System.Drawing.Size(200, 313);
            this.predictionGroupBox.TabIndex = 18;
            this.predictionGroupBox.TabStop = false;
            this.predictionGroupBox.Text = "Tomorrow prediction";
            // 
            // rsiDaysBox
            // 
            this.rsiDaysBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rsiDaysBox.FormattingEnabled = true;
            this.rsiDaysBox.Location = new System.Drawing.Point(77, 177);
            this.rsiDaysBox.Name = "rsiDaysBox";
            this.rsiDaysBox.Size = new System.Drawing.Size(98, 21);
            this.rsiDaysBox.TabIndex = 33;
            this.rsiDaysBox.SelectedIndexChanged += new System.EventHandler(this.rsiDaysBox_SelectedIndexChanged);
            // 
            // rsiValueLabel
            // 
            this.rsiValueLabel.AutoSize = true;
            this.rsiValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rsiValueLabel.Location = new System.Drawing.Point(19, 207);
            this.rsiValueLabel.Name = "rsiValueLabel";
            this.rsiValueLabel.Size = new System.Drawing.Size(34, 13);
            this.rsiValueLabel.TabIndex = 32;
            this.rsiValueLabel.Text = "Value";
            // 
            // rsiDaysLabel
            // 
            this.rsiDaysLabel.AutoSize = true;
            this.rsiDaysLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rsiDaysLabel.Location = new System.Drawing.Point(19, 180);
            this.rsiDaysLabel.Name = "rsiDaysLabel";
            this.rsiDaysLabel.Size = new System.Drawing.Size(56, 13);
            this.rsiDaysLabel.TabIndex = 30;
            this.rsiDaysLabel.Text = "Since Day";
            // 
            // RSItextBox
            // 
            this.RSItextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RSItextBox.Location = new System.Drawing.Point(77, 202);
            this.RSItextBox.Multiline = true;
            this.RSItextBox.Name = "RSItextBox";
            this.RSItextBox.Size = new System.Drawing.Size(100, 20);
            this.RSItextBox.TabIndex = 29;
            // 
            // RSILabel
            // 
            this.RSILabel.AutoSize = true;
            this.RSILabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RSILabel.Location = new System.Drawing.Point(19, 155);
            this.RSILabel.Name = "RSILabel";
            this.RSILabel.Size = new System.Drawing.Size(27, 15);
            this.RSILabel.TabIndex = 28;
            this.RSILabel.Text = "RSI";
            // 
            // todayValuesLabel
            // 
            this.todayValuesLabel.AutoSize = true;
            this.todayValuesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.todayValuesLabel.Location = new System.Drawing.Point(19, 26);
            this.todayValuesLabel.Name = "todayValuesLabel";
            this.todayValuesLabel.Size = new System.Drawing.Size(80, 15);
            this.todayValuesLabel.TabIndex = 27;
            this.todayValuesLabel.Text = "Today Values";
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
            // closeTextBox
            // 
            this.closeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.closeTextBox.Location = new System.Drawing.Point(79, 123);
            this.closeTextBox.Multiline = true;
            this.closeTextBox.Name = "closeTextBox";
            this.closeTextBox.Size = new System.Drawing.Size(100, 20);
            this.closeTextBox.TabIndex = 26;
            this.closeTextBox.TextChanged += new System.EventHandler(this.closeTextBox_TextChanged);
            // 
            // closeLabel
            // 
            this.closeLabel.AutoSize = true;
            this.closeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.closeLabel.Location = new System.Drawing.Point(19, 128);
            this.closeLabel.Name = "closeLabel";
            this.closeLabel.Size = new System.Drawing.Size(33, 13);
            this.closeLabel.TabIndex = 25;
            this.closeLabel.Text = "Close";
            // 
            // highLabel
            // 
            this.highLabel.AutoSize = true;
            this.highLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.highLabel.Location = new System.Drawing.Point(19, 102);
            this.highLabel.Name = "highLabel";
            this.highLabel.Size = new System.Drawing.Size(29, 13);
            this.highLabel.TabIndex = 23;
            this.highLabel.Text = "High";
            // 
            // highTextBox
            // 
            this.highTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.highTextBox.Location = new System.Drawing.Point(79, 97);
            this.highTextBox.Multiline = true;
            this.highTextBox.Name = "highTextBox";
            this.highTextBox.Size = new System.Drawing.Size(100, 20);
            this.highTextBox.TabIndex = 24;
            this.highTextBox.TextChanged += new System.EventHandler(this.highTextBox_TextChanged);
            // 
            // lowTextBox
            // 
            this.lowTextBox.AcceptsReturn = true;
            this.lowTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lowTextBox.Location = new System.Drawing.Point(79, 71);
            this.lowTextBox.Multiline = true;
            this.lowTextBox.Name = "lowTextBox";
            this.lowTextBox.Size = new System.Drawing.Size(100, 20);
            this.lowTextBox.TabIndex = 22;
            this.lowTextBox.TextChanged += new System.EventHandler(this.lowTextBox_TextChanged);
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
            // lowLabel
            // 
            this.lowLabel.AutoSize = true;
            this.lowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lowLabel.Location = new System.Drawing.Point(19, 76);
            this.lowLabel.Name = "lowLabel";
            this.lowLabel.Size = new System.Drawing.Size(27, 13);
            this.lowLabel.TabIndex = 21;
            this.lowLabel.Text = "Low";
            // 
            // openLabel
            // 
            this.openLabel.AutoSize = true;
            this.openLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.openLabel.Location = new System.Drawing.Point(19, 50);
            this.openLabel.Name = "openLabel";
            this.openLabel.Size = new System.Drawing.Size(33, 13);
            this.openLabel.TabIndex = 19;
            this.openLabel.Text = "Open";
            // 
            // openTextBox
            // 
            this.openTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.openTextBox.Location = new System.Drawing.Point(79, 45);
            this.openTextBox.Multiline = true;
            this.openTextBox.Name = "openTextBox";
            this.openTextBox.Size = new System.Drawing.Size(100, 20);
            this.openTextBox.TabIndex = 20;
            this.openTextBox.TextChanged += new System.EventHandler(this.openTextBox_TextChanged);
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
            // 
            // finalLearningRateBox
            // 
            this.finalLearningRateBox.Location = new System.Drawing.Point(139, 50);
            this.finalLearningRateBox.Name = "finalLearningRateBox";
            this.finalLearningRateBox.Size = new System.Drawing.Size(100, 20);
            this.finalLearningRateBox.TabIndex = 24;
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
            this.learnGroupBox.Controls.Add(this.initalLearningRateLabel);
            this.learnGroupBox.Controls.Add(this.finalLearningRateLabel);
            this.learnGroupBox.Controls.Add(this.initialLearningRateBox);
            this.learnGroupBox.Controls.Add(this.functionBox);
            this.learnGroupBox.Controls.Add(this.learningFunctionLabel);
            this.learnGroupBox.Location = new System.Drawing.Point(8, 27);
            this.learnGroupBox.Name = "learnGroupBox";
            this.learnGroupBox.Size = new System.Drawing.Size(256, 119);
            this.learnGroupBox.TabIndex = 1;
            this.learnGroupBox.TabStop = false;
            this.learnGroupBox.Text = "Network Learn Ability";
            // 
            // structureGroupBox
            // 
            this.structureGroupBox.Controls.Add(this.hiddenLayerCountBox);
            this.structureGroupBox.Controls.Add(this.hiddenLayerCountLabel);
            this.structureGroupBox.Controls.Add(this.neuronCountLabel1);
            this.structureGroupBox.Controls.Add(this.neuronCountBox1);
            this.structureGroupBox.Controls.Add(this.neuronCountLabel2);
            this.structureGroupBox.Controls.Add(this.neuronCountBox2);
            this.structureGroupBox.Controls.Add(this.neuronCountLabel3);
            this.structureGroupBox.Controls.Add(this.neuronCountBox3);
            this.structureGroupBox.Location = new System.Drawing.Point(8, 158);
            this.structureGroupBox.Name = "structureGroupBox";
            this.structureGroupBox.Size = new System.Drawing.Size(256, 131);
            this.structureGroupBox.TabIndex = 1;
            this.structureGroupBox.TabStop = false;
            this.structureGroupBox.Text = "Network Structure";
            // 
            // initializationGroupBox
            // 
            this.initializationGroupBox.Controls.Add(this.initializerParameter2Box);
            this.initializationGroupBox.Controls.Add(this.initializerParameter2Label);
            this.initializationGroupBox.Controls.Add(this.initializerParameter1Box);
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
            this.initializerParameter2Box.Location = new System.Drawing.Point(139, 78);
            this.initializerParameter2Box.Name = "initializerParameter2Box";
            this.initializerParameter2Box.Size = new System.Drawing.Size(100, 20);
            this.initializerParameter2Box.TabIndex = 29;
            this.initializerParameter2Box.TextChanged += new System.EventHandler(this.initializerParameter2Box_TextChanged);
            // 
            // initializerParameter2Label
            // 
            this.initializerParameter2Label.AutoSize = true;
            this.initializerParameter2Label.Location = new System.Drawing.Point(15, 81);
            this.initializerParameter2Label.Name = "initializerParameter2Label";
            this.initializerParameter2Label.Size = new System.Drawing.Size(0, 13);
            this.initializerParameter2Label.TabIndex = 28;
            // 
            // initializerParameter1Box
            // 
            this.initializerParameter1Box.Location = new System.Drawing.Point(140, 52);
            this.initializerParameter1Box.Name = "initializerParameter1Box";
            this.initializerParameter1Box.Size = new System.Drawing.Size(100, 20);
            this.initializerParameter1Box.TabIndex = 27;
            this.initializerParameter1Box.TextChanged += new System.EventHandler(this.initializerParameter1Box_TextChanged);
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
            this.trainGroup.Controls.Add(this.startBtn);
            this.trainGroup.Controls.Add(this.trainingIterationsBox);
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
            this.predictionGroupBox.ResumeLayout(false);
            this.predictionGroupBox.PerformLayout();
            this.learnGroupBox.ResumeLayout(false);
            this.learnGroupBox.PerformLayout();
            this.structureGroupBox.ResumeLayout(false);
            this.structureGroupBox.PerformLayout();
            this.initializationGroupBox.ResumeLayout(false);
            this.initializationGroupBox.PerformLayout();
            this.trainGroup.ResumeLayout(false);
            this.trainGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl graph;
        private System.Windows.Forms.Label initalLearningRateLabel;
        private System.Windows.Forms.TextBox initialLearningRateBox;
        private System.Windows.Forms.TextBox trainingIterationsBox;
        private System.Windows.Forms.Label trainingIterationsLabel;
        private System.Windows.Forms.TextBox hiddenLayerCountBox;
        private System.Windows.Forms.Label hiddenLayerCountLabel;
        private System.Windows.Forms.TextBox neuronCountBox1;
        private System.Windows.Forms.Label neuronCountLabel1;
        private System.Windows.Forms.TextBox neuronCountBox2;
        private System.Windows.Forms.Label neuronCountLabel2;
        private System.Windows.Forms.TextBox neuronCountBox3;
        private System.Windows.Forms.Label neuronCountLabel3;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.GroupBox filesGroupBox;
        private System.Windows.Forms.ListBox filesListBox;
        private System.Windows.Forms.GroupBox predictionGroupBox;
        private System.Windows.Forms.TextBox closeTextBox;
        private System.Windows.Forms.Label closeLabel;
        private System.Windows.Forms.Label highLabel;
        private System.Windows.Forms.TextBox highTextBox;
        private System.Windows.Forms.TextBox lowTextBox;
        private System.Windows.Forms.Button predictButton;
        private System.Windows.Forms.Label lowLabel;
        private System.Windows.Forms.Label openLabel;
        private System.Windows.Forms.TextBox openTextBox;
        private System.Windows.Forms.ListBox predictionRespone;
        private System.Windows.Forms.Label todayValuesLabel;
        private System.Windows.Forms.Label meanSSELabel;
        private System.Windows.Forms.Label meanSSEValue;
        private System.Windows.Forms.Label learningFunctionLabel;
        private System.Windows.Forms.ComboBox functionBox;
        private System.Windows.Forms.TextBox finalLearningRateBox;
        private System.Windows.Forms.Label finalLearningRateLabel;
        private System.Windows.Forms.GroupBox learnGroupBox;
        private System.Windows.Forms.GroupBox structureGroupBox;
        private System.Windows.Forms.GroupBox initializationGroupBox;
        private System.Windows.Forms.Label initializerLabel;
        private System.Windows.Forms.ComboBox initializerBox;
        private System.Windows.Forms.TextBox initializerParameter2Box;
        private System.Windows.Forms.Label initializerParameter2Label;
        private System.Windows.Forms.TextBox initializerParameter1Box;
        private System.Windows.Forms.Label initializerParameter1Label;
        private System.Windows.Forms.GroupBox trainGroup;
        private System.Windows.Forms.TextBox RSItextBox;
        private System.Windows.Forms.Label RSILabel;
        private System.Windows.Forms.RadioButton monthlyButton;
        private System.Windows.Forms.Label sampleFormatLabel;
        private System.Windows.Forms.RadioButton dailyButton;
        private System.Windows.Forms.RadioButton weeklyButton;
        private System.Windows.Forms.ComboBox rsiDaysBox;
        private System.Windows.Forms.Label rsiValueLabel;
        private System.Windows.Forms.Label rsiDaysLabel;
    }
}

