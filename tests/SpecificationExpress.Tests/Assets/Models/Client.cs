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

        public int Id { get; }
        public string Name { get; }
        public bool Active { get; }
        public bool PremiumMember { get; }
    }
}