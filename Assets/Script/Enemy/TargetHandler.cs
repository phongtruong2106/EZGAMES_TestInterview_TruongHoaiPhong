using UnityEngine;

public class TargetHandler : MonoBehaviour, ITargeter
{
    public event System.Action<ITargetable> OnTargetFound;

    [SerializeField] private EntityFaction faction;
    public EntityFaction Faction => faction;

    private ITargetable currentTarget;

    public void FindNewTarget()
    {
        currentTarget = TargetManager.Instance.FindClosestTarget(this);

        if (currentTarget != null)
        {
            Debug.Log($"{gameObject.name} found target: {currentTarget.GetTransform().name}");
            OnTargetFound?.Invoke(currentTarget);
        }
        else
        {
            Debug.LogWarning($"{gameObject.name} could not find any target.");
        }
    }

    public ITargetable GetTarget() => currentTarget;

    public Transform GetTransform() => transform;
}
