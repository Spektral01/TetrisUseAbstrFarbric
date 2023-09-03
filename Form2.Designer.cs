
namespace TetrisAbstrFabric
{
    partial class Form2
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
            this.VertLabel = new System.Windows.Forms.Label();
            this.HorizLabel = new System.Windows.Forms.Label();
            this.EdHoriz = new System.Windows.Forms.NumericUpDown();
            this.EdVertical = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EdHoriz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdVertical)).BeginInit();
            this.SuspendLayout();
            // 
            // VertLabel
            // 
            this.VertLabel.AutoSize = true;
            this.VertLabel.Location = new System.Drawing.Point(35, 74);
            this.VertLabel.Name = "VertLabel";
            this.VertLabel.Size = new System.Drawing.Size(150, 17);
            this.VertLabel.TabIndex = 3;
            this.VertLabel.Text = "Размер по вертикали";
            // 
            // HorizLabel
            // 
            this.HorizLabel.AutoSize = true;
            this.HorizLabel.Location = new System.Drawing.Point(35, 35);
            this.HorizLabel.Name = "HorizLabel";
            this.HorizLabel.Size = new System.Drawing.Size(164, 17);
            this.HorizLabel.TabIndex = 2;
            this.HorizLabel.Text = "Размер по горизонтали";
            // 
            // EdHoriz
            // 
            this.EdHoriz.Location = new System.Drawing.Point(314, 35);
            this.EdHoriz.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.EdHoriz.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.EdHoriz.Name = "EdHoriz";
            this.EdHoriz.Size = new System.Drawing.Size(120, 22);
            this.EdHoriz.TabIndex = 4;
            this.EdHoriz.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // EdVertical
            // 
            this.EdVertical.Location = new System.Drawing.Point(314, 74);
            this.EdVertical.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.EdVertical.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.EdVertical.Name = "EdVertical";
            this.EdVertical.Size = new System.Drawing.Size(120, 22);
            this.EdVertical.TabIndex = 5;
            this.EdVertical.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 141);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 33);
            this.button1.TabIndex = 6;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 201);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.EdVertical);
            this.Controls.Add(this.EdHoriz);
            this.Controls.Add(this.VertLabel);
            this.Controls.Add(this.HorizLabel);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.EdHoriz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EdVertical)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label VertLabel;
        private System.Windows.Forms.Label HorizLabel;
        private System.Windows.Forms.NumericUpDown EdHoriz;
        private System.Windows.Forms.NumericUpDown EdVertical;
        private System.Windows.Forms.Button button1;
    }
}