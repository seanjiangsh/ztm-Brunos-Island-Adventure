using RPG.Character;

namespace RPG.Character
{
  public abstract class AIBaseState
  {
    public abstract void EnterState(EmenyController enemy);
    public abstract void UpdateState(EmenyController enemy);
    public abstract void ExitState(EmenyController enemy);
  }
}