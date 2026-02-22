using MathTextAssignments.States;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MathTextAssignments;

public partial class MainWindow : Window
{
  private readonly ProblemManager problemManager;
  private readonly FieldStateMachine[] fieldStates = new FieldStateMachine[4];
  private int currentFieldIndex = 0;
  private bool isProblemCompleted = false;

  public MainWindow()
  {
    InitializeComponent();
    problemManager = new ProblemManager();

    // Przechowuj referencje do granic pól

    fieldStates[0] = new FieldStateMachine(
      0,
      problemManager,
      new GuiField(Number1TextBlock, Number1Border, Color.FromRgb(33, 150, 243), 2),
      this,
      false);
    fieldStates[1] = new FieldStateMachine(
      1,
      problemManager,
      new GuiField(OperationTextBlock, OperationBorder, Color.FromRgb(245, 124, 0), 1),
      this,
      false);
    fieldStates[2] = new FieldStateMachine(
      2,
      problemManager,
      new GuiField(Number2TextBlock, Number2Border, Color.FromRgb(33, 150, 243), 2),
      this,
      false);
    fieldStates[3] = new FieldStateMachine(
      3,
      problemManager,
      new GuiField(ResultTextBlock, ResultBorder, Color.FromRgb(156, 39, 176), 2),
      this,
      true);

    // Obsługa klawisza Enter
    this.KeyDown += MainWindow_KeyDown;

    LoadProblem();
  }

  private void LoadProblem()
  {
    foreach (var fieldState in fieldStates)
    {
      fieldState.Reset();
    }

    isProblemCompleted = false;
    ActivateField(0);

    NextCheckButton.IsEnabled = true;
    NextCheckButton.Background = new SolidColorBrush(Color.FromRgb(76, 175, 80));

    // Reset tip display
    NumiconDisplay.Visibility = Visibility.Collapsed;
    NumiconDisplay.Tip = problemManager.CurrentProblem.Tip;
    TipButton.IsEnabled = !string.IsNullOrEmpty(problemManager.CurrentProblem.Tip);

    ProblemTextBlock.Text = problemManager.CurrentProblem.Text;
  }

  private void ActivateField(int fieldIndex)
  {
    currentFieldIndex = fieldIndex;
    fieldStates[fieldIndex].Activate();
    UpdateNumericButtonsState();
  }

  private void NumberButton_Click(object sender, RoutedEventArgs e)
  {
    if (isProblemCompleted)
      return;

    var button = sender as Button;
    var number = button?.Content as string;
    fieldStates[currentFieldIndex].Input(number[0]);
  }

  private void OperatorButton_Click(object sender, RoutedEventArgs e)
  {
    if (isProblemCompleted)
      return;

    var button = sender as Button;
    var number = button?.Content as string;
    fieldStates[currentFieldIndex].Input(number[0]);
  }

  private void DeleteButton_Click(object sender, RoutedEventArgs e)
  {
    if (isProblemCompleted)
      return;

    fieldStates[currentFieldIndex].Back();
    UpdateNumericButtonsState();
  }

  private void ClearButton_Click(object sender, RoutedEventArgs e) //bug
  {
    foreach (var fieldState in fieldStates)
    {
      fieldState.Reset();
    }
    ActivateField(0);
    UpdateNumericButtonsState();
  }

  private void NextCheckButton_Click(object sender, RoutedEventArgs e)
  {
    if (NextCheckButton.Content.ToString() == "Dalej →")
    {
      // Przejdź do następnego problemu
      problemManager.GetNextProblem();
      LoadProblem();
    }
    else
    {
      fieldStates[currentFieldIndex].ValidateCurrentField();
    }
  }

  private void UpdateNumericButtonsState()
  {
    var isInOperationField = currentFieldIndex == 1;
            
    var grid = FindChild<Grid>(this, "KeyboardGrid");
    if (grid != null)
    {
      foreach (var child in grid.Children)
      {
        if (child is Button button)
        {
          var content = button.Content?.ToString() ?? "";
          if (content.Length == 1 && char.IsDigit(content[0]))
          {
            button.Opacity = isInOperationField ? 0.4 : 1.0;
            button.IsEnabled = !isInOperationField;
          }
        }
      }
    }
  }

  private T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
  {
    if (parent == null)
      return null;

    for (var i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
    {
      var child = VisualTreeHelper.GetChild(parent, i);
                
      if (child is FrameworkElement fe && fe.Name == childName)
        return child as T;

      var result = FindChild<T>(child, childName);
      if (result != null)
        return result;
    }

    return null;
  }

  public void MoveToNextFieldFrom(int index)
  {
    ActivateField(index + 1);
  }

  public void MoveToPreviousFieldFrom(int index)
  {
    ActivateField(index - 1);
  }

  public void ActivateFinalField()
  {
    NextCheckButton.Content = "Sprawdź";
  }

  public void ActivateNonFinalField()
  {
    NextCheckButton.Content = "Następne pole";
  }

  public void CompleteProblem()
  {
    isProblemCompleted = true;
    NextCheckButton.Content = "Dalej →";
    NextCheckButton.Background = new SolidColorBrush(Color.FromRgb(76, 175, 80));
  }

  private void TipButton_Click(object sender, RoutedEventArgs e)
  {
    NumiconDisplay.Visibility = NumiconDisplay.Visibility == Visibility.Visible 
      ? Visibility.Collapsed 
      : Visibility.Visible;
  }

  private void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
  {
    if (e.Key == System.Windows.Input.Key.Enter)
    {
      e.Handled = true;
      NextCheckButton_Click(NextCheckButton, new RoutedEventArgs());
    }
  }
}