
namespace fmedit
{
    partial class EditorForm
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
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.playerUidTextBox = new System.Windows.Forms.TextBox();
            this.saveAttributesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // propertyGrid
            // 
            this.propertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid.HelpVisible = false;
            this.propertyGrid.Location = new System.Drawing.Point(12, 47);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(395, 391);
            this.propertyGrid.TabIndex = 0;
            this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid_PropertyValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Player UID";
            // 
            // playerUidTextBox
            // 
            this.playerUidTextBox.Location = new System.Drawing.Point(78, 13);
            this.playerUidTextBox.Name = "playerUidTextBox";
            this.playerUidTextBox.Size = new System.Drawing.Size(126, 20);
            this.playerUidTextBox.TabIndex = 2;
            this.playerUidTextBox.TextChanged += new System.EventHandler(this.playerUidTextBox_TextChanged);
            // 
            // saveAttributesButton
            // 
            this.saveAttributesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveAttributesButton.Location = new System.Drawing.Point(295, 13);
            this.saveAttributesButton.Name = "saveAttributesButton";
            this.saveAttributesButton.Size = new System.Drawing.Size(112, 23);
            this.saveAttributesButton.TabIndex = 3;
            this.saveAttributesButton.Text = "Save Attributes";
            this.saveAttributesButton.UseVisualStyleBackColor = true;
            this.saveAttributesButton.Click += new System.EventHandler(this.saveAttributesButton_Click);
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 450);
            this.Controls.Add(this.saveAttributesButton);
            this.Controls.Add(this.playerUidTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.propertyGrid);
            this.Name = "EditorForm";
            this.Text = "FM Edit";
            this.Load += new System.EventHandler(this.EditorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox playerUidTextBox;
        private System.Windows.Forms.Button saveAttributesButton;
    }
}

