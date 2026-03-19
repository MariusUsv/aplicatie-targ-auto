using System;

[Flags]
public enum OptiuniMasina
{
    NicioOptiune = 0,
    AerConditionat = 1,
    Navigatie = 2,
    CutieAutomata = 4,
    ScauneIncalzite = 8,
    Bluetooth = 16
}

public enum CuloareMasina
{
    Rosu,
    Alb,
    Negru,
    Albastru,
    Gri
}

public class Masina
{
    public string Firma { get; set; }
    public string Model { get; set; }
    public int AnFabricatie { get; set; }
    public CuloareMasina Culoare { get; set; }
    public OptiuniMasina Optiuni { get; set; }

    public Masina(string firma, string model, int anFabricatie,
                  CuloareMasina culoare, OptiuniMasina optiuni)
    {
        Firma = firma;
        Model = model;
        AnFabricatie = anFabricatie;
        Culoare = culoare;
        Optiuni = optiuni;
    }

    public override string ToString()
    {
        return $"{Firma} {Model} ({AnFabricatie}) - Culoare: {Culoare}, Optiuni: {Optiuni}";
    }
}