using Connect_agenda_data.repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace Connect_agenda_services.Services.Jobs;

public class VerifyScheduleJobService : IHostedService, IDisposable
{
    private Timer _timer1; // Para rodar todos os dias às 07h

    private readonly ILogger<VerifyScheduleJobService> _logger;
    private readonly IConfiguration _configuration;

    private readonly IServiceScopeFactory _serviceScopeFactory;

    private int disparos1;
    private int disparos2;

    public VerifyScheduleJobService(ILogger<VerifyScheduleJobService> logger, IServiceScopeFactory serviceScopeFactory, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public void Dispose()
    {
        _timer1?.Dispose();
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        // Configura o temporizador para rodar às todos os dias as 07hrs
        _timer1 = new Timer(
            call => ExecuteAsync1(),
            null,
            CalculateTimeUntilNext7AM(),
            TimeSpan.FromHours(24)
        );

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer1?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    private async void ExecuteAsync1()
    {
        disparos1++;

        _logger.LogInformation($"Função 1 - Disparos: {disparos1}");

        //await GetAllRebimentosDueByWeek();
    }

    private TimeSpan CalculateTimeUntilNext7AM()
    {
        // Calcula o tempo até as 07h do próximo dia 
        DateTime now = DateTime.UtcNow;
        TimeZoneInfo tzBrasilia = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");

        DateTime dateTimeBrasilia = new DateTime(now.Year, now.Month, now.Day, 7, 0, 0);
        DateTime next7AM = TimeZoneInfo.ConvertTimeToUtc(dateTimeBrasilia, tzBrasilia);

        if (now >= next7AM)
        {
            next7AM = next7AM.AddDays(1);
        }

        return next7AM - now;
    }


    //private async Task<bool> VerifySchedulesForADay()
    //{
    //    using var scope = _serviceScopeFactory.CreateScope();
    //    var orderRepository = scope.ServiceProvider.GetRequiredService<OrderRepository>();
    //    var sendEmailService = scope.ServiceProvider.GetRequiredService<SendEmailService>();

    //    try
    //    {
    //        numeroMaximoTentativas = (await GetAllCertificates()).Length;

    //        var rebimentos = await estoqueRepository.GetAllRecebimentosNfeWSemDue();
    //        List<RecebimentoNfeGraosModel> RecebimentosAtualizados = new List<RecebimentoNfeGraosModel>();

    //        foreach (var rebimento in rebimentos)
    //        {
    //            siscomexToken = await GetSiscomexToken();

    //            if (siscomexToken == null) throw new Exception("Erro ao buscar token do siscomex");

    //            bool tentarNovamente = true;

                
    //        }

    //        return RecebimentosAtualizados;
    //    }
    //    catch (Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }
    //}
}  