using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Outcome", menuName = "Outcome/Flame")]
public class OutcomeFlame : Outcome
{
    public float interval = 1f;
    public int reps = 4;
    public override void Affect(Being target, Vector3 direction)
    {
        base.Affect(target, direction);
        target.hp += damage;
        Flame flame = target.gameObject.AddComponent<Flame>();
        flame.damage = damage;
        flame.interval = interval;
        flame.reps = reps;
        flame.being = target;
    }
}
