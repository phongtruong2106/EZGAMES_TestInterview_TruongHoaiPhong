using System.Collections;
using UnityEngine;

public class Obj_Movement : NewMonobehavior
{  
    private Vector3 targetPosition;
    
    [SerializeField] private float moveDistance = 1f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Camera mainCamera;
    [SerializeField] protected PlayerControllerr playerControllerr;
    public bool isDontMove;

    protected override void Start()
    {
        base.Start();
        mainCamera = Camera.main;
        targetPosition = transform.position;
        InputManager.OnSwipe += HandleSwipe;
    }

    private void FixedUpdate()
    {
        this.Move();
    }
    private void Move()
    {
        if (playerControllerr._characterController == null) return;

        Vector3 currentPosition = playerControllerr._characterController.transform.position;
        Vector3 direction = targetPosition - currentPosition;
        direction.y = 0;

        Vector3 move = Vector3.zero;

        if (direction.magnitude > 0.05f)
        {
            move = direction.normalized * moveSpeed * Time.fixedDeltaTime;
        }
        move.y += Physics.gravity.y * Time.fixedDeltaTime;

        playerControllerr._characterController.Move(move);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }

    private void LoadPlayerController()
    {
        if (this.playerControllerr != null) return;
        this.playerControllerr = gameObject.GetComponentInParent<PlayerControllerr>();
    }

    private void HandleSwipe(SwipeDirection dir)
    {
        Debug.Log("Move to direction: " + dir);
        Vector3 inputDirection = Vector3.zero;

        switch (dir)
        {
            case SwipeDirection.Left:       inputDirection = Vector3.left; break;
            case SwipeDirection.Right:      inputDirection = Vector3.right; break;
            case SwipeDirection.Up:         inputDirection = Vector3.forward; break;
            case SwipeDirection.Down:       inputDirection = Vector3.back; break;
            case SwipeDirection.UpLeft:     inputDirection = new Vector3(-1, 0, 1); break;
            case SwipeDirection.UpRight:    inputDirection = new Vector3(1, 0, 1); break;
            case SwipeDirection.DownLeft:   inputDirection = new Vector3(-1, 0, -1); break;
            case SwipeDirection.DownRight:  inputDirection = new Vector3(1, 0, -1); break;
        }

        Vector3 moveDirection = GetCameraRelativeDirection(inputDirection);
        targetPosition += moveDirection * moveDistance;

        playerControllerr._anim.SetFloat("MoveX", inputDirection.x);
        playerControllerr._anim.SetFloat("MoveY", inputDirection.z);

        StartCoroutine(ResetMoveParams());
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

    private IEnumerator ResetMoveParams()
    {
        yield return new WaitForSeconds(0.5f);
        playerControllerr._anim.SetFloat("MoveX", 0f);
        playerControllerr._anim.SetFloat("MoveY", 0f);
    }

    private void OnDestroy()
    {
        InputManager.OnSwipe -= HandleSwipe;
    }
}
