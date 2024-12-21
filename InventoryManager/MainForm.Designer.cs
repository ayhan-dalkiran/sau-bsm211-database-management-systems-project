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
		this.itemView = new PostgresqlDataGridView();
		this.receiptPage = new TabPage();
		this.receiptView = new PostgresqlDataGridView();
		this.shipmentPage = new TabPage();
		this.shipmentView = new PostgresqlDataGridView();
		this.entityPage = new TabPage();
		this.entityView = new PostgresqlDataGridView();
		this.employeePage = new TabPage();
		this.employeeView = new PostgresqlDataGridView();
		this.workplacePage = new TabPage();
		this.workplaceView = new PostgresqlDataGridView();
		this.TableSelector.SuspendLayout();
		this.itemPage.SuspendLayout();
		this.receiptPage.SuspendLayout();
		this.shipmentPage.SuspendLayout();
		this.entityPage.SuspendLayout();
		this.employeePage.SuspendLayout();
		this.workplacePage.SuspendLayout();
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
		this.itemPage.Controls.Add(this.itemView);
		this.itemPage.Location = new Point(4, 24);
		this.itemPage.Name = "itemPage";
		this.itemPage.Padding = new Padding(3);
		this.itemPage.Size = new Size(792, 422);
		this.itemPage.TabIndex = 0;
		this.itemPage.Text = "Items";
		this.itemPage.UseVisualStyleBackColor = true;
		// 
		// itemView
		// 
		this.itemView.Dock = DockStyle.Fill;
		this.itemView.GridDataSource = null;
		this.itemView.Location = new Point(3, 3);
		this.itemView.Name = "itemView";
		this.itemView.SearchBoxText = "";
		this.itemView.Size = new Size(786, 416);
		this.itemView.TabIndex = 0;
		// 
		// receiptPage
		// 
		this.receiptPage.Controls.Add(this.receiptView);
		this.receiptPage.Location = new Point(4, 24);
		this.receiptPage.Name = "receiptPage";
		this.receiptPage.Padding = new Padding(3);
		this.receiptPage.Size = new Size(792, 422);
		this.receiptPage.TabIndex = 1;
		this.receiptPage.Text = "Receipts";
		this.receiptPage.UseVisualStyleBackColor = true;
		// 
		// receiptView
		// 
		this.receiptView.Dock = DockStyle.Fill;
		this.receiptView.GridDataSource = null;
		this.receiptView.Location = new Point(3, 3);
		this.receiptView.Name = "receiptView";
		this.receiptView.SearchBoxText = "";
		this.receiptView.Size = new Size(786, 416);
		this.receiptView.TabIndex = 1;
		// 
		// shipmentPage
		// 
		this.shipmentPage.Controls.Add(this.shipmentView);
		this.shipmentPage.Location = new Point(4, 24);
		this.shipmentPage.Name = "shipmentPage";
		this.shipmentPage.Padding = new Padding(3);
		this.shipmentPage.Size = new Size(792, 422);
		this.shipmentPage.TabIndex = 2;
		this.shipmentPage.Text = "Shipments";
		this.shipmentPage.UseVisualStyleBackColor = true;
		// 
		// shipmentView
		// 
		this.shipmentView.Dock = DockStyle.Fill;
		this.shipmentView.GridDataSource = null;
		this.shipmentView.Location = new Point(3, 3);
		this.shipmentView.Name = "shipmentView";
		this.shipmentView.SearchBoxText = "";
		this.shipmentView.Size = new Size(786, 416);
		this.shipmentView.TabIndex = 1;
		// 
		// entityPage
		// 
		this.entityPage.Controls.Add(this.entityView);
		this.entityPage.Location = new Point(4, 24);
		this.entityPage.Name = "entityPage";
		this.entityPage.Padding = new Padding(3);
		this.entityPage.Size = new Size(792, 422);
		this.entityPage.TabIndex = 3;
		this.entityPage.Text = "Entities";
		this.entityPage.UseVisualStyleBackColor = true;
		// 
		// entityView
		// 
		this.entityView.Dock = DockStyle.Fill;
		this.entityView.GridDataSource = null;
		this.entityView.Location = new Point(3, 3);
		this.entityView.Name = "entityView";
		this.entityView.SearchBoxText = "";
		this.entityView.Size = new Size(786, 416);
		this.entityView.TabIndex = 1;
		this.entityView.OnAddRequest += this.entityView_OnAddRequest;
		this.entityView.OnUpdateRequest += this.entityView_OnUpdateRequest;
		this.entityView.OnDeleteRequest += this.entityView_OnDeleteRequest;
		this.entityView.OnSearchRequest += this.entityView_OnSearchRequest;
		// 
		// employeePage
		// 
		this.employeePage.Controls.Add(this.employeeView);
		this.employeePage.Location = new Point(4, 24);
		this.employeePage.Name = "employeePage";
		this.employeePage.Padding = new Padding(3);
		this.employeePage.Size = new Size(792, 422);
		this.employeePage.TabIndex = 4;
		this.employeePage.Text = "Employees";
		this.employeePage.UseVisualStyleBackColor = true;
		// 
		// employeeView
		// 
		this.employeeView.Dock = DockStyle.Fill;
		this.employeeView.GridDataSource = null;
		this.employeeView.Location = new Point(3, 3);
		this.employeeView.Name = "employeeView";
		this.employeeView.SearchBoxText = "";
		this.employeeView.Size = new Size(786, 416);
		this.employeeView.TabIndex = 1;
		// 
		// workplacePage
		// 
		this.workplacePage.Controls.Add(this.workplaceView);
		this.workplacePage.Location = new Point(4, 24);
		this.workplacePage.Name = "workplacePage";
		this.workplacePage.Padding = new Padding(3);
		this.workplacePage.Size = new Size(792, 422);
		this.workplacePage.TabIndex = 5;
		this.workplacePage.Text = "Workplaces";
		this.workplacePage.UseVisualStyleBackColor = true;
		// 
		// workplaceView
		// 
		this.workplaceView.Dock = DockStyle.Fill;
		this.workplaceView.GridDataSource = null;
		this.workplaceView.Location = new Point(3, 3);
		this.workplaceView.Name = "workplaceView";
		this.workplaceView.SearchBoxText = "";
		this.workplaceView.Size = new Size(786, 416);
		this.workplaceView.TabIndex = 1;
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
		this.receiptPage.ResumeLayout(false);
		this.shipmentPage.ResumeLayout(false);
		this.entityPage.ResumeLayout(false);
		this.employeePage.ResumeLayout(false);
		this.workplacePage.ResumeLayout(false);
		this.ResumeLayout(false);
	}

	#endregion

	private TabControl TableSelector;
	private TabPage itemPage;
	private TabPage shipmentPage;
	private TabPage entityPage;
	private TabPage workplacePage;
	private TabPage receiptPage;
	private PostgresqlDataGridView itemView;
	private PostgresqlDataGridView receiptView;
	private PostgresqlDataGridView shipmentView;
	private PostgresqlDataGridView entityView;
	private PostgresqlDataGridView workplaceView;
	private TabPage employeePage;
	private PostgresqlDataGridView employeeView;
}
