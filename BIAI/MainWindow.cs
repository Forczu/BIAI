using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuronDotNet;
using NeuronDotNet.Core;
using NeuronDotNet.Core.Backpropagation;
using NeuronDotNet.Core.Initializers;
using NeuronDotNet.Core.LearningRateFunctions;
using ZedGraph;
using Ideafixxxer.CsvParser;
using System.IO;

namespace BIAI
{
    public partial class MainWindow : Form
    {
        #region Wartości domyślne
        /// <summary>
        /// Domyślna wartość dzisiejszego kursu
        /// </summary>
        private readonly double defaultTodayRate = 1.00000d;
        #endregion

        #region Wartości stałe
        /// <summary>
        /// minimalna liczba wartw pośrednich
        /// </summary>
        private const int HIDDEN_LAYER_MIN_COUNT = 1;
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
        /// Możliwe netody nauki
        /// </summary>
        public enum Function { None, Expotential, Hyperbolic, Linear };
        private readonly Dictionary<String, Function> functionDic = new Dictionary<String, Function>()
        {
            {"None", Function.None},
            {"Expotential", Function.Expotential},
            {"Hyperbolic", Function.Hyperbolic},
            {"Linear", Function.Linear}
        };
        /// <summary>
        /// Może sposoby inicjalizacji sieci
        /// </summary>
        public enum Initializer { None, Constant, NgyuenWidrow, NormalizedRandom, Random, Zero };
        private readonly Dictionary<String, Initializer> initializerDic = new Dictionary<String, Initializer>()
        {
            {"None", Initializer.None},
            {"Constant", Initializer.Constant},
            {"NgyuenWidrow", Initializer.NgyuenWidrow},
            {"NormalizedRandom", Initializer.NormalizedRandom},
            {"Random", Initializer.Random},
            {"Zero", Initializer.Zero}
        };
        #endregion

        private BackpropagationNetwork ourNetwork;
        private double[] errorList;
        private int iterations;
        private int hiddenLayerCount;
        private List<int> neuronCountList;
        private double initialLearningRate, finalLearningRate;
        private int trainingDataCount;

        private CsvParser parser;
        private List<Dictionary<DateTime, Double[]>> inputData;
        private ExchangeData data;
        private int selected_rsi_date = 0;

        private double initializerParameter1, initializerParameter2;

        #region Wartości do wstępnego przetworzenia
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


        #region Wartości dzisiejszego kursu
        /// <summary>
        /// Wartości dzisiejszego kursu, jako podstawa do obliczenia jutrzejszego
        /// </summary>
        double todayClose, todayHigh, todayLow, todayOpen, todayRSI;
        #endregion

        public MainWindow()
        {
            // inicjalizacja okna
            InitializeComponent();
            // przydzielenie pamięci dla obiektów
            this.neuronCountList = new List<int>();
            for (int i = 0; i < HIDDEN_LAYER_MAX_COUNT; ++i)
            {
                neuronCountList.Add(0);
            }
            this.parser = new CsvParser();
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
            todayClose = todayHigh = todayLow = todayOpen = todayRSI = 1.00000;
            // rodzaje metod nauki
            foreach (Function func in Enum.GetValues(typeof(Function)))
	        {
                this.functionBox.Items.Add(func.ToString());
	        }
            this.functionBox.Text = this.functionBox.Items[0].ToString();
            // rodzaje inicjalizatorów
            foreach (Initializer initializer in Enum.GetValues(typeof(Initializer)))
            {
                this.initializerBox.Items.Add(initializer);
            }
            this.initializerBox.Text = this.initializerBox.Items[0].ToString();
        }

        /// <summary>
        /// Uruchomienie nauki sieci pleco-propagacji
        /// </summary>
        private void Train()
        {
            errorList = new double[iterations];
            InitGraph();

            // Utworzenie sieci neuronowej
            this.CreateNetwork();

            // ustawienie mocy poznawczej
            this.SetNetworkLearningRate();

            // zestaw treningowy XD *doxus face*
            TrainingSet trainingSet = new TrainingSet(5, 1);
            
            // 70% danych do treningu
            trainingDataCount = (int)Math.Ceiling(inputData.Count * 0.7);

            // próbki treningowe
            // każda próbka powstaje na podstawie jednego pliku
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
            double max = 0.0d;
            ourNetwork.EndEpochEvent +=
            delegate(object network, TrainingEpochEventArgs args)
            {
                errorList[args.TrainingIteration] = ourNetwork.MeanSquaredError;
                max = Math.Max(max, ourNetwork.MeanSquaredError);
            };
            // nauka sieci
            ourNetwork.Learn(trainingSet, iterations);

            // utworzenie osi poziomej wykresu
            double[] indices = new double[iterations];
            for (int i = 0; i < iterations; i++) 
            {
                indices[i] = i;
            }
            ourNetwork.StopLearning();

            // narysowanie wykresu
            LineItem errorCurve = new LineItem("Differences", indices, errorList, Color.GreenYellow, SymbolType.None, 1.5f);
            graph.GraphPane.YAxis.Scale.Max = max;
            graph.GraphPane.CurveList.Add(errorCurve);
            graph.Invalidate();
            // pobranie średniej wartości błędu w procentach
            double percentSSE = ourNetwork.MeanSquaredError * 100;
            this.meanSSEValue.Text = percentSSE.ToString("0.0000000") + '%';

            // Ustawienie jako dzisiejszych wartości z ostatniej próbki
            //double[] lastValues = this.inputData.Last().Values.ToList().Last();
            //todayClose = lastValues[0];
            //this.closeTextBox.Text = todayClose.ToString("0.00000");
            //todayLow = lastValues[1];
            //this.lowTextBox.Text = todayLow.ToString("0.00000");
            //todayHigh = lastValues[2];
            //this.highTextBox.Text = todayHigh.ToString("0.00000");
            //todayOpen = lastValues[3];
            //this.openTextBox.Text = todayOpen.ToString("0.00000");
            //todayRSI = RSI.Last();
            //this.RSItextBox.Text = todayRSI.ToString("0.00");
            // ustawienie możliwości wyboru RSI
            //this.rsiDaysBox.Items.Clear();
            //List<DateTime> dtList = data.KeysToList();
            //for (int i = 1; i < dtList.Count - 1; ++i)
            //{
            //    this.rsiDaysBox.Items.Add(dtList[i].ToString("yy-MM-dd"));
            //}
            //this.selected_rsi_date = 0;
            //this.rsiDaysBox.Text = this.rsiDaysBox.Items[selected_rsi_date].ToString();
        }

        /// <summary>
        /// Załadowanie wartości w okienku
        /// </summary>
        private void LoadWindow(object sender, EventArgs e)
        {
            // narysowanie grafu
            InitGraph();
            this.monthlyButton.Checked = true;
            this.dailySampleBox.Visible = false;
            // przekazanie domyślnych wartości z okna do odpowiednich zmiennych
            DecimalToInt32(trainingIterationsBox.Value, ref iterations);
            DecimalToInt32(hiddenLayerCountBox.Value, ref hiddenLayerCount);
            ChangeHiddenLayersNumber(hiddenLayerCount);
            DecimalToDouble(initialLearningRateBox.Value, ref initialLearningRate);
            DecimalToDouble(finalLearningRateBox.Value, ref finalLearningRate);
            neuronCountList[0] = DecimalToInt32(neuronCountBox1.Value);
            neuronCountList[1] = DecimalToInt32(neuronCountBox2.Value);
            neuronCountList[2] = DecimalToInt32(neuronCountBox3.Value);
            DecimalToDouble(initializerParameter1Box.Value, ref initializerParameter1);
            DecimalToDouble(initializerParameter2Box.Value, ref initializerParameter2);
        }

        private void InitGraph()
        {
            GraphPane pane = graph.GraphPane;
            pane.Chart.Fill = new Fill(Color.Red, Color.BlueViolet, -45.0f);
            pane.Title.Text = "Graph";
            pane.XAxis.Title.Text = "Iteration Number";
            pane.YAxis.Title.Text = "Squared Error";
            pane.XAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.IsVisible = true;
            pane.YAxis.MajorGrid.Color = Color.LightGray;
            pane.XAxis.MajorGrid.Color = Color.LightGray;
            pane.XAxis.Scale.Max = this.iterations;
            pane.XAxis.Scale.Min = 0;
            pane.YAxis.Scale.Min = 0;
            pane.YAxis.Scale.Max = 0.5;
            pane.CurveList.Clear();
            pane.Legend.IsVisible = false;
            pane.AxisChange();
            graph.Invalidate();
        }

        /// <summary>
        /// Zmiana liczby ukrytych warstw
        /// W zależności od wartości blokuje inne textboxy z liczbami neuronów w warstwie
        /// </summary>
        private void hiddenLayerCountBox_ValueChanged(object sender, EventArgs e)
        {
            DecimalToInt32(hiddenLayerCountBox.Value, ref hiddenLayerCount);
            ChangeHiddenLayersNumber(hiddenLayerCount);
        }
        /// <summary>
        /// Zmiana liczby ukrytych warstw w sieci neuronowej
        /// </summary>
        /// <param name="number"></param>
        private void ChangeHiddenLayersNumber(int number)
        {
            switch (hiddenLayerCount)
            {
                case 3:
                    this.neuronCountBox3.Enabled = true;
                    this.neuronCountBox2.Enabled = true;
                    break;
                case 2:
                    this.neuronCountBox3.Enabled = false;
                    this.neuronCountBox2.Enabled = true;
                    break;
                case 1: default:
                    this.neuronCountBox3.Enabled = false;
                    this.neuronCountBox2.Enabled = false;
                    break;
            }
        }

        /// <summary>
        /// Przycisk START, rozpoczęcie treningu sieci
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startBtn_Click(object sender, EventArgs e)
        {
            if (data != null)
            {
                this.PrepareData();
                this.Train();
            }
        }

        /// <summary>
        /// Otworzenie nowych plików i zparsowanie ich
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "$(dir)";
            openFileDialog.Filter = "csv files (*.csv)|*.csv";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Multiselect = false;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.filesListBox.Items.Clear();
                try
                {
                    using (StreamReader reader = File.OpenText(openFileDialog.FileName))
                    {
                        this.data = new ExchangeData(this.parser.Parse(reader));
                        this.filesListBox.Items.Add(Path.GetFileName(openFileDialog.FileName) + '\n');
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Wstępne przetwarzenie danych.
        /// Przygotowuje wykładniczą średnią kroczącą jako punkt odniesienia
        /// Dla N okresów, ostatni ma wartość n, z kolei ostatni 1
        /// W naszych plikach .CSV pierwszy okres jest ostatnim
        /// </summary>
        private void PrepareData()
        {
            // podzielenie pliku na mniejsze części
            if (this.monthlyButton.Checked)
                inputData = this.data.GetSplitData(ExchangeData.SplitMethod.Monthly);
            else if (this.weeklyButton.Checked)
                inputData = this.data.GetSplitData(ExchangeData.SplitMethod.Weekly);
            else
                inputData = this.data.GetSplitData(ExchangeData.SplitMethod.Daily, Convert.ToInt32(dailySampleBox.Value));

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
        private double calculateRSI(List<Double[]> input)
        {
            if (input.Count == 1)
            {
                return input.First()[0];
            }

            int periodNumber = input.Count;
            double alpha = 2.0d / (periodNumber + 1);
            double denominator = 0.0d;
            double avg_growth = 0.0d, avg_fall = 0.0d;
            List<double> growth = new List<double>();
            List<double> fall = new List<double>();

            // porównanie wartości Close pomiędzy kolejnymi dniami oraz obliczenie spadku/wzrostu
            for (int i = 0; i < periodNumber - 1; ++i)
            {
                double weight = Math.Pow(1 - alpha, periodNumber - i);
                double value = input[i][0];
                double value_next = input[i + 1][0];
                if ((value - value_next) >= 0)
                    fall.Add((value - value_next)*weight);
                else
                    fall.Add(0);
                if ((value_next - value) >= 0)
                    growth.Add((value_next - value)*weight);
                else
                    growth.Add(0);

                denominator += weight;
            }

            //obliczanie sredniego spadku/wzrostu
            avg_fall = fall.Sum()/denominator;
            avg_growth = growth.Sum()/denominator;

            //oblicznie RSI
            double RSI = 100 - (100 / (1 + (avg_growth / avg_fall)));

            return RSI;
        }

        /// <summary>
        /// Przycisk PREDICT AWAY!, próba przewidzenia jutrzejszego kursu walutowego
        /// </summary>
        private void predictButton_Click(object sender, EventArgs e)
        {
            if (ourNetwork != null)
            {
                this.predictionRespone.Items.Clear();
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

                this.predictionRespone.Items.Add("Przewidziano " + true_count.ToString() + " na " + correctPredict.Length.ToString() + " dobrze ");

                /*
                this.predictionRespone.Items.Clear();
                this.predictionRespone.Items.Add("Tomorrow, the close rate will be\n");
                double result = ourNetwork.Run(
                    new double[INPUT_NUMBER]
                    {
                        Double.Parse(closeTextBox.Text, CultureInfo.InvariantCulture),
					    Double.Parse(highTextBox.Text, CultureInfo.InvariantCulture),
                        Double.Parse(lowTextBox.Text, CultureInfo.InvariantCulture),
                        Double.Parse(openTextBox.Text, CultureInfo.InvariantCulture),
                        Double.Parse(RSItextBox.Text, CultureInfo.InvariantCulture)
                    })[0];
                if (result > 0.0d)
                {
                    this.predictionRespone.Items.Add("GREATER");
                }
                else
                {
                    this.predictionRespone.Items.Add("LOWER");
                }*/
            }
        }

        /// <summary>
        /// Sprawdzenie poprawności konwersji string -> double,
        /// i przypisanie jej wskazanemu TextBoxowi
        /// </summary>
        /// <param name="value">gdzie wynik zostanie zapisany</param>
        /// <param name="defaultValue">wartość domyślna wyniku</param>
        /// <param name="where">miejsce (textbox), gdzie wartość ma być zapisana</param>
        /// <param name="strToParse">treść stringu</param>
        private void ParseDoubleBox(ref double value, double defaultValue, Action<string> where, string strToParse)
        {
            if (!double.TryParse(strToParse, out value))
            {
                todayOpen = defaultValue;
                where(todayOpen.ToString("0.00000"));
            }
        }

        /// <summary>
        /// Wybór opcji inicjalizacji sieci
        /// </summary>
        private void initializerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Initializer initializer = this.initializerDic[this.initializerBox.Text.ToString()];
            switch (initializer)
            {
                case Initializer.None:
                case Initializer.NormalizedRandom:
                case Initializer.Zero:
                default:
                    this.initializerParameter1Box.Visible = false;
                    this.initializerParameter2Box.Visible = false;
                    this.initializerParameter1Label.Text = String.Empty;
                    this.initializerParameter2Label.Text = String.Empty;
                    break;
                case Initializer.Constant:
                    this.initializerParameter1Box.Visible = true;
                    this.initializerParameter2Box.Visible = false;
                    this.initializerParameter1Label.Text = "Constant";
                    this.initializerParameter2Label.Text = String.Empty;
                    break;
                case Initializer.NgyuenWidrow:
                    this.initializerParameter1Box.Visible = true;
                    this.initializerParameter2Box.Visible = false;
                    this.initializerParameter1Label.Text = "Output range";
                    this.initializerParameter2Label.Text = String.Empty;
                    break;
                case Initializer.Random:
                    this.initializerParameter1Box.Visible = true;
                    this.initializerParameter2Box.Visible = true;
                    this.initializerParameter1Label.Text = "Min limit";
                    this.initializerParameter2Label.Text = "Max limit";
                    break;
            }
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
            Initializer initializer = this.initializerDic[initializerBox.Text.ToString()];
            switch (initializer)
            {
                case Initializer.None: default:
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
            Function func = this.functionDic[this.functionBox.Text.ToString()];
            switch (func)
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

        private double CalculateRSI(List<Double[]> input, int start)
        {
            if (input.Count == 1)
            {
                return input.First()[0];
            }

            int N = input.Count - start;
            double alpha = 2.0d / (N + 1);
            double denominator = 0.0d;
            double avg_growth = 0.0d, avg_fall = 0.0d;
            List<double> growth = new List<double>();
            List<double> fall = new List<double>();

            // porównanie wartości Close pomiędzy kolejnymi dniami oraz obliczenie spadku/wzrostu
            for (int i = start; i < input.Count - 1; ++i)
            {
                double weight = Math.Pow(1 - alpha, input.Count - i);
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

        private void dailyButton_CheckedChanged(object sender, EventArgs e)
        {
            if (dailyButton.Checked)
            {
                this.dailySampleBox.Visible = true;
            }
            else
            {
                this.dailySampleBox.Visible = false;
            }
        }

        private void initialLearningRateBox_ValueChanged(object sender, EventArgs e)
        {
            DecimalToDouble(initialLearningRateBox.Value, ref initialLearningRate);
        }
        private void finalLearningRateBox_ValueChanged(object sender, EventArgs e)
        {
            DecimalToDouble(finalLearningRateBox.Value, ref finalLearningRate);
        }
        private void trainingIterationsBox_ValueChanged(object sender, EventArgs e)
        {
            DecimalToInt32(trainingIterationsBox.Value, ref iterations);
        }
        private void initializerParameter1Box_ValueChanged(object sender, EventArgs e)
        {
            DecimalToDouble(initializerParameter1Box.Value, ref initializerParameter1);
        }
        private void initializerParameter2Box_ValueChanged(object sender, EventArgs e)
        {
            DecimalToDouble(initializerParameter2Box.Value, ref initializerParameter2);
        }
        private void DecimalToDouble(Decimal input, ref Double output)
        {
            output = Decimal.ToDouble(input);
        }
        private Double DecimalToDouble(Decimal input)
        {
            return Decimal.ToDouble(input);
        }
        private void DecimalToInt32(Decimal input, ref Int32 output)
        {
            output = Decimal.ToInt32(input);
        }
        private Int32 DecimalToInt32(Decimal input)
        {
            return Decimal.ToInt32(input);
        }
    }
}
