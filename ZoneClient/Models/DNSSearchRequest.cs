using Microsoft.AspNetCore.Mvc;

namespace ZoneClient.Models
{
    public class DNSSearchRequestVM
    {
        public int Draw { get; set; }
        [ModelBinder(Name ="length")]
        public int Limit { get;set; }
        [ModelBinder(Name = "start")]
        public int OffSet { get; set; }
        [ModelBinder(Name = "order[0][column]")]
        public string OrderByField { get; set; }
        [ModelBinder(Name = "order[0][dir]")]
        public string OrderBy { get; set; }
        [ModelBinder(Name = "search[value]")]
        public string Fqrs { get; set; }
        public int Id { get; set; }
        public int ZoneId { get; set; }


    }
}
