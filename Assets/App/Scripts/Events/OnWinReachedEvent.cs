using DynamicBox.EventManagement;

public class OnWinReachedEvent : GameEvent
{
    public bool IsWin;

    public OnWinReachedEvent(bool isWin)
    {
        IsWin = isWin;
    }
}