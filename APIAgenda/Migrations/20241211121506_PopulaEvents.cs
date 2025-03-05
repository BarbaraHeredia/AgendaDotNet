using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAgenda.Migrations
{
    /// <inheritdoc />
    public partial class PopulaEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" INSERT INTO Events (Id, EventName, EventDescription, EventDateStart, EventDateEnd, UserId) VALUES 
                (1, 'Reunião de Planejamento', 'Reunião mensal para planejar as atividades do próximo mês.', 
                    '2024-12-15 10:00:00', '2024-12-15 12:00:00', '1'), 
                (2, 'Workshop de Desenvolvimento', 'Workshop sobre as melhores práticas de desenvolvimento de software.', 
                    '2024-12-18 09:00:00', '2024-12-18 17:00:00', '2'), 
                (3, 'Conferência de Tecnologia', 'Conferência anual para discutir inovações tecnológicas.', 
                    '2025-01-10 08:00:00', '2025-01-10 18:00:00', '3'), 
                (4, 'Sessão de Treinamento', 'Sessão de treinamento sobre segurança da informação.', 
                    '2025-01-20 14:00:00', '2025-01-20 16:00:00', '4'), 
                (5, 'Reunião de Feedback', 'Reunião para coletar feedback dos clientes.', '2025-02-05 11:00:00', 
                    '2025-02-05 13:00:00', '2'), 
                (6, 'Seminário de Inovação', 'Seminário sobre as últimas tendências em inovação e tecnologia.', 
                    '2025-02-15 09:00:00', '2025-02-15 17:00:00', '5') ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Events WHERE Id IN (1, 2, 3, 4, 5, 6)");
        }
    }
}
