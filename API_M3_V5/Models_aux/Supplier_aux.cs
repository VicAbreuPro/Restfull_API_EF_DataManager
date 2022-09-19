namespace API_M3_V5.Models_aux
{
    public class Supplier_aux
    {
        public int SupplierId { get; set; }
        public double? DeliveryAverage { get; set; }
        public int BusinessId { get; set; }
        public int EntityId { get; set; }
        public string BusinessType { get; set; } = null!;
        public string BusinessName { get; set; } = null!;
        public int Nif { get; set; }
        public string Addressline { get; set; } = null!;
        public string Zipcode { get; set; } = null!;
        public int LocationId { get; set; }
        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        public string Country { get; set; } = null!;

        public Supplier_aux(){ }
    }
}
