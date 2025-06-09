using FluentValidation;
using GuessingGameApp.Data.Contexts;
using GuessingGameApp.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace GuessingGameApp.API.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // normal flow
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");

                context.Response.ContentType = "application/json";

                var response = new ErrorResponse();
                int statusCode;

                switch (ex)
                {
                    case ValidationException validationEx:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        response.Title = "Doğrulama Hatası";
                        response.Message = string.Join(" | ", validationEx.Errors.Select(e => e.ErrorMessage));
                        break;

                    case UnauthorizedAccessException:
                        statusCode = (int)HttpStatusCode.Unauthorized;
                        response.Title = "Yetkisiz Erişim";
                        response.Message = "Bu işlemi yapma yetkiniz yok.";
                        break;

                    default:
                        statusCode = (int)HttpStatusCode.InternalServerError;
                        response.Title = "Sunucu Hatası";
                        response.Message = "Beklenmeyen bir hata oluştu.";
                        break;
                }

                response.StatusCode = statusCode;
                context.Response.StatusCode = statusCode;

                // Hata logunu veritabanına kaydet
                var errorLog = new ErrorLog
                {
                    Title = response.Title,
                    Message = response.Message,
                    StatusCode = response.StatusCode,
                    Path = context.Request.Path,
                    Method = context.Request.Method,
                    UserAgent = context.Request.Headers.UserAgent.ToString(),
                    CreatedAt = DateTime.UtcNow
                };

                try
                {
                    using var scope = context.RequestServices.CreateScope();
                    var db = scope.ServiceProvider.GetRequiredService<GuessingGameDbContext>();
                    db.ErrorLogs.Add(errorLog);
                    await db.SaveChangesAsync();
                }
                catch (Exception dbEx)
                {
                    _logger.LogError(dbEx, "❌ Hata veritabanına kaydedilemedi.");
                }

                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }

        private class ErrorResponse
        {
            public string Title { get; set; } = "";
            public string Message { get; set; } = "";
            public int StatusCode { get; set; }
        }
    }
}
