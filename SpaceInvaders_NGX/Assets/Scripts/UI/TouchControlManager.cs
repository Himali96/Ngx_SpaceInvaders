using UnityEngine;

public class TouchControlManager : MonoBehaviour
{
    public PlayerController playerController;

    public void OnLeftPointerDown()
    {
        playerController.isLeftButtonPressed = true;
    }

    public void OnRightPointerDown()
    {
        playerController.isRightButtonPressed = true;
    }

    public void OnLeftPointerUp()
    {
        playerController.isLeftButtonPressed = false;
    }

    public void OnRightPointerUp()
    {
        playerController.isRightButtonPressed = false;
    }
}
