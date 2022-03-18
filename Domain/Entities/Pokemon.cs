using Domain.Base;

namespace Domain.Entities
{
    public class Pokemon : BaseModel<int>
    {
        public Pokemon()
        {

        }

        public Pokemon(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; } = default!;
    }
}
