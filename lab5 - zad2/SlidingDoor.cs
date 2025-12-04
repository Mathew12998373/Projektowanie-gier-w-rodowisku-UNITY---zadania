using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform leftPanel;
    public Transform rightPanel;

    public Transform leftClosedPosition;
    public Transform rightClosedPosition;
    public Transform leftOpenPosition;
    public Transform rightOpenPosition;

    public float openSpeed = 2f;

    private bool _open = false;

    void Update()
    {
        if (leftPanel != null && leftClosedPosition != null && leftOpenPosition != null)
        {
            Transform targetL = _open ? leftOpenPosition : leftClosedPosition;
            leftPanel.position = Vector3.MoveTowards(leftPanel.position, targetL.position, openSpeed * Time.deltaTime);
        }

        if (rightPanel != null && rightClosedPosition != null && rightOpenPosition != null)
        {
            Transform targetR = _open ? rightOpenPosition : rightClosedPosition;
            rightPanel.position = Vector3.MoveTowards(rightPanel.position, targetR.position, openSpeed * Time.deltaTime);
        }
    }

    public void SetOpen(bool value)
    {
        _open = value;
    }
}
