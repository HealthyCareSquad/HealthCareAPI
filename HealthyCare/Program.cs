//using Microsoft.Extensions.DependencyInjection;

namespace HealthyCare
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<Projeto.Data.Context.DataBaseContext>();

            builder.Services.AddScoped<
                Projeto.Data.Interfaces.IAgendamentoConfiguracaoRepository,
                Projeto.Data.Repository.AgendamentoConfiguracaoRepository>();

            builder.Services.AddScoped<
               Projeto.Data.Interfaces.IAgendamentoRepository,
               Projeto.Data.Repository.AgendamentoRepository>();

            builder.Services.AddScoped<
               Projeto.Data.Interfaces.IAgendamentoConfiguracaoRepository,
               Projeto.Data.Repository.AgendamentoConfiguracaoRepository>();

            builder.Services.AddScoped<
              Projeto.Data.Interfaces.IBeneficiarioRepository,
              Projeto.Data.Repository.BeneficiarioRepository>();

            builder.Services.AddScoped<
              Projeto.Data.Interfaces.IDadosBancarioRepository,
              Projeto.Data.Repository.DadosBancarioRepository>();

            builder.Services.AddScoped<
              Projeto.Data.Interfaces.IEspecialidadeRepository,
              Projeto.Data.Repository.EspecialidadeRepository>();

            builder.Services.AddScoped<
              Projeto.Data.Interfaces.IHospitalRepository,
              Projeto.Data.Repository.HospitalRepository>();

            builder.Services.AddScoped<
             Projeto.Data.Interfaces.IProfissionalRepository,
             Projeto.Data.Repository.ProfissionalRepository>();


            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MinhaRegraCors",
                    policy =>
                    {
                        policy.AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod();

                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("MinhaRegraCors");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}