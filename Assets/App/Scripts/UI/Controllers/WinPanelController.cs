using UnityEngine;
using DynamicBox.EventManagement;
using App.UI.Events;

public class WinPanelController : MonoBehaviour
{
    [SerializeField] private WinPanelView view;


    void OnEnable()
    {
        EventManager.Instance.AddListener<OnWinReachedEvent>(OnGameStateChangeHandler);
    }
    void OnDisable()
    {
        EventManager.Instance.RemoveListener<OnWinReachedEvent>(OnGameStateChangeHandler);
    }
    private void OnGameStateChangeHandler(OnWinReachedEvent eventDetails)
    {
        view.gameObject.SetActive(eventDetails.IsWin);
    }
    public void OnReplayButtonClick()
    {
        EventManager.Instance.Raise(new OnReplayButtonClickedEvent());
    }
}