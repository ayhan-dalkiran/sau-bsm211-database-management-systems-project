using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Npgsql;
using NpgsqlTypes;

namespace InventoryManager;
internal static partial class DatabaseApi {
	public static BindingSource ItemAllSource { get; } = new();
	public static BindingSource ItemOtherSource { get; } = new();
	public static BindingSource FoodSource { get; } = new();
	public static BindingSource ChemicalSource { get; } = new();
	public static BindingSource ReceiptSource { get; } = new();
	public static BindingSource ShipmentSource { get; } = new();
	public static BindingSource EntityAllSource { get; } = new();
	public static BindingSource CompanySource { get; } = new();
	public static BindingSource PersonSource { get; } = new();
	public static BindingSource EmployeeSource { get; } = new();
	public static BindingSource WorkplaceAllSource { get; } = new();
	public static BindingSource WarehouseSource { get; } = new();
	public static BindingSource OfficeSource { get; } = new();

	public static NpgsqlDataSourceBuilder Builder { get; } = new("""
		Host=localhost;
		Username=postgres;
		Password=admin;
		Database=Proje;
		Max Auto Prepare=30;
		Include Error Detail=true;
		""");
	static DatabaseApi() {
		Builder.MapEnum<ItemType>("item_type");
		Builder.MapEnum<EntityType>("entity_type");
		Builder.MapEnum<WorkplaceType>("workplace_type");
	}

	public static async Task UpdateViewBulk() {
		ItemAllSource.DataSource =  await DatabaseApi.SelectItemAllViewBulk();
		ItemOtherSource.DataSource = await DatabaseApi.SelectItemOtherViewBulk();
		FoodSource.DataSource = await DatabaseApi.SelectFoodViewBulk();
		ChemicalSource.DataSource = await DatabaseApi.SelectChemicalViewBulk();
		ReceiptSource.DataSource = await DatabaseApi.SelectReceiptViewBulk();
		ShipmentSource.DataSource = await DatabaseApi.SelectShipmentViewBulk();
		EntityAllSource.DataSource = await DatabaseApi.SelectEntityAllViewBulk();
		CompanySource.DataSource = await DatabaseApi.SelectCompanyViewBulk();
		PersonSource.DataSource = await DatabaseApi.SelectPersonViewBulk();
		EmployeeSource.DataSource = await DatabaseApi.SelectEmployeeViewBulk();
		WorkplaceAllSource.DataSource = await DatabaseApi.SelectWorkplaceViewBulk();
		WarehouseSource.DataSource = await DatabaseApi.SelectWarehouseViewBulk();
		OfficeSource.DataSource = await DatabaseApi.SelectOfficeViewBulk();
	}
}
