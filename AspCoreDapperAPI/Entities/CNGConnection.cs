namespace AspCoreDapperAPI.Entities
{
    public class CNGConnection
    {
        public List<States> State { get; set; }
       
    }
    public class States 
    {
        public string State { get; set; }
        public List<Connection> Connections { get; set; }
    }
    public class Connection
    {
        public string? Domestic { get; set;}
        public string? CumDomestic { get; set; }
        public string? Commercial { get; set; }
        public string? CumCommercial { get; set; }
        public string? Industrial { get; set; }
        public string? CumIndustrial { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
    }
    public class ReturnConnection
    {
        public string? State { get; set; }
        public string? Domestic { get; set; }
        public string? CumDomestic { get; set; }
        public string? Commercial { get; set; }
        public string? CumCommercial { get; set; }
        public string? Industrial { get; set; }
        public string? CumIndustrial { get; set; }
        public string? Month { get; set; }
        public string? Year { get; set; }
    }
}
