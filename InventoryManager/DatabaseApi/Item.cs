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
using static InventoryManager.DatabaseApi;

namespace InventoryManager;
internal static partial class DatabaseApi {
	public static async Task<BindingList<ItemView>> SelectItemViewBulk() {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT "id", "item_name", "manufacturer_id", "manufacturer_mersis_id",
			"manufacturer_name", "barcode", "count", "item_type", "thumbnail_blob_base64"
			FROM "public"."item_view"
			""");

		var list = new BindingList<ItemView>();
		using var reader = await command.ExecuteReaderAsync();
		while (await reader.ReadAsync()) {
			byte[]? thumbnailBlob = await reader.IsDBNullAsync(8) ? null : Convert.FromBase64String(reader.GetString(8));
			Bitmap? thumbnail = null;
			if (thumbnailBlob is not null) {
				using var ms = new MemoryStream(thumbnailBlob);
				thumbnail = new(ms);
			}
			var data = new ItemView {
				Id = reader.GetInt32(0),
				ItemName = reader.GetString(1),
				ManufacturerId = reader.GetInt32(2),
				ManufacturerMersisId = reader.GetInt32(3),
				ManufacturerName = reader.GetString(4),
				Barcode = reader.GetString(5),
				Count = reader.GetInt64(6),
				ItemType = await reader.GetFieldValueAsync<ItemType>(7),
				ThumbnailBlob = thumbnail,
			};
			list.Add(data);
		}

		return list;
	}
	public static async Task<BindingList<FoodView>> SelectFoodViewBulk() {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT "id", "item_name", "manufacturer_id", "manufacturer_mersis_id",
			"manufacturer_name", "barcode", "count", "thumbnail_blob_base64", "energy",
			"fat", "saturated_fat", "carbonhydrate", "sugar", "protein", "salt"
			FROM "public"."food_view"
			""");

		var list = new BindingList<FoodView>();
		using var reader = await command.ExecuteReaderAsync();
		while (await reader.ReadAsync()) {
			byte[]? thumbnailBlob = await reader.IsDBNullAsync(8) ? null : Convert.FromBase64String(reader.GetString(8));
			Bitmap? thumbnail = null;
			if (thumbnailBlob is not null) {
				using var ms = new MemoryStream(thumbnailBlob);
				thumbnail = new(ms);
			}
			var data = new FoodView {
				Id = reader.GetInt32(0),
				ItemName = reader.GetString(1),
				ManufacturerId = reader.GetInt32(2),
				ManufacturerMersisId = reader.GetInt32(3),
				ManufacturerName = reader.GetString(4),
				Barcode = reader.GetString(5),
				Count = reader.GetInt64(6),
				ThumbnailBlob = thumbnail,
				Energy = reader.GetDecimal(8),
				Fat = reader.GetDecimal(9),
				SaturatedFat = reader.GetDecimal(10),
				Carbonhydrate = reader.GetDecimal(11),
				Sugar = reader.GetDecimal(12),
				Protein = reader.GetDecimal(13),
				Salt = reader.GetDecimal(14),
			};
			list.Add(data);
		}

		return list;
	}
	public static async Task<BindingList<ChemicalView>> SelectChemicalViewBulk() {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT "id", "item_name", "manufacturer_id", "manufacturer_mersis_id",
			"manufacturer_name", "barcode", "count", "thumbnail_blob_base64",
			"explosive", "flammable", "oxidizing", "compressed_gas", "corrosive", "toxic",
			"health_hazard", "serious_health_hazard", "environment_hazard", "infectious",
			"radioactive"
			FROM "public"."chemical_view"
			""");

		var list = new BindingList<ChemicalView>();
		using var reader = await command.ExecuteReaderAsync();
		while (await reader.ReadAsync()) {
			byte[]? thumbnailBlob = await reader.IsDBNullAsync(8) ? null : Convert.FromBase64String(reader.GetString(8));
			Bitmap? thumbnail = null;
			if (thumbnailBlob is not null) {
				using var ms = new MemoryStream(thumbnailBlob);
				thumbnail = new(ms);
			}
			var data = new ChemicalView {
				Id = reader.GetInt32(0),
				ItemName = reader.GetString(1),
				ManufacturerId = reader.GetInt32(2),
				ManufacturerMersisId = reader.GetInt32(3),
				ManufacturerName = reader.GetString(4),
				Barcode = reader.GetString(5),
				Count = reader.GetInt64(6),
				ThumbnailBlob = thumbnail,
				Explosive = reader.GetBoolean(8),
				Flammable = reader.GetBoolean(9),
				Oxidizing = reader.GetBoolean(10),
				CompressedGas = reader.GetBoolean(11),
				Corrosive = reader.GetBoolean(12),
				Toxic = reader.GetBoolean(13),
				HealthHazard = reader.GetBoolean(14),
				SeriousHealthHazard = reader.GetBoolean(15),
				EnvironmentHazard = reader.GetBoolean(16),
				Infectious = reader.GetBoolean(17),
				Radioactive = reader.GetBoolean(18),
			};
			list.Add(data);
		}

		return list;
	}

	public static async Task<ItemView> SelectItemView(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT "id", "item_name", "manufacturer_id", "manufacturer_mersis_id",
			"manufacturer_name", "barcode", "count", "item_type", "thumbnail_blob_base64"
			FROM "public"."item_view"
			WHERE "id" = @id
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		using var reader = await command.ExecuteReaderAsync();
		byte[]? thumbnailBlob = await reader.IsDBNullAsync(8) ? null : Convert.FromBase64String(reader.GetString(8));
		Bitmap? thumbnail = null;
		if (thumbnailBlob is not null) {
			using var ms = new MemoryStream(thumbnailBlob);
			thumbnail = new(ms);
		}
		var data = new ItemView {
			Id = reader.GetInt32(0),
			ItemName = reader.GetString(1),
			ManufacturerId = reader.GetInt32(2),
			ManufacturerMersisId = reader.GetInt32(3),
			ManufacturerName = reader.GetString(4),
			Barcode = reader.GetString(5),
			Count = reader.GetInt64(6),
			ItemType = await reader.GetFieldValueAsync<ItemType>(7),
			ThumbnailBlob = thumbnail,
		};

		return data;
	}
	public static async Task<FoodView> SelectFoodView(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT "id", "item_name", "manufacturer_id", "manufacturer_mersis_id",
			"manufacturer_name", "barcode", "count", "thumbnail_blob_base64", "energy",
			"fat", "saturated_fat", "carbonhydrate", "sugar", "protein", "salt"
			FROM "public"."food_view"
			WHERE "id" = @id
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		using var reader = await command.ExecuteReaderAsync();
		byte[]? thumbnailBlob = await reader.IsDBNullAsync(7) ? null : Convert.FromBase64String(reader.GetString(7));
		Bitmap? thumbnail = null;
		if (thumbnailBlob is not null) {
			using var ms = new MemoryStream(thumbnailBlob);
			thumbnail = new(ms);
		}
		var data = new FoodView {
			Id = reader.GetInt32(0),
			ItemName = reader.GetString(1),
			ManufacturerId = reader.GetInt32(2),
			ManufacturerMersisId = reader.GetInt32(3),
			ManufacturerName = reader.GetString(4),
			Barcode = reader.GetString(5),
			Count = reader.GetInt64(6),
			ThumbnailBlob = thumbnail,
			Energy = reader.GetDecimal(8),
			Fat = reader.GetDecimal(9),
			SaturatedFat = reader.GetDecimal(10),
			Carbonhydrate = reader.GetDecimal(11),
			Sugar = reader.GetDecimal(12),
			Protein = reader.GetDecimal(13),
			Salt = reader.GetDecimal(14),
		};

		return data;
	}
	public static async Task<ChemicalView> SelectChemicalView(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT "id", "item_name", "manufacturer_id", "manufacturer_mersis_id",
			"manufacturer_name", "barcode", "count", "thumbnail_blob_base64",
			"explosive", "flammable", "oxidizing", "compressed_gas", "corrosive", "toxic",
			"health_hazard", "serious_health_hazard", "environment_hazard", "infectious",
			"radioactive"
			FROM "public"."chemical_view"
			WHERE "id" = @id
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		var list = new BindingList<ChemicalView>();
		using var reader = await command.ExecuteReaderAsync();
		byte[]? thumbnailBlob = await reader.IsDBNullAsync(8) ? null : Convert.FromBase64String(reader.GetString(8));
		Bitmap? thumbnail = null;
		if (thumbnailBlob is not null) {
			using var ms = new MemoryStream(thumbnailBlob);
			thumbnail = new(ms);
		}
		var data = new ChemicalView {
			Id = reader.GetInt32(0),
			ItemName = reader.GetString(1),
			ManufacturerId = reader.GetInt32(2),
			ManufacturerMersisId = reader.GetInt32(3),
			ManufacturerName = reader.GetString(4),
			Barcode = reader.GetString(5),
			Count = reader.GetInt64(6),
			ThumbnailBlob = thumbnail,
			Explosive = reader.GetBoolean(8),
			Flammable = reader.GetBoolean(9),
			Oxidizing = reader.GetBoolean(10),
			CompressedGas = reader.GetBoolean(11),
			Corrosive = reader.GetBoolean(12),
			Toxic = reader.GetBoolean(13),
			HealthHazard = reader.GetBoolean(14),
			SeriousHealthHazard = reader.GetBoolean(15),
			EnvironmentHazard = reader.GetBoolean(16),
			Infectious = reader.GetBoolean(17),
			Radioactive = reader.GetBoolean(18),
		};

		return data;
	}

	public static async Task<Item> SelectItem(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT "id", "item_name", "manufacturer_id", "barcode", "count", "item_type"
			FROM "public"."item"
			WHERE "id" = @id
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		using var reader = await command.ExecuteReaderAsync();
		var data = new Item {
			Id = reader.GetInt32(0),
			ItemName = reader.GetString(1),
			Manufacturer = await DatabaseApi.SelectCompanyView(reader.GetInt32(2)),
			Barcode = reader.GetString(3),
			Count = reader.GetInt64(4),
			ItemType = await reader.GetFieldValueAsync<ItemType>(5),
		};

		return data;
	}
	public static async Task<Food> SelectFood(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT "id", "item_name", "manufacturer_id", "barcode", "count", "energy",
			"fat", "saturated_fat", "carbonhydrate", "sugar", "protein", "salt"
			FROM "public"."food_view"
			WHERE "id" = @id
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		using var reader = await command.ExecuteReaderAsync();
		var data = new Food {
			Id = reader.GetInt32(0),
			ItemName = reader.GetString(1),
			Manufacturer = await DatabaseApi.SelectCompanyView(reader.GetInt32(2)),
			Barcode = reader.GetString(3),
			Count = reader.GetInt64(4),
			ItemType = ItemType.Food,
			Energy = reader.GetDecimal(5),
			Fat = reader.GetDecimal(6),
			SaturatedFat = reader.GetDecimal(7),
			Carbonhydrate = reader.GetDecimal(8),
			Sugar = reader.GetDecimal(9),
			Protein = reader.GetDecimal(10),
			Salt = reader.GetDecimal(11),
		};

		return data;
	}
	public static async Task<Chemical> SelectChemical(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT "id", "item_name", "manufacturer_id", "barcode", "count",
			"explosive", "flammable", "oxidizing", "compressed_gas", "corrosive", "toxic",
			"health_hazard", "serious_health_hazard", "environment_hazard", "infectious",
			"radioactive"
			FROM "public"."chemical_view"
			WHERE "id" = @id
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", id));

		var list = new BindingList<ChemicalView>();
		using var reader = await command.ExecuteReaderAsync();
		var data = new Chemical {
			Id = reader.GetInt32(0),
			ItemName = reader.GetString(1),
			Manufacturer = await DatabaseApi.SelectCompanyView(reader.GetInt32(2)),
			Barcode = reader.GetString(3),
			Count = reader.GetInt64(4),
			ItemType = ItemType.Chemical,
			Explosive = reader.GetBoolean(5),
			Flammable = reader.GetBoolean(6),
			Oxidizing = reader.GetBoolean(7),
			CompressedGas = reader.GetBoolean(8),
			Corrosive = reader.GetBoolean(9),
			Toxic = reader.GetBoolean(10),
			HealthHazard = reader.GetBoolean(11),
			SeriousHealthHazard = reader.GetBoolean(12),
			EnvironmentHazard = reader.GetBoolean(13),
			Infectious = reader.GetBoolean(14),
			Radioactive = reader.GetBoolean(15),
		};

		return data;
	}

	public static async Task InsertItem(Item data) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			INSERT INTO "public"."item"("item_name", "manufacturer_id", "barcode", "item_type") 
			VALUES(@item_name, @manufacturer_id, @barcode, @item_type)
			""");
		command.Parameters.Add(new NpgsqlParameter<string>("item_name", data.ItemName));
		command.Parameters.Add(new NpgsqlParameter<int>("manufacturer_id", data.Manufacturer.EntityId));
		command.Parameters.Add(new NpgsqlParameter<string>("barcode", data.Barcode));
		command.Parameters.Add(new NpgsqlParameter<ItemType>("item_type", data.ItemType));
		command.ExecuteNonQuery();
	}
	public static async Task InsertFood(Food data) {
		await using var dataSource = Builder.Build();
		await using var batch = dataSource.CreateBatch();
		var command1 = batch.CreateBatchCommand();
		command1.CommandText = """
			INSERT INTO "public"."item"("item_name", "manufacturer_id", "barcode", "item_type") 
			VALUES(@item_name, @manufacturer_id, @barcode, @item_type)
			""";
		command1.Parameters.Add(new NpgsqlParameter<string>("item_name", data.ItemName));
		command1.Parameters.Add(new NpgsqlParameter<int>("manufacturer_id", data.Manufacturer.EntityId));
		command1.Parameters.Add(new NpgsqlParameter<string>("barcode", data.Barcode));
		command1.Parameters.Add(new NpgsqlParameter<ItemType>("item_type", ItemType.Food));
		var command2 = batch.CreateBatchCommand();
		command2.CommandText = """
			INSERT INTO "public"."food"("item_id", "energy", "fat", "saturated_fat", "carbonhydrate",
			"sugar", "protein", "salt") 
			VALUES(@item_id, @energy, @fat, @saturated_fat, @carbonhydrate, @sugar, @protein, @salt)
			""";
		command2.Parameters.Add(new NpgsqlParameter<int>("entity_id", data.Id));
		command2.Parameters.Add(new NpgsqlParameter<decimal>("energy", data.Energy));
		command2.Parameters.Add(new NpgsqlParameter<decimal>("fat", data.Fat));
		command2.Parameters.Add(new NpgsqlParameter<decimal>("saturated_fat", data.SaturatedFat));
		command2.Parameters.Add(new NpgsqlParameter<decimal>("carbonhydrate", data.Carbonhydrate));
		command2.Parameters.Add(new NpgsqlParameter<decimal>("sugar", data.Sugar));
		command2.Parameters.Add(new NpgsqlParameter<decimal>("protein", data.Protein));
		command2.Parameters.Add(new NpgsqlParameter<decimal>("salt", data.Salt));
		await batch.ExecuteNonQueryAsync();
	}
	public static async Task InsertChemical(Chemical data) {
		await using var dataSource = Builder.Build();
		await using var batch = dataSource.CreateBatch();
		var command1 = batch.CreateBatchCommand();
		command1.CommandText = """
			INSERT INTO "public"."item"("item_name", "manufacturer_id", "barcode", "item_type") 
			VALUES(@item_name, @manufacturer_id, @barcode, @item_type)
			""";
		command1.Parameters.Add(new NpgsqlParameter<string>("item_name", data.ItemName));
		command1.Parameters.Add(new NpgsqlParameter<int>("manufacturer_id", data.Manufacturer.EntityId));
		command1.Parameters.Add(new NpgsqlParameter<string>("barcode", data.Barcode));
		command1.Parameters.Add(new NpgsqlParameter<ItemType>("item_type", ItemType.Chemical));
		var command2 = batch.CreateBatchCommand();
		command2.CommandText = """
			INSERT INTO "public"."chemical"("item_id", "explosive", "flammable", "oxidizing", "compressed_gas",
			"corrosive", "toxic", "health_hazard", "serious_health_hazard", "environment_hazard", "infectious",
			"radioactive") 
			VALUES(@item_id, @explosive, @flammable, @oxidizing, @compressed_gas, @corrosive, @toxic,
			@health_hazard, @serious_health_hazard, @environment_hazard, @infectious, @radioactive)
			""";
		command2.Parameters.Add(new NpgsqlParameter<int>("entity_id", data.Id));
		command2.Parameters.Add(new NpgsqlParameter<bool>("explosive", data.Explosive));
		command2.Parameters.Add(new NpgsqlParameter<bool>("flammable", data.Flammable));
		command2.Parameters.Add(new NpgsqlParameter<bool>("oxidizing", data.Oxidizing));
		command2.Parameters.Add(new NpgsqlParameter<bool>("compressed_gas", data.CompressedGas));
		command2.Parameters.Add(new NpgsqlParameter<bool>("corrosive", data.Corrosive));
		command2.Parameters.Add(new NpgsqlParameter<bool>("toxic", data.Toxic));
		command2.Parameters.Add(new NpgsqlParameter<bool>("health_hazard", data.HealthHazard));
		command2.Parameters.Add(new NpgsqlParameter<bool>("serious_health_hazard", data.SeriousHealthHazard));
		command2.Parameters.Add(new NpgsqlParameter<bool>("environment_hazard", data.EnvironmentHazard));
		command2.Parameters.Add(new NpgsqlParameter<bool>("infectious", data.Infectious));
		command2.Parameters.Add(new NpgsqlParameter<bool>("radioactive", data.Radioactive));
		await batch.ExecuteNonQueryAsync();
	}

	public static async Task UpdateItem(Item data) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			UPDATE "public"."item"
			SET
				"item_name" = @item_name,
				"manufacturer_id" = @manufacturer_id,
				"barcode" = @barcode
			WHERE "id" = @id
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("id", data.Id));
		command.Parameters.Add(new NpgsqlParameter<string>("item_name", data.ItemName));
		command.Parameters.Add(new NpgsqlParameter<int>("manufacturer_id", data.Manufacturer.EntityId));
		command.Parameters.Add(new NpgsqlParameter<string>("barcode", data.Barcode));
		command.ExecuteNonQuery();
	}
	public static async Task UpdateFood(Food data) {
		await using var dataSource = Builder.Build();
		await using var batch = dataSource.CreateBatch();
		var command1 = batch.CreateBatchCommand();
		command1.CommandText = """
			UPDATE "public"."item"
			SET
				"item_name" = @item_name,
				"manufacturer_id" = @manufacturer_id,
				"barcode" = @barcode
			WHERE "id" = @id
			""";
		command1.Parameters.Add(new NpgsqlParameter<int>("id", data.Id));
		command1.Parameters.Add(new NpgsqlParameter<string>("item_name", data.ItemName));
		command1.Parameters.Add(new NpgsqlParameter<int>("manufacturer_id", data.Manufacturer.EntityId));
		command1.Parameters.Add(new NpgsqlParameter<string>("barcode", data.Barcode));
		var command2 = batch.CreateBatchCommand();
		command2.CommandText = """
			UPDATE "public"."food"
			SET
				"energy" = @energy,
				"fat" = @fat,
				"saturated_fat" = @saturated_fat,
				"carbonhydrate" = @carbonhydrate,
				"sugar" = @sugar,
				"protein" = @protein,
				"salt" = @salt
			WHERE "item_id" = @item_id
			""";
		command2.Parameters.Add(new NpgsqlParameter<int>("item_id", data.Id));
		command2.Parameters.Add(new NpgsqlParameter<decimal>("energy", data.Energy));
		command2.Parameters.Add(new NpgsqlParameter<decimal>("fat", data.Fat));
		command2.Parameters.Add(new NpgsqlParameter<decimal>("saturated_fat", data.SaturatedFat));
		command2.Parameters.Add(new NpgsqlParameter<decimal>("carbonhydrate", data.Carbonhydrate));
		command2.Parameters.Add(new NpgsqlParameter<decimal>("sugar", data.Sugar));
		command2.Parameters.Add(new NpgsqlParameter<decimal>("protein", data.Protein));
		command2.Parameters.Add(new NpgsqlParameter<decimal>("salt", data.Salt));
		await batch.ExecuteNonQueryAsync();
	}
	public static async Task UpdateChemical(Chemical data) {
		await using var dataSource = Builder.Build();
		await using var batch = dataSource.CreateBatch();
		var command1 = batch.CreateBatchCommand();
		command1.CommandText = """
			UPDATE "public"."item"
			SET
				"item_name" = @item_name,
				"manufacturer_id" = @manufacturer_id,
				"barcode" = @barcode
			WHERE "id" = @id
			""";
		command1.Parameters.Add(new NpgsqlParameter<int>("id", data.Id));
		command1.Parameters.Add(new NpgsqlParameter<string>("item_name", data.ItemName));
		command1.Parameters.Add(new NpgsqlParameter<int>("manufacturer_id", data.Manufacturer.EntityId));
		command1.Parameters.Add(new NpgsqlParameter<string>("barcode", data.Barcode));
		var command2 = batch.CreateBatchCommand();
		command2.CommandText = """
			UPDATE "public"."chemical"
			SET
				"explosive" = @explosive,
				"flammable" = @flammable,
				"oxidizing" = @oxidizing,
				"compressed_gas" = @compressed_gas,
				"corrosive" = @corrosive,
				"toxic" = @toxic,
				"health_hazard" = @health_hazard,
				"serious_health_hazard" = @serious_health_hazard,
				"environment_hazard" = @environment_hazard,
				"infectious" = @infectious,
				"radioactive" = @radioactive
			WHERE "item_id" = @item_id
			""";
		command2.Parameters.Add(new NpgsqlParameter<int>("item_id", data.Id));
		command2.Parameters.Add(new NpgsqlParameter<bool>("explosive", data.Explosive));
		command2.Parameters.Add(new NpgsqlParameter<bool>("flammable", data.Flammable));
		command2.Parameters.Add(new NpgsqlParameter<bool>("oxidizing", data.Oxidizing));
		command2.Parameters.Add(new NpgsqlParameter<bool>("compressed_gas", data.CompressedGas));
		command2.Parameters.Add(new NpgsqlParameter<bool>("corrosive", data.Corrosive));
		command2.Parameters.Add(new NpgsqlParameter<bool>("toxic", data.Toxic));
		command2.Parameters.Add(new NpgsqlParameter<bool>("health_hazard", data.HealthHazard));
		command2.Parameters.Add(new NpgsqlParameter<bool>("serious_health_hazard", data.SeriousHealthHazard));
		command2.Parameters.Add(new NpgsqlParameter<bool>("environment_hazard", data.EnvironmentHazard));
		command2.Parameters.Add(new NpgsqlParameter<bool>("infectious", data.Infectious));
		command2.Parameters.Add(new NpgsqlParameter<bool>("radioactive", data.Radioactive));
		await batch.ExecuteNonQueryAsync();
	}

	public static async Task DeleteItemBulk(List<int> list) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			DELETE FROM "public"."item" WHERE "id" = ANY(@list)
			""");
		command.Parameters.Add(new NpgsqlParameter<List<int>>("list", list));
		command.ExecuteNonQuery();
	}
}

public enum ItemType : int {
	[PgName("other")] Other = 0,
	[PgName("food")] Food = 1,
	[PgName("chemical")] Chemical = 2,
}

public record ItemView {
	[DisplayName("Kalem No")] public required int Id { get; set; }
	[DisplayName("Kalem Adı")] public required string ItemName { get; set; }
	[DisplayName("İmalatçı Firma No")] public required int ManufacturerId { get; set; }
	[DisplayName("İmalatçı Firma Mersis No")] public required int ManufacturerMersisId { get; set; }
	[DisplayName("İmalatçı Firma Adı")] public required string ManufacturerName { get; set; }
	[DisplayName("Barkod")] public required string Barcode { get; set; }
	[DisplayName("Count")] public required long Count { get; set; }
	[Browsable(false)] public required ItemType ItemType { get; set; }
	[DisplayName("Kalem Tipi")] public string ItemTypeString => this.ItemType switch {
		ItemType.Other => "Diğer",
		ItemType.Food => "Gıda",
		ItemType.Chemical => "Kimyasal",
		_ => throw new InvalidEnumArgumentException(),
	};
	[DisplayName("Önizleme")] public required Bitmap? ThumbnailBlob { get; set; }
}
public record Item {
	public required int Id { get; set; }
	public required string ItemName { get; set; }
	public required CompanyView Manufacturer { get; set; }
	public required string Barcode { get; set; }
	public required long Count { get; set; }
	public required ItemType ItemType { get; set; }
}

public record FoodView {
	[DisplayName("Kalem No")] public required int Id { get; set; }
	[DisplayName("Kalem Adı")] public required string ItemName { get; set; }
	[DisplayName("İmalatçı Firma No")] public required int ManufacturerId { get; set; }
	[DisplayName("İmalatçı Firma Mersis No")] public required int ManufacturerMersisId { get; set; }
	[DisplayName("İmalatçı Firma Adı")] public required string ManufacturerName { get; set; }
	[DisplayName("Barkod")] public required string Barcode { get; set; }
	[DisplayName("Count")] public required long Count { get; set; }
	[DisplayName("Önizleme")] public required Bitmap? ThumbnailBlob { get; set; }
	[DisplayName("Enerji (kcal/100g)")] public required decimal Energy { get; set; }
	[DisplayName("Yağ (g/100g)")] public required decimal Fat { get; set; }
	[DisplayName("Doymuş Yağ (g/100g)")] public required decimal SaturatedFat { get; set; }
	[DisplayName("Karbonhidrat (g/100g)")] public required decimal Carbonhydrate { get; set; }
	[DisplayName("Şekerler (g/100g)")] public required decimal Sugar { get; set; }
	[DisplayName("Protein (g/100g)")] public required decimal Protein { get; set; }
	[DisplayName("Tuz (g/100g)")] public required decimal Salt { get; set; }
}
public record Food : Item {
	public required decimal Energy { get; set; }
	public required decimal Fat { get; set; }
	public required decimal SaturatedFat { get; set; }
	public required decimal Carbonhydrate { get; set; }
	public required decimal Sugar { get; set; }
	public required decimal Protein { get; set; }
	public required decimal Salt { get; set; }
}

public record ChemicalView {
	[DisplayName("Kalem No")] public required int Id { get; set; }
	[DisplayName("Kalem Adı")] public required string ItemName { get; set; }
	[DisplayName("İmalatçı Firma No")] public required int ManufacturerId { get; set; }
	[DisplayName("İmalatçı Firma Mersis No")] public required int ManufacturerMersisId { get; set; }
	[DisplayName("İmalatçı Firma Adı")] public required string ManufacturerName { get; set; }
	[DisplayName("Barkod")] public required string Barcode { get; set; }
	[DisplayName("Count")] public required long Count { get; set; }
	[DisplayName("Önizleme")] public required Bitmap? ThumbnailBlob { get; set; }
	[DisplayName("Patlayıcı")] public required bool Explosive { get; set; }
	[DisplayName("Yanıcı")] public required bool Flammable { get; set; }
	[DisplayName("Oksitleyici")] public required bool Oxidizing { get; set; }
	[DisplayName("Sıkıştırılmış Gaz")] public required bool CompressedGas { get; set; }
	[DisplayName("Aşındırıcı")] public required bool Corrosive { get; set; }
	[DisplayName("Zehirli")] public required bool Toxic { get; set; }
	[DisplayName("Zararlı")] public required bool HealthHazard { get; set; }
	[DisplayName("Sağlık Tehlikesi")] public required bool SeriousHealthHazard { get; set; }
	[DisplayName("Çevresel Tehlike")] public required bool EnvironmentHazard { get; set; }
	[DisplayName("Bulaşıcı Madde")] public required bool Infectious { get; set; }
	[DisplayName("Radyoaktif Materyal")] public required bool Radioactive { get; set; }
}
public record Chemical : Item {
	public required bool Explosive { get; set; }
	public required bool Flammable { get; set; }
	public required bool Oxidizing { get; set; }
	public required bool CompressedGas { get; set; }
	public required bool Corrosive { get; set; }
	public required bool Toxic { get; set; }
	public required bool HealthHazard { get; set; }
	public required bool SeriousHealthHazard { get; set; }
	public required bool EnvironmentHazard { get; set; }
	public required bool Infectious { get; set; }
	public required bool Radioactive { get; set; }
}