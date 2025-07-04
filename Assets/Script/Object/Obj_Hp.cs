using UnityEngine;

public class Obj_Hp : NewMonobehavior
{
    public int health = 100;

       public bool IsAlive()
    {
        return health > 0;
    }
}