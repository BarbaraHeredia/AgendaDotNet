using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAgenda.Migrations
{
    /// <inheritdoc />
    public partial class PopulaReminders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" INSERT INTO Reminders (Id, Name, Title, Content, Created, SentDate, EventActionId) VALUES 
                (1, 'Lembrete Reunião de Planejamento', 'Reunião de Planejamento', 
                    'Lembre-se da reunião de planejamento mensal que ocorrerá em breve.', '2024-12-01 09:00:00', 
                    '2024-12-15 09:00:00', 1), 
                (2, 'Lembrete Workshop de Desenvolvimento', 'Workshop de Desenvolvimento', 
                    'Não perca o workshop de desenvolvimento de software que ocorrerá na próxima semana.', '2024-12-10 09:00:00', 
                    '2024-12-18 08:00:00', 4) ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Reminders WHERE Id IN (1, 2)");
        }
    }
}
