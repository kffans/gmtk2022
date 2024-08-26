using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new Outcome", menuName = "Outcome/Slow")]

public class OutcomeSlow : Outcome
{
    public float duration = 3f;
    public float amount = 0.5f;
    public override void Affect(Being target, Vector3 direction)
    {
        base.Affect(target, direction);
        SlowDown slow = target.gameObject.AddComponent<SlowDown>();
        slow.amount = amount;
        slow.duration = duration;
        MovingType mov = target.gameObject.GetComponent<MovingType>();
        mov.speed *= amount;
        slow.being = mov;
    }
}
