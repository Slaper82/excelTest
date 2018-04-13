using ExcelReaderTest.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ExcelReaderTest
{
    class DataHandle
    {
        public  int startX { get; set; }
        public  int startY { get; set; }
        
        public DataTable Data { get; set; } = new DataTable();

        public List<string> Headers = new List<string>();

        public List<string> MainHeaders;

        public DataHandle()
        {
            MainHeaders = new List<string>() { "Nazwa", "ID", "Cena", "Pozycja", "Poziom", "Opis", "NrZamówienia" };
        }
        /// <summary>
        /// W sumie nie użyłem tego ale myślałem że może się przydać
        /// </summary>
        /// <param name="HeaderDict"></param>
        private void DictonaryCleaner(Dictionary<string, int> HeaderDict)
        {
            var newDict = HeaderDict
                        .Where(kvp => MainHeaders.Contains(kvp.Key))
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            HeaderDict = newDict;
        }

        private void FindTableHeader()
        {
            for (int i = 0; i < Data.Rows.Count; i++)
            {
                DataRow dr = Data.Rows[i];
                for (int j = 0; j < dr.ItemArray.Length; j++)
                {
                    if (dr.ItemArray[j].ToString() != String.Empty)
                    {
                        startX = i;
                        startY = j;
                        i = Data.Rows.Count;
                        break;
                    }
                }
            }
        }
        private void DictonaryPopulate( Dictionary<string, int> HeaderDict, List<Emission> Emisions)
        {
            FindTableHeader();
            DataRow datarow = Data.Rows[startX];
            int count = 0;
            foreach (var item in datarow.ItemArray)
            {
                ++count;
                if (item.ToString() != String.Empty)
                {
                    string dict = item.ToString().Replace(" ", String.Empty);
                    HeaderDict.Add(dict, count);

                    if (dict.Contains("-"))
                    {
                        string[] tmp = dict.Split('-');
                        Emission em = new Emission()
                        {
                            Id = count,
                            Start = Convert.ToDateTime(tmp[0]),
                            Stop = Convert.ToDateTime(tmp[1])
                        };
                        Emisions.Add(em);
                    }
                }

            }
        }
  
        public IEnumerable<PoziomData> DataToCalculate(Dictionary<string, int> HeaderDict, List<Emission> Emisions)
        {
            var dane = new List<PoziomData>();
            DictonaryPopulate(HeaderDict, Emisions);
            for (int i = startX + 1; i < Data.Rows.Count; i++)
            {
                DataRow dr = Data.Rows[i];
                PoziomData nowy = new PoziomData()
                {
                    ID = dr.ItemArray[HeaderDict["ID"] - 1].ToString(),
                    Cena = dr.ItemArray[HeaderDict["Cena"] - 1].ToString(),
                    Nazwa = dr.ItemArray[HeaderDict.Where(s => s.Key == "Nazwa").Select(s => s.Value).FirstOrDefault() - 1].ToString(),
                    Pozycja = dr.ItemArray[HeaderDict["Pozycja"] - 1].ToString(),
                    Opis = dr.ItemArray[HeaderDict["Opis"] - 1].ToString(),
                    NrZamowienia = dr.ItemArray[HeaderDict["NrZamówienia"] - 1].ToString(),
                    Poziom = dr.ItemArray[HeaderDict["Poziom"] - 1].ToString()
                };

                foreach (var em in Emisions)
                {
                    if (dr.ItemArray[em.Id - 1].ToString()!=String.Empty)//zadanie dodatkowe pozwala odczytać dowolne oznaczenie że emisja była aktywna
                    {
                        nowy.Emisje.Add(em);
                    }
                }
                dane.Add(nowy);
            }
            return dane;
        }

        public IEnumerable<Result> Result(IEnumerable<PoziomData> dane)
        {
            List<Result> res = new List<Result>();
            foreach (var d in dane)
            {
                int suma = 0;
                
                foreach (var s in d.Emisje)
                {
                    suma += (int)(s.Stop - s.Start).TotalDays + 1;
                }
          
                string Cena = Validator.ValidateNumber(d.Cena);//zadanie dodatkowe
                bool val = Decimal.TryParse(Cena, out decimal srednia);

                if (val)
                {
                    srednia = srednia * suma;
                    var result = new Result()
                    {
                        ID = d.ID,
                        Nazwa = d.Nazwa,
                        Poziom = d.Poziom,
                        Srednia = srednia
                    };
                    res.Add(result);
                }
                else
                {
                    var result = new Result()
                    {
                        ID = d.ID,
                        Nazwa = d.Nazwa,
                        Poziom = d.Poziom,
                        Srednia = 0
                    };
                    res.Add(result);
                }
            }
            return res;
        }
    }
}
