using DataLayer;

namespace HomeIO.Models.Entities
{
    public class KeyValues : IEntity
    {
        public int Id { get; set; }
        public string KeyName { get; set; }
        public string KeyValue { get; set; }
    }
}