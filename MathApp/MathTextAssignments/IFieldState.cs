using MathTextAssignments.States;

namespace MathTextAssignments;

/// <summary>
/// State - interfejs dla wszystkich stanów
/// </summary>
public interface IFieldState
{
  void Activate(FieldStateMachine context);
  void HandleInput(char c, FieldStateMachine context);
  void ValidateCurrentValue(FieldStateMachine context);
  void Back(FieldStateMachine context);
}