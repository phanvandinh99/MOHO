namespace Ecommerce.Data.Entities
{
    public class Order
    {
        public int Id { set; get; }
        public DateTime OrderDate { set; get; }
        public Guid UserId { set; get; }
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
        public int Status { set; get; } // = 1 chờ xác nhận // = 2 chờ lấy hàng // = 3 đang giao // = 4 đã giao // = 0 đã hủy

        public List<OrderDetail> OrderDetails { get; set; }

        public AppUser? AppUser { get; set; }
    }
}
