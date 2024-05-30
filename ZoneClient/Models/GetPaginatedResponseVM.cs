using AutoMapper.Configuration.Annotations;
using Zone.Core.DNS.Queries;
using Zone.Core.Response;

namespace ZoneClient.Models
{
    public class GetPaginatedResponseVM<T>
    {
        [SourceMember("TotalRecords")]
        public int RecordsTotal { get; set; }
        [SourceMember("Offset")]
        public int Offset { get; set; }
        public int Draw { get; set; }
        public int RecordsFiltered { get; set; }


        public T Data{ get; set; }
    }
}
