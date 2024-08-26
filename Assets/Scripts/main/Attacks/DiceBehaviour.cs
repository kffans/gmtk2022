using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceBehaviour : MonoBehaviour
{
    public Dice diceTemplate;
    public Rigidbody2D rb;
    bool toUse = true;
    float vel = 0f;

    public List<AudioClip> pickSounds;

    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = diceTemplate.color;
    }

    private void Update() //checking if dice stopped rolling
    {
        if (rb.velocity.magnitude < vel && rb.velocity.magnitude <= 10f && toUse)
        {
            Outcome otc = diceTemplate.Roll();
            otc.Perform(transform.position);
            GameplayManager.ad.PlayOneShot(otc.sound);
            toUse = false;
            gameObject.GetComponent<Collider2D>().isTrigger = true;
        }
        vel = rb.velocity.magnitude;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            PlayerAction pac = collision.gameObject.GetComponent<PlayerAction>();
            if (!pac.dice.Contains(diceTemplate))
            {
                for (int i = 0; i < pac.dice.Count; i++)
                {
                    if (!pac.dice[i].ready)
                    {
                        pac.dice[i] = diceTemplate;
                        diceTemplate.ready = true;
                        collision.gameObject.GetComponent<AudioSource>().PlayOneShot(pickSounds[Random.Range(0, pickSounds.Count)]);
                        Destroy(this.gameObject);
                        break;
                    }
                }
            }
            else
            {
                diceTemplate.ready = true;
                collision.gameObject.GetComponent<AudioSource>().PlayOneShot(pickSounds[Random.Range(0, pickSounds.Count)]);
                Destroy(gameObject);
            }
        }
    }
    public void OnCollisionEnter2D(Collision2D collision) //collecting the dice
    {
        if (collision.gameObject.name == "player")
        {
            PlayerAction pac = collision.gameObject.GetComponent<PlayerAction>();
            if (!pac.dice.Contains(diceTemplate))
            {
                for (int i = 0; i<pac.dice.Count; i++)
                {
                    if (!pac.dice[i].ready)
                    {
                        pac.dice[i] = diceTemplate;
                        diceTemplate.ready = true;
                        collision.gameObject.GetComponent<AudioSource>().PlayOneShot(pickSounds[Random.Range(0, pickSounds.Count)]);
                        Destroy(this.gameObject);
                        break;
                    }
                }
            }
            else
            {
                diceTemplate.ready = true;
                collision.gameObject.GetComponent<AudioSource>().PlayOneShot(pickSounds[Random.Range(0, pickSounds.Count)]);
                Destroy(this.gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        diceTemplate.ready = true;
    }
}
