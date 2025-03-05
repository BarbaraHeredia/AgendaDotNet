using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAgenda.Migrations
{
    /// <inheritdoc />
    public partial class PopulaEventMessages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" INSERT INTO EventMessages (Id, MessageBody, MessageRecipient, MessageCreated, EventActionId) VALUES 
                (1, 'Lembrete: Não se esqueça da reunião de planejamento amanhã às 10:00 AM.', '+5511998765432', 
                    '2024-12-14 09:00:00', 2), 
                (2, 'Lembrete: Workshop de Desenvolvimento começa hoje às 9:00 AM. Nos vemos lá!', '+5511987654321', 
                    '2024-12-18 07:00:00', 5) ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM EventMessages WHERE Id IN (1, 2)");
        }
    }
}
