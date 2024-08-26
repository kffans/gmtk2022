using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Being //template for every enemy, attach to enemy object
{
    public float damage = 10f;
    public float knockback = 5f;
    [HideInInspector] public Rigidbody2D rb;

    public List<AudioClip> sounds;
    AudioSource ad;
    public float audioInterval = 0.3f;
    public float audioRandomness = 0.3f;
    float audioTimer;
    override public void Start()
    {
        base.Start();
        rb = gameObject.GetComponent<Rigidbody2D>();
        ad = gameObject.GetComponent<AudioSource>();
        audioTimer = audioInterval + Random.Range(-audioRandomness, audioRandomness);
    }

    public override void Update()
    {
        base.Update();

        audioTimer -= Time.deltaTime;
        if (audioTimer <= 0f)
        {
            ad.PlayOneShot(sounds[Random.Range(0, sounds.Count)]);
            audioTimer = audioInterval + Random.Range(-audioRandomness, audioRandomness);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            Being player = collision.gameObject.GetComponent<Being>();
            player.hp -= damage;
            if (player.hp <= 0f)
            {
                player.hp = 0f;
                GameplayManager.GameOver();
            }
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce((collision.gameObject.transform.position - transform.position) * knockback);
        }
    }
    private void OnDestroy()
    {
        ExitGate exitGate = FindObjectOfType<ExitGate>();
        if (exitGate != null)
        {
            exitGate.CheckIfOpen();
        }
    }
}
