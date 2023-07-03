
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
            this.load_button = new System.Windows.Forms.Button();
            this.exit_button = new System.Windows.Forms.Button();
            this.clear_button = new System.Windows.Forms.Button();
            this.save_button = new System.Windows.Forms.Button();
            this.canvasPanel = new System.Windows.Forms.Panel();
            this.toolboxPanel = new System.Windows.Forms.Panel();
            this.resize_button = new System.Windows.Forms.PictureBox();
            this.move_button = new System.Windows.Forms.PictureBox();
            this.select_button = new System.Windows.Forms.PictureBox();
            this.ellipse_button = new System.Windows.Forms.PictureBox();
            this.rectangle_button = new System.Windows.Forms.PictureBox();
            this.colorbox = new System.Windows.Forms.PictureBox();
            this.paintbrush_size = new System.Windows.Forms.NumericUpDown();
            this.TopPanel.SuspendLayout();
            this.canvasPanel.SuspendLayout();
            this.toolboxPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resize_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.move_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.select_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ellipse_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectangle_button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorbox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paintbrush_size)).BeginInit();
            this.SuspendLayout();
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.TopPanel.Controls.Add(this.load_button);
            this.TopPanel.Controls.Add(this.exit_button);
            this.TopPanel.Controls.Add(this.clear_button);
            this.TopPanel.Controls.Add(this.save_button);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(800, 51);
            this.TopPanel.TabIndex = 0;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseDown);
            this.TopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseMove);
            this.TopPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TopPanel_MouseUp);
            // 
            // load_button
            // 
            this.load_button.Location = new System.Drawing.Point(433, 14);
            this.load_button.Name = "load_button";
            this.load_button.Size = new System.Drawing.Size(75, 23);
            this.load_button.TabIndex = 4;
            this.load_button.Text = "Laden";
            this.load_button.UseVisualStyleBackColor = true;
            this.load_button.Click += new System.EventHandler(this.load_button_Click);
            // 
            // exit_button
            // 
            this.exit_button.Location = new System.Drawing.Point(713, 14);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(75, 23);
            this.exit_button.TabIndex = 3;
            this.exit_button.Text = "Sluiten";
            this.exit_button.UseVisualStyleBackColor = true;
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(595, 14);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(75, 23);
            this.clear_button.TabIndex = 2;
            this.clear_button.Text = "Legen";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // save_button
            // 
            this.save_button.Location = new System.Drawing.Point(514, 14);
            this.save_button.Name = "save_button";
            this.save_button.Size = new System.Drawing.Size(75, 23);
            this.save_button.TabIndex = 1;
            this.save_button.Text = "Opslaan";
            this.save_button.UseVisualStyleBackColor = true;
            this.save_button.Click += new System.EventHandler(this.save_button_Click);
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
            this.canvasPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvasPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvasPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // toolboxPanel
            // 
            this.toolboxPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.toolboxPanel.Controls.Add(this.resize_button);
            this.toolboxPanel.Controls.Add(this.move_button);
            this.toolboxPanel.Controls.Add(this.select_button);
            this.toolboxPanel.Controls.Add(this.ellipse_button);
            this.toolboxPanel.Controls.Add(this.rectangle_button);
            this.toolboxPanel.Controls.Add(this.colorbox);
            this.toolboxPanel.Controls.Add(this.paintbrush_size);
            this.toolboxPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolboxPanel.Location = new System.Drawing.Point(0, 0);
            this.toolboxPanel.Name = "toolboxPanel";
            this.toolboxPanel.Size = new System.Drawing.Size(55, 399);
            this.toolboxPanel.TabIndex = 0;
            // 
            // resize_button
            // 
            this.resize_button.Image = ((System.Drawing.Image)(resources.GetObject("resize_button.Image")));
            this.resize_button.Location = new System.Drawing.Point(6, 210);
            this.resize_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resize_button.Name = "resize_button";
            this.resize_button.Size = new System.Drawing.Size(43, 46);
            this.resize_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.resize_button.TabIndex = 8;
            this.resize_button.TabStop = false;
            this.resize_button.Click += new System.EventHandler(this.resize_button_Click);
            // 
            // move_button
            // 
            this.move_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.move_button.Image = ((System.Drawing.Image)(resources.GetObject("move_button.Image")));
            this.move_button.Location = new System.Drawing.Point(6, 159);
            this.move_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.move_button.Name = "move_button";
            this.move_button.Size = new System.Drawing.Size(43, 46);
            this.move_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.move_button.TabIndex = 7;
            this.move_button.TabStop = false;
            this.move_button.Click += new System.EventHandler(this.move_button_Click);
            // 
            // select_button
            // 
            this.select_button.Image = ((System.Drawing.Image)(resources.GetObject("select_button.Image")));
            this.select_button.Location = new System.Drawing.Point(6, 108);
            this.select_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.select_button.Name = "select_button";
            this.select_button.Size = new System.Drawing.Size(43, 46);
            this.select_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.select_button.TabIndex = 6;
            this.select_button.TabStop = false;
            this.select_button.Click += new System.EventHandler(this.select_button_Click);
            // 
            // ellipse_button
            // 
            this.ellipse_button.Image = ((System.Drawing.Image)(resources.GetObject("ellipse_button.Image")));
            this.ellipse_button.Location = new System.Drawing.Point(6, 58);
            this.ellipse_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ellipse_button.Name = "ellipse_button";
            this.ellipse_button.Size = new System.Drawing.Size(43, 46);
            this.ellipse_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ellipse_button.TabIndex = 5;
            this.ellipse_button.TabStop = false;
            this.ellipse_button.Click += new System.EventHandler(this.ellipse_button_Click);
            // 
            // rectangle_button
            // 
            this.rectangle_button.Image = ((System.Drawing.Image)(resources.GetObject("rectangle_button.Image")));
            this.rectangle_button.Location = new System.Drawing.Point(6, 7);
            this.rectangle_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rectangle_button.Name = "rectangle_button";
            this.rectangle_button.Size = new System.Drawing.Size(43, 46);
            this.rectangle_button.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.rectangle_button.TabIndex = 4;
            this.rectangle_button.TabStop = false;
            this.rectangle_button.Click += new System.EventHandler(this.rectangle_button_Click);
            // 
            // colorbox
            // 
            this.colorbox.BackColor = System.Drawing.Color.Black;
            this.colorbox.Location = new System.Drawing.Point(0, 346);
            this.colorbox.Name = "colorbox";
            this.colorbox.Size = new System.Drawing.Size(58, 53);
            this.colorbox.TabIndex = 3;
            this.colorbox.TabStop = false;
            this.colorbox.Click += new System.EventHandler(this.colorbox_Click);
            // 
            // paintbrush_size
            // 
            this.paintbrush_size.Location = new System.Drawing.Point(0, 325);
            this.paintbrush_size.Name = "paintbrush_size";
            this.paintbrush_size.Size = new System.Drawing.Size(58, 20);
            this.paintbrush_size.TabIndex = 2;
            this.paintbrush_size.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.paintbrush_size.ValueChanged += new System.EventHandler(this.paintbrushsize_change);
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
            this.canvasPanel.ResumeLayout(false);
            this.toolboxPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resize_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.move_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.select_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ellipse_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectangle_button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorbox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paintbrush_size)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.PictureBox resize_button;

        private System.Windows.Forms.PictureBox move_button;

        private System.Windows.Forms.PictureBox select_button;

        private System.Windows.Forms.Button load_button;

        #endregion

        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel canvasPanel;
        private System.Windows.Forms.Panel toolboxPanel;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Button save_button;
        private System.Windows.Forms.PictureBox colorbox;
        private System.Windows.Forms.NumericUpDown paintbrush_size;
        private System.Windows.Forms.PictureBox rectangle_button;
        private System.Windows.Forms.PictureBox ellipse_button;
    }
}

