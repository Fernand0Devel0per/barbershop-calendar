using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarbershopCalendar.Persistence.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_DaysAppointment_DayAppointmentId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_TypesOfWork_TypeOfWorkId",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfWorkId",
                table: "Appointments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Appointments",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Appointments",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "DayAppointmentId",
                table: "Appointments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "ClientName",
                table: "Appointments",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_DaysAppointment_DayAppointmentId",
                table: "Appointments",
                column: "DayAppointmentId",
                principalTable: "DaysAppointment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_TypesOfWork_TypeOfWorkId",
                table: "Appointments",
                column: "TypeOfWorkId",
                principalTable: "TypesOfWork",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_DaysAppointment_DayAppointmentId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_TypesOfWork_TypeOfWorkId",
                table: "Appointments");

            migrationBuilder.AlterColumn<int>(
                name: "TypeOfWorkId",
                table: "Appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Appointments",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Appointments",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DayAppointmentId",
                table: "Appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ClientName",
                table: "Appointments",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_DaysAppointment_DayAppointmentId",
                table: "Appointments",
                column: "DayAppointmentId",
                principalTable: "DaysAppointment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_TypesOfWork_TypeOfWorkId",
                table: "Appointments",
                column: "TypeOfWorkId",
                principalTable: "TypesOfWork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
