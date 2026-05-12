namespace TargAutoApp
{
    public class Persoana
    {
        public string Nume { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

        public Persoana(string nume, string telefon = "", string email = "")
        {
            Nume = nume;
            Telefon = telefon;
            Email = email;
        }
    }
}