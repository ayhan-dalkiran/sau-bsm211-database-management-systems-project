namespace InventoryManager;

partial class MainForm {
	/// <summary>
	///  Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	///  Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing) {
		if (disposing && (components != null)) {
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	///  Required method for Designer support - do not modify
	///  the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent() {
		this.TableSelector = new TabControl();
		this.itemPage = new TabPage();
		this.tabControl1 = new TabControl();
		this.tabPage1 = new TabPage();
		this.tabPage2 = new TabPage();
		this.tabPage3 = new TabPage();
		this.tabPage4 = new TabPage();
		this.receiptPage = new TabPage();
		this.shipmentPage = new TabPage();
		this.entityPage = new TabPage();
		this.tabControl2 = new TabControl();
		this.tabPage5 = new TabPage();
		this.tabPage6 = new TabPage();
		this.tabPage7 = new TabPage();
		this.employeePage = new TabPage();
		this.workplacePage = new TabPage();
		this.tabControl3 = new TabControl();
		this.tabPage8 = new TabPage();
		this.tabPage9 = new TabPage();
		this.tabPage10 = new TabPage();
		this.postgresqlDataGridView1 = new PostgresqlDataGridView();
		this.TableSelector.SuspendLayout();
		this.itemPage.SuspendLayout();
		this.tabControl1.SuspendLayout();
		this.tabPage1.SuspendLayout();
		this.entityPage.SuspendLayout();
		this.tabControl2.SuspendLayout();
		this.workplacePage.SuspendLayout();
		this.tabControl3.SuspendLayout();
		this.SuspendLayout();
		// 
		// TableSelector
		// 
		this.TableSelector.Controls.Add(this.itemPage);
		this.TableSelector.Controls.Add(this.receiptPage);
		this.TableSelector.Controls.Add(this.shipmentPage);
		this.TableSelector.Controls.Add(this.entityPage);
		this.TableSelector.Controls.Add(this.employeePage);
		this.TableSelector.Controls.Add(this.workplacePage);
		this.TableSelector.Dock = DockStyle.Fill;
		this.TableSelector.Location = new Point(0, 0);
		this.TableSelector.Name = "TableSelector";
		this.TableSelector.SelectedIndex = 0;
		this.TableSelector.Size = new Size(800, 450);
		this.TableSelector.TabIndex = 0;
		// 
		// itemPage
		// 
		this.itemPage.Controls.Add(this.tabControl1);
		this.itemPage.Location = new Point(4, 24);
		this.itemPage.Name = "itemPage";
		this.itemPage.Padding = new Padding(3);
		this.itemPage.Size = new Size(792, 422);
		this.itemPage.TabIndex = 0;
		this.itemPage.Text = "Kalemler";
		this.itemPage.UseVisualStyleBackColor = true;
		// 
		// tabControl1
		// 
		this.tabControl1.Controls.Add(this.tabPage1);
		this.tabControl1.Controls.Add(this.tabPage2);
		this.tabControl1.Controls.Add(this.tabPage3);
		this.tabControl1.Controls.Add(this.tabPage4);
		this.tabControl1.Dock = DockStyle.Fill;
		this.tabControl1.Location = new Point(3, 3);
		this.tabControl1.Name = "tabControl1";
		this.tabControl1.SelectedIndex = 0;
		this.tabControl1.Size = new Size(786, 416);
		this.tabControl1.TabIndex = 0;
		// 
		// tabPage1
		// 
		this.tabPage1.Controls.Add(this.postgresqlDataGridView1);
		this.tabPage1.Location = new Point(4, 24);
		this.tabPage1.Name = "tabPage1";
		this.tabPage1.Padding = new Padding(3);
		this.tabPage1.Size = new Size(778, 388);
		this.tabPage1.TabIndex = 0;
		this.tabPage1.Text = "Hepsi";
		this.tabPage1.UseVisualStyleBackColor = true;
		// 
		// tabPage2
		// 
		this.tabPage2.Location = new Point(4, 24);
		this.tabPage2.Name = "tabPage2";
		this.tabPage2.Padding = new Padding(3);
		this.tabPage2.Size = new Size(778, 388);
		this.tabPage2.TabIndex = 1;
		this.tabPage2.Text = "Gıdalar";
		this.tabPage2.UseVisualStyleBackColor = true;
		// 
		// tabPage3
		// 
		this.tabPage3.Location = new Point(4, 24);
		this.tabPage3.Name = "tabPage3";
		this.tabPage3.Padding = new Padding(3);
		this.tabPage3.Size = new Size(778, 388);
		this.tabPage3.TabIndex = 2;
		this.tabPage3.Text = "Kimyasallar";
		this.tabPage3.UseVisualStyleBackColor = true;
		// 
		// tabPage4
		// 
		this.tabPage4.Location = new Point(4, 24);
		this.tabPage4.Name = "tabPage4";
		this.tabPage4.Size = new Size(778, 388);
		this.tabPage4.TabIndex = 3;
		this.tabPage4.Text = "Diğer";
		this.tabPage4.UseVisualStyleBackColor = true;
		// 
		// receiptPage
		// 
		this.receiptPage.Location = new Point(4, 24);
		this.receiptPage.Name = "receiptPage";
		this.receiptPage.Padding = new Padding(3);
		this.receiptPage.Size = new Size(792, 422);
		this.receiptPage.TabIndex = 1;
		this.receiptPage.Text = "Faturalar";
		this.receiptPage.UseVisualStyleBackColor = true;
		// 
		// shipmentPage
		// 
		this.shipmentPage.Location = new Point(4, 24);
		this.shipmentPage.Name = "shipmentPage";
		this.shipmentPage.Padding = new Padding(3);
		this.shipmentPage.Size = new Size(792, 422);
		this.shipmentPage.TabIndex = 2;
		this.shipmentPage.Text = "Sevkiyatlar";
		this.shipmentPage.UseVisualStyleBackColor = true;
		// 
		// entityPage
		// 
		this.entityPage.Controls.Add(this.tabControl2);
		this.entityPage.Location = new Point(4, 24);
		this.entityPage.Name = "entityPage";
		this.entityPage.Padding = new Padding(3);
		this.entityPage.Size = new Size(792, 422);
		this.entityPage.TabIndex = 3;
		this.entityPage.Text = "Varlıklar";
		this.entityPage.UseVisualStyleBackColor = true;
		// 
		// tabControl2
		// 
		this.tabControl2.Controls.Add(this.tabPage5);
		this.tabControl2.Controls.Add(this.tabPage6);
		this.tabControl2.Controls.Add(this.tabPage7);
		this.tabControl2.Dock = DockStyle.Fill;
		this.tabControl2.Location = new Point(3, 3);
		this.tabControl2.Name = "tabControl2";
		this.tabControl2.SelectedIndex = 0;
		this.tabControl2.Size = new Size(786, 416);
		this.tabControl2.TabIndex = 0;
		// 
		// tabPage5
		// 
		this.tabPage5.Location = new Point(4, 24);
		this.tabPage5.Name = "tabPage5";
		this.tabPage5.Padding = new Padding(3);
		this.tabPage5.Size = new Size(778, 388);
		this.tabPage5.TabIndex = 0;
		this.tabPage5.Text = "Hepsi";
		this.tabPage5.UseVisualStyleBackColor = true;
		// 
		// tabPage6
		// 
		this.tabPage6.Location = new Point(4, 24);
		this.tabPage6.Name = "tabPage6";
		this.tabPage6.Padding = new Padding(3);
		this.tabPage6.Size = new Size(778, 388);
		this.tabPage6.TabIndex = 1;
		this.tabPage6.Text = "Firmalar";
		this.tabPage6.UseVisualStyleBackColor = true;
		// 
		// tabPage7
		// 
		this.tabPage7.Location = new Point(4, 24);
		this.tabPage7.Name = "tabPage7";
		this.tabPage7.Padding = new Padding(3);
		this.tabPage7.Size = new Size(778, 388);
		this.tabPage7.TabIndex = 2;
		this.tabPage7.Text = "Kişiler";
		this.tabPage7.UseVisualStyleBackColor = true;
		// 
		// employeePage
		// 
		this.employeePage.Location = new Point(4, 24);
		this.employeePage.Name = "employeePage";
		this.employeePage.Padding = new Padding(3);
		this.employeePage.Size = new Size(792, 422);
		this.employeePage.TabIndex = 4;
		this.employeePage.Text = "Personeller";
		this.employeePage.UseVisualStyleBackColor = true;
		// 
		// workplacePage
		// 
		this.workplacePage.Controls.Add(this.tabControl3);
		this.workplacePage.Location = new Point(4, 24);
		this.workplacePage.Name = "workplacePage";
		this.workplacePage.Padding = new Padding(3);
		this.workplacePage.Size = new Size(792, 422);
		this.workplacePage.TabIndex = 5;
		this.workplacePage.Text = "İşyerleri";
		this.workplacePage.UseVisualStyleBackColor = true;
		// 
		// tabControl3
		// 
		this.tabControl3.Controls.Add(this.tabPage8);
		this.tabControl3.Controls.Add(this.tabPage9);
		this.tabControl3.Controls.Add(this.tabPage10);
		this.tabControl3.Dock = DockStyle.Fill;
		this.tabControl3.Location = new Point(3, 3);
		this.tabControl3.Name = "tabControl3";
		this.tabControl3.SelectedIndex = 0;
		this.tabControl3.Size = new Size(786, 416);
		this.tabControl3.TabIndex = 0;
		// 
		// tabPage8
		// 
		this.tabPage8.Location = new Point(4, 24);
		this.tabPage8.Name = "tabPage8";
		this.tabPage8.Padding = new Padding(3);
		this.tabPage8.Size = new Size(778, 388);
		this.tabPage8.TabIndex = 0;
		this.tabPage8.Text = "Hepsi";
		this.tabPage8.UseVisualStyleBackColor = true;
		// 
		// tabPage9
		// 
		this.tabPage9.Location = new Point(4, 24);
		this.tabPage9.Name = "tabPage9";
		this.tabPage9.Padding = new Padding(3);
		this.tabPage9.Size = new Size(778, 388);
		this.tabPage9.TabIndex = 1;
		this.tabPage9.Text = "Depolar";
		this.tabPage9.UseVisualStyleBackColor = true;
		// 
		// tabPage10
		// 
		this.tabPage10.Location = new Point(4, 24);
		this.tabPage10.Name = "tabPage10";
		this.tabPage10.Size = new Size(778, 388);
		this.tabPage10.TabIndex = 2;
		this.tabPage10.Text = "Ofisler";
		this.tabPage10.UseVisualStyleBackColor = true;
		// 
		// postgresqlDataGridView1
		// 
		this.postgresqlDataGridView1.GridDataSource = null;
		this.postgresqlDataGridView1.Location = new Point(177, 171);
		this.postgresqlDataGridView1.Name = "postgresqlDataGridView1";
		this.postgresqlDataGridView1.SearchBoxText = "";
		this.postgresqlDataGridView1.Size = new Size(557, 303);
		this.postgresqlDataGridView1.TabIndex = 0;
		// 
		// MainForm
		// 
		this.AutoScaleDimensions = new SizeF(7F, 15F);
		this.AutoScaleMode = AutoScaleMode.Font;
		this.ClientSize = new Size(800, 450);
		this.Controls.Add(this.TableSelector);
		this.Name = "MainForm";
		this.Text = "Manager";
		this.Load += this.MainForm_Load;
		this.TableSelector.ResumeLayout(false);
		this.itemPage.ResumeLayout(false);
		this.tabControl1.ResumeLayout(false);
		this.tabPage1.ResumeLayout(false);
		this.entityPage.ResumeLayout(false);
		this.tabControl2.ResumeLayout(false);
		this.workplacePage.ResumeLayout(false);
		this.tabControl3.ResumeLayout(false);
		this.ResumeLayout(false);
	}

	#endregion

	private TabControl TableSelector;
	private TabPage itemPage;
	private TabPage shipmentPage;
	private TabPage entityPage;
	private TabPage workplacePage;
	private TabPage receiptPage;
	private TabPage employeePage;
	private TabControl tabControl1;
	private TabPage tabPage1;
	private TabPage tabPage2;
	private TabPage tabPage3;
	private TabPage tabPage4;
	private TabControl tabControl2;
	private TabPage tabPage5;
	private TabPage tabPage6;
	private TabPage tabPage7;
	private TabControl tabControl3;
	private TabPage tabPage8;
	private TabPage tabPage9;
	private TabPage tabPage10;
	private PostgresqlDataGridView postgresqlDataGridView1;
}
