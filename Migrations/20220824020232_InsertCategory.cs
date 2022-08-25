using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Nft.Migrations
{
    public partial class InsertCategory : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Categories(CategoryName) Values('Nft')");
            mb.Sql("Insert into Categories(CategoryName) Values('Coin')");
            mb.Sql("Insert into Categories(CategoryName) Values('Other')");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Categories");
        }
    }
}
