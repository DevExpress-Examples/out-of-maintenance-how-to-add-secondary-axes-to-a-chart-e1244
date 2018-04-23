using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraCharts;
// ...

namespace SecondaryAxes {
    public partial class Form1: Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            // Create a new chart.
            ChartControl chartControl1 = new ChartControl();

            // Create two series.
            Series series1 = new Series("Series 1", ViewType.Bar);
            Series series2 = new Series("Series 2", ViewType.Line);

            // Add points to them, with their arguments different.
            series1.Points.Add(new SeriesPoint("A", 10));
            series1.Points.Add(new SeriesPoint("B", 12));
            series1.Points.Add(new SeriesPoint("C", 17));
            series1.Points.Add(new SeriesPoint("D", 14));
            series2.Points.Add(new SeriesPoint("I", 1500));
            series2.Points.Add(new SeriesPoint("II", 1800));
            series2.Points.Add(new SeriesPoint("III", 2500));
            series2.Points.Add(new SeriesPoint("IV", 3300));

            // Add both series to the chart.
            chartControl1.Series.AddRange(new Series[] { series1, series2 });

            // Hide the legend (optional).
            chartControl1.Legend.Visible = false;

            // Create two secondary axes, and add them to the chart's Diagram.
            SecondaryAxisX myAxisX = new SecondaryAxisX("my X-Axis");
            SecondaryAxisY myAxisY = new SecondaryAxisY("my Y-Axis");

            ((XYDiagram)chartControl1.Diagram).SecondaryAxesX.Add(myAxisX);
            ((XYDiagram)chartControl1.Diagram).SecondaryAxesY.Add(myAxisY);

            // Assign the series2 to the created axes.
            ((LineSeriesView)series2.View).AxisX = myAxisX;
            ((LineSeriesView)series2.View).AxisY = myAxisY;

            // Customize the appearance of the secondary axes (optional).
            myAxisX.Title.Text = "A Secondary X-Axis";
            myAxisX.Title.Visible = true;
            myAxisX.Title.TextColor = Color.Red;
            myAxisX.Label.TextColor = Color.Red;
            myAxisX.Color = Color.Red;

            myAxisY.Title.Text = "A Secondary Y-Axis";
            myAxisY.Title.Visible = true;
            myAxisY.Title.TextColor = Color.Blue;
            myAxisY.Label.TextColor = Color.Blue;
            myAxisY.Color = Color.Blue;

            // Add the chart to the form.
            chartControl1.Dock = DockStyle.Fill;
            this.Controls.Add(chartControl1);
        }

    }
}