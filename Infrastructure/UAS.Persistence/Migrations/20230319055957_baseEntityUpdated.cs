using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UAS.Persistence.Migrations
{
    public partial class baseEntityUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ChangeUserIdentityId",
                table: "SiteSettings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreateUserIdentityId",
                table: "SiteSettings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IfTransferredToSecondary",
                table: "SiteSettings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "RecordStatusId",
                table: "SiteSettings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "SiteSettings",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<long>(
                name: "ChangeUserIdentityId",
                table: "PersonelRolTips",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreateUserIdentityId",
                table: "PersonelRolTips",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IfTransferredToSecondary",
                table: "PersonelRolTips",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "RecordStatusId",
                table: "PersonelRolTips",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "PersonelRolTips",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<long>(
                name: "ChangeUserIdentityId",
                table: "PersonelRols",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreateUserIdentityId",
                table: "PersonelRols",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IfTransferredToSecondary",
                table: "PersonelRols",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "RecordStatusId",
                table: "PersonelRols",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "PersonelRols",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<long>(
                name: "ChangeUserIdentityId",
                table: "MenuPanels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreateUserIdentityId",
                table: "MenuPanels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IfTransferredToSecondary",
                table: "MenuPanels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "RecordStatusId",
                table: "MenuPanels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "MenuPanels",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<long>(
                name: "ChangeUserIdentityId",
                table: "MenuKategories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreateUserIdentityId",
                table: "MenuKategories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IfTransferredToSecondary",
                table: "MenuKategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "RecordStatusId",
                table: "MenuKategories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "MenuKategories",
                type: "rowversion",
                rowVersion: true,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<long>(
                name: "ChangeUserIdentityId",
                table: "GrupMenuPanels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "CreateUserIdentityId",
                table: "GrupMenuPanels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IfTransferredToSecondary",
                table: "GrupMenuPanels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<long>(
                name: "RecordStatusId",
                table: "GrupMenuPanels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<byte[]>(
                name: "RowVersion",
                table: "GrupMenuPanels",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangeUserIdentityId",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "CreateUserIdentityId",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "IfTransferredToSecondary",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "RecordStatusId",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "SiteSettings");

            migrationBuilder.DropColumn(
                name: "ChangeUserIdentityId",
                table: "PersonelRolTips");

            migrationBuilder.DropColumn(
                name: "CreateUserIdentityId",
                table: "PersonelRolTips");

            migrationBuilder.DropColumn(
                name: "IfTransferredToSecondary",
                table: "PersonelRolTips");

            migrationBuilder.DropColumn(
                name: "RecordStatusId",
                table: "PersonelRolTips");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "PersonelRolTips");

            migrationBuilder.DropColumn(
                name: "ChangeUserIdentityId",
                table: "PersonelRols");

            migrationBuilder.DropColumn(
                name: "CreateUserIdentityId",
                table: "PersonelRols");

            migrationBuilder.DropColumn(
                name: "IfTransferredToSecondary",
                table: "PersonelRols");

            migrationBuilder.DropColumn(
                name: "RecordStatusId",
                table: "PersonelRols");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "PersonelRols");

            migrationBuilder.DropColumn(
                name: "ChangeUserIdentityId",
                table: "MenuPanels");

            migrationBuilder.DropColumn(
                name: "CreateUserIdentityId",
                table: "MenuPanels");

            migrationBuilder.DropColumn(
                name: "IfTransferredToSecondary",
                table: "MenuPanels");

            migrationBuilder.DropColumn(
                name: "RecordStatusId",
                table: "MenuPanels");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "MenuPanels");

            migrationBuilder.DropColumn(
                name: "ChangeUserIdentityId",
                table: "MenuKategories");

            migrationBuilder.DropColumn(
                name: "CreateUserIdentityId",
                table: "MenuKategories");

            migrationBuilder.DropColumn(
                name: "IfTransferredToSecondary",
                table: "MenuKategories");

            migrationBuilder.DropColumn(
                name: "RecordStatusId",
                table: "MenuKategories");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "MenuKategories");

            migrationBuilder.DropColumn(
                name: "ChangeUserIdentityId",
                table: "GrupMenuPanels");

            migrationBuilder.DropColumn(
                name: "CreateUserIdentityId",
                table: "GrupMenuPanels");

            migrationBuilder.DropColumn(
                name: "IfTransferredToSecondary",
                table: "GrupMenuPanels");

            migrationBuilder.DropColumn(
                name: "RecordStatusId",
                table: "GrupMenuPanels");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "GrupMenuPanels");
        }
    }
}
