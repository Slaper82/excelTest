using System.Collections.Generic;

namespace ExcelReaderTest
{
    public class PoziomData
    {
        public string Nazwa { get; set; }
        public string ID { get; set; }
        public string Cena { get; set; }
        public string Pozycja { get; set; }
        public string Poziom { get; set; }
        public string Opis { get; set; }
        public string NrZamowienia { get; set; }
        public List<Emission> Emisje { get; set; } = new List<Emission>();

    }

}
