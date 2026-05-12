using System;
namespace TargAutoApp
{
    public enum CuloareMasina { Alb, Negru, Rosu, Albastru, Gri, Necunoscut }
    [Flags]
    public enum OptiuniMasina { Standard = 0, AC = 1, Navigatie = 2, Camera = 4, Piele = 8, Bluetooth = 16 }
    public class Masina
    {
        public string Firma { get; set; }
        public string Model { get; set; }
        public int AnFabricatie { get; set; }
        public CuloareMasina Culoare { get; set; }
        public OptiuniMasina Optiuni { get; set; }
        public Masina(string firma, string model, int an, CuloareMasina culoare, OptiuniMasina optiuni)
        {
            Firma = firma; Model = model; AnFabricatie = an; Culoare = culoare; Optiuni = optiuni;
        }
    }
}