namespace DataLayer.DTO
{
    public class EpayResponse
    {
        public string amount { get; set; }
        public string currency { get; set; }
        public string date { get; set; }
        public string time { get; set; }

        public string orderid { get; set; }
        public string txnid { get; set; }
        public string hash { get; set; }
    }
}