﻿using ToastNotification.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace ToastNotification.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNotyf(this IApplicationBuilder builder)
        {
            builder.UseMiddleware<NotyfMiddleware>();
            return builder;
        }
    }
}
