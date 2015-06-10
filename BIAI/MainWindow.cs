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
        #region Wartości stałe
        /// <summary>
        /// Słownik netod nauki
        /// </summary>
        private readonly Dictionary<String, Function> functionDic = new Dictionary<String, Function>()
        {
            {"None", Function.None},
            {"Expotential", Function.Expotential},
            {"Hyperbolic", Function.Hyperbolic},
            {"Linear", Function.Linear}
        };
        /// <summary>
        /// Słownik sposobów inicjalizacji sieci
        /// </summary>
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

        private Network ourNetwork;
        private CsvParser parser;
        private ExchangeData data;
        private int selected_rsi_date = 0;

        public MainWindow()
        {
            // Utworzenie sieci
            ourNetwork = new Network();
            // inicjalizacja okna
            InitializeComponent();
            // przydzielenie pamięci
            this.parser = new CsvParser();
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
            // Przydzielenie sieci wartości z okna
            ourNetwork.Iterations = DecimalToInt32(this.trainingIterationsBox.Value);
            ourNetwork.Initializer = initializerDic[initializerBox.Text.ToString()];
            ourNetwork.LearningFunction = functionDic[this.functionBox.Text.ToString()];
            // rozpoczęcie nauki
            ourNetwork.Train();
            // narysowanie wykresu
            // uruchomienie grafu na nowo
            InitGraph(ourNetwork.Iterations);
            // utworzenie osi poziomej wykresu
            double[] indices = new double[ourNetwork.Iterations];
            for (int i = 0; i < ourNetwork.Iterations; i++)
            {
                indices[i] = i;
            }

            LineItem errorCurve = new LineItem("Differences", indices, ourNetwork.Errors, Color.GreenYellow, SymbolType.None, 1.5f);
            graph.GraphPane.YAxis.Scale.Max = ourNetwork.MaxError;
            graph.GraphPane.CurveList.Add(errorCurve);
            graph.Invalidate();
            // pobranie średniej wartości błędu w procentach
            double percentSSE = ourNetwork.MeanError * 100;
            this.meanSSEValue.Text = percentSSE.ToString("0.0000000") + '%';
        }

        /// <summary>
        /// Załadowanie wartości w okienku
        /// </summary>
        private void LoadWindow(object sender, EventArgs e)
        {
            this.monthlyButton.Checked = true;
            this.dailySampleBox.Visible = false;
            // przekazanie domyślnych wartości z okna do odpowiednich zmiennych z sieci
            ourNetwork.Iterations = DecimalToInt32(trainingIterationsBox.Value);
            ourNetwork.HiddenLayerCount = DecimalToInt32(hiddenLayerCountBox.Value);
            ChangeHiddenLayersNumber(ourNetwork.HiddenLayerCount);

            ourNetwork.InitialLearningRate = DecimalToDouble(initialLearningRateBox.Value);
            ourNetwork.FinalLearningRate = DecimalToDouble(finalLearningRateBox.Value);
            ourNetwork.FirstInitializerParameter = DecimalToDouble(initializerParameter1Box.Value);
            ourNetwork.SecondInitializerParameter = DecimalToDouble(initializerParameter2Box.Value);

            ourNetwork.NeuronCount[0] = DecimalToInt32(neuronCountBox1.Value);
            ourNetwork.NeuronCount[1] = DecimalToInt32(neuronCountBox2.Value);
            ourNetwork.NeuronCount[2] = DecimalToInt32(neuronCountBox3.Value);
            // narysowanie grafu
            InitGraph(ourNetwork.Iterations);
        }

        private void InitGraph(int scaleMax)
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
            pane.XAxis.Scale.Max = scaleMax;
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
            ourNetwork.HiddenLayerCount = DecimalToInt32(hiddenLayerCountBox.Value);
            ChangeHiddenLayersNumber(ourNetwork.HiddenLayerCount);
        }
        /// <summary>
        /// Zmiana liczby ukrytych warstw w sieci neuronowej
        /// </summary>
        /// <param name="number"></param>
        private void ChangeHiddenLayersNumber(int number)
        {
            switch (number)
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
        /// Wstępne przetwarzenie danych
        /// </summary>
        private void PrepareData()
        {
            // wyczyszczenie obecnych danych
            ourNetwork.EraseData();
            // podzielenie pliku na mniejsze części
            if (this.monthlyButton.Checked)
                ourNetwork.PrepareData(data, ExchangeData.SplitMethod.Monthly);
            else if (this.weeklyButton.Checked)
                ourNetwork.PrepareData(data, ExchangeData.SplitMethod.Weekly);
            else
                ourNetwork.PrepareData(data, ExchangeData.SplitMethod.Daily, Convert.ToInt32(dailySampleBox.Value));
        }

        /// <summary>
        /// Przycisk PREDICT AWAY!, próba przewidzenia jutrzejszego kursu walutowego
        /// </summary>
        private void predictButton_Click(object sender, EventArgs e)
        {
            if (ourNetwork != null)
            {
                this.predictionRespone.Items.Clear();
                float efficiency = ourNetwork.Run();
                this.predictionRespone.Items.Add("Sprawność sieci = " + Math.Ceiling(efficiency).ToString("0.0") + "%");
            }
        }

        /// <summary>
        /// Wybór opcji inicjalizacji sieci
        /// </summary>
        private void initializerBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ourNetwork.Initializer = this.initializerDic[this.initializerBox.Text.ToString()];
            switch (ourNetwork.Initializer)
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


        #region Reakcje na zmiany wartości boxów
        private void initialLearningRateBox_ValueChanged(object sender, EventArgs e)
        {
            ourNetwork.InitialLearningRate = DecimalToDouble(initialLearningRateBox.Value);
        }
        private void finalLearningRateBox_ValueChanged(object sender, EventArgs e)
        {
            ourNetwork.FinalLearningRate = DecimalToDouble(finalLearningRateBox.Value);
        }
        private void trainingIterationsBox_ValueChanged(object sender, EventArgs e)
        {
            ourNetwork.Iterations = DecimalToInt32(trainingIterationsBox.Value);
        }
        private void initializerParameter1Box_ValueChanged(object sender, EventArgs e)
        {
            ourNetwork.SecondInitializerParameter = DecimalToDouble(initializerParameter1Box.Value);
        }
        private void initializerParameter2Box_ValueChanged(object sender, EventArgs e)
        {
            ourNetwork.SecondInitializerParameter = DecimalToDouble(initializerParameter2Box.Value);
        }
        private void functionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ourNetwork.LearningFunction = functionDic[functionBox.Text.ToString()];
        }
        private void neuronCountBox1_ValueChanged(object sender, EventArgs e)
        {
            ourNetwork.NeuronCount[0] = DecimalToInt32(neuronCountBox1.Value);
        }
        private void neuronCountBox2_ValueChanged(object sender, EventArgs e)
        {
            ourNetwork.NeuronCount[1] = DecimalToInt32(neuronCountBox2.Value);
        }
        private void neuronCountBox3_ValueChanged(object sender, EventArgs e)
        {
            ourNetwork.NeuronCount[2] = DecimalToInt32(neuronCountBox3.Value);
        }
        #endregion

        private Double DecimalToDouble(Decimal input)
        {
            return Decimal.ToDouble(input);
        }
        private Int32 DecimalToInt32(Decimal input)
        {
            return Decimal.ToInt32(input);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
