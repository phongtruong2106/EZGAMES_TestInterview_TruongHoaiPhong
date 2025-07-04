using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : NewMonobehavior, IMovable
{
    [SerializeField] protected Enemy_Controller enemy_Controller;
    [SerializeField] private float decisionInterval = 1.2f;
    [SerializeField] private float stopDistance = 1.5f;
    private float decisionTimer;
    private float targetSearchTimer;
    private float targetSearchInterval = 2f;
    private Vector3 offsetDir = Vector3.zero;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyController();
    }

    private void LoadEnemyController()
    {
        if (enemy_Controller != null) return;
        enemy_Controller = GetComponentInParent<Enemy_Controller>();
    }

    protected override void Start()
    {
        enemy_Controller._agent.updateRotation = false;
        decisionTimer = Random.Range(0f, decisionInterval);
        MovementManager.Instance?.Register(this);

        enemy_Controller._targetHandler.OnTargetFound += OnTargetAcquired;
    }

    private void OnDestroy()
    {
        if (MovementManager.Instance != null)
            MovementManager.Instance.Unregister(this);

        if (enemy_Controller._targetHandler != null)
            enemy_Controller._targetHandler.OnTargetFound -= OnTargetAcquired;
    }

    private void PickRandomOffset()
    {
        int rand = Random.Range(0, 3);
        offsetDir = rand switch
        {
            0 => Vector3.zero,
            1 => -enemy_Controller.transform.right * 1f,
            _ => enemy_Controller.transform.right * 1f
        };
    }

    private void MoveWithCondition()
    {
        var target = enemy_Controller._targetHandler?.GetTarget();
        if (target == null || !target.IsAlive()) return;

        Vector3 targetPos = target.GetTransform().position;
        float dist = Vector3.Distance(enemy_Controller.transform.position, targetPos);

        if (dist > stopDistance)
        {
            enemy_Controller._agent.destination = targetPos + offsetDir;
        }
        else
        {
            if (enemy_Controller.isAttacking)
            {
                enemy_Controller._agent.destination = enemy_Controller.transform.position;
            }
            else
            {
                offsetDir = (Random.value < 0.7f) ? Vector3.zero : GetRandomSideOffset();
                enemy_Controller._agent.destination = enemy_Controller.transform.position + offsetDir;
            }
        }

    }
    private void RotateTowardTarget()
    {
        var target = enemy_Controller._targetHandler?.GetTarget();
        if (target == null || !target.IsAlive()) return;

        Vector3 dir = target.GetTransform().position - enemy_Controller.transform.position;
        dir.y = 0;

        if (dir.sqrMagnitude > 0.01f)
        {
            Quaternion rot = Quaternion.LookRotation(dir);
            enemy_Controller.transform.rotation = Quaternion.Slerp(enemy_Controller.transform.rotation, rot, Time.deltaTime * 5f);
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
        if (velocity.sqrMagnitude > 0.01f)
        {
            Vector3 local = enemy_Controller.transform.InverseTransformDirection(velocity);
            enemy_Controller._anim.SetFloat("MoveX", local.x, 0.1f, Time.deltaTime);
            enemy_Controller._anim.SetFloat("MoveY", local.z, 0.1f, Time.deltaTime);
        }
        else
        {
            enemy_Controller._anim.SetFloat("MoveX", 0f);
            enemy_Controller._anim.SetFloat("MoveY", 0f);
        }
    }

    public void Tick(float deltaTime)
    {
        decisionTimer -= deltaTime;
        targetSearchTimer -= deltaTime;

        if (decisionTimer <= 0f)
        {
            PickRandomOffset();
            decisionTimer = decisionInterval;
        }

        if (targetSearchTimer <= 0f)
        {
            enemy_Controller._targetHandler?.FindNewTarget();
            targetSearchTimer = targetSearchInterval;
        }

        MoveWithCondition();
        RotateTowardTarget();
        UpdateAnimatorMoveParams();
    }
    private Vector3 GetRandomSideOffset()
    {
        int rand = Random.Range(0, 2);
        return (rand == 0)
            ? -enemy_Controller.transform.right * 1f
            : enemy_Controller.transform.right * 1f;
    }
    private void OnTargetAcquired(ITargetable target)
    {
        Debug.Log($"{gameObject.name} just found target: {target?.GetTransform().name ?? "null"}");
    }
}
