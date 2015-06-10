using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuronDotNet;
using NeuronDotNet.Core;
using NeuronDotNet.Core.Backpropagation;
using NeuronDotNet.Core.Initializers;
using NeuronDotNet.Core.LearningRateFunctions;

namespace BIAI
{
    /// <summary>
    /// Możliwe netody nauki
    /// </summary>
    public enum Function { None, Expotential, Hyperbolic, Linear };
    /// <summary>
    /// Możliwe sposoby inicjalizacji sieci
    /// </summary>
    public enum Initializer { None, Constant, NgyuenWidrow, NormalizedRandom, Random, Zero };

    class Network
    {
        #region Wartości stałe
        /// <summary>
        /// maksymalna liczba wartw pośrednich
        /// </summary>
        private const int HIDDEN_LAYER_MAX_COUNT = 3;
        /// <summary>
        /// Liczba neuronów w warstywie wejściowej,
        /// musi być równa liczbie danych wejściowych
        /// </summary>
        private const int INPUT_NUMBER = 5;
        /// <summary>
        /// Liczba neuronów w warstywie wyjściowej,
        /// </summary>
        private const int OUTPUT_NUMBER = 1;
        #endregion

        #region Składowe
        /// <summary>
        /// Sieć bakpropagacji
        /// </summary>
        private BackpropagationNetwork ourNetwork;
        /// <summary>
        /// Liczba iteracji po sieci
        /// </summary>
        private int iterations;
        /// <summary>
        /// Liczba ukrytych warstw
        /// </summary>
        private int hiddenLayerCount;
        /// <summary>
        /// Liczby neuronów w ukrytych warstwach
        /// </summary>
        private List<int> neuronCountList;
        /// <summary>
        /// Początkowa i końcowa zdolność nauki
        /// </summary>
        private double initialLearningRate, finalLearningRate;
        /// <summary>
        /// Liczba próbek treningowych
        /// </summary>
        private int trainingDataCount;
        /// <summary>
        /// Opcjonalne parametry dla inicjalizacji sieci
        /// </summary>
        private double initializerParameter1, initializerParameter2;
        /// <summary>
        /// Stopa błędów trenowania sieci
        /// </summary>
        private double[] errorList;
        /// <summary>
        /// Maksymalny błąd, jaki pojawił się w czasie nauki
        /// </summary>
        private double maxError;
        /// <summary>
        /// Wybrany inicjalizator sieci
        /// </summary>
        Initializer chosenInitializer;
        /// <summary>
        /// Wybrana funkcja ucząca
        /// </summary>
        Function chosenFunction;
        #endregion

        #region Wartości do wstępnego przetworzenia
        /// <summary>
        /// Mapa dat i wartości kursu
        /// </summary>
        private List<Dictionary<DateTime, Double[]>> inputData;
        /// <summary>
        /// Średnie kursów walut dla każdego pliku wejściowego
        /// </summary>
        List<double> meanClose, meanHigh, meanLow, meanOpen;
        /// <summary>
        /// Najświeższy kurs walut dla każdego pliku wejściowego
        /// </summary>
        List<double> actualClose, actualHigh, actualLow, actualOpen;
        /// <summary>
        /// Wartość RSI dla kazdego pliku wejsciowego
        /// </summary>
        List<double> RSI;
        /// <summary>
        /// Wartość do obliczenia przez sieć - czy jest mniejszy lub większy
        /// </summary>
        List<double> tomorrowClose;
        #endregion


        #region Konstruktor
        public Network()
        {
            // przydzielenie pamięci dla obiektów
            this.neuronCountList = new List<int>();
            for (int i = 0; i < HIDDEN_LAYER_MAX_COUNT; ++i)
            {
                neuronCountList.Add(0);
            }
            // pamięć dla wartości z plików
            RSI = new List<double>();
            meanClose = new List<double>();
            meanHigh = new List<double>();
            meanLow = new List<double>();
            meanOpen = new List<double>();
            actualClose = new List<double>();
            actualHigh = new List<double>();
            actualLow = new List<double>();
            actualOpen = new List<double>();
            tomorrowClose = new List<double>();
        }
        #endregion

        #region Propertysy
        /// <summary>
        /// Liczba iteracji
        /// </summary>
        public Int32 Iterations
        {
            get { return iterations; }
            set { iterations = value; }
        }
        /// <summary>
        /// Wybór inicjalizatora sieci
        /// </summary>
        public Initializer Initializer
        {
            get { return chosenInitializer; }
            set { chosenInitializer = value; }
        }
        /// <summary>
        /// Wybór funkcji poznawczej(??)
        /// </summary>
        public Function LearningFunction
        {
            set { chosenFunction = value; }
        }
        /// <summary>
        /// Błędy wygenerowane w czasie nauki sieci
        /// </summary>
        public double[] Errors
        {
            get { return errorList; }
        }
        /// <summary>
        /// Średni błąd w czasie trwania nauki
        /// </summary>
        public double MeanError
        {
            get { return ourNetwork.MeanSquaredError; }
        }
        /// <summary>
        /// Maksymalny błąd, jaki pojawił się w trakcie nauki sieci
        /// </summary>
        public double MaxError
        {
            get { return maxError; }
        }
        /// <summary>
        /// Liczba warstw pośrednich
        /// </summary>
        public int HiddenLayerCount
        {
            get { return hiddenLayerCount; }
            set { hiddenLayerCount = value; }
        }
        /// <summary>
        /// Początkowy stopień nauki
        /// </summary>
        public double InitialLearningRate
        {
            get { return initialLearningRate; }
            set { initialLearningRate = value; }
        }
        /// <summary>
        /// Początkowy stopień nauki
        /// </summary>
        public double FinalLearningRate
        {
            get { return finalLearningRate; }
            set { finalLearningRate = value; }
        }
        /// <summary>
        /// Wartość pierwszego parametru inicjalizacji
        /// </summary>
        public double FirstInitializerParameter
        {
            get { return initializerParameter1; }
            set { initializerParameter1 = value; }
        }
        /// <summary>
        /// Wartość drugiego parametru inicjalizacji
        /// </summary>
        public double SecondInitializerParameter
        {
            get { return initializerParameter2; }
            set { initializerParameter2 = value; }
        }
        /// <summary>
        /// Liczba neuronów w warstwach ukrytych
        /// </summary>
        public List<int> NeuronCount
        {
            get { return neuronCountList; }
        }
        #endregion

        #region Metody

        /// <summary>
        /// Wytrenowanie sieci
        /// </summary>
        public void Train()
        {
            errorList = new double[iterations];
            // Utworzenie sieci neuronowej
            CreateNetwork();
            // ustawienie mocy poznawczej
            SetNetworkLearningRate();
            // przydzielenie próbek
            TrainingSet trainingSet = new TrainingSet(INPUT_NUMBER, OUTPUT_NUMBER);
            // 70% danych do treningu
            trainingDataCount = (int)Math.Ceiling(inputData.Count * 0.7);
            for (int i = 0; i < trainingDataCount; ++i)
            {
                trainingSet.Add(
                    new TrainingSample(
                    // wektorem wejściowym są różnice między aktualną wartością, a średnią
                        new double[INPUT_NUMBER]
                        {
                            actualClose[i] - meanClose[i], actualHigh[i] - meanHigh[i], actualLow[i] - meanLow[i], actualOpen[i] - meanOpen[i], RSI[i]
                        },
                    // wektorem wyjściowym jest różnica między jutrzejszym kursem zamknięcia, a aktualnym
                        new double[1]
                        {
                            tomorrowClose[i] - actualClose[i]
                        }
                    )
                );
            }
            // zapisanie błędu sieci oraz wartości maksymalnej błędu
            maxError = 0.0d;
            ourNetwork.EndEpochEvent +=
            delegate(object network, TrainingEpochEventArgs args)
            {
                errorList[args.TrainingIteration] = ourNetwork.MeanSquaredError;
                maxError = Math.Max(maxError, ourNetwork.MeanSquaredError);
            };
            // nauka sieci
            ourNetwork.Learn(trainingSet, iterations);
            ourNetwork.StopLearning();
        }

        /// <summary>
        /// Utworzenie sieci neuronowej - neuronów w warstwach
        /// oraz zainicjalizowanie jej
        /// </summary>
        private void CreateNetwork()
        {
            // warstwa wejściowa
            LinearLayer inputLayer = new LinearLayer(INPUT_NUMBER);
            // lista warstw pośrednich
            List<SigmoidLayer> hiddenLayerList = new List<SigmoidLayer>();
            for (int i = 0; i < hiddenLayerCount; i++)
            {
                hiddenLayerList.Add(new SigmoidLayer(neuronCountList[i]));
            }
            // warstwa wyjściowa
            SigmoidLayer outputLayer = new SigmoidLayer(1);
            // wybór inicjalizatora połączeń
            IInitializer initFunction;
            switch (chosenInitializer)
            {
                case Initializer.None:
                default:
                    initFunction = null;
                    break;
                case Initializer.Constant:
                    initFunction = new ConstantFunction(initializerParameter1);
                    break;
                case Initializer.NgyuenWidrow:
                    initFunction = new NguyenWidrowFunction(initializerParameter1);
                    break;
                case Initializer.NormalizedRandom:
                    initFunction = new NormalizedRandomFunction();
                    break;
                case Initializer.Random:
                    initFunction = new RandomFunction(initializerParameter1, initializerParameter2);
                    break;
                case Initializer.Zero:
                    initFunction = new ZeroFunction();
                    break;
            }
            // połączenie warstw
            new BackpropagationConnector(inputLayer, hiddenLayerList[0]).Initializer = initFunction;
            for (int i = 1; i < hiddenLayerCount; i++)
            {
                new BackpropagationConnector(hiddenLayerList[i - 1], hiddenLayerList[i]).Initializer = initFunction;
            }
            new BackpropagationConnector(hiddenLayerList[hiddenLayerCount - 1], outputLayer).Initializer = initFunction;

            // przypisanie nowej sieci naszej
            this.ourNetwork = new BackpropagationNetwork(inputLayer, outputLayer);
        }

        /// <summary>
        /// Ustawienie naszej sieci odpowiedniej mocy poznawczej
        /// </summary>
        private void SetNetworkLearningRate()
        {
            switch (chosenFunction)
            {
                case Function.None:
                default:
                    this.ourNetwork.SetLearningRate(initialLearningRate, finalLearningRate);
                    break;
                case Function.Expotential:
                    this.ourNetwork.SetLearningRate(new ExponentialFunction(initialLearningRate, finalLearningRate));
                    break;
                case Function.Hyperbolic:
                    this.ourNetwork.SetLearningRate(new HyperbolicFunction(initialLearningRate, finalLearningRate));
                    break;
                case Function.Linear:
                    this.ourNetwork.SetLearningRate(new LinearFunction(initialLearningRate, finalLearningRate));
                    break;
            }
        }

        /// <summary>
        /// Wstępne przetwarzenie danych.
        /// Przygotowuje wykładniczą średnią kroczącą jako punkt odniesienia
        /// Dla N okresów, ostatni ma wartość n, z kolei ostatni 1
        /// W naszych plikach .CSV pierwszy okres jest ostatnim
        /// </summary>
        public void PrepareData(ExchangeData data, ExchangeData.SplitMethod method, int days = 7)
        {
            // podzielenie pliku na mniejsze części wg metody
            this.inputData = data.GetSplitData(method, days);

            // dla każdego pliku wejściowego
            for (int i = 0; i < inputData.Count; ++i)
            {
                // zmiana mapy na listę
                List<Double[]> list = inputData[i].Values.ToList();

                //obliczenie RSi dla kazdego pliku wejsciowego
                RSI.Add(calculateRSI(list));

                // obliczenie średnich każdego z kursów dziennych
                meanClose.Add(this.CalculateEMA(inputData[i], 0));
                meanHigh.Add(this.CalculateEMA(inputData[i], 1));
                meanLow.Add(this.CalculateEMA(inputData[i], 2));
                meanOpen.Add(this.CalculateEMA(inputData[i], 3));
                // pozyskanie ostatnich wartości kursów
                actualClose.Add(inputData[i].Last().Value[0]);
                actualHigh.Add(inputData[i].Last().Value[1]);
                actualLow.Add(inputData[i].Last().Value[2]);
                actualOpen.Add(inputData[i].Last().Value[3]);
                // pozyskanie wartości przewidywanej
                if (i != inputData.Count - 1)
                {
                    tomorrowClose.Add(inputData[i + 1].First().Value[0]);
                }
                else
                {
                    tomorrowClose.Add(inputData[i].Last().Value[0]);
                }
            }
        }

        /// <summary>
        /// Obliczenie wykładniczej średniej kroczącej
        /// Dla konkretnych danych kursu (Close = 1, Max = 2, Min = 3, Open = 4)
        /// </summary>
        private double CalculateEMA(Dictionary<DateTime, Double[]> input, int which)
        {
            if (input.Count == 1)
            {
                return input.Values.ToList().Last()[which];
            }
            int periodNumber = input.Count;
            double alpha = 2.0d / (periodNumber + 1);
            double numerator = 0.0d, denominator = 0.0d;
            // iterujemy od zera, czyli od najdawniejszego okresu
            int i = 0;
            foreach (var entry in input)
            {
                double weight = Math.Pow(1 - alpha, periodNumber - i);
                double value = entry.Value[which];
                numerator += value * weight;
                denominator += weight;
                ++i;
            }
            return numerator / denominator;
        }

        /// <summary>
        /// Obliczenie RSI
        /// RSI = 100 - 100/(1+ sredni wzrost/sredni spadek)
        /// </summary>
        private double calculateRSI(List<Double[]> input, int start = 0)
        {
            if (input.Count == 1)
            {
                return input.First()[0];
            }

            int periodNumber = input.Count - start;
            double alpha = 2.0d / (periodNumber + 1);
            double denominator = 0.0d;
            double avg_growth = 0.0d, avg_fall = 0.0d;
            List<double> growth = new List<double>();
            List<double> fall = new List<double>();

            // porównanie wartości Close pomiędzy kolejnymi dniami oraz obliczenie spadku/wzrostu
            for (int i = start; i < periodNumber - 1; ++i)
            {
                double weight = Math.Pow(1 - alpha, periodNumber - i);
                double value = input[i][0];
                double value_next = input[i + 1][0];
                if ((value - value_next) >= 0)
                    fall.Add((value - value_next) * weight);
                else
                    fall.Add(0);
                if ((value_next - value) >= 0)
                    growth.Add((value_next - value) * weight);
                else
                    growth.Add(0);

                denominator += weight;
            }

            //obliczanie sredniego spadku/wzrostu
            avg_fall = fall.Sum() / denominator;
            avg_growth = growth.Sum() / denominator;

            //oblicznie RSI
            double RSI = 100 - (100 / (1 + (avg_growth / avg_fall)));

            return RSI;
        }

        /// <summary>
        /// Uruchomienie sieci
        /// </summary>
        public float Run()
        {
            //tablica wyników przewidywan
            double[] result = new double[inputData.Count - trainingDataCount];
            //tablica booli: true - jesli wynik przewidywania i aktualne dane sie pokrywaja
            bool[] correctPredict = new bool[inputData.Count - trainingDataCount];
            int j = 0;
            //30% danych do testowania
            for (int i = trainingDataCount; i < inputData.Count; ++i)
            {
                result[j] = ourNetwork.Run(
                    new double[INPUT_NUMBER]
                    {
                        actualClose[i] - meanClose[i], actualHigh[i] - meanHigh[i], actualLow[i] - meanLow[i], actualOpen[i] - meanOpen[i], RSI[i]
                    })[0];

                if ((tomorrowClose[i] - actualClose[i]) > 0 && result[j] > 0)
                    correctPredict[j] = true;
                else if ((tomorrowClose[i] - actualClose[i]) <= 0 && result[j] <= 0)
                    correctPredict[j] = true;
                else
                    correctPredict[j] = false;
                j++;
            }

            int true_count = 0;

            for (int i = 0; i < correctPredict.Length; ++i)
                if (correctPredict[i])
                    true_count++;

            return ((float)true_count / (float)correctPredict.Length) * 100;
        }

        #endregion
    }
}
