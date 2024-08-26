using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistance : MovingType
{
    public float distance = 1f;
    public override void Update()
    {
        base.Update();
        direction = GameplayManager.playerTrans.position - transform.position;
        if (direction.magnitude < distance) direction = Vector3.zero;
        else direction.Normalize();
    }

    void FixedUpdate()
    {
        if (being.stun == 0f) rb.AddForce(direction * speed * Time.fixedDeltaTime); //if not stunned move in the dicrection with specified speed
    }
}
