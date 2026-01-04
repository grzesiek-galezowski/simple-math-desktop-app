namespace MathTextAssignments.States;

/// <summary>
/// State 2: Aktywna pusta
/// </summary>
public class ActiveEmptyState : IFieldState
{
  public void Activate(FieldStateMachine context)
  {
    context.ActivateField();
  }

  public void HandleInput(char c, FieldStateMachine context)
  {
    context.AddValue(c);
    context.SetState(FieldStateType.ActiveWithValue);
  }

  public void ValidateCurrentValue(FieldStateMachine context)
  {
    context.MarkAsInvalid();
  }

  public void Back(FieldStateMachine context)
  {
    context.MoveToPreviousField();
  }
}