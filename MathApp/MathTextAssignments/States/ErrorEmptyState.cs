namespace MathTextAssignments.States;

/// <summary>
/// State 4: B³êdna pusta
/// </summary>
public class ErrorEmptyState : IFieldState //bug not used so far
{
  public void Activate(FieldStateMachine context)
  {
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