﻿namespace ComputerShopWebApi.Models;

public class ComponentApiModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Coast { get; set; }
    public string ImageUrl { get; set; }
}