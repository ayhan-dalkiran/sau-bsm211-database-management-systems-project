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
	public static async Task<BindingList<EmployeeView>> SelectEmployeeViewBulk() {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"employee_id",
				"employee_national_id",
				"employee_name",
				"workplace_id",
				"workplace_name",
				"supervisor_id",
				"supervisor_name",
				"hire_date",
				"position",
				"wage"
			FROM "public"."employee_view";
			""");

		var list = new BindingList<EmployeeView>();
		using var reader = await command.ExecuteReaderAsync();
		while (await reader.ReadAsync()) {
			var data = new EmployeeView {
				EmployeeId = reader.GetInt32(0),
				EmployeeNationalId = reader.GetString(1),
				EmployeeName = reader.GetString(2),
				WorkplaceId = reader.GetInt32(3),
				WorkplaceName = reader.GetString(4),
				SupervisorId = await reader.IsDBNullAsync(5) ? null : reader.GetInt32(5),
				SupervisorName = await reader.IsDBNullAsync(6) ? null : reader.GetString(6),
				HireDate = DateOnly.FromDateTime(reader.GetDateTime(7)),
				Position = reader.GetString(8),
				Wage = reader.GetDecimal(9),
			};
			list.Add(data);
		}
		return list;
	}
	public static async Task<EmployeeView> SelectEmployeeView(int employee_id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT
				"employee_id",
				"employee_national_id",
				"employee_name",
				"workplace_id",
				"workplace_name",
				"supervisor_id",
				"supervisor_name",
				"hire_date",
				"position",
				"wage"
			FROM "public"."employee_view"
			WHERE 
				"employee_id" = @employee_id;
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("employee_id", employee_id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new EmployeeView {
			EmployeeId = reader.GetInt32(0),
			EmployeeNationalId = reader.GetString(1),
			EmployeeName = reader.GetString(2),
			WorkplaceId = reader.GetInt32(3),
			WorkplaceName = reader.GetString(4),
			SupervisorId = await reader.IsDBNullAsync(5) ? null : reader.GetInt32(5),
			SupervisorName = await reader.IsDBNullAsync(6) ? null : reader.GetString(6),
			HireDate = DateOnly.FromDateTime(reader.GetDateTime(7)),
			Position = reader.GetString(8),
			Wage = reader.GetDecimal(9),
		};

		return data;
	}
	public static async Task<Employee> SelectEmployee(int id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT "person_id", "workplace_id", "hire_date",
			"position", "wage"
			FROM "public"."employee"
			WHERE "person_id" = @person_id
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("person_id", id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new Employee {
			Person = await DatabaseApi.SelectPerson(reader.GetInt32(0)),
			Workplace = await DatabaseApi.SelectWorkplaceView(reader.GetInt32(1)),
			HireDate = DateOnly.FromDateTime(reader.GetDateTime(2)),
			Position = reader.GetString(3),
			Wage= reader.GetDecimal(4),
		};

		return data;
	}
	//public static async Task InsertEmployee(Employee data) {
	//	await using var dataSource = Builder.Build();
	//	await using var command = dataSource.CreateCommand("""
	//		INSERT INTO "public"."employee"("person_id", "workplace_id",
	//		 "hire_date", "position", "wage") 
	//		VALUES(@person_id, @workplace_id,
	//		 @hire_date, @position, @wage)
	//		""");
	//	command.Parameters.Add(new NpgsqlParameter<int>("person_id", data.Person.Id));
	//	command.Parameters.Add(new NpgsqlParameter<int>("workplace_id", data.Workplace.Id));
	//	command.Parameters.Add(new NpgsqlParameter<DateOnly>("hire_date", data.HireDate));
	//	command.Parameters.Add(new NpgsqlParameter<string>("position", data.Position));
	//	command.Parameters.Add(new NpgsqlParameter<decimal>("wage", data.Wage));
	//	command.ExecuteNonQuery();
	//}
	//public static async Task UpdateEmployee(Employee data) {
	//	await using var dataSource = Builder.Build();
	//	await using var command = dataSource.CreateCommand("""
	//		UPDATE "public"."employee"
	//		SET "workplace_id" = @workplace_id,
	//		 "hire_date" = @hire_date,
	//		 "position" = @position,
	//		 "wage" = @wage
	//		WHERE "person_id" = @person_id;
	//		""");
	//	command.Parameters.Add(new NpgsqlParameter<int>("person_id", data.Person.Id));
	//	command.Parameters.Add(new NpgsqlParameter<int>("workplace_id", data.Workplace.Id));
	//	command.Parameters.Add(new NpgsqlParameter<DateOnly>("hire_date", data.HireDate));
	//	command.Parameters.Add(new NpgsqlParameter<string>("position", data.Position));
	//	command.Parameters.Add(new NpgsqlParameter<decimal>("wage", data.Wage));
	//	command.ExecuteNonQuery();
	//}
	//public static async Task DeleteEmployeeBulk(List<int> list) {
	//	await using var dataSource = Builder.Build();
	//	await using var command = dataSource.CreateCommand("""
	//		DELETE FROM "public"."employee" WHERE "person_id" = ANY(@list)
	//		""");
	//	command.Parameters.Add(new NpgsqlParameter<List<int>>("list", list));
	//	command.ExecuteNonQuery();
	//}
}

public record EmployeeView {
	[DisplayName("Personel No")] public required int EmployeeId { get; set; }
	[DisplayName("Personel T.C. Kimlik No")] public required string EmployeeNationalId { get; set; }
	[DisplayName("Personel Adı")] public required string EmployeeName { get; set; }
	[DisplayName("Yönetici No")] public required int? SupervisorId { get; set; }
	[DisplayName("Yönetici Adı")] public required string? SupervisorName { get; set; }
	[DisplayName("İşyeri No")] public required int WorkplaceId { get; set; }
	[DisplayName("İşyeri Adı")] public required string WorkplaceName { get; set; }
	[DisplayName("İşe Alınış Tarihi")] public required DateOnly HireDate { get; set; }
	[DisplayName("Mevki")] public required string Position { get; set; }
	[DisplayName("Maaş")] public required decimal Wage { get; set; }
}
public record Employee {
	public required Person Person { get; set; }
	public required WorkplaceView Workplace { get; set; }
	public required DateOnly HireDate { get; set; }
	public required string Position { get; set; }
	public required decimal Wage { get; set; }
}
