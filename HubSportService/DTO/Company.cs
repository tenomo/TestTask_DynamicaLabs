namespace HubSportService.DTO
{
    public class Company
    {
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }

        public override string ToString()
        {
            return $"{nameof(CompanyId)}: {CompanyId}, {nameof(Name)}: {Name}, {nameof(Website)}: {Website}, {nameof(City)}: {City}, {nameof(State)}: {State}, {nameof(Zip)}: {Zip}, {nameof(Phone)}: {Phone}";
        }
         
    }
}
