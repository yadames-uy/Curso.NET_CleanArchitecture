using Clean.Domain.Common;

namespace Clean.Domain.Entities
{
    public class Hero : BaseEntity
    {
        public string Nombre { get; set; }

        public List<Poderes> Poderes { get; set; }
    }
}