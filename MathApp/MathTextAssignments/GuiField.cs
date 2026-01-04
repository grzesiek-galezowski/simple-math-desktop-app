using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MathTextAssignments;

public class GuiField(TextBlock textBlock, Border border, Color defaultColor, int limit)
{
  public void Reset()
  {
    textBlock.Text = "";
    border.BorderBrush = new SolidColorBrush(defaultColor);
    border.BorderThickness = new Thickness(2);
  }

  public void Deactivate()
  {
    border.BorderBrush = new SolidColorBrush(defaultColor);
    border.BorderThickness = new Thickness(2);
  }

  public void Activate()
  {
    border.BorderBrush = new SolidColorBrush(Color.FromRgb(13, 71, 161));
    border.BorderThickness = new Thickness(4);
  }

  public void AddCharacter(char c)
  {
    textBlock.Text += c;
  }

  public bool CanHandleMoreChars()
  {
    return textBlock.Text.Length < limit;
  }

  public void MarkAsInvalid()
  {
    border.BorderBrush = new SolidColorBrush(Color.FromRgb(244, 67, 54));
    border.BorderThickness = new Thickness(4);
  }

  public bool IsCurrentValueEqualTo(string currentProblemExpectedValue)
  {
    return textBlock.Text == currentProblemExpectedValue;
  }

  public void MarkAsValid()
  {
    border.BorderBrush = new SolidColorBrush(Color.FromRgb(76, 175, 80));
    border.BorderThickness = new Thickness(2);
  }

  public bool IsEmpty()
  {
    return textBlock.Text.Length == 0;
  }

  public void RemoveLastCharacter()
  {
    textBlock.Text = textBlock.Text[..^1];
  }

  public void ClearValue()
  {
    textBlock.Text = "";
  }
}