﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.DTOs
{
    /// <summary>
    /// DTO for creating/updating EquipmentInventory.
    /// </summary>
    public class EquipmentInventoryRequestDto
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Make { get; set; }
        public string? ItemModel { get; set; }
        public string? TrackingMethod { get; set; }
        public int ItemGroupId { get; set; }
        public bool IsVoid { get; set; }
    }

    /// <summary>
    /// DTO for returning EquipmentInventory data.
    /// </summary>
    public class EquipmentInventoryResponseDto
    {
        public int Id { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Make { get; set; }
        public string? ItemModel { get; set; }
        public string? TrackingMethod { get; set; }
        public int ItemGroupId { get; set; }
        public string ItemGroupName { get; set; }
        public bool IsVoid { get; set; }
    }
}