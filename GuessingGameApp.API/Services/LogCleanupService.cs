using GuessingGameApp.Data.Contexts;

public class LogCleanupService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public LogCleanupService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<GuessingGameDbContext>();

            var oneMonthAgo = DateTime.UtcNow.AddMonths(-1);
            var oldLogs = db.ErrorLogs.Where(l => l.CreatedAt < oneMonthAgo);

            db.ErrorLogs.RemoveRange(oldLogs);
            await db.SaveChangesAsync();

            await Task.Delay(TimeSpan.FromHours(24), stoppingToken); // Günde 1 kez çalış
        }
    }
}
