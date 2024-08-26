using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dasher : MovingType
{
    public float dash = 100000f;
    public float interval = 5f;
    float timer;

    private void Awake()
    {
        timer = Random.Range(0f, interval);
    }

    public override void Update()
    {
        base.Update();
        if (timer <= 0)
        {
            Vector3 direct = (GameplayManager.playerTrans.position - transform.position).normalized;
            if (being.stun == 0f) rb.AddForce(direct * dash * speed);
            timer = interval;
        }
        timer -= Time.deltaTime;
    }
}
