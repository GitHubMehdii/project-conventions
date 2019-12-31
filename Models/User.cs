namespace projectconventions.Models
{
    public class User
    {
        public int Apogee { get; set; }
        public string BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Filiere { get; set; }
        public string Year { get; set; }
        public string About { get; set; }

        public User()
        {
        }

        public User(
            int Apogee
        )
        {
            this.Apogee = Apogee;
        }


        public User(
            int Apogee,
            string BirthDate,
            string FirstName,
            string LastName,
            string Email,
            string Filiere,
            string Year,
            string About
        )
        {
            this.Apogee = Apogee;
            this.BirthDate = BirthDate;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Filiere = Filiere;
            this.Year = Year;
            this.About = About;
        }
    }
}
