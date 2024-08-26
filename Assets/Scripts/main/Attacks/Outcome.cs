using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* here the fun stuff will happen
 i mean different dice effects
if you want to code an effect: create new class derive from this one and override Affect function*/
[CreateAssetMenu(fileName = "new Outcome", menuName = "Outcome/Base")]
public class Outcome : ScriptableObject
{
    public AudioClip sound;
    public float radius = 50f;
    public float time = 1f;
    public float damage = 10f;
    public float stun = 1f;
    public float knockback = 500f;
    public List<Being> targets;
    public Sprite icon;
    public virtual void Perform(Vector3 position)
    {
        GameObject effect = Instantiate(GameplayManager.areaObj, position, new Quaternion(0f, 0f, 0f, 1f));
        effect.GetComponent<CircleCollider2D>().radius = radius;
        AreaCollector ar = effect.GetComponent<AreaCollector>();
        ar.time = time;
        ar.outcomeTemplate = this;
        Instantiate(GameplayManager.icon, position, new Quaternion(0f, 0f, 0f, 1f)).GetComponent<EffectIconPop>().sp.sprite = icon;
    }
    public virtual void Affect (Being target, Vector3 direction)
    {
        target.hp -= damage;
        target.stun += stun;
        target.gameObject.GetComponent<Rigidbody2D>().AddForce(direction.normalized * knockback);
        if (target.hp <= 0f) Destroy(target.gameObject);
    }

}
