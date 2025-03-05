using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAgenda.Migrations
{
    /// <inheritdoc />
    public partial class PopulaEventActions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" INSERT INTO EventActions 
                                (EventActionId, EventActionName, EventctionDescription, ActionType, EventId) VALUES 
                    (1, 'Enviar Lembrete', 'Enviar lembrete por e-mail para todos os participantes.', 1, 1), 
                    (2, 'Enviar Mensagem', 'Enviar mensagem de WhatsApp para lembrar os participantes do evento.', 2, 2), 
                    (3, 'Enviar E-mail', 'Enviar e-mail com detalhes do evento e anexos importantes.', 3, 3), 
                    (4, 'Enviar Lembrete', 'Enviar lembrete por e-mail para a equipe.', 1, 4), 
                    (5, 'Enviar Mensagem', 'Enviar mensagem de WhatsApp para confirmar presença.', 2, 5), 
                    (6, 'Enviar E-mail', 'Enviar e-mail com feedback após o evento.', 3, 6) ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM EventActions WHERE EventActionId IN (1, 2, 3, 4, 5, 6)");
        }
    }
}
