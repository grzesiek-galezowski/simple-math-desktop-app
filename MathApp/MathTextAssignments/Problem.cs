namespace MathTextAssignments;

public class Problem
{
  public string Text { get; set; }
  public char Operation { get; set; }
  public int Number1 { get; set; }
  public int Number2 { get; set; }
  public int ExpectedResult { get; set; }
  public string Tip { get; set; } // Numicon bricks tip (e.g., "GGGGYY\nGGGGY")

  public Problem(string text, int number1, char operation, int number2, string tip = "")
  {
    Text = text;
    Number1 = number1;
    Operation = operation;
    Number2 = number2;
    ExpectedResult = operation == '+' ? number1 + number2 : number1 - number2;
    Tip = tip;
  }

  public string[] ExpectedValues =>
  [
    Number1.ToString(), Operation.ToString(), Number2.ToString(), ExpectedResult.ToString()
  ];
}