namespace ComputerShopLogic.Dto;

public class OrderDto
{
    public int Id { get; set; }
    //public UserDto User { get; set; }
    public int UserId { get; set; }
    //public ComponentDto Component { get; set; }
    public int ComponentId { get; set; }
    public decimal Coast { get; set; }
}