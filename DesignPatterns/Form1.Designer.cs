
namespace DesignPatterns
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.TopPanel = new System.Windows.Forms.Panel();
            this.canvasPanel = new System.Windows.Forms.Panel();
            this.toolboxPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.save_button = new System.Windows.Forms.Button();
            this.clear_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.paintbrush_button = new System.Windows.Forms.PictureBox();
            this.eraser_button = new System.Windows.Forms.PictureBox();
            this.paintbrush_size = new System.Windows.Forms.NumericUpDown();
            this.colorbox = new System.Windows.Forms.PictureBox();
            this.TopPanel.SuspendLayout();
            this.canvasPanel.SuspendLayout();
            this.toolboxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paintbrush_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eraser_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paintbrush_size)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorbox)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.TopPanel.Controls.Add(this.exit_button);
            this.TopPanel.Controls.Add(this.clear_button);
            this.TopPanel.Controls.Add(this.save_button);
            this.TopPanel.Controls.Add(this.label1);
            this.TopPanel.Controls.Add(this.pictureBox1);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(800, 51);
            this.TopPanel.TabIndex = 0;
            // 
            // canvasPanel
            // 
            this.canvasPanel.BackColor = System.Drawing.Color.White;
            this.canvasPanel.Controls.Add(this.toolboxPanel);
            this.canvasPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvasPanel.Location = new System.Drawing.Point(0, 51);
            this.canvasPanel.Name = "canvasPanel";
            this.canvasPanel.Size = new System.Drawing.Size(800, 399);
            this.canvasPanel.TabIndex = 1;
            // 
            // toolboxPanel
            // 
            this.toolboxPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolboxPanel.Controls.Add(this.colorbox);
            this.toolboxPanel.Controls.Add(this.paintbrush_size);
            this.toolboxPanel.Controls.Add(this.eraser_button);
            this.toolboxPanel.Controls.Add(this.paintbrush_button);
            this.toolboxPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolboxPanel.Location = new System.Drawing.Point(0, 0);
            this.toolboxPanel.Name = "toolboxPanel";
            this.toolboxPanel.Size = new System.Drawing.Size(58, 399);
            this.toolboxPanel.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-2, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(64, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Teken applicatie";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(514, 14);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 1;
            this.save_button.Text = "Opslaan";
            this.save_button.UseVisualStyleBackColor = true;
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(595, 14);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(75, 23);
            this.clear_button.TabIndex = 2;
            this.clear_button.Text = "Legen";
            this.clear_button.UseVisualStyleBackColor = true;
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(713, 14);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(75, 23);
            this.exit_button.TabIndex = 3;
            this.exit_button.Text = "Sluiten";
            this.exit_button.UseVisualStyleBackColor = true;
            // 
            // paintbrush_button
            // 
            this.paintbrush_button.Image = ((System.Drawing.Image)(resources.GetObject("paintbrush_button.Image")));
            this.paintbrush_button.Location = new System.Drawing.Point(7, 9);
            this.paintbrush_button.Name = "paintbrush_button";
            this.paintbrush_button.Size = new System.Drawing.Size(43, 46);
            this.paintbrush_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.paintbrush_button.TabIndex = 0;
            this.paintbrush_button.TabStop = false;
            // 
            // eraser_button
            // 
            this.eraser_button.Image = ((System.Drawing.Image)(resources.GetObject("eraser_button.Image")));
            this.eraser_button.Location = new System.Drawing.Point(7, 61);
            this.eraser_button.Name = "eraser_button";
            this.eraser_button.Size = new System.Drawing.Size(43, 42);
            this.eraser_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.eraser_button.TabIndex = 1;
            this.eraser_button.TabStop = false;
            // 
            // paintbrush_size
            // 
            this.paintbrush_size.Location = new System.Drawing.Point(0, 325);
            this.paintbrush_size.Name = "paintbrush_size";
            this.paintbrush_size.Size = new System.Drawing.Size(58, 20);
            this.paintbrush_size.TabIndex = 2;
            // 
            // colorbox
            // 
            this.colorbox.BackColor = System.Drawing.Color.Black;
            this.colorbox.Location = new System.Drawing.Point(0, 346);
            this.colorbox.Name = "colorbox";
            this.colorbox.Size = new System.Drawing.Size(58, 53);
            this.colorbox.TabIndex = 3;
            this.colorbox.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.canvasPanel);
            this.Controls.Add(this.TopPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.canvasPanel.ResumeLayout(false);
            this.toolboxPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paintbrush_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eraser_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paintbrush_size)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorbox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel canvasPanel;
        private System.Windows.Forms.Panel toolboxPanel;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.PictureBox colorbox;
        private System.Windows.Forms.NumericUpDown paintbrush_size;
        private System.Windows.Forms.PictureBox eraser_button;
        private System.Windows.Forms.PictureBox paintbrush_button;
    }
}

