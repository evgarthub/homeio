using DataLayer;

namespace HomeIO.Models.Entities
{
    public class RType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Formula { get; set; }
    }
}