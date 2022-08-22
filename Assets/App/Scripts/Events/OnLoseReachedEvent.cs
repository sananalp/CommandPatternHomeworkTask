using DynamicBox.EventManagement;

public class OnLoseReachedEvent : GameEvent
{
    public bool IsLose;


    public OnLoseReachedEvent(bool isLose)
    {
        IsLose = isLose;
    }
}
