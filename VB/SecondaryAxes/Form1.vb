Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
' ...

Namespace SecondaryAxes
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Create a new chart.
			Dim chartControl1 As New ChartControl()

			' Create two series.
			Dim series1 As New Series("Series 1", ViewType.Bar)
			Dim series2 As New Series("Series 2", ViewType.Line)

			' Add points to them, with their arguments different.
			series1.Points.Add(New SeriesPoint("A", 10))
			series1.Points.Add(New SeriesPoint("B", 12))
			series1.Points.Add(New SeriesPoint("C", 17))
			series1.Points.Add(New SeriesPoint("D", 14))
			series2.Points.Add(New SeriesPoint("I", 1500))
			series2.Points.Add(New SeriesPoint("II", 1800))
			series2.Points.Add(New SeriesPoint("III", 2500))
			series2.Points.Add(New SeriesPoint("IV", 3300))

			' Add both series to the chart.
			chartControl1.Series.AddRange(New Series() { series1, series2 })

			' Hide the legend (optional).
			chartControl1.Legend.Visible = False

			' Create two secondary axes, and add them to the chart's Diagram.
			Dim myAxisX As New SecondaryAxisX("my X-Axis")
			Dim myAxisY As New SecondaryAxisY("my Y-Axis")

			CType(chartControl1.Diagram, XYDiagram).SecondaryAxesX.Add(myAxisX)
			CType(chartControl1.Diagram, XYDiagram).SecondaryAxesY.Add(myAxisY)

			' Assign the series2 to the created axes.
			CType(series2.View, LineSeriesView).AxisX = myAxisX
			CType(series2.View, LineSeriesView).AxisY = myAxisY

			' Customize the appearance of the secondary axes (optional).
			myAxisX.Title.Text = "A Secondary X-Axis"
			myAxisX.Title.Visible = True
			myAxisX.Title.TextColor = Color.Red
			myAxisX.Label.TextColor = Color.Red
			myAxisX.Color = Color.Red

			myAxisY.Title.Text = "A Secondary Y-Axis"
			myAxisY.Title.Visible = True
			myAxisY.Title.TextColor = Color.Blue
			myAxisY.Label.TextColor = Color.Blue
			myAxisY.Color = Color.Blue

			' Add the chart to the form.
			chartControl1.Dock = DockStyle.Fill
			Me.Controls.Add(chartControl1)
		End Sub

	End Class
End Namespace