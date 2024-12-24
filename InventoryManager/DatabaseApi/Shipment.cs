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
	public static async Task<BindingList<ShipmentView>> SelectShipmentViewBulk() {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"order_date",
				"supplier_id",
				"supplier_mersis_id",
				"supplier_name",
				"supplier_telephone_number",
				"supplier_address",
				"warehouse_id",
				"warehouse_name",
				"warehouse_telephone_number",
				"warehouse_address",
				"cost"
			FROM "public"."shipment_view";
			""");

		var list = new BindingList<ShipmentView>();
		using var reader = await command.ExecuteReaderAsync();
		while (await reader.ReadAsync()) {
			var data = new ShipmentView {
				Id = reader.GetInt32(0),
				OrderDate = reader.GetDateTime(1),
				SupplierId = reader.GetInt32(2),
				SupplierMersisId = reader.GetString(3),
				SupplierName = reader.GetString(4),
				SupplierTelephoneNumber = reader.GetString(5),
				SupplierAddress = reader.GetString(6),
				WarehouseId = reader.GetInt32(7),
				WarehouseName = reader.GetString(8),
				WarehouseTelephoneNumber = reader.GetString(9),
				WarehouseAddress = reader.GetString(10),
				Cost = reader.GetDecimal(11),
			};
			list.Add(data);
		}

		return list;
	}

	public static async Task<BindingList<ShipmentItemView>> SelectShipmentItemViewBulk() {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"shipment_id",
				"order_date",
				"item_id",
				"manufacturer_id",
				"manufacturer_name",
				"manufacturer_mersis_id",
				"barcode",
				"cost",
				"count"
			FROM "public"."shipment_item_view";
			""");

		var list = new BindingList<ShipmentItemView>();
		using var reader = await command.ExecuteReaderAsync();
		while (await reader.ReadAsync()) {
			var data = new ShipmentItemView {
				ShipmentId = reader.GetInt32(0),
				OrderDate = reader.GetDateTime(1),
				ItemId = reader.GetInt32(2),
				ManufacturerId = reader.GetInt32(3),
				ManufacturerName = reader.GetString(4),
				ManufacturerMersisId = reader.GetString(5),
				Barcode = reader.GetString(6),
				Cost = reader.GetDecimal(7),
				Count = reader.GetInt64(8),
			};
			list.Add(data);
		}

		return list;
	}

	public static async Task<ShipmentView> SelectShipmentView(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"order_date",
				"supplier_id",
				"supplier_mersis_id",
				"supplier_name",
				"supplier_telephone_number",
				"supplier_address",
				"warehouse_id",
				"warehouse_name",
				"warehouse_telephone_number",
				"warehouse_address",
				"cost"
			FROM "public"."shipment_view"
			WHERE 
				"id" = @id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new ShipmentView {
			Id = reader.GetInt32(0),
			OrderDate = reader.GetDateTime(1),
			SupplierId = reader.GetInt32(2),
			SupplierMersisId = reader.GetString(3),
			SupplierName = reader.GetString(4),
			SupplierTelephoneNumber = reader.GetString(5),
			SupplierAddress = reader.GetString(6),
			WarehouseId = reader.GetInt32(7),
			WarehouseName = reader.GetString(8),
			WarehouseTelephoneNumber = reader.GetString(9),
			WarehouseAddress = reader.GetString(10),
			Cost = reader.GetDecimal(11),
		};

		return data;
	}

	public static async Task<ShipmentItemView> SelectShipmentItemView(int receipt_id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"shipment_id",
				"order_date",
				"item_id",
				"manufacturer_id",
				"manufacturer_name",
				"manufacturer_mersis_id",
				"barcode",
				"cost",
				"count"
			FROM "public"."shipment_item_view"
			WHERE 
				"shipment_id" = @shipment_id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("shipment_id", receipt_id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new ShipmentItemView {
			ShipmentId = reader.GetInt32(0),
			OrderDate = reader.GetDateTime(1),
			ItemId = reader.GetInt32(2),
			ManufacturerId = reader.GetInt32(3),
			ManufacturerName = reader.GetString(4),
			ManufacturerMersisId = reader.GetString(5),
			Barcode = reader.GetString(6),
			Cost = reader.GetDecimal(7),
			Count = reader.GetInt64(8),
		};

		return data;
	}
	public static async Task<Shipment> SelectShipment(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"supplier_id",
				"warehouse_id",
				"order_date",
				"cost"
			FROM "public"."shipment"
			WHERE 
				"id" = @id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new Shipment {
			Id = reader.GetInt32(0),
			Supplier = await DatabaseApi.SelectCompanyView(reader.GetInt32(1)),
			Warehouse = await DatabaseApi.SelectWarehouseView(reader.GetInt32(2)),
			OrderDate = reader.GetDateTime(3),
			Cost = reader.GetDecimal(4),
		};

		return data;
	}
	public static async Task<ShipmentItem> SelectShipmentItem(int shipment_id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"shipment_id",
				"item_id",
				"count",
				"cost"
			FROM "public"."shipment_item"
			WHERE 
				"shipment_id" = @shipment_id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("shipment_id", shipment_id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new ShipmentItem {
			Shipment = await DatabaseApi.SelectShipmentView(reader.GetInt32(0)),
			Item = await DatabaseApi.SelectItemView(reader.GetInt32(1)),
			Count = reader.GetInt64(2),
			Cost = reader.GetDecimal(3),
		};

		return data;
	}
}

public record ShipmentView {
	[DisplayName("Sevkiyat No")] public required int Id { get; set; }
	[DisplayName("Sevkiyat Tarihi")] public required DateTime OrderDate { get; set; }
	[DisplayName("Sevkiyatçı Firma No")] public required int SupplierId { get; set; }
	[DisplayName("Sevkiyatçı Firma Adı")] public required string SupplierName { get; set; }
	[DisplayName("Sevkiyatçı Firma Mersis No")] public required string SupplierMersisId { get; set; }
	[DisplayName("Sevkiyatçı Firma Telefon Numarası")] public required string SupplierTelephoneNumber { get; set; }
	[DisplayName("Sevkiyatçı Firma Adresi")] public required string SupplierAddress { get; set; }
	[DisplayName("Depo No")] public required int WarehouseId { get; set; }
	[DisplayName("Depo Adı")] public required string WarehouseName { get; set; }
	[DisplayName("Depo Telefon Numarası")] public required string WarehouseTelephoneNumber { get; set; }
	[DisplayName("Depo Adresi")] public required string WarehouseAddress { get; set; }
	[DisplayName("Tutar")] public required decimal Cost { get; set; }
}
public record Shipment {
	public required int Id { get; set; }
	public required CompanyView Supplier { get; set; }
	public required WarehouseView Warehouse { get; set; }
	public required DateTime OrderDate { get; set; }
	public required decimal Cost { get; set; }
}

public record ShipmentItemView {
	[DisplayName("Sevkiyat No")] public required int ShipmentId { get; set; }
	[DisplayName("Sevkiyat Tarihi")] public required DateTime OrderDate { get; set; }
	[DisplayName("Kalem No")] public required int ItemId { get; set; }
	[DisplayName("İmalatçı Firma No")] public required int ManufacturerId { get; set; }
	[DisplayName("İmalatçı Firma Adı")] public required string ManufacturerName { get; set; }
	[DisplayName("İmalatçı Firma Mersis No")] public required string ManufacturerMersisId { get; set; }
	[DisplayName("Barkod")] public required string Barcode { get; set; }
	[DisplayName("Tutar")] public required decimal Cost { get; set; }
	[DisplayName("Adet")] public required long Count { get; set; }
}
public record ShipmentItem {
	public required ShipmentView Shipment { get; set; }
	public required ItemView Item { get; set; }
	public required long Count { get; set; }
	public required decimal Cost { get; set; }
}