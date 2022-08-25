using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Nft.Migrations
{
    public partial class InsertOwner : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("Insert into Owner(Name, Address) Values('John', 'Rua Jorge Street, 213, Rio de Janeiro/RJ')");
            mb.Sql("Insert into Owner(Name, Address) Values('Abel', 'Rua São João, 34, Sao Paulo/SP')");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("delete from Owner");
        }
    }
}
