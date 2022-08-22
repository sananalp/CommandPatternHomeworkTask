using UnityEngine;

public class LosePanelView : MonoBehaviour
{
    [SerializeField] private LosePanelController controller;


    public void OnReplayButtonClick()
    {
        controller.OnReplayButtonClick();
    }
}
