namespace HubSportService.DTO
{
   public class Contact
    {
        public long vid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public Company Company { get; set; }

        public override string ToString()
        {
            return $"{nameof(vid)}: {vid}, {nameof(firstname)}: {firstname}, {nameof(lastname)}: {lastname}, {nameof(Company)}: {Company}";
        }
    }
}
