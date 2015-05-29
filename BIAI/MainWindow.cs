﻿using System;
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
using ZedGraph;
using Ideafixxxer.CsvParser;
using System.IO;

namespace BIAI
{
    public partial class MainWindow : Form
    {
        #region WARTOŚCI DOMYŚLNE
        /// <summary>
        /// domyślna liczba cykli treningowych
        /// </summary>
        private readonly int defaultIterations = 100;
        /// <summary>
        /// domyślna liczba ukrytych warstw
        /// </summary>
        private readonly int defaultHiddenLayerCount = 3;
        /// <summary>
        /// domyślna liczba neuronów
        /// </summary>
        private readonly int defaultNeuronCount = 3;
        /// <summary>
        /// domyślna wartość poznawcza (jakoś tak)
        /// </summary>
        private readonly double defaultLearningRate = 0.25d;
        /// <summary>
        /// Domyślna wartość dzisiejszego kursu
        /// </summary>
        private readonly double defaultTodayRate = 1.00000d;
        #endregion

        #region WARTOŚCI STAŁE
        /// <summary>
        /// minimalna liczba wartw pośrednich
        /// </summary>
        private readonly int HIDDEN_LAYER_MIN_COUNT = 1;
        /// <summary>
        /// maksymalna liczba wartw pośrednich
        /// </summary>
        private readonly int HIDDEN_LAYER_MAX_COUNT = 3;
        /// <summary>
        /// Liczba neuronów w warstywie wejściowej,
        /// musi być równa liczbie danych wejściowych
        /// </summary>
        private const int INPUT_NUMBER = 4;
        #endregion


        private BackpropagationNetwork ourNetwork;
        private double[] errorList;
        private int iterations;
        private int hiddenLayerCount;
        private List<int> neuronCountList;
        private double learningRate;

        private CsvParser parser;
        private List<string[][]> inputData;

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
        /// Wartość do obliczenia przez sieć - czy jest mniejszy lub większy
        /// </summary>
        List<double> tomorrowClose;
        #endregion


        #region
        /// <summary>
        /// Wartości dzisiejszego kursu, jako podstawa do obliczenia jutrzejszego
        /// </summary>
        double todayClose, todayHigh, todayLow, todayOpen;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            this.iterations = defaultIterations;
            this.hiddenLayerCount = HIDDEN_LAYER_MIN_COUNT;
            this.neuronCountList = new List<int>();
            for (int i = 0; i < HIDDEN_LAYER_MAX_COUNT; ++i)
            {
                neuronCountList.Add(defaultNeuronCount);
            }
            this.learningRate = defaultLearningRate;
            this.parser = new CsvParser();
            this.inputData = new List<string[][]>();
            // pamięć dla wartości z plików
            meanClose = new List<double>();
            meanHigh = new List<double>();
            meanLow = new List<double>();
            meanOpen = new List<double>();
            actualClose = new List<double>();
            actualHigh = new List<double>();
            actualLow = new List<double>();
            actualOpen = new List<double>();
            tomorrowClose = new List<double>();
            todayClose = todayHigh = todayLow = todayOpen = 1.00000;
        }

        /// <summary>
        /// Uruchomienie nauki sieci pleco-propagacji
        /// </summary>
        private void Train()
        {
            // ustawienie wartości
            this.ValidateInputValues();

            // ustawienie ich ponownie w textboxach w oknie
            trainingIterationsBox.Text = iterations.ToString();
            learningRateBox.Text = learningRate.ToString();
            neuronCountBox1.Text = neuronCountList[0].ToString();
            neuronCountBox2.Text = neuronCountList[1].ToString();
            neuronCountBox3.Text = neuronCountList[2].ToString();

            errorList = new double[iterations];
            InitGraph();

            // Utworzenie sieci neuronowej
            LinearLayer inputLayer = new LinearLayer(INPUT_NUMBER);
            List<SigmoidLayer> hiddenLayerList = new List<SigmoidLayer>();
            for (int i = 0; i < hiddenLayerCount; i++)
            {
                hiddenLayerList.Add(new SigmoidLayer(neuronCountList[i]));
            }
            SigmoidLayer outputLayer = new SigmoidLayer(1);
            new BackpropagationConnector(inputLayer, hiddenLayerList[0]);
            for (int i = 1; i < hiddenLayerCount; i++)
            {
                new BackpropagationConnector(hiddenLayerList[i - 1], hiddenLayerList[i]);
            }
            new BackpropagationConnector(hiddenLayerList[hiddenLayerCount - 1], outputLayer);
            this.ourNetwork = new BackpropagationNetwork(inputLayer, outputLayer);
            this.ourNetwork.SetLearningRate(learningRate);

            // zestaw treningowy XD *doxus face*
            TrainingSet trainingSet = new TrainingSet(4, 1);
            
            // próbki treningowe
            // każda próbka powstaje na podstawie jednego pliku
            for (int i = 0; i < inputData.Count; ++i)
            {
                trainingSet.Add(
                    new TrainingSample(
                        // wektorem wejściowym są różnice między aktualną wartością, a średnią
                        new double[INPUT_NUMBER]
                        {
                            actualClose[i] - meanClose[i], actualHigh[i] - meanHigh[i], actualLow[i] - meanLow[i], actualOpen[i] - meanOpen[i]
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
            // narysowanie wykresu
            LineItem errorCurve = new LineItem("Differences", indices, errorList, Color.GreenYellow, SymbolType.None, 1.5f);
            graph.GraphPane.YAxis.Scale.Max = max;
            graph.GraphPane.CurveList.Add(errorCurve);
            graph.Invalidate();
            // pobranie średniej wartości błędu w procentach
            double percentSSE = ourNetwork.MeanSquaredError * 100;
            this.meanSSEValue.Text = percentSSE.ToString("0.0000000") + '%';

            // Ustawienie jako dzisiejszych wartości z ostatniego pliku
            string[][] lastFile = inputData[inputData.Count - 1];
            string[]   lastValues = lastFile[lastFile.Length - 1];
            todayClose = Double.Parse(lastValues[1], CultureInfo.InvariantCulture);
            this.closeTextBox.Text = todayClose.ToString("0.00000");
            todayLow = Double.Parse(lastValues[2], CultureInfo.InvariantCulture);
            this.lowTextBox.Text = todayLow.ToString("0.00000");
            todayHigh = Double.Parse(lastValues[3], CultureInfo.InvariantCulture);
            this.highTextBox.Text = todayHigh.ToString("0.00000");
            todayOpen = Double.Parse(lastValues[4], CultureInfo.InvariantCulture);
            this.openTextBox.Text = todayOpen.ToString("0.00000");
        }

        /// <summary>
        /// Załadowanie wartości w okienku
        /// </summary>
        private void LoadWindow(object sender, EventArgs e)
        {
            InitGraph();
            this.trainingIterationsBox.Text = iterations.ToString();
            this.learningRateBox.Text = learningRate.ToString();
            this.hiddenLayerCountBox.Text = hiddenLayerCount.ToString();
            this.neuronCountBox1.Text = neuronCountList[0].ToString();
            this.neuronCountBox2.Text = neuronCountList[1].ToString();
            this.neuronCountBox3.Text = neuronCountList[2].ToString();
            this.closeTextBox.Text = todayClose.ToString("0.00000");
            this.lowTextBox.Text = todayLow.ToString("0.00000");
            this.highTextBox.Text = todayHigh.ToString("0.00000");
            this.openTextBox.Text = todayOpen.ToString("0.00000");
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
        /// Sprawdzenie, czy wpisane wartości przez użytkownika sa poprawne
        /// Jeśli nie, zostają zastąpione wartościami domyślnymi
        /// </summary>
        private void ValidateInputValues()
        {
            if (!int.TryParse(trainingIterationsBox.Text.Trim(), out iterations))
            {
                iterations = defaultIterations;
            }
            if (!double.TryParse(learningRateBox.Text.Trim(), out learningRate))
            {
                learningRate = defaultLearningRate;
            }
            if (neuronCountBox3.Enabled)
            {
                int result;
                if (!int.TryParse(neuronCountBox3.Text.Trim(), out result))
                    neuronCountList[2] = defaultNeuronCount;
                else
                    neuronCountList[2] = result;
            }
            if (neuronCountBox2.Enabled)
            {
                int result;
                if (!int.TryParse(neuronCountBox2.Text.Trim(), out result))
                    neuronCountList[1] = defaultNeuronCount;
                else
                    neuronCountList[1] = result;
            }
            if (neuronCountBox1.Enabled)
            {
                int result;
                if (!int.TryParse(neuronCountBox1.Text.Trim(), out result))
                    neuronCountList[0] = defaultNeuronCount;
                else
                    neuronCountList[0] = result;
            }
            
            if (iterations < 1)
            {
                iterations = 1;
            }
            if (learningRate < 0.01)
            {
                learningRate = 0.01;
            }
            for (int i = 0; i < HIDDEN_LAYER_MAX_COUNT; i++)
            {
                if (neuronCountList[i] < 1)
                {
                    neuronCountList[i] = 1;
                }
            }
        }

        /// <summary>
        /// Zmiana liczby ukrytych warstw
        /// W zależności od wartości blokuje inne textboxy z liczbami neuronów w warstwie
        /// </summary>
        private void hiddenLayerCountBox_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(hiddenLayerCountBox.Text.Trim(), out hiddenLayerCount))
            {
                hiddenLayerCount = HIDDEN_LAYER_MIN_COUNT;
            }
            if (hiddenLayerCount < 1) 
            {
                hiddenLayerCount = HIDDEN_LAYER_MIN_COUNT;
                this.hiddenLayerCountBox.Text = HIDDEN_LAYER_MIN_COUNT.ToString();
            }
            else if (hiddenLayerCount > 3)
            {
                hiddenLayerCount = HIDDEN_LAYER_MAX_COUNT;
                this.hiddenLayerCountBox.Text = HIDDEN_LAYER_MAX_COUNT.ToString();
            }
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
                case 1:
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
            if (inputData.Count > 0)
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
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    foreach (string filename in openFileDialog.FileNames)
                    {
                        using (StreamReader reader = File.OpenText(filename))
                        {
                            this.inputData.Add(this.parser.Parse(reader));
                            this.filesListBox.Items.Add(Path.GetFileName(filename) + '\n');
                        }
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
            // dla każdego pliku wejściowego
            foreach (string[][] inputFile in inputData)
            {
                // obliczenie średnich każdego z kursów dziennych
                meanClose.Add(this.CalculateEMA(inputFile, 1));
                meanHigh.Add(this.CalculateEMA(inputFile, 2));
                meanLow.Add(this.CalculateEMA(inputFile, 3));
                meanOpen.Add(this.CalculateEMA(inputFile, 4));
                // pozyskanie ostatnich wartości kursów
                actualClose.Add(Double.Parse(inputFile[inputFile.Length - 2][1], CultureInfo.InvariantCulture));
                actualHigh.Add(Double.Parse(inputFile[inputFile.Length - 2][2], CultureInfo.InvariantCulture));
                actualLow.Add(Double.Parse(inputFile[inputFile.Length - 2][3], CultureInfo.InvariantCulture));
                actualOpen.Add(Double.Parse(inputFile[inputFile.Length - 2][4], CultureInfo.InvariantCulture));
                // pozyskanie wartości przewidywanej
                tomorrowClose.Add(Double.Parse(inputFile[inputFile.Length - 1][1], CultureInfo.InvariantCulture));
            }
        }
        /// <summary>
        /// Obliczenie wykładniczej średniej kroczącej
        /// Dla konkretnych danych kursu (Close = 1, Max = 2, Min = 3, Open = 4)
        /// </summary>
        private double CalculateEMA(string[][] input, int which)
        {
            int periodNumber = input.Length;
            double alpha = 2.0d / (periodNumber + 1);
            double numerator = 0.0d, denominator = 0.0d;
            // iterujemy od zera, czyli od najdawniejszego okresu
            for (int i = 0; i < periodNumber - 1; ++i)
            {
                double weight = Math.Pow(1 - alpha, periodNumber - i);
                double value = Double.Parse(input[i][which], CultureInfo.InvariantCulture);
                numerator += value * weight;
                denominator += weight;
            }
            return numerator / denominator;
        }

        /// <summary>
        /// Przycisk PREDICT AWAY!, próba przewidzenia jutrzejszego kursu walutowego
        /// </summary>
        private void predictButton_Click(object sender, EventArgs e)
        {
            if (ourNetwork != null)
            {
                this.predictionRespone.Items.Clear();
                this.predictionRespone.Items.Add("Tomorrow, the close rate will be\n");
                double result = ourNetwork.Run(
                    new double[INPUT_NUMBER]
                    {
                        Double.Parse(closeTextBox.Text, CultureInfo.InvariantCulture),
					    Double.Parse(highTextBox.Text, CultureInfo.InvariantCulture),
                        Double.Parse(lowTextBox.Text, CultureInfo.InvariantCulture),
                        Double.Parse(openTextBox.Text, CultureInfo.InvariantCulture)
                    })[0];
                if (result >= 0.0000000d)
                {
                    this.predictionRespone.Items.Add("LARGER");
                }
                else
                {
                    this.predictionRespone.Items.Add("GREATER");
                }
            }
        }

        private void openTextBox_TextChanged(object sender, EventArgs e)
        {
            this.ParseDoubleBox(ref todayOpen, defaultTodayRate, value => openTextBox.Text = value, openTextBox.Text.Trim());
        }

        private void lowTextBox_TextChanged(object sender, EventArgs e)
        {
            this.ParseDoubleBox(ref todayLow, defaultTodayRate, value => lowTextBox.Text = value, lowTextBox.Text.Trim());
        }

        private void highTextBox_TextChanged(object sender, EventArgs e)
        {
            this.ParseDoubleBox(ref todayHigh, defaultTodayRate, value => highTextBox.Text = value, highTextBox.Text.Trim());
        }

        private void closeTextBox_TextChanged(object sender, EventArgs e)
        {
            this.ParseDoubleBox(ref todayClose, defaultTodayRate, value => closeTextBox.Text = value, closeTextBox.Text.Trim());
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
    }
}
