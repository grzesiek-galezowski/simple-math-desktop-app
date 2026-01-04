namespace MathTextAssignments.States;

/// <summary>
/// State 1: Nieaktywna
/// </summary>
public class InactiveState : IFieldState
{
  public void Activate(FieldStateMachine context)
  {
    context.ActivateField();
    context.SetState(FieldStateType.ActiveEmpty);

  }

  public void HandleInput(char c, FieldStateMachine context)
  {
    throw new NotImplementedException();
  }

  public void ValidateCurrentValue(FieldStateMachine context)
  {
    throw new NotImplementedException();
  }

  public void Back(FieldStateMachine context)
  {
    throw new NotImplementedException();
  }
}