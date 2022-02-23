
namespace ProjetDotNet
{
    partial class Graph
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Graph));
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl3 = new ZedGraph.ZedGraphControl();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox_fioul = new System.Windows.Forms.CheckBox();
            this.checkBox_bio = new System.Windows.Forms.CheckBox();
            this.checkBox_sol = new System.Windows.Forms.CheckBox();
            this.checkBox_charbon = new System.Windows.Forms.CheckBox();
            this.checkBox_gaz = new System.Windows.Forms.CheckBox();
            this.checkBox_eol = new System.Windows.Forms.CheckBox();
            this.checkBox_hydra = new System.Windows.Forms.CheckBox();
            this.checkBox_nuc = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox_all = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(13, 13);
            this.zedGraphControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(773, 641);
            this.zedGraphControl1.TabIndex = 0;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // zedGraphControl3
            // 
            this.zedGraphControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl3.Location = new System.Drawing.Point(794, 13);
            this.zedGraphControl3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.zedGraphControl3.Name = "zedGraphControl3";
            this.zedGraphControl3.ScrollGrace = 0D;
            this.zedGraphControl3.ScrollMaxX = 0D;
            this.zedGraphControl3.ScrollMaxY = 0D;
            this.zedGraphControl3.ScrollMaxY2 = 0D;
            this.zedGraphControl3.ScrollMinX = 0D;
            this.zedGraphControl3.ScrollMinY = 0D;
            this.zedGraphControl3.ScrollMinY2 = 0D;
            this.zedGraphControl3.Size = new System.Drawing.Size(733, 641);
            this.zedGraphControl3.TabIndex = 2;
            this.zedGraphControl3.UseExtendedPrintDialog = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.Font = new System.Drawing.Font("Sylfaen", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(12, 770);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 54);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_fioul
            // 
            this.checkBox_fioul.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox_fioul.AutoSize = true;
            this.checkBox_fioul.Checked = true;
            this.checkBox_fioul.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_fioul.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_fioul.Location = new System.Drawing.Point(724, 769);
            this.checkBox_fioul.Name = "checkBox_fioul";
            this.checkBox_fioul.Size = new System.Drawing.Size(67, 24);
            this.checkBox_fioul.TabIndex = 19;
            this.checkBox_fioul.Text = "Fioul";
            this.checkBox_fioul.UseVisualStyleBackColor = true;
            this.checkBox_fioul.Click += new System.EventHandler(this.checkboxChange);
            // 
            // checkBox_bio
            // 
            this.checkBox_bio.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox_bio.AutoSize = true;
            this.checkBox_bio.Checked = true;
            this.checkBox_bio.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_bio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_bio.Location = new System.Drawing.Point(582, 769);
            this.checkBox_bio.Name = "checkBox_bio";
            this.checkBox_bio.Size = new System.Drawing.Size(120, 24);
            this.checkBox_bio.TabIndex = 18;
            this.checkBox_bio.Text = "Bioenergies";
            this.checkBox_bio.UseVisualStyleBackColor = true;
            this.checkBox_bio.Click += new System.EventHandler(this.checkboxChange);
            // 
            // checkBox_sol
            // 
            this.checkBox_sol.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox_sol.AutoSize = true;
            this.checkBox_sol.Checked = true;
            this.checkBox_sol.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_sol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_sol.Location = new System.Drawing.Point(724, 730);
            this.checkBox_sol.Name = "checkBox_sol";
            this.checkBox_sol.Size = new System.Drawing.Size(83, 24);
            this.checkBox_sol.TabIndex = 17;
            this.checkBox_sol.Text = "Solaire";
            this.checkBox_sol.UseVisualStyleBackColor = true;
            this.checkBox_sol.Click += new System.EventHandler(this.checkboxChange);
            // 
            // checkBox_charbon
            // 
            this.checkBox_charbon.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox_charbon.AutoSize = true;
            this.checkBox_charbon.Checked = true;
            this.checkBox_charbon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_charbon.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_charbon.Location = new System.Drawing.Point(872, 730);
            this.checkBox_charbon.Name = "checkBox_charbon";
            this.checkBox_charbon.Size = new System.Drawing.Size(94, 24);
            this.checkBox_charbon.TabIndex = 16;
            this.checkBox_charbon.Text = "Charbon";
            this.checkBox_charbon.UseVisualStyleBackColor = true;
            this.checkBox_charbon.Click += new System.EventHandler(this.checkboxChange);
            // 
            // checkBox_gaz
            // 
            this.checkBox_gaz.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox_gaz.AutoSize = true;
            this.checkBox_gaz.Checked = true;
            this.checkBox_gaz.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_gaz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_gaz.Location = new System.Drawing.Point(582, 730);
            this.checkBox_gaz.Name = "checkBox_gaz";
            this.checkBox_gaz.Size = new System.Drawing.Size(62, 24);
            this.checkBox_gaz.TabIndex = 15;
            this.checkBox_gaz.Text = "Gaz";
            this.checkBox_gaz.UseVisualStyleBackColor = true;
            this.checkBox_gaz.Click += new System.EventHandler(this.checkboxChange);
            // 
            // checkBox_eol
            // 
            this.checkBox_eol.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox_eol.AutoSize = true;
            this.checkBox_eol.Checked = true;
            this.checkBox_eol.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_eol.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_eol.Location = new System.Drawing.Point(872, 693);
            this.checkBox_eol.Name = "checkBox_eol";
            this.checkBox_eol.Size = new System.Drawing.Size(77, 24);
            this.checkBox_eol.TabIndex = 14;
            this.checkBox_eol.Text = "Eolien";
            this.checkBox_eol.UseVisualStyleBackColor = true;
            this.checkBox_eol.Click += new System.EventHandler(this.checkboxChange);
            // 
            // checkBox_hydra
            // 
            this.checkBox_hydra.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox_hydra.AutoSize = true;
            this.checkBox_hydra.Checked = true;
            this.checkBox_hydra.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_hydra.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_hydra.Location = new System.Drawing.Point(724, 693);
            this.checkBox_hydra.Name = "checkBox_hydra";
            this.checkBox_hydra.Size = new System.Drawing.Size(120, 24);
            this.checkBox_hydra.TabIndex = 13;
            this.checkBox_hydra.Text = "Hydraulique";
            this.checkBox_hydra.UseVisualStyleBackColor = true;
            this.checkBox_hydra.Click += new System.EventHandler(this.checkboxChange);
            // 
            // checkBox_nuc
            // 
            this.checkBox_nuc.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox_nuc.AutoSize = true;
            this.checkBox_nuc.Checked = true;
            this.checkBox_nuc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_nuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_nuc.Location = new System.Drawing.Point(582, 693);
            this.checkBox_nuc.Name = "checkBox_nuc";
            this.checkBox_nuc.Size = new System.Drawing.Size(102, 24);
            this.checkBox_nuc.TabIndex = 12;
            this.checkBox_nuc.Text = "Nucleaire";
            this.checkBox_nuc.UseVisualStyleBackColor = true;
            this.checkBox_nuc.Click += new System.EventHandler(this.checkboxChange);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Location = new System.Drawing.Point(1118, 768);
            this.dateTimePicker1.MaxDate = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(263, 22);
            this.dateTimePicker1.TabIndex = 20;
            this.dateTimePicker1.Value = new System.DateTime(2020, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(1421, 760);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 42);
            this.button2.TabIndex = 21;
            this.button2.Text = "Annuel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox_all
            // 
            this.checkBox_all.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.checkBox_all.AutoSize = true;
            this.checkBox_all.Checked = true;
            this.checkBox_all.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_all.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_all.Location = new System.Drawing.Point(872, 769);
            this.checkBox_all.Name = "checkBox_all";
            this.checkBox_all.Size = new System.Drawing.Size(50, 24);
            this.checkBox_all.TabIndex = 20;
            this.checkBox_all.Text = "All";
            this.checkBox_all.UseVisualStyleBackColor = true;
            this.checkBox_all.CheckedChanged += new System.EventHandler(this.checkBox_all_CheckedChanged);
            this.checkBox_all.Click += new System.EventHandler(this.checkboxChange);
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(1682, 836);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.checkBox_all);
            this.Controls.Add(this.checkBox_fioul);
            this.Controls.Add(this.checkBox_bio);
            this.Controls.Add(this.checkBox_sol);
            this.Controls.Add(this.checkBox_charbon);
            this.Controls.Add(this.checkBox_gaz);
            this.Controls.Add(this.checkBox_eol);
            this.Controls.Add(this.checkBox_hydra);
            this.Controls.Add(this.checkBox_nuc);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.zedGraphControl3);
            this.Controls.Add(this.zedGraphControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1700, 883);
            this.Name = "Graph";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Green";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl1;
        private ZedGraph.ZedGraphControl zedGraphControl3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox_fioul;
        private System.Windows.Forms.CheckBox checkBox_bio;
        private System.Windows.Forms.CheckBox checkBox_sol;
        private System.Windows.Forms.CheckBox checkBox_charbon;
        private System.Windows.Forms.CheckBox checkBox_gaz;
        private System.Windows.Forms.CheckBox checkBox_eol;
        private System.Windows.Forms.CheckBox checkBox_hydra;
        private System.Windows.Forms.CheckBox checkBox_nuc;

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button2;

        private System.Windows.Forms.CheckBox checkBox_all;

    }
}

