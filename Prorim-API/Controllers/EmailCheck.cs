using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Prorim_MediatrHandling.Interfaces;
using Prorim_Services.Entities;
using Prorim_MediatrHandling.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Prorim_Backend.Controllers;
public class EmailCheck : IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    private Task _executingTask;
    private CancellationTokenSource _cts;

    public EmailCheck(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

        _executingTask = Task.Run(() => RunLoopAsync(_cts.Token));

        return Task.CompletedTask;
    }

    private async Task RunLoopAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();

            var _lembreteRepository = scope.ServiceProvider.GetRequiredService<ILembretesRepository>();
            var _userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
            var _mailService = scope.ServiceProvider.GetRequiredService<IMailService>();

            var emailsToSend = await _lembreteRepository.GetAll();
            var pendentes = emailsToSend
                .Where(x => x.emailEnviado == false && x.DataLembrete < DateTime.Now)
                .ToList();

            foreach (var email in pendentes)
            {
                var cliente = await _userRepository.GetByID(email.clienteID);

                _mailService.SendMail(new EmailDTO()
                {
                    EmailToName = cliente.displayName,
                    EmailBody = "",
                    EmailSubject = "teste",
                    EmailToId = cliente.email,
                });

                email.emailEnviado = true;
                await _lembreteRepository.Edit(email);
            }

            await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        if (_executingTask == null)
            return;

        _cts.Cancel();

        await Task.WhenAny(_executingTask, Task.Delay(-1, cancellationToken));
    }
}
