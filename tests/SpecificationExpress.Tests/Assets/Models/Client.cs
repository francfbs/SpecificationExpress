namespace SpecificationExpress.Tests.Assets.Models
{
    public class Client
    {
        public Client(int id, string name, bool active, bool premiumMember)
        {
            Id = id;
            Name = name;
            Active = active;
            PremiumMember = premiumMember;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool Active { get; private set; }
        public bool PremiumMember { get; private set; }
    }
}