using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAgenda.Migrations
{
    /// <inheritdoc />
    public partial class PopulaUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@" INSERT INTO Users (Id, UserName, UserUrl, NormalizedUserName, Email, NormalizedEmail, 
                                    EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, 
                                    PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount) VALUES 
                    ('1', 'john_doe', 'https://example.com/john', 'JOHN_DOE', 'john.doe@example.com', 'JOHN.DOE@EXAMPLE.COM', 1, 
                        'AQAAAAEAACcQAAAAEBN5bMZ3VBVbq1pQ==', 'YG6W3S4R6IJ7NJKL3', 'XK6DF4TSJ5L3FSFR', '1234567890', 1, 0, NULL, 1, 0), 
                    ('2', 'jane_smith', 'https://example.com/jane', 'JANE_SMITH', 'jane.smith@example.com', 'JANE.SMITH@EXAMPLE.COM',
                        1, 'AQAAAAEAACcQAAAAEPLJBZ4TT7N3AK6Q==', 'LKJ8RE34NJ9YTG54H', 'WIE87RE89DD9UUS6', '0987654321', 1, 0,
                        NULL, 1, 0), 
                    ('3', 'alice_johnson', 'https://example.com/alice', 'ALICE_JOHNSON', 'alice.johnson@example.com', 
                        'ALICE.JOHNSON@EXAMPLE.COM', 1, 'AQAAAAEAACcQAAAAE5JH3M5L3YJKOP8Q==', 'JH87GRE54K90F3JL8', 
                        'LK90J3H45KLR5J90', '1122334455', 1, 0, NULL, 1, 0), 
                    ('4', 'bob_brown', 'https://example.com/bob', 'BOB_BROWN', 'bob.brown@example.com', 'BOB.BROWN@EXAMPLE.COM', 
                        1, 'AQAAAAEAACcQAAAAEBH7MZ6P9N5B7RTQ==', 'HJ76YT8O4LF9DK3L6', 'KL87YG34K9R8JL56', '3344556677', 1, 0, 
                        NULL, 1, 0), 
                    ('5', 'carol_white', 'https://example.com/carol', 'CAROL_WHITE', 'carol.white@example.com', 
                        'CAROL.WHITE@EXAMPLE.COM', 1, 'AQAAAAEAACcQAAAAERH7P9L3R2K4Q9Z==', 'LK89JH56DF9L3H6T8', 
                        'KP87JH6F5R9JD4L6', '5566778899', 1, 0, NULL, 1, 0) ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Users WHERE Id IN ('1', '2', '3', '4', '5')");
        }
    }
}
