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
	public static BindingSource ItemView { get; } = new();
	public static BindingSource ReceiptView { get; } = new();
	public static BindingSource ShipmentView { get; } = new();
	public static BindingSource EntityView { get; } = new();
	public static BindingSource EmployeeView { get; } = new();
	public static BindingSource WorkplaceView { get; } = new();

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
		await DatabaseApi.UpdateItemView();
		//DatabaseApi.UpdateReceiptView();
		//DatabaseApi.UpdateShipmentView();
		await DatabaseApi.UpdateEntityView();
		//DatabaseApi.UpdateEmployeeView();
		//DatabaseApi.UpdateWorkplaceView();
	}
}
