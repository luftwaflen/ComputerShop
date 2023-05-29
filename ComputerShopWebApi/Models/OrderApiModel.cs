namespace ComputerShopWebApi.Models;

public class OrderApiModel
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ComponentId { get; set; }
    public decimal Coast { get; set; }
}