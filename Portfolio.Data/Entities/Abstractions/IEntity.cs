using Dapper.Contrib.Extensions;

namespace Portfolio.Data.Entities.Abstractions
{
    public interface IEntity<IdType> where IdType : struct
    {
        /// <summary>
        /// Primary key
        /// </summary>
        [Key]
        IdType Id { get; set; }
    }
}