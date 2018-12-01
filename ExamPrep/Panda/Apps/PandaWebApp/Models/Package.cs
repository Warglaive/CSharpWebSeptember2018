﻿using System;
using System.ComponentModel.DataAnnotations;
using PandaWebApp.Models.Enums;

namespace PandaWebApp.Models
{
    public class Package
    {
        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        public double Weight { get; set; }

        public string ShippingAddress { get; set; }

        public Status Status { get; set; }

        public DateTime EstimatedDeliveryDate { get; set; }

        public User Recipient { get; set; }
        public int RecipientId { get; set; }

        public Receipt Receipt { get; set; }
        public int ReceiptId { get; set; }
    }
}