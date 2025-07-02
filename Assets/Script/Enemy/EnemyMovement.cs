using UnityEngine;

public class EnemyMovement : NewMonobehavior
{
    [SerializeField] protected Enemy_Controller enemy_Controller;
    [SerializeField] private float decisionInterval = 2f;
    private float decisionTimer;

    private Vector3 offsetDir = Vector3.zero;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyController();
    }

    private void LoadEnemyController()
    {
        if (this.enemy_Controller != null) return;
        this.enemy_Controller = gameObject.GetComponentInParent<Enemy_Controller>();
    }

    private void Start()
    {
        this.enemy_Controller._agent.updateRotation = false;
        decisionTimer = decisionInterval;
    }

    private void Update()
    {
        decisionTimer -= Time.deltaTime;

        if (decisionTimer <= 0f)
        {
            PickRandomOffset(); // đổi hướng ngẫu nhiên
            decisionTimer = decisionInterval;
        }

        MoveToPlayerWithOffset();
        RotateTowardMoveDirection();
    }

    private void PickRandomOffset()
    {
        int rand = Random.Range(0, 3); // 0: thẳng, 1: lệch trái, 2: lệch phải

        if (rand == 0)
            offsetDir = Vector3.zero;
        else if (rand == 1)
            offsetDir = -enemy_Controller.transform.right * 1f; // lệch trái
        else
            offsetDir = enemy_Controller.transform.right * 1f; // lệch phải
    }

    private void MoveToPlayerWithOffset()
    {
        Vector3 playerPos = enemy_Controller._playerControllerr.transform.position;
        Vector3 target = playerPos + offsetDir;
        enemy_Controller._agent.destination = target;
    }

    private void RotateTowardMoveDirection()
    {
        Vector3 direction = enemy_Controller._agent.steeringTarget - transform.position;
        direction.y = 0;

        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * 5f);
        }
    }
}
