namespace MathTextAssignments.States;

/// <summary>
/// State 5: B³êdna z wartoœci¹
/// </summary>
public class ErrorWithValueState : IFieldState
{
  public void Activate(FieldStateMachine context)
  {
    throw new InvalidOperationException();
  }

  public void HandleInput(char c, FieldStateMachine context)
  {
    context.Reset();
    context.ActivateField();
    context.AddValue(c);
    context.SetState(FieldStateType.ActiveWithValue);
  }

  public void ValidateCurrentValue(FieldStateMachine context)
  {
    context.MarkAsInvalid();
  }

  public void Back(FieldStateMachine context)
  {
    context.RemoveLastChar();
  }
}