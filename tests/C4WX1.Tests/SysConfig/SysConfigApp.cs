using C4WX1.API.Features.SysConfig.Dtos;
using Dapper;
using Npgsql;

namespace C4WX1.Tests.SysConfig
{
    public class SysConfigApp : C4WX1App
    {
        protected override async ValueTask SetupAsync()
        {
            using var connection = new NpgsqlConnection(_container.GetConnectionString());
            await connection.ExecuteAsync("""
                CREATE TABLE "SysConfig" (
                    "ConfigName" VARCHAR(50) NOT NULL,
                    "ConfigValue" TEXT,
                    "ModifiedDate" TIMESTAMP WITHOUT TIME ZONE,
                    "ModifiedBy_FK" INTEGER,
                    "IsConfigurable" BOOLEAN,
                    "Description" TEXT,
                    CONSTRAINT "PK_SysConfig" PRIMARY KEY ("ConfigName")
                );
                """);

            await base.SetupAsync();
        }
    }
}
