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
	public static async Task<BindingList<ReceiptView>> SelectReceiptViewBulk() {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"order_date",
				"e_archive_receipt_id",
				"customer_id",
				"customer_name",
				"customer_telephone_number",
				"customer_address",
				"cost"
			FROM "public"."receipt_view";
			""");

		var list = new BindingList<ReceiptView>();
		using var reader = await command.ExecuteReaderAsync();
		while (await reader.ReadAsync()) {
			var data = new ReceiptView {
				Id = reader.GetInt32(0),
				OrderDate = reader.GetDateTime(1),
				EArchiveReceiptId = reader.GetString(2),
				CustomerId = reader.GetInt32(3),
				CustomerName = reader.GetString(4),
				CustomerTelephoneNumber = reader.GetString(5),
				CustomerAddress = reader.GetString(6),
				Cost = reader.GetDecimal(7),
			};
			list.Add(data);
		}

		return list;
	}
	public static async Task<BindingList<ReceiptItemView>> SelectReceiptItemViewBulk() {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"receipt_id",
				"order_date",
				"e_archive_receipt_id",
				"item_id",
				"manufacturer_id",
				"manufacturer_name",
				"manufacturer_mersis_id",
				"barcode",
				"cost",
				"count"
			FROM "public"."receipt_item_view";
			""");

		var list = new BindingList<ReceiptItemView>();
		using var reader = await command.ExecuteReaderAsync();
		while (await reader.ReadAsync()) {
			var data = new ReceiptItemView {
				ReceiptId = reader.GetInt32(0),
				OrderDate = reader.GetDateTime(1),
				EArchiveReceiptId = reader.GetString(2),
				ItemId = reader.GetInt32(3),
				ManufacturerId = reader.GetInt32(4),
				ManufacturerName = reader.GetString(5),
				ManufacturerMersisId = reader.GetString(6),
				Barcode = reader.GetString(7),
				Cost = reader.GetDecimal(8),
				Count = reader.GetInt64(9),
			};
			list.Add(data);
		}

		return list;
	}

	public static async Task<ReceiptView> SelectReceiptView(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"order_date",
				"e_archive_receipt_id",
				"customer_id",
				"customer_name",
				"customer_telephone_number",
				"customer_address",
				"cost"
			FROM "public"."receipt_view"
			WHERE 
				"id" = @id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new ReceiptView {
			Id = reader.GetInt32(0),
			OrderDate = reader.GetDateTime(1),
			EArchiveReceiptId = reader.GetString(2),
			CustomerId = reader.GetInt32(3),
			CustomerName = reader.GetString(4),
			CustomerTelephoneNumber = reader.GetString(5),
			CustomerAddress = reader.GetString(6),
			Cost = reader.GetDecimal(7),
		};

		return data;
	}
	public static async Task<ReceiptItemView> SelectReceiptItemView(int receipt_id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"receipt_id",
				"order_date",
				"e_archive_receipt_id",
				"item_id",
				"manufacturer_id",
				"manufacturer_name",
				"manufacturer_mersis_id",
				"barcode",
				"cost",
				"count"
			FROM "public"."receipt_item_view"
			WHERE 
				"receipt_id" = @receipt_id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("receipt_id", receipt_id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new ReceiptItemView {
			ReceiptId = reader.GetInt32(0),
			OrderDate = reader.GetDateTime(1),
			EArchiveReceiptId = reader.GetString(2),
			ItemId = reader.GetInt32(3),
			ManufacturerId = reader.GetInt32(4),
			ManufacturerName = reader.GetString(5),
			ManufacturerMersisId = reader.GetString(6),
			Barcode = reader.GetString(7),
			Cost = reader.GetDecimal(8),
			Count = reader.GetInt64(9),
		};

		return data;
	}

	public static async Task<Receipt> SelectReceipt(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"id",
				"customer_id",
				"e_archive_receipt_id",
				"cost",
				"order_date"
			FROM "public"."receipt"
			WHERE 
				"id" = @id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new Receipt {
			Id = reader.GetInt32(0),
			Customer = await DatabaseApi.SelectEntityView(reader.GetInt32(1)),
			EArchiveReceiptId = reader.GetString(2),
			Cost = reader.GetDecimal(3),
			OrderDate = reader.GetDateTime(4),
		};

		return data;
	}
	public static async Task<ReceiptItem> SelectReceiptItem(int receipt_id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"receipt_id",
				"item_id",
				"count",
				"cost"
			FROM "public"."receipt_item"
			WHERE 
				"receipt_id" = @receipt_id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("receipt_id", receipt_id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new ReceiptItem {
			Receipt = await DatabaseApi.SelectReceiptView(reader.GetInt32(0)),
			Item = await DatabaseApi.SelectItemView(reader.GetInt32(1)),
			Count = reader.GetInt64(2),
			Cost= reader.GetDecimal(3),
		};

		return data;
	}

	public static async Task InsertReceipt(Receipt data) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			INSERT INTO "public"."receipt"("customer_id", "e_archive_receipt_id", "order_date") 
			VALUES (@customer_id, @e_archive_receipt_id, @order_date);
			""");

		command.Parameters.Add(new NpgsqlParameter<int>("customer_id", data.Customer.Id));
		command.Parameters.Add(new NpgsqlParameter<string>("e_archive_receipt_id", data.EArchiveReceiptId));
		command.Parameters.Add(new NpgsqlParameter<DateTime>("order_date", data.OrderDate));
		command.ExecuteNonQuery();
	}
	public static async Task InsertReceiptItem(ReceiptItem data) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			INSERT INTO "public"."receipt_item" ("receipt_id", "item_id", "count", "cost") 
			VALUES (@receipt_id, @item_id, @count, @cost);
			""");

		command.Parameters.Add(new NpgsqlParameter<int>("receipt_id", data.Receipt.Id));
		command.Parameters.Add(new NpgsqlParameter<int>("item_id", data.Item.Id));
		command.Parameters.Add(new NpgsqlParameter<long>("count", data.Count));
		command.Parameters.Add(new NpgsqlParameter<decimal>("cost", data.Cost));
		command.ExecuteNonQuery();
	}

	public static async Task UpdateReceipt(Receipt data) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			UPDATE "public"."receipt" SET
				       "customer_id" = @customer_id,
				"e_archive_receipt_id" = @e_archive_receipt_id,
				        "order_date" = @order_date
			WHERE
				                "id" = @id;
			""");

		command.Parameters.Add(new NpgsqlParameter<int>("id", data.Id));
		command.Parameters.Add(new NpgsqlParameter<int>("customer_id", data.Customer.Id));
		command.Parameters.Add(new NpgsqlParameter<string>("e_archive_receipt_id", data.EArchiveReceiptId));
		command.Parameters.Add(new NpgsqlParameter<DateTime>("order_date", data.OrderDate));
		command.ExecuteNonQuery();
	}
	public static async Task UpdateReceiptItem(ReceiptItem data) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			UPDATE "public"."receiptItem" SET
				       "count" = @count,
				"cost" = @cost,
			WHERE
				                "receipt_id" = @receipt_id;
			""");

		command.Parameters.Add(new NpgsqlParameter<int>("receipt_id", data.Receipt.Id));
		command.Parameters.Add(new NpgsqlParameter<long>("count", data.Count));
		command.Parameters.Add(new NpgsqlParameter<decimal>("cost", data.Cost));
		command.ExecuteNonQuery();
	}

	public static async Task DeleteEmployeeBulk(List<int> list) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			DELETE FROM "public"."employee" WHERE "person_id" = ANY(@list)
			""");
		command.Parameters.Add(new NpgsqlParameter<List<int>>("list", list));
		command.ExecuteNonQuery();
	}
}

public record ReceiptView {
	[DisplayName("Fatura No")] public required int Id { get; set; }
	[DisplayName("Sipariş Tarihi")] public required DateTime OrderDate { get; set; }
	[DisplayName("e-Arşiv Fatura No")] public required string EArchiveReceiptId { get; set; }
	[DisplayName("Müşteri No")] public required int CustomerId { get; set; }
	[DisplayName("Müşteri İsmi")] public required string CustomerName { get; set; }
	[DisplayName("Müşteri Telefon Numarası")] public required string CustomerTelephoneNumber { get; set; }
	[DisplayName("Müşteri Adresi")] public required string CustomerAddress { get; set; }
	[DisplayName("Tutar")] public required decimal Cost { get; set; }
}
public record Receipt {
	public required int Id { get; set; }
	public required EntityView Customer { get; set; }
	public required string EArchiveReceiptId { get; set; }
	public required decimal Cost { get; set; }  
	public required DateTime OrderDate { get; set; }
}

public record ReceiptItemView {
	[DisplayName("Fatura No")] public required int ReceiptId { get; set; }
	[DisplayName("Sipariş Tarihi")] public required DateTime OrderDate { get; set; }
	[DisplayName("e-Arşiv Fatura No")] public required string EArchiveReceiptId { get; set; }
	[DisplayName("Kalem No")] public required int ItemId { get; set; }
	[DisplayName("İmalatçı Firma No")] public required int ManufacturerId { get; set; }
	[DisplayName("İmalatçı Firma Adı")] public required string ManufacturerName { get; set; }
	[DisplayName("İmalatçı Firma Mersis No")] public required string ManufacturerMersisId { get; set; }
	[DisplayName("Barkod")] public required string Barcode { get; set; }
	[DisplayName("Tutar")] public required decimal Cost { get; set; }
	[DisplayName("Adet")] public required long Count { get; set; }
}
public record ReceiptItem {
	public required ReceiptView Receipt { get; set; }
	public required ItemView Item { get; set; }
	public required long Count { get; set; }
	public required decimal Cost { get; set; }
}