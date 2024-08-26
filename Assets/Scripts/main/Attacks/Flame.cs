using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour //makes beings burn
{
    public Being being;
    public int reps = 4;
    public float damage = 5f;
    public float interval = 1f;
    public float timer;
    void Update()
    {
        if (timer <= 0f)
        {
            timer = interval;
            being.hp -= damage;
            if (being.hp <= 0f) Destroy(being.gameObject);
            reps--;
        }
        if (reps == 0) Destroy(this);
        timer -= Time.deltaTime;
    }
}
