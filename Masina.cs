public class Masina
{
    public string Firma { get; set; }
    public string Model { get; set; }
    public int AnFabricatie { get; set; }
    public string Culoare { get; set; }
    public string Optiuni { get; set; }

    // Constructor
    public Masina(string firma, string model, int anFabricatie, string culoare, string optiuni)
    {
        Firma = firma;
        Model = model;
        AnFabricatie = anFabricatie;
        Culoare = culoare;
        Optiuni = optiuni;
    }
}