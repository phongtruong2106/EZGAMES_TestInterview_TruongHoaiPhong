using System.Collections;
using UnityEngine;

public class Obj_Movement : NewMonobehavior
{
    [SerializeField] private float moveDistance = 1f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] protected PlayerControllerr playerControllerr;
    [SerializeField] private Camera mainCamera;


    private Vector3 targetPosition;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }

    protected override void Start()
    {
        mainCamera = Camera.main;
        targetPosition = transform.position;
        SwipeDetector.SwipeEvent += HandleSwipe;
    }

    private void OnDestroy()
    {
        SwipeDetector.SwipeEvent -= HandleSwipe;
    }

    private void Update()
    {
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, targetPosition, moveSpeed * Time.deltaTime);
    }
    private void LoadPlayerController()
    {
        if (this.playerControllerr != null) return;
        this.playerControllerr = gameObject.GetComponentInParent<PlayerControllerr>();
    }

    private Vector3 GetCameraRelativeDirection(Vector3 inputDirection)
    {
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDir = inputDirection.z * forward + inputDirection.x * right;
        return moveDir.normalized;
    }

    private void HandleSwipe(SwipeDirection direction)
    {
        Vector3 inputDirection = Vector3.zero;

        switch (direction)
        {
            case SwipeDirection.Left:
                inputDirection = Vector3.left;
                break;
            case SwipeDirection.Right:
                inputDirection = Vector3.right;
                break;
            case SwipeDirection.Up:
                inputDirection = Vector3.forward;
                break;
            case SwipeDirection.Down:
                inputDirection = Vector3.back;
                break;
            case SwipeDirection.UpLeft:
                inputDirection = new Vector3(-1, 0, 1);
                break;
            case SwipeDirection.UpRight:
                inputDirection = new Vector3(1, 0, 1);
                break;
            case SwipeDirection.DownLeft:
                inputDirection = new Vector3(-1, 0, -1);
                break;
            case SwipeDirection.DownRight:
                inputDirection = new Vector3(1, 0, -1);
                break;
        }

        Vector3 moveDirection = GetCameraRelativeDirection(inputDirection);
        targetPosition += moveDirection * moveDistance;
    }



}