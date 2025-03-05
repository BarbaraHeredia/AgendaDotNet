using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAgenda.Migrations
{
    /// <inheritdoc />
    public partial class PopulaEmails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" INSERT INTO Emails (Id, Email, EmailMessage, EmailSubject, EmailBody, EmailRecipient, 
                                    EmailAttachments, DateTime, EventActionId) VALUES 
                (1, 'organizador@example.com', 'Detalhes da Reunião de Planejamento', 'Reunião de Planejamento Mensal', 
                    'Prezados, Segue em anexo a pauta e os detalhes da reunião de planejamento mensal. Atenciosamente, 
                    Organizador', 'participante1@example.com', NULL, '2024-12-10 09:00:00', 3), 
                (2, 'coordenador@example.com', 'Workshop de Desenvolvimento', 'Workshop sobre Desenvolvimento de Software', 
                    'Olá, Não se esqueça de participar do nosso workshop sobre desenvolvimento de software. Detalhes em anexo. 
                    Cumprimentos, Coordenador', 'participante2@example.com', 'workshop_details.pdf', '2024-12-17 09:00:00', 6) ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Emails WHERE Id IN (1, 2)");
        }
    }
}
