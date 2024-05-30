using Zone.Core.Response;

namespace Zone.Core.DNS.Queries
{
    public class GetZonesListResponse : ServiceResponse<List<ZoneRecordListVM>>
    {
        public GetZonesListResponse() : base(null)
        {

        }
    }
}
