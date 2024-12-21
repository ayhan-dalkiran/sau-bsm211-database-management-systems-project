using System.ComponentModel;

namespace InventoryManager;

public partial class MainForm : Form {
	public MainForm() {
		InitializeComponent();
	}

	private async void MainForm_Load(object sender, EventArgs e) {
		this.itemView.GridDataSource = DatabaseApi.ItemView;
		this.receiptView.GridDataSource = DatabaseApi.ReceiptView;
		this.shipmentView.GridDataSource = DatabaseApi.ShipmentView;
		this.entityView.GridDataSource = DatabaseApi.EntityView;
		this.employeeView.GridDataSource = DatabaseApi.EmployeeView;
		this.workplaceView.GridDataSource = DatabaseApi.WorkplaceView;
		await DatabaseApi.UpdateViewBulk();
	}

	private async void entityView_OnAddRequest(object sender, EventArgs e) {
		using var form = new EntityPrompt();
		form.RequestType = RequestType.Add;
		if (form.ShowDialog() != DialogResult.OK)
			return;

		var entity = form.EntityObject;
		await DatabaseApi.InsertEntity(form.EntityObject);
		await DatabaseApi.UpdateEntityView();
	}

	private async void entityView_OnUpdateRequest(object sender, EventArgs e) {
		var entity = (Entity)this.entityView.SelectedRowObject;
		using var form = new EntityPrompt();
		form.EntityObject = entity.EntityType switch {
			EntityType.Company => await DatabaseApi.SelectCompany(entity.Id),
			EntityType.Person => await DatabaseApi.SelectPerson(entity.Id),
			_ => throw new InvalidEnumArgumentException(),
		};

		form.RequestType = RequestType.Update;
		if (form.ShowDialog() != DialogResult.OK)
			return;

		await DatabaseApi.UpdateEntity(form.EntityObject);
		await DatabaseApi.UpdateEntityView();
	}

	private async void entityView_OnDeleteRequest(object sender, EventArgs e) {
		List<int> ids = new();

		foreach (DataGridViewRow row in this.entityView.SelectedRows) {
			ids.Add(((Entity)row.DataBoundItem).Id);
		}

		await DatabaseApi.DeleteEntityBulk(ids);
		await DatabaseApi.UpdateEntityView();
	}

	private async void entityView_OnSearchRequest(object sender, EventArgs e) {
		if (this.entityView.SearchBoxText == "company") {
			await DatabaseApi.UpdateEntityView(EntityType.Company);
		}
		else if (this.entityView.SearchBoxText == "person") {
			await DatabaseApi.UpdateEntityView(EntityType.Person);
		}
		else {
			await DatabaseApi.UpdateEntityView(EntityType.Undefined);
		}
	}
}
