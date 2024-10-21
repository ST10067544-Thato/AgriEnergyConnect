using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

public class EmailSender : IEmailSender
{
    private readonly ILogger<EmailSender> _logger;

    public EmailSender(ILogger<EmailSender> logger)
    {
        _logger = logger;
    }

    public Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        // Log the email details for development purposes
        _logger.LogInformation("Sending email to {Email} with subject {Subject} and message {Message}", email, subject, htmlMessage);
        return Task.CompletedTask;
    }
}
