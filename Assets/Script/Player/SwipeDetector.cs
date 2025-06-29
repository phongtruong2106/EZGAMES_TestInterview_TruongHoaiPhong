using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : NewMonobehavior
{
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    public float swipeThreshold = 50f;

    public delegate void OnSwipeDetected(SwipeDirection direction);
    public static event OnSwipeDetected SwipeEvent;

    protected void Update()
    {
        // Touch (trên điện thoại)
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    endTouchPosition = touch.position;
                    DetectSwipe();
                    break;
            }
        }

        // Mouse (trên máy tính / trong Editor)
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            endTouchPosition = Input.mousePosition;
            DetectSwipe();
        }
#endif
    }

    private void DetectSwipe()
    {
        Vector2 delta = endTouchPosition - startTouchPosition;

        if (delta.magnitude > swipeThreshold)
        {
            float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;
            SwipeDirection direction = SwipeDirection.None;

            if (angle >= -22.5f && angle < 22.5f)
                direction = SwipeDirection.Right;
            else if (angle >= 22.5f && angle < 67.5f)
                direction = SwipeDirection.UpRight;
            else if (angle >= 67.5f && angle < 112.5f)
                direction = SwipeDirection.Up;
            else if (angle >= 112.5f && angle < 157.5f)
                direction = SwipeDirection.UpLeft;
            else if (angle >= 157.5f || angle < -157.5f)
                direction = SwipeDirection.Left;
            else if (angle >= -157.5f && angle < -112.5f)
                direction = SwipeDirection.DownLeft;
            else if (angle >= -112.5f && angle < -67.5f)
                direction = SwipeDirection.Down;
            else if (angle >= -67.5f && angle < -22.5f)
                direction = SwipeDirection.DownRight;

            SwipeEvent?.Invoke(direction);
        }
    }

}
