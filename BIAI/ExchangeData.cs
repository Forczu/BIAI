using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIAI
{
    class ExchangeData
    {
        /// <summary>
        /// Liczba uwzględnianych kursów.
        /// Cztery, ponierważ mamy Close, Low, High i Open
        /// </summary>
        private const int RATE_NUMBER = 4;

        /// <summary>
        /// Mapa kursu w czasie
        /// </summary>
        private readonly Dictionary<DateTime, Double[]> data;

        /// <summary>
        /// Utworzenie nowego zbioru danych
        /// </summary>
        /// <param name="inputData">informacje w postaci csv</param>
        public ExchangeData(string[][] inputData)
        {
            data = new Dictionary<DateTime, Double[]>();
            for (int i = 0; i < inputData.GetLength(0); i++)
            {
                DateTime dt = ToDateTime(inputData[i][0]);
                Double[] rate = new Double[RATE_NUMBER];
                // Close
                rate[0] = Double.Parse(inputData[i][1], CultureInfo.InvariantCulture);
                // High
                rate[1] = Double.Parse(inputData[i][2], CultureInfo.InvariantCulture);
                // Low
                rate[2] = Double.Parse(inputData[i][3], CultureInfo.InvariantCulture);
                // Open
                rate[3] = Double.Parse(inputData[i][4], CultureInfo.InvariantCulture);
                this.data[dt] = rate;
            }
        }

        /// <summary>
        /// Funkcja przekształcająca datę wygenerowaną przez stronę
        /// udostępniającą dane z Forexa na DateTime
        /// </summary>
        /// <param name="datetime">data</param>
        /// <returns>data we właściwym formacie</returns>
        public static DateTime ToDateTime(string datetime)
        {
            string year = datetime.Substring(0, 4);
            string month = datetime.Substring(5, 2);
            string day = datetime.Substring(8, 2);
            return new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
        }


        /// <summary>
        /// Zwraca część danych wejściowych.
        /// </summary>
        /// <param name="start">Indeks początkowy.</param>
        /// <param name="days">Liczba dni w liście.</param>
        /// <returns></returns>
        public List<Double[]> GetSplitData(Int32 start, Int32 days)
        {
            List<Double[]> values = data.Values.ToList();
            return values.GetRange(start, days);
        }


        public int Count
        {
            get { return data.Count; }
        }

        public List<Double[]> ValuesToList()
        {
            return data.Values.ToList();
        }

        public List<DateTime> KeysToList()
        {
            return data.Keys.ToList();
        }
    }
}
