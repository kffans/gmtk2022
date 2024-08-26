using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDown : MonoBehaviour
{
    public MovingType being;
    public float amount = 5f;
    public float duration = 1f;
    void Update()
    {
        if (duration <= 0)
        {
            being.speed /= amount;
            Destroy(this);
        }
        duration -= Time.deltaTime;
    }
}
