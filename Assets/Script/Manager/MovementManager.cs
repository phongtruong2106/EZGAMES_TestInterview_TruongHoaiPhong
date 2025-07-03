using System.Collections.Generic;
using UnityEngine;

public class MovementManager : NewMonobehavior
{
    // public static MovementManager Instance { get; private set; }

    // [SerializeField] private float decisionInterval = 1.2f;
    // private float timer;

    // private readonly List<EnemyMovement> movables = new();

    // protected override void Awake()
    // {
    //     if (Instance != null && Instance != this) Destroy(this);
    //     else Instance = this;
    // }

    // public void Register(IMovable movable)
    // {
    //     if (movable is EnemyMovement enemy && !movables.Contains(enemy))
    //     {
    //         movables.Add(enemy);
    //     }
    // }

    // public void Unregister(IMovable movable)
    // {
    //     if (movable is EnemyMovement enemy)
    //     {
    //         movables.Remove(enemy);
    //     }
    // }

    // private void Update()
    // {
    //     timer -= Time.deltaTime;
    //     if (timer <= 0f)
    //     {
    //         foreach (var enemy in movables)
    //         {
    //             enemy.UpdateOffset();
    //         }
    //         timer = decisionInterval;
    //     }

    //     foreach (var enemy in movables)
    //     {
    //         if (enemy == null) continue;

    //         var controller = enemy.GetComponent<Enemy_Controller>();
    //         if (controller == null) continue;

    //         Vector3 target = controller._playerControllerr.transform.position;
    //         if (enemy.ShouldMove())
    //             target += enemy.GetOffset();
    //         else
    //             target = enemy.transform.position + enemy.GetOffset();

    //         enemy.SetDestination(target);
    //         Vector3 dir = controller._playerControllerr.transform.position - controller.transform.position;
    //         dir.y = 0;
    //         if (dir.sqrMagnitude > 0.01f)
    //         {
    //             Quaternion rot = Quaternion.LookRotation(dir);
    //             controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, rot, Time.deltaTime * 5f);
    //         }
    //     }
    // }
}
