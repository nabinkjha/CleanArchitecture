﻿using ToastNotification.Abstractions;
using ToastNotification.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToastNotification.Toastify.Models
{
    public class ToastifyNotification : Notification
    {
        public ToastifyNotification(ToastNotificationType type, string message, int? durationInSeconds) : base(type, message, durationInSeconds)
        {
        }
    }
}
