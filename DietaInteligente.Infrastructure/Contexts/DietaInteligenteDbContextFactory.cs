//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;
//using Microsoft.Extensions.Configuration;
//using System.IO;
//using System.Reflection;

//namespace DietaInteligente.Infrastructure.Contexts
//{
//    public class DietaInteligenteDbContextFactory : IDesignTimeDbContextFactory<DietaInteligenteDbContext>
//    {
//        public DietaInteligenteDbContext CreateDbContext(string[] args)
//        {
//            // Ajuste do caminho base para o local do arquivo appsettings.json
//            var basePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
//            basePath = Path.Combine(basePath, "..", "..", "..", "DietaInteligente.API");

//            IConfigurationRoot configuration = new ConfigurationBuilder()
//                .SetBasePath(basePath)
//                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//                .Build();

//            // Obtendo a string de conexão do arquivo de configuração
//            var connectionString = configuration.GetConnectionString("AppDbConnectioString");

//            // Configurando o DbContextOptionsBuilder com a string de conexão
//            var builder = new DbContextOptionsBuilder<DietaInteligenteDbContext>();
//            builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

//            // Retornando uma nova instância do contexto
//            return new DietaInteligenteDbContext(builder.Options);
//        }
//    }
//}
