namespace MathTextAssignments;

public class ProblemManager
{
  private List<Problem> allProblems;
  private readonly List<int> usedIndices;
  private readonly Random random;

  public Problem CurrentProblem { get; private set; }

  public ProblemManager()
  {
    random = new Random();
    usedIndices = [];
    allProblems = AllProblems();
    GetNextProblem();
  }

  private static List<Problem> AllProblems()
  {
    return new List<Problem>
    {
      new("Zenek zerwa³ 1 jab³ko, a Asia 5 jab³ek. Ile jab³ek zebrali razem?", 1, '+', 5, "155\n555"),
      new("Corvax mia³ 5 komputerów i 1 mu siê zepsu³. Ile komputerów mu zosta³o?", 5, '-', 1, "55\n55X"),
      new("Ania ma 2 cukierki, Bartek da³ jej 3 cukierki. Ile cukierków ma teraz Ania?", 2, '+', 3, "23\n233"),
      new("W koszyku by³o 8 gruszek, Kasia zabra³a 2 z nich. Ile gruszek zosta³o w koszyku?", 8, '-', 2, "888X\n888X"),
      new("Tomek mia³ 3 znaczki, mama kupi³a mu jeszcze 4 znaczki. Ile znaczków ma teraz?", 3, '+', 4, "3344\n 344"),
      new("Na pó³ce by³o 9 ksi¹¿ek do przeczytania, Zosia przeczyta³a 3 z nich. Ile ksi¹¿ek zosta³o do przeczytania?", 9, '-', 3, "999X\n999XX"),
      new("Marek zdoby³ 1 punkt w ping ponga, a Jola zdoby³a 6 punktów. Ile zdobyli razem?", 1, '+', 6, "1666\n 666"),
      new("Pani Jola mia³a 7 chlebów, sprzeda³a 2 z nich. Ile jej zosta³o?", 7, '-', 2, " 77X\n777X"),
      new("W klasie siedz¹ 4 dziewczynki i 5 ch³opców. Ile dzieci siedzi w klasie?", 4, '+', 5, "44555\n4455"),
      new("Na drzewie siedzia³o 10 ptaków, 3 odlecia³y. Ile ptaków zosta³o na drzewie?", 10, '-', 3, "0000X\n000XX"),
      new("Piotrek zebra³ 2 kamyki, Micha³ zebra³ 7 kamyków. Ile zebrali razem?", 2, '+', 7, "2777\n27777"),
      new("Marta mia³a 9 kredek, 4 zgubi³a. Ile kredek ma teraz?", 9, '-', 4, " 99XX\n999XX"),
      new("W koszyku s¹ 3 jab³ka i 6 pomarañczy. Ile owoców razem jest w koszyku?", 3, '+', 6, "33666\n 3666"),
      new("Na talerzu by³o 10 ciastek, Kuba zjad³ 5. Ile ciastek zosta³o na talerzu?", 10, '-', 5, "00XXX\n000XX"),
      new("Janek ma 5 z³otych, a jego siostra da³a mu 3 z³ote. Ile ma teraz?", 5, '+', 3, "5553\n5533"),
      new("Pani mia³a 8 piórek, 3 z nich rozda³a uczniom. Ile piórek ma teraz?", 8, '-', 3, "888X\n88XX"),
      new("Mama kupi³a 4 banany i 5 jab³ek. Ile ³¹cznie owoców kupi³a?", 4, '+', 5, "44555\n4455"),
      new("W parku by³o 10 sprawnych ³awek, ale 2 z nich siê zepsu³y. Ile sprawnych ³awek zosta³o?", 10, '-', 2, "0000X\n0000X"),
      new("Staœ ma 6 klocków, a Kasia ma 2 klocki. Ile klocków maj¹ razem?", 6, '+', 2, "6662\n6662"),
      new("Babcia upiek³a 9 ciasteczek, wnuczek zjad³ 1. Ile ciasteczek zosta³o?", 9, '-', 1, "9999\n9999X"),
      new("W akwarium p³ywaj¹ 3 rybki czerwone i 4 rybki z³ote. Ile rybek p³ywa razem w akwarium?", 3, '+', 4, "3344\n 344"),
      new("Zuzia mia³a 7 naklejek, 2 da³a kole¿ance. Ile naklejek ma teraz?", 7, '-', 2, "777X\n 77X"),
      new("Kuba ma 1 pi³kê, a jego kolega ma 8 pi³ek. Ile pi³ek maj¹ razem?", 1, '+', 8, "18888\n 8888"),
      new("Na pó³ce by³o 10 jab³ek, 4 z nich zosta³y zjedzone. Ile jab³ek zosta³o?", 10, '-', 4, "000XX\n000XX"),
    };
  }

  public void GetNextProblem()
  {
    if (usedIndices.Count == allProblems.Count)
    {
      usedIndices.Clear();
    }

    int index;
    do
    {
      index = random.Next(allProblems.Count);
    } while (usedIndices.Contains(index));

    usedIndices.Add(index);
    CurrentProblem = allProblems[index];
  }
}