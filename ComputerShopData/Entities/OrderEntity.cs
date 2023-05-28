namespace ComputerShopData.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        //public UserEntity User { get; set; }
        public int UserId { get; set; }
        //public ComponentEntity Component { get; set; }
        public int ComponentId { get; set; }
        public decimal Coast { get; set; }
    }
}
