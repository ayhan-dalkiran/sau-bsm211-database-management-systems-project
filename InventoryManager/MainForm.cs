using System.ComponentModel;

namespace InventoryManager;

public partial class MainForm : Form {
	public MainForm() {
		InitializeComponent();
	}

	private async void MainForm_Load(object sender, EventArgs e) {
		//this.itemView.GridDataSource = DatabaseApi.ItemView;
		//this.receiptView.GridDataSource = DatabaseApi.ReceiptView;
		//this.shipmentView.GridDataSource = DatabaseApi.ShipmentView;
		//this.entityView.GridDataSource = DatabaseApi.EntityView;
		//this.employeeView.GridDataSource = DatabaseApi.EmployeeView;
		//this.workplaceView.GridDataSource = DatabaseApi.WorkplaceView;
		await DatabaseApi.UpdateViewBulk();
	}
}
