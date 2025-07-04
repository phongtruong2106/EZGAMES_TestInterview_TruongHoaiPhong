using UnityEngine;

public class PlayerTargetable : NewMonobehavior, ITargetable
{
    [SerializeField] private EntityFaction faction = EntityFaction.Player;
    public EntityFaction Faction => faction;

    [SerializeField] private PlayerControllerr playerControllerr;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }
    protected override void Start()
    {
        base.Start();
        //Debug.Log($"[PlayerTargetable] Start(): Register target: {gameObject.name}");
        TargetManager.Instance?.Register(this);
    }
    private void LoadPlayerController()
    {
        if (this.playerControllerr != null) return;
        this.playerControllerr = gameObject.GetComponentInParent<PlayerControllerr>();
    }
    protected override void OnEnable()
    {
       // Debug.Log("Register target: " + gameObject.name);
        TargetManager.Instance?.Register(this);
    }

    private void OnDisable()
    {
        TargetManager.Instance?.Unregister(this);
    }

    public bool IsAlive()
    {
        return playerControllerr._player_HP != null && playerControllerr._player_HP.IsAlive();
    }

    public Transform GetTransform()
    {
        return transform;
    }
}