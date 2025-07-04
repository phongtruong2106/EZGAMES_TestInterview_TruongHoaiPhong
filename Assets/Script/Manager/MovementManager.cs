using System.Collections.Generic;
using UnityEngine;

public class MovementManager : NewMonobehavior
{
    public static MovementManager Instance { get; private set; }

    private readonly List<IMovable> movables = new List<IMovable>();

    protected override void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void Register(IMovable entity)
    {
        if (!movables.Contains(entity))
            movables.Add(entity);
    }

    public void Unregister(IMovable entity)
    {
        movables.Remove(entity);
    }

    private void Update()
    {
        float dt = Time.deltaTime;
        for (int i = 0; i < movables.Count; i++)
        {
            movables[i].Tick(dt);
        }
    }
}
