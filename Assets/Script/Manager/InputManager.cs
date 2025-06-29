using System;
using UnityEngine;

public class InputManager : NewMonobehavior
{
    public float swipeThreshold = 50f;
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;

    public static event Action OnTap;
    public static event Action<SwipeDirection> OnSwipe;

    protected void Update()
    {
        // Ưu tiên xử lý touch nếu có
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPos = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPos = touch.position;
                DetectInput();
            }
            return; // không xử lý chuột khi đang có touch
        }

    #if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetMouseButtonDown(0))
            startTouchPos = Input.mousePosition;

        if (Input.GetMouseButtonUp(0))
        {
            endTouchPos = Input.mousePosition;
            DetectInput();
        }
    #endif
    }

    private void DetectInput()
    {
        Vector2 delta = endTouchPos - startTouchPos;

        if (delta.magnitude < swipeThreshold)
        {
            //Debug.Log(">>> TAP Detected");
            OnTap?.Invoke();
        }
        else
        {
            SwipeDirection direction = DetectDirection(delta);
           // Debug.Log(">>> SWIPE Detected: " + direction);
            OnSwipe?.Invoke(direction);
        }
    }

    private SwipeDirection DetectDirection(Vector2 delta)
    {
        float angle = Mathf.Atan2(delta.y, delta.x) * Mathf.Rad2Deg;

        if (angle >= -22.5f && angle < 22.5f) return SwipeDirection.Right;
        if (angle >= 22.5f && angle < 67.5f) return SwipeDirection.UpRight;
        if (angle >= 67.5f && angle < 112.5f) return SwipeDirection.Up;
        if (angle >= 112.5f && angle < 157.5f) return SwipeDirection.UpLeft;
        if (angle >= 157.5f || angle < -157.5f) return SwipeDirection.Left;
        if (angle >= -157.5f && angle < -112.5f) return SwipeDirection.DownLeft;
        if (angle >= -112.5f && angle < -67.5f) return SwipeDirection.Down;
        if (angle >= -67.5f && angle < -22.5f) return SwipeDirection.DownRight;

        return SwipeDirection.None;
    }

    protected void OnDestroy()
    {
        
        OnTap = null;
        OnSwipe = null;
    }
    
}