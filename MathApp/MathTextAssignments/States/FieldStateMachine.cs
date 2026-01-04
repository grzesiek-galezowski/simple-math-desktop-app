namespace MathTextAssignments.States;

/// <summary>
/// Context - zarz¹dza stanem i deleguje obs³ugê sygna³ów do stanów
/// </summary>
public class FieldStateMachine : IFieldStateContext
{
  private IFieldState _currentState;
  private readonly int _index;
  private readonly ProblemManager _problemManager;
  private readonly GuiField _guiField;
  private readonly MainWindow _mainWindow;
  private readonly bool _isFinal;

  public FieldStateMachine(int index, ProblemManager problemManager, GuiField guiField, MainWindow mainWindow,
    bool isFinal)
  {
    _index = index;
    _problemManager = problemManager;
    _guiField = guiField;
    _mainWindow = mainWindow;
    _isFinal = isFinal;
    SetState(FieldStateType.Inactive);
  }

  internal void SetState(FieldStateType newStateType)
  {
    _currentState = newStateType switch
    {
      FieldStateType.Inactive => new InactiveState(),
      FieldStateType.ActiveEmpty => new ActiveEmptyState(),
      FieldStateType.ActiveWithValue => new ActiveWithValueState(),
      FieldStateType.ErrorEmpty => new ErrorEmptyState(),
      FieldStateType.ErrorWithValue => new ErrorWithValueState(),
      _ => throw new InvalidOperationException("Unknown state")
    };
  }

  public void Reset()
  {
    _guiField.Reset();
    SetState(FieldStateType.Inactive);
  }

  //bug necessary to go through state?
  public void Activate()
  {
    _currentState.Activate(this);
  }

  public void ActivateField()
  {
    _guiField.Activate();
    if (_isFinal)
    {
      _mainWindow.ActivateFinalField();
    }
    else
    {
      _mainWindow.ActivateNonFinalField();
    }
  }

  public void Input(char c)
  {
    _currentState.HandleInput(c, this);
  }

  public void AddValue(char c)
  {
    _guiField.AddCharacter(c);
  }

  public bool CanHandleMoreChars()
  {
    return _guiField.CanHandleMoreChars();
  }

  public void ValidateCurrentField()
  {
    _currentState.ValidateCurrentValue(this);
  }

  public void MarkAsInvalid()
  {
    _guiField.MarkAsInvalid();

  }

  public bool IsValueAsExpected()
  {
    return _guiField.IsCurrentValueEqualTo(_problemManager.CurrentProblem.ExpectedValues[_index]);
  }

  public void MarkAsValid()
  {
    _guiField.MarkAsValid();
    if (_isFinal)
    {
      _mainWindow.CompleteProblem();
    }
    else
    {
      _mainWindow.MoveToNextFieldFrom(_index);
    }
  }

  public void Back()
  {
    _currentState.Back(this);
  }

  public void MoveToPreviousField()
  {
    if (_index != 0)
    {
      _guiField.Deactivate();
      _mainWindow.MoveToPreviousFieldFrom(_index);
    }
  }

  public void RemoveLastChar()
  {
    _guiField.RemoveLastCharacter();
    if (ValueIsEmpty())
    {
      SetState(FieldStateType.ActiveEmpty);
    }
    else
    {
      SetState(FieldStateType.ActiveWithValue);
    }
  }

  private bool ValueIsEmpty()
  {
    return _guiField.IsEmpty();
  }
}