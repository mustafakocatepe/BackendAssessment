﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Infrastructure.Common.Attributes
{
    public sealed class StateDisplayAttribute : Attribute
    {
        public int Order { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

        public StateDisplayAttribute()
        {
            Order = default;
            Code = default;
            Name = default;
            Message = default;
            Success = default;
        }

        public int? GetOrder()
        {
            return Order;
        }

        public int? GetCode()
        {
            return Code;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetMessage()
        {
            return Message;
        }

        public bool GetSuccess()
        {
            return Success;
        }
    }
}
