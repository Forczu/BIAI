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
        /// Możliwe metody podziału danych wejściowych
        /// </summary>
        public enum SplitMethod { Monthly, Weekly, Daily }
        private Dictionary<String, SplitMethod> splitMethodDic = new Dictionary<String, SplitMethod>()
        {
            {"Monthly", SplitMethod.Monthly},
            {"Weekly", SplitMethod.Weekly},
            {"Daily", SplitMethod.Daily}
        };

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
        /// Funkcja zwracają listę danych wejściowych, podzielonych wg przekazanego kryterium
        /// </summary>
        /// <param name="method">kryterium</param>
        /// <returns>Listę podzielonych danych</returns>
        public List<Dictionary<DateTime, Double[]>> GetSplitData(SplitMethod method)
        {
            switch(method)
            {
                case SplitMethod.Monthly: default:
                    var monthlyList =
                        data.GroupBy(pair => pair.Key.Month)
                             .OrderBy(gr => gr.Key)
                             .Select(gr => gr.ToDictionary(item => item.Key, item => item.Value))
                             .ToList();
                    return monthlyList;

                case SplitMethod.Weekly:
                    List<Dictionary<DateTime, Double[]>> weeklyList = new List<Dictionary<DateTime, Double[]>>();
                    int currentiteration = 0;
                    int currentDic = -1;
                    foreach (var entry in data)
                    {
                        if (currentDic != currentiteration / 7)
                        {
                            currentDic++;
                            weeklyList.Add(new Dictionary<DateTime, Double[]>());
                        }
                        weeklyList[currentDic].Add(entry.Key, entry.Value);
                        currentiteration++;
                    }
                    return weeklyList;

                case SplitMethod.Daily:
                    List<Dictionary<DateTime, Double[]>> dailyList = new List<Dictionary<DateTime, Double[]>>();
                    var tmpMonthlyList =
                        data.GroupBy(pair => pair.Key.Day)
                             .OrderBy(gr => gr.Key)
                             .Select(gr => gr.ToDictionary(item => item.Key, item => item.Value))
                             .ToList();
                    foreach (var month in tmpMonthlyList)
                    {
                        var tmpDailyList =
                            month.GroupBy(pair => pair.Key.Month)
                                 .OrderBy(gr => gr.Key)
                                 .Select(gr => gr.ToDictionary(item => item.Key, item => item.Value))
                                 .ToList();
                        dailyList.AddRange(tmpDailyList);
                    }
                    return dailyList;
            }
        }


        public int Count
        {
            get { return data.Count; }
        }

        public List<Double[]> ToList()
        {
            return data.Values.ToList();
        }
    }
}
