using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPickup : MonoBehaviour
{
    public float amount = 50f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "player")
        {
            Being ben = collision.gameObject.GetComponent<Being>();
            if (ben.hp < ben.maxhp)
            {
                ben.hp = Mathf.Clamp(ben.hp + amount, 0f, ben.maxhp);
                Destroy(gameObject);
            }
        }
    }
}
