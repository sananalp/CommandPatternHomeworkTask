using UnityEngine;

public class WinPanelView : MonoBehaviour
{
    [SerializeField] private WinPanelController controller;


    public void OnReplayButtonClick()
    {
        controller.OnReplayButtonClick();
    }
}
