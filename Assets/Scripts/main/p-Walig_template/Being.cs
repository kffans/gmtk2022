using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Being : MonoBehaviour //template for everything that exists, has HP and stamina
{
    public GameObject healthbar;
    public float maxhp = 100f;
    public float hp = 100f;
    public float maxStamina = 100f;
    public float staminaRegeneration = 10f;
    [HideInInspector] public float stun;
    [HideInInspector] public float stamina;
    [HideInInspector] public float coolDown;

    public virtual void Start()
    {
        stamina = maxStamina;
    }

    public virtual void Update()
    {
        stamina = Mathf.Clamp(stamina + (Time.deltaTime * staminaRegeneration), 0f, maxStamina);
        stun = Mathf.Clamp(stun - Time.deltaTime, 0f, 10f);
        coolDown = Mathf.Clamp(coolDown - Time.deltaTime, 0f, 10f);
        healthbar.transform.localScale = new Vector3(hp / maxhp, 0.23f, 1f);
    }
}
