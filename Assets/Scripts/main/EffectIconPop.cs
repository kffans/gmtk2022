using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectIconPop : MonoBehaviour
{
    public float time = 1f;
    public SpriteRenderer sp;
    void Update()
    {
        sp.color = new Color(1f, 1f, 1f, time);
        time -= Time.deltaTime;
        if (time <= 0f) Destroy(gameObject);
    }
}
