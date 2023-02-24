using UnityEngine;

public class TouchTracker : MonoBehaviour
{
    public static bool LeftSidePressed { get; private set; }
    public static bool RightSidePressed { get; private set; }
	private void Update() {
        LeftSidePressed = false;
        RightSidePressed = false;
        for (int i = 0; i < Input.touchCount; i++) {

            if (Input.touches[i].position.x < Screen.width / 2) {
                LeftSidePressed = true;
            }
            else if (Input.touches[i].position.x > Screen.width / 2)
                RightSidePressed = true;
        }
    }
}
