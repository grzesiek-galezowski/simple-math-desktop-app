using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MathTextAssignments;

public partial class NumiconBricksControl : UserControl
{
  public static readonly DependencyProperty TipProperty =
    DependencyProperty.Register(
      nameof(Tip),
      typeof(string),
      typeof(NumiconBricksControl),
      new PropertyMetadata("", OnTipChanged));

  public string Tip
  {
    get => (string)GetValue(TipProperty);
    set => SetValue(TipProperty, value);
  }

  public NumiconBricksControl()
  {
    InitializeComponent();
  }

  private static void OnTipChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    if (d is NumiconBricksControl control)
    {
      control.RenderBricks();
    }
  }

  private void RenderBricks()
  {
    if (BricksCanvas == null)
      return;

    BricksCanvas.Children.Clear();

    if (string.IsNullOrEmpty(Tip))
      return;

    var lines = Tip.Split('\n');
    const int brickSize = 20;
    const int spacing = 2;
    var y = 10;

    foreach (var line in lines)
    {
      var x = 10;
      foreach (var brick in line)
      {
        var color = brick switch
        {
          '1' => Color.FromRgb(255, 128, 0), 
          '2' => Color.FromRgb(171, 186, 225),
          '3' => Color.FromRgb(255, 204, 0),
          '4' => Color.FromRgb(102, 204, 0),
          '5' => Color.FromRgb(204, 0, 0),
          '6' => Color.FromRgb(0, 204, 204),
          '7' => Color.FromRgb(255, 102, 204),
          '8' => Color.FromRgb(0, 153, 0),
          '9' => Color.FromRgb(153, 51, 204),
          '0' => Color.FromRgb(0, 102, 204),
          'X' => Color.FromRgb(255, 255, 255),
          _ => Color.FromRgb(255, 255, 255)
        };

        var rect = new Rectangle
        {
          Width = brickSize,
          Height = brickSize,
          Fill = new SolidColorBrush(color),
          Stroke = new SolidColorBrush(Colors.Black),
          StrokeThickness = StrokeThickness(brick)
        };

        Canvas.SetLeft(rect, x);
        Canvas.SetTop(rect, y);
        BricksCanvas.Children.Add(rect);

        // Add strikethrough line for removed bricks
        if (brick == 'X')
        {
          var line_element = new Line
          {
            X1 = x,
            Y1 = y + brickSize / 2,
            X2 = x + brickSize,
            Y2 = y + brickSize / 2,
            Stroke = new SolidColorBrush(Colors.Black),
            StrokeThickness = 2
          };
          BricksCanvas.Children.Add(line_element);
        }

        x += brickSize + spacing;
      }

      y += brickSize + spacing;
    }
  }

  private static int StrokeThickness(char brick)
  {
    if (brick == 'X')
      return 2;
    if (brick == ' ')
      return 0;
    else
      return 1;
  }
}
