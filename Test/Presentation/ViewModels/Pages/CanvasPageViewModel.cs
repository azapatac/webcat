using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using Windows.Devices.Input;
using Windows.Foundation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace Presentation.ViewModels
{
    public partial class CanvasPageViewModel : ObservableObject
    {
        private Point? previousPoint;
        private List<Point> currentLinePoints;
        private Line currentLine;

        public CanvasPageViewModel()
        {
            currentLinePoints = new List<Point>();
        }
        public void PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (e.Pointer.PointerDeviceType == PointerDeviceType.Mouse || e.Pointer.PointerDeviceType == PointerDeviceType.Pen)
            {
                currentLine = new Line
                {
                    Stroke = new SolidColorBrush(Windows.UI.Colors.Green),
                    StrokeThickness = 2
                };

                ((Canvas)sender).Children.Add(currentLine);
                currentLinePoints.Clear();
                previousPoint = e.GetCurrentPoint((Canvas)sender).Position;
                currentLinePoints.Add(previousPoint.Value);
            }
        }

        public void PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            if (currentLine != null)
            {
                Point currentPoint = e.GetCurrentPoint((Canvas)sender).Position;
                currentLinePoints.Add(currentPoint);

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
                    ((Canvas)sender).Children.Add(curveSegment);
                }
            }
        }

        public void PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            previousPoint = null;
            currentLine = null;
        }
    }
}