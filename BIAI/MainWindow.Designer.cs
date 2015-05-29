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
            this.learningRateLabel = new System.Windows.Forms.Label();
            this.learningRateBox = new System.Windows.Forms.TextBox();
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
            this.filesListBox = new System.Windows.Forms.ListBox();
            this.predictionGroupBox = new System.Windows.Forms.GroupBox();
            this.predictButton = new System.Windows.Forms.Button();
            this.lowTextBox = new System.Windows.Forms.TextBox();
            this.lowLabel = new System.Windows.Forms.Label();
            this.openTextBox = new System.Windows.Forms.TextBox();
            this.openLabel = new System.Windows.Forms.Label();
            this.closeTextBox = new System.Windows.Forms.TextBox();
            this.closeLabel = new System.Windows.Forms.Label();
            this.highLabel = new System.Windows.Forms.Label();
            this.highTextBox = new System.Windows.Forms.TextBox();
            this.predictionRespone = new System.Windows.Forms.ListBox();
            this.todayValuesLabel = new System.Windows.Forms.Label();
            this.meanSSELabel = new System.Windows.Forms.Label();
            this.meanSSEValue = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.filesGroupBox.SuspendLayout();
            this.predictionGroupBox.SuspendLayout();
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
            // learningRateLabel
            // 
            this.learningRateLabel.AutoSize = true;
            this.learningRateLabel.Location = new System.Drawing.Point(12, 129);
            this.learningRateLabel.Name = "learningRateLabel";
            this.learningRateLabel.Size = new System.Drawing.Size(74, 13);
            this.learningRateLabel.TabIndex = 1;
            this.learningRateLabel.Text = "Learning Rate";
            // 
            // learningRateBox
            // 
            this.learningRateBox.Location = new System.Drawing.Point(128, 126);
            this.learningRateBox.Name = "learningRateBox";
            this.learningRateBox.Size = new System.Drawing.Size(100, 20);
            this.learningRateBox.TabIndex = 2;
            // 
            // trainingIterationsBox
            // 
            this.trainingIterationsBox.Location = new System.Drawing.Point(128, 333);
            this.trainingIterationsBox.Name = "trainingIterationsBox";
            this.trainingIterationsBox.Size = new System.Drawing.Size(100, 20);
            this.trainingIterationsBox.TabIndex = 6;
            // 
            // trainingIterationsLabel
            // 
            this.trainingIterationsLabel.AutoSize = true;
            this.trainingIterationsLabel.Location = new System.Drawing.Point(12, 336);
            this.trainingIterationsLabel.Name = "trainingIterationsLabel";
            this.trainingIterationsLabel.Size = new System.Drawing.Size(91, 13);
            this.trainingIterationsLabel.TabIndex = 5;
            this.trainingIterationsLabel.Text = "Training Iterations";
            // 
            // hiddenLayerCountBox
            // 
            this.hiddenLayerCountBox.Location = new System.Drawing.Point(128, 156);
            this.hiddenLayerCountBox.Name = "hiddenLayerCountBox";
            this.hiddenLayerCountBox.Size = new System.Drawing.Size(100, 20);
            this.hiddenLayerCountBox.TabIndex = 8;
            this.hiddenLayerCountBox.TextChanged += new System.EventHandler(this.hiddenLayerCountBox_TextChanged);
            // 
            // hiddenLayerCountLabel
            // 
            this.hiddenLayerCountLabel.AutoSize = true;
            this.hiddenLayerCountLabel.Location = new System.Drawing.Point(12, 159);
            this.hiddenLayerCountLabel.Name = "hiddenLayerCountLabel";
            this.hiddenLayerCountLabel.Size = new System.Drawing.Size(101, 13);
            this.hiddenLayerCountLabel.TabIndex = 7;
            this.hiddenLayerCountLabel.Text = "Hidden Layer Count";
            // 
            // neuronCountBox1
            // 
            this.neuronCountBox1.Location = new System.Drawing.Point(128, 191);
            this.neuronCountBox1.Name = "neuronCountBox1";
            this.neuronCountBox1.Size = new System.Drawing.Size(100, 20);
            this.neuronCountBox1.TabIndex = 10;
            // 
            // neuronCountLabel1
            // 
            this.neuronCountLabel1.AutoSize = true;
            this.neuronCountLabel1.Location = new System.Drawing.Point(12, 194);
            this.neuronCountLabel1.Name = "neuronCountLabel1";
            this.neuronCountLabel1.Size = new System.Drawing.Size(111, 13);
            this.neuronCountLabel1.TabIndex = 9;
            this.neuronCountLabel1.Text = "Layer 1 Neuron Count";
            // 
            // neuronCountBox2
            // 
            this.neuronCountBox2.Location = new System.Drawing.Point(128, 217);
            this.neuronCountBox2.Name = "neuronCountBox2";
            this.neuronCountBox2.Size = new System.Drawing.Size(100, 20);
            this.neuronCountBox2.TabIndex = 12;
            // 
            // neuronCountLabel2
            // 
            this.neuronCountLabel2.AutoSize = true;
            this.neuronCountLabel2.Location = new System.Drawing.Point(12, 220);
            this.neuronCountLabel2.Name = "neuronCountLabel2";
            this.neuronCountLabel2.Size = new System.Drawing.Size(111, 13);
            this.neuronCountLabel2.TabIndex = 11;
            this.neuronCountLabel2.Text = "Layer 2 Neuron Count";
            // 
            // neuronCountBox3
            // 
            this.neuronCountBox3.Location = new System.Drawing.Point(128, 243);
            this.neuronCountBox3.Name = "neuronCountBox3";
            this.neuronCountBox3.Size = new System.Drawing.Size(100, 20);
            this.neuronCountBox3.TabIndex = 14;
            // 
            // neuronCountLabel3
            // 
            this.neuronCountLabel3.AutoSize = true;
            this.neuronCountLabel3.Location = new System.Drawing.Point(12, 246);
            this.neuronCountLabel3.Name = "neuronCountLabel3";
            this.neuronCountLabel3.Size = new System.Drawing.Size(111, 13);
            this.neuronCountLabel3.TabIndex = 13;
            this.neuronCountLabel3.Text = "Layer 3 Neuron Count";
            // 
            // startBtn
            // 
            this.startBtn.Location = new System.Drawing.Point(45, 371);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(157, 45);
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
            this.filesGroupBox.Controls.Add(this.filesListBox);
            this.filesGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.filesGroupBox.Location = new System.Drawing.Point(270, 27);
            this.filesGroupBox.Name = "filesGroupBox";
            this.filesGroupBox.Size = new System.Drawing.Size(200, 187);
            this.filesGroupBox.TabIndex = 17;
            this.filesGroupBox.TabStop = false;
            this.filesGroupBox.Text = "Files for Training";
            // 
            // filesListBox
            // 
            this.filesListBox.BackColor = System.Drawing.SystemColors.Control;
            this.filesListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.filesListBox.FormattingEnabled = true;
            this.filesListBox.ItemHeight = 16;
            this.filesListBox.Location = new System.Drawing.Point(6, 22);
            this.filesListBox.Name = "filesListBox";
            this.filesListBox.Size = new System.Drawing.Size(188, 144);
            this.filesListBox.TabIndex = 0;
            // 
            // predictionGroupBox
            // 
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
            this.predictionGroupBox.Location = new System.Drawing.Point(270, 220);
            this.predictionGroupBox.Name = "predictionGroupBox";
            this.predictionGroupBox.Size = new System.Drawing.Size(200, 277);
            this.predictionGroupBox.TabIndex = 18;
            this.predictionGroupBox.TabStop = false;
            this.predictionGroupBox.Text = "Tomorrow prediction";
            // 
            // predictButton
            // 
            this.predictButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.predictButton.Location = new System.Drawing.Point(26, 165);
            this.predictButton.Name = "predictButton";
            this.predictButton.Size = new System.Drawing.Size(157, 45);
            this.predictButton.TabIndex = 19;
            this.predictButton.Text = "Predict away!";
            this.predictButton.UseVisualStyleBackColor = true;
            this.predictButton.Click += new System.EventHandler(this.predictButton_Click);
            // 
            // lowTextBox
            // 
            this.lowTextBox.AcceptsReturn = true;
            this.lowTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lowTextBox.Location = new System.Drawing.Point(83, 82);
            this.lowTextBox.Multiline = true;
            this.lowTextBox.Name = "lowTextBox";
            this.lowTextBox.Size = new System.Drawing.Size(100, 20);
            this.lowTextBox.TabIndex = 22;
            this.lowTextBox.TextChanged += new System.EventHandler(this.lowTextBox_TextChanged);
            // 
            // lowLabel
            // 
            this.lowLabel.AutoSize = true;
            this.lowLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lowLabel.Location = new System.Drawing.Point(23, 82);
            this.lowLabel.Name = "lowLabel";
            this.lowLabel.Size = new System.Drawing.Size(27, 13);
            this.lowLabel.TabIndex = 21;
            this.lowLabel.Text = "Low";
            // 
            // openTextBox
            // 
            this.openTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.openTextBox.Location = new System.Drawing.Point(83, 56);
            this.openTextBox.Multiline = true;
            this.openTextBox.Name = "openTextBox";
            this.openTextBox.Size = new System.Drawing.Size(100, 20);
            this.openTextBox.TabIndex = 20;
            this.openTextBox.TextChanged += new System.EventHandler(this.openTextBox_TextChanged);
            // 
            // openLabel
            // 
            this.openLabel.AutoSize = true;
            this.openLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.openLabel.Location = new System.Drawing.Point(23, 56);
            this.openLabel.Name = "openLabel";
            this.openLabel.Size = new System.Drawing.Size(33, 13);
            this.openLabel.TabIndex = 19;
            this.openLabel.Text = "Open";
            // 
            // closeTextBox
            // 
            this.closeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.closeTextBox.Location = new System.Drawing.Point(83, 134);
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
            this.closeLabel.Location = new System.Drawing.Point(23, 134);
            this.closeLabel.Name = "closeLabel";
            this.closeLabel.Size = new System.Drawing.Size(33, 13);
            this.closeLabel.TabIndex = 25;
            this.closeLabel.Text = "Close";
            // 
            // highLabel
            // 
            this.highLabel.AutoSize = true;
            this.highLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.highLabel.Location = new System.Drawing.Point(23, 108);
            this.highLabel.Name = "highLabel";
            this.highLabel.Size = new System.Drawing.Size(29, 13);
            this.highLabel.TabIndex = 23;
            this.highLabel.Text = "High";
            // 
            // highTextBox
            // 
            this.highTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.highTextBox.Location = new System.Drawing.Point(83, 108);
            this.highTextBox.Multiline = true;
            this.highTextBox.Name = "highTextBox";
            this.highTextBox.Size = new System.Drawing.Size(100, 20);
            this.highTextBox.TabIndex = 24;
            this.highTextBox.TextChanged += new System.EventHandler(this.highTextBox_TextChanged);
            // 
            // predictionRespone
            // 
            this.predictionRespone.BackColor = System.Drawing.SystemColors.Control;
            this.predictionRespone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.predictionRespone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.predictionRespone.FormattingEnabled = true;
            this.predictionRespone.ItemHeight = 15;
            this.predictionRespone.Location = new System.Drawing.Point(26, 216);
            this.predictionRespone.Name = "predictionRespone";
            this.predictionRespone.Size = new System.Drawing.Size(157, 45);
            this.predictionRespone.TabIndex = 1;
            // 
            // todayValuesLabel
            // 
            this.todayValuesLabel.AutoSize = true;
            this.todayValuesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.todayValuesLabel.Location = new System.Drawing.Point(23, 30);
            this.todayValuesLabel.Name = "todayValuesLabel";
            this.todayValuesLabel.Size = new System.Drawing.Size(72, 13);
            this.todayValuesLabel.TabIndex = 27;
            this.todayValuesLabel.Text = "Today Values";
            // 
            // meanSSELabel
            // 
            this.meanSSELabel.AutoSize = true;
            this.meanSSELabel.Location = new System.Drawing.Point(12, 436);
            this.meanSSELabel.Name = "meanSSELabel";
            this.meanSSELabel.Size = new System.Drawing.Size(102, 13);
            this.meanSSELabel.TabIndex = 19;
            this.meanSSELabel.Text = "Mean Sqaured Error";
            // 
            // meanSSEValue
            // 
            this.meanSSEValue.AutoSize = true;
            this.meanSSEValue.Location = new System.Drawing.Point(126, 436);
            this.meanSSEValue.Name = "meanSSEValue";
            this.meanSSEValue.Size = new System.Drawing.Size(0, 13);
            this.meanSSEValue.TabIndex = 20;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 509);
            this.Controls.Add(this.meanSSEValue);
            this.Controls.Add(this.meanSSELabel);
            this.Controls.Add(this.predictionGroupBox);
            this.Controls.Add(this.filesGroupBox);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.neuronCountBox3);
            this.Controls.Add(this.neuronCountLabel3);
            this.Controls.Add(this.neuronCountBox2);
            this.Controls.Add(this.neuronCountLabel2);
            this.Controls.Add(this.neuronCountBox1);
            this.Controls.Add(this.neuronCountLabel1);
            this.Controls.Add(this.hiddenLayerCountBox);
            this.Controls.Add(this.hiddenLayerCountLabel);
            this.Controls.Add(this.trainingIterationsBox);
            this.Controls.Add(this.trainingIterationsLabel);
            this.Controls.Add(this.learningRateBox);
            this.Controls.Add(this.learningRateLabel);
            this.Controls.Add(this.graph);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "Przewidywanie kursu walutowego";
            this.Load += new System.EventHandler(this.LoadWindow);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.filesGroupBox.ResumeLayout(false);
            this.predictionGroupBox.ResumeLayout(false);
            this.predictionGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl graph;
        private System.Windows.Forms.Label learningRateLabel;
        private System.Windows.Forms.TextBox learningRateBox;
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
    }
}

