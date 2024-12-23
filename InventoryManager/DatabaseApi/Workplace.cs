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
	public static async Task SelectWorkplaceViewBulk() {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT "employee_id", "employee_national_id","employee_name",
			 "supervisor_id", "supervisor_name", "workplace_id", "workplace_name",
			 "hire_date", "position", "wage"
			FROM "public"."employee_view"
			""");

		var list = new BindingList<EmployeeView>();
		using var reader = await command.ExecuteReaderAsync();
		while (await reader.ReadAsync()) {
			var data = new EmployeeView {
				EmployeeId = reader.GetInt32(0),
				EmployeeNationalId = reader.GetString(1),
				EmployeeName = reader.GetString(2),
				SupervisorId = await reader.IsDBNullAsync(3) ? null : reader.GetInt32(3),
				SupervisorName = await reader.IsDBNullAsync(4) ? null : reader.GetString(4),
				WorkplaceId = reader.GetInt32(5),
				WorkplaceName = reader.GetString(6),
				HireDate = DateOnly.FromDateTime(reader.GetDateTime(7)),
				Position = reader.GetString(8),
				Wage = reader.GetDecimal(9),
			};
			list.Add(data);
		}
		EntityView.DataSource = list;
	}
	public static async Task<WorkplaceView> SelectWorkplaceView(int employee_id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT "employee_id", "employee_national_id","employee_name",
			 "supervisor_id", "supervisor_name", "workplace_id", "workplace_name",
			 "hire_date", "position", "wage"
			FROM "public"."employee_view"
			WHERE "employee_id" = @employee_id
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("employee_id", employee_id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new EmployeeView {
			EmployeeId = reader.GetInt32(0),
			EmployeeNationalId = reader.GetString(1),
			EmployeeName = reader.GetString(2),
			SupervisorId = await reader.IsDBNullAsync(3) ? null : reader.GetInt32(3),
			SupervisorName = await reader.IsDBNullAsync(4) ? null : reader.GetString(4),
			WorkplaceId = reader.GetInt32(5),
			WorkplaceName = reader.GetString(6),
			HireDate = DateOnly.FromDateTime(reader.GetDateTime(7)),
			Position = reader.GetString(8),
			Wage = reader.GetDecimal(9),
		};

		return data;
	}
	public static async Task<Workplace> SelectWorkplace(int employee_id) {
		await using var dataSource = Builder.Build();
		await using var command = dataSource.CreateCommand("""
			SELECT "person_id", "supervisor_id", "workplace_id",
			 "hire_date", "position", "wage"
			FROM "public"."employee"
			WHERE "person_id" = @employee_id
			""");
		command.Parameters.Add(new NpgsqlParameter<int>("employee_id", employee_id));

		using var reader = await command.ExecuteReaderAsync();
		await reader.ReadAsync();
		var data = new Employee {
			Person = await DatabaseApi.SelectPerson(reader.GetInt32(0)),
			Supervisor = await DatabaseApi.SelectEmployeeView(reader.GetInt32(1)),
			Workplace = await
			Id = reader.GetInt32(0),
			EntityName = reader.GetString(1),
			TelephoneNumber = reader.GetString(2),
			Address = reader.GetString(3),
			MersisId = reader.GetString(4),
		};

		return data;
	}
}

public enum WorkplaceType : int {
	Undefined = -1,
	[PgName("warehouse")] Warehouse = 0,
	[PgName("office")] Office = 1,


public class WorkplaceView {
	public required int Id { get; set; }
}

public class Workplace {
	public required int Id { get; set; }
}