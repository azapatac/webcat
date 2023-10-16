using CommunityToolkit.Mvvm.ComponentModel;
using PropertyChanged;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
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
        public ICollection<Line> Lines { get; } = new ObservableCollection<Line>();
        [DoNotNotify]
        public Canvas MyCanvas { get; set; }
        [DoNotNotify]
        private Point? previousPoint;
        [DoNotNotify]
        private List<Point> currentLinePoints;
        [DoNotNotify]
        private Line currentLine { get; set; }

        public ICommand PointerMovedCommand { get; set; }
        public ICommand PointerPressedCommand { get; set; }
        public ICommand PointerReleasedCommand { get; set; }

        public CanvasPageViewModel()
        {
            MyCanvas = new Canvas();
            currentLinePoints = new List<Point>();
            PointerMovedCommand = new RelayCommand(PointerMoved);
            PointerPressedCommand = new RelayCommand(PointerPressed);
            PointerReleasedCommand = new RelayCommand(PointerReleased);
        }

        private void PointerPressed(object sender)
        {
            var e = (PointerRoutedEventArgs)sender;

            if (e!= null && e.Pointer.PointerDeviceType == PointerDeviceType.Mouse || e.Pointer.PointerDeviceType == PointerDeviceType.Pen)
            {
                currentLine = new Line
                {
                    Stroke = new SolidColorBrush(Windows.UI.Colors.Green),
                    StrokeThickness = 2
                };

                Lines.Add(currentLine);
                currentLinePoints.Clear();
                previousPoint = e.GetCurrentPoint(MyCanvas).Position;
                currentLinePoints.Add(previousPoint.Value);
            }
        }

        public void PointerMoved(object sender)
        {
            var e = (PointerRoutedEventArgs)sender;

            if (currentLine != null && e != null)
            {
                Point currentPoint = e.GetCurrentPoint(MyCanvas).Position;
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
                    Lines.Add(curveSegment);
                }
            }
        }

        public void PointerReleased(object sender)
        {
            previousPoint = null;
            currentLine = null;
        }
    }
}