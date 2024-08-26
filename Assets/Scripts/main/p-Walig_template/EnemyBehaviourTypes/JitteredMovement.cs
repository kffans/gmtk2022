using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JitteredMovement : MovingType
{

    public float amount = 100000f;
    public float amountRandom = 50000f;
    public float interval = 5f;
    public float intervalRandom = 3f;
    float timer;

    public override void Update()
    {
        base.Update();
        if (timer <= 0)
        {
            Vector3 direct = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
            if (being.stun == 0f) rb.AddForce(direct * (amount + Random.Range(-amountRandom, amountRandom)));
            timer = interval + Random.Range(-intervalRandom, intervalRandom);
        }
        timer -= Time.deltaTime;
    }
}
