namespace Domain.DTO
{
   public class Contact
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Company Company { get; set; }
        public long CompanyId { get; set; }
        public string LifecycleStage { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}, {nameof(Company)}: {Company}";
        }
    }
}
