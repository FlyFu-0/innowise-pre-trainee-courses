using FluentMigrator;

namespace task_3_tasks_manager.Migrations;

[Migration(20251013)]
public class AddTasksTable : Migration {
    public override void Up()
    {
        Create.Table("Tasks").InSchema("dbo")
            .WithColumn("Id").AsInt32().Identity().PrimaryKey()
            .WithColumn("Title").AsString(255).NotNullable()
            .WithColumn("Description").AsString(255).NotNullable()
            .WithColumn("IsCompleted").AsBoolean().NotNullable().WithDefaultValue(false)
            .WithColumn("CreatedAt").AsDateTime().NotNullable().WithDefaultValue(SystemMethods.CurrentDateTime);
    }

    public override void Down()
    {
        Delete.Table("Tasks").InSchema("dbo");
    }
}