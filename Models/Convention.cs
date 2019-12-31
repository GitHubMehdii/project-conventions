namespace projectconventions.Models
{
    public class Convention
    {
        public int Id { get; set; }
        public int Apogee { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string CompanyName { get; set; }

        public Convention()
        {
        }

        public Convention(
            int Id,
            int Apogee,
            string StartDate,
            string EndDate,
            string CompanyName
        )
        {
            this.Id = Id;
            this.Apogee = Apogee;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.CompanyName = CompanyName;
        }
    }
}
