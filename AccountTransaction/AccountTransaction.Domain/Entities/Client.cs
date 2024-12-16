namespace Domain.Entities
{
    public record Client
    {
        public Guid Id { get; private set; } 
        public string Name { get; private set; } 

        public Client(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        
        private Client(){}
    };
}