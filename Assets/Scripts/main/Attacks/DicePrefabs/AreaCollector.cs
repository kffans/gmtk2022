using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaCollector : MonoBehaviour
{
    public Outcome outcomeTemplate;
    public float time = 1f;
    private void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0f) Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        outcomeTemplate.Affect(collision.gameObject.GetComponent<Being>(), collision.transform.position - transform.position);
    }
}
