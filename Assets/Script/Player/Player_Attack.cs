using UnityEngine;

public class Player_Attack : NewMonobehavior
{
    [SerializeField] private PlayerControllerr playerControllerr;
    public float cooldownTime = 2f;
    public static int noOfClicks = 0;
    private float lastClickedTime = 0f;
    private float maxComboDelay = 1f;

    protected override void Start()
    {
        InputManager.OnTap += HandleAttack;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerController();
    }
    private void Update()
    {
        AnimatorStateInfo stateInfo = playerControllerr._anim.GetCurrentAnimatorStateInfo(0);

        if (Time.time - lastClickedTime > maxComboDelay)
        {
            noOfClicks = 0;
        }
        if (stateInfo.IsName("Attack1") && stateInfo.normalizedTime > 0.7f)
        {
            playerControllerr._anim.SetBool("Attack1", false);
        }

        if (stateInfo.IsName("Attack2") && stateInfo.normalizedTime > 0.7f)
        {
            playerControllerr._anim.SetBool("Attack2", false);
        }

        if (stateInfo.IsName("Attack3") && stateInfo.normalizedTime > 0.7f)
        {
            playerControllerr._anim.SetBool("Attack3", false);
            noOfClicks = 0;
        }

        HandleCombo(stateInfo);
    }
    private void LoadPlayerController()
    {
        if (this.playerControllerr != null) return;
        this.playerControllerr = gameObject.GetComponentInParent<PlayerControllerr>();
    }
    private void HandleAttack()
    {
        lastClickedTime = Time.time;
        noOfClicks++;
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);

        AnimatorStateInfo stateInfo = playerControllerr._anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsTag("MovementTree") || stateInfo.IsName("MovementTree"))
        {
            playerControllerr._anim.SetBool("Attack1", true);
            playerControllerr._obj_LoadBoxHit._HitBoxRight.SetAttackType(AttackType.KidneyL);
            playerControllerr._obj_LoadBoxHit._HitBoxLeft.SetAttackType(AttackType.KidneyL);
        }
    }

    private void HandleCombo(AnimatorStateInfo stateInfo)
    {
        if (noOfClicks >= 2 && stateInfo.IsName("Attack1") && stateInfo.normalizedTime > 0.7f)
        {
            playerControllerr._anim.SetBool("Attack1", false);
            playerControllerr._anim.SetBool("Attack2", true);
            playerControllerr._obj_LoadBoxHit._HitBoxRight.SetAttackType(AttackType.Head);
            playerControllerr._obj_LoadBoxHit._HitBoxLeft.SetAttackType(AttackType.Head);
        }

        if (noOfClicks >= 3 && stateInfo.IsName("Attack2") && stateInfo.normalizedTime > 0.7f)
        {
            playerControllerr._anim.SetBool("Attack2", false);
            playerControllerr._anim.SetBool("Attack3", true);
            playerControllerr._obj_LoadBoxHit._HitBoxRight.SetAttackType(AttackType.Stomach);
            playerControllerr._obj_LoadBoxHit._HitBoxLeft.SetAttackType(AttackType.Stomach);
        }
    }

    private void OnDestroy()
    {
        InputManager.OnTap -= HandleAttack;
    }
}