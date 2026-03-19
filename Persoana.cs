public class Persoana
{
    public string Nume { get; set; }

    // Constructor
    public Persoana(string nume)
    {
        Nume = nume;
    }

    public override string ToString()
    {
        return Nume;
    }
}