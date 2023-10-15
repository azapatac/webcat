using System.Collections.Generic;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Presentation.Views
{
    public sealed partial class CanvasPage : Page
    {
        public CanvasPage()
        {
            InitializeComponent();
            currentLinePoints = new List<Point>();
        }

        private Point? previousPoint;
        private List<Point> currentLinePoints;
        private Line currentLine;

        private void Canvas_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (e.Pointer.PointerDeviceType == PointerDeviceType.Mouse || e.Pointer.PointerDeviceType == PointerDeviceType.Pen)
            {
                currentLine = new Line
                {
                    Stroke = new SolidColorBrush(Windows.UI.Colors.Green),
                    StrokeThickness = 2
                };

                MyCanvas.Children.Add(currentLine);
                currentLinePoints.Clear();
                previousPoint = e.GetCurrentPoint(MyCanvas).Position;
                currentLinePoints.Add(previousPoint.Value);
            }
        }

        private void Canvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (currentLine != null)
            {
                Point currentPoint = e.GetCurrentPoint(MyCanvas).Position;
                currentLinePoints.Add(currentPoint);
                DrawSmoothCurve();
            }
        }

        private void Canvas_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            previousPoint = null;
            currentLine = null;
        }

        private void DrawSmoothCurve()
        {
            if (currentLinePoints.Count < 2)
                return;

            for (int i = 1; i < currentLinePoints.Count; i++)
            {
                Point p1 = currentLinePoints[i - 1];
                Point p2 = currentLinePoints[i];
                Line curveSegment = new Line
                {
                    Stroke = currentLine.Stroke,
                    StrokeThickness = currentLine.StrokeThickness,
                    X1 = p1.X,
                    Y1 = p1.Y,
                    X2 = p2.X,
                    Y2 = p2.Y
                };
                MyCanvas.Children.Add(curveSegment);
            }
        }
    }
}