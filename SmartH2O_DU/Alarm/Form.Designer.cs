namespace Alarm
{
    partial class Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.OnOff = new System.Windows.Forms.Button();
            this.treeViewTriggers = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // OnOff
            // 
            resources.ApplyResources(this.OnOff, "OnOff");
            this.OnOff.Name = "OnOff";
            this.OnOff.UseVisualStyleBackColor = true;
            this.OnOff.Click += new System.EventHandler(this.OnOff_Click);
            // 
            // treeViewTriggers
            // 
            resources.ApplyResources(this.treeViewTriggers, "treeViewTriggers");
            this.treeViewTriggers.Name = "treeViewTriggers";
            // 
            // Form
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeViewTriggers);
            this.Controls.Add(this.OnOff);
            this.Name = "Form";
            this.Load += new System.EventHandler(this.Form_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button OnOff;
        private System.Windows.Forms.TreeView treeViewTriggers;
    }
}

