using Microsoft.EntityFrameworkCore;

namespace Zone.Core.Response
{
    public class PaginatedList<T> : List<T>
    {
        public int TotalRecords { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
        public PaginatedList()
        {

        }
        public PaginatedList(List<T> items, int totalRecords, int offset, int limit)
        {
            Offset = offset; Limit = limit; TotalRecords = totalRecords;
            this.AddRange(items);            
        }
       
        /// <summary>
        /// It is not supported by In-memory database but this must be used in real time 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int offset, int limit)
        {
            var count = await source.CountAsync();
            var items = await source.Skip(offset).Take(limit).ToListAsync();
            return new PaginatedList<T>(items, count,offset,limit);
        }
        /// <summary>
        /// Do not use in real time as it wont support async
        /// </summary>
        /// <param name="source"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public static PaginatedList<T> Create(IEnumerable<T> source, int offset, int limit)
        {
            var count = source.Count();
            var items = source.Skip(offset).Take(limit).ToList();
            return new PaginatedList<T>(items, count, offset, limit);
        }

    }
}
