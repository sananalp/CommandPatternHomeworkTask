using App.UI.Events;
using UnityEngine;
using DynamicBox.EventManagement;

public class LosePanelController : MonoBehaviour
{
    [SerializeField] private LosePanelView view;


    void OnEnable()
    {
        EventManager.Instance.AddListener<OnLoseReachedEvent>(OnGameStateChangeHandler);
    }
    void OnDisable()
    {
        EventManager.Instance.RemoveListener<OnLoseReachedEvent>(OnGameStateChangeHandler);
    }
    private void OnGameStateChangeHandler(OnLoseReachedEvent eventDetails)
    {
        view.gameObject.SetActive(eventDetails.IsLose);
    }
    public void OnReplayButtonClick()
    {
        EventManager.Instance.Raise(new OnReplayButtonClickedEvent());
    }
}
