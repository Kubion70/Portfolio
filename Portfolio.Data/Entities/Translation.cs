using Dapper.Contrib.Extensions;
using Portfolio.Data.Entities.Abstractions;

namespace Portfolio.Data.Entities
{
    [Table(nameof(Translation))]
    public class Translation : IEntity<int>
    {
        public int Id { get; set; }
    }
}
