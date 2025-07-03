using UnityEngine;

public class EnemyMovement : NewMonobehavior
{
    [SerializeField] protected Enemy_Controller enemy_Controller;
    [SerializeField] private float decisionInterval = 1.2f;
    [SerializeField] private float stopDistance = 1.5f;  
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

    protected override void Start()
    {
        this.enemy_Controller._agent.updateRotation = false;
        decisionTimer = decisionInterval;
    }

    private void Update()
    {
        decisionTimer -= Time.deltaTime;

        if (decisionTimer <= 0f)
        {
            PickRandomOffset();
            decisionTimer = decisionInterval;
        }

        MoveWithCondition();
        RotateTowardMoveDirection();
        UpdateAnimatorMoveParams();
    }

    private void PickRandomOffset()
    {
        int rand = Random.Range(0, 3);

        if (rand == 0)
            offsetDir = Vector3.zero;
        else if (rand == 1)
            offsetDir = -enemy_Controller.transform.right * 1f;
        else
            offsetDir = enemy_Controller.transform.right * 1f;
    }

    private void MoveWithCondition()
    {
        Vector3 playerPos = enemy_Controller._playerControllerr.transform.position;
        float distanceToPlayer = Vector3.Distance(enemy_Controller.transform.position, playerPos);

        if (distanceToPlayer > stopDistance)
        {
            enemy_Controller._agent.destination = playerPos + offsetDir;
        }
        else
        {
            if (enemy_Controller.isAttacking)
            {
                enemy_Controller._agent.destination = enemy_Controller.transform.position;
            }
            else
            {
                if (Random.value < 0.7f)
                {
                    offsetDir = Vector3.zero;
                }
                else
                {
                    PickRandomOffset();
                }
                Vector3 target = enemy_Controller.transform.position + offsetDir;
                enemy_Controller._agent.destination = target;
            }
        }
    }



    private void UpdateAnimatorMoveParams()
    {
        if (enemy_Controller.isAttacking)
        {
            enemy_Controller._anim.SetFloat("MoveX", 0f);
            enemy_Controller._anim.SetFloat("MoveY", 0f);
            return;
        }

        Vector3 velocity = enemy_Controller._agent.velocity;

        if (velocity.magnitude > 0.1f)
        {
            Vector3 localVelocity = enemy_Controller.transform.InverseTransformDirection(velocity);
            enemy_Controller._anim.SetFloat("MoveX", localVelocity.x, 0.1f, Time.deltaTime);
            enemy_Controller._anim.SetFloat("MoveY", localVelocity.z, 0.1f, Time.deltaTime);
        }
        else
        {
            enemy_Controller._anim.SetFloat("MoveX", 0f);
            enemy_Controller._anim.SetFloat("MoveY", 0f);
        }
    }

    private void RotateTowardMoveDirection()
    {
        Vector3 direction = enemy_Controller._playerControllerr.transform.position - enemy_Controller.transform.position;
        direction.y = 0;

        if (direction.sqrMagnitude > 0.01f)
        {
            Quaternion targetRot = Quaternion.LookRotation(direction);
            enemy_Controller.transform.rotation = Quaternion.Slerp(enemy_Controller.transform.rotation, targetRot, Time.deltaTime * 5f);
        }
    }

}
