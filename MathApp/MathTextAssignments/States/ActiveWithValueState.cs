namespace MathTextAssignments.States;

/// <summary>
/// State 3: Aktywna z wartoœci¹
/// </summary>
public class ActiveWithValueState : IFieldState
{
  public void Activate(FieldStateMachine context)
  {
    context.ActivateField();
  }

  public void HandleInput(char c, FieldStateMachine context)
  {
    if (context.CanHandleMoreChars())
    {
      context.AddValue(c);
    }
  }

  public void ValidateCurrentValue(FieldStateMachine context)
  {
    if (context.IsValueAsExpected())
    {
      context.MarkAsValid();
    }
    else
    {
      context.MarkAsInvalid();
      context.SetState(FieldStateType.ErrorWithValue);
    }
  }

  public void Back(FieldStateMachine context)
  {
    context.RemoveLastChar();
  }
}