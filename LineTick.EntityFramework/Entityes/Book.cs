using LineTick.EntityFramework.Entityes;

namespace LineTick.EntityFramework.Entities
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
