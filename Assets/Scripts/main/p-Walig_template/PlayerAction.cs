using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    //audio stuff
    public List<AudioClip> attackSounds;
    AudioSource ad;

    public List<KeyCode> keys; //list of buttons responsible for performing a dice throw
    //Animator animator;
    public List<Dice> dice;
    [HideInInspector] public Being being;
    void Start()
    {
        being = gameObject.GetComponent<Being>();
    }

    public void Throw(Vector3 target, Dice dice)
    {
        GameObject diceObj = Instantiate(GameplayManager.Dice, transform.position + ((target - transform.position).normalized * 100f), new Quaternion(0f, 0f, 0f, 1f));
        DiceBehaviour realDice = diceObj.GetComponent<DiceBehaviour>();
        realDice.rb.AddForce((target - transform.position) * dice.speed);
        realDice.diceTemplate = dice;
        dice.ready = false;
        diceObj.GetComponent<SpriteRenderer>().color = dice.color;
    }
    private void Awake()
    {
        ad = gameObject.GetComponent<AudioSource>();
        //animator = GetComponentInChildren<Animator>();
    }
    private void Update()
    {
        for (int i = 0; i < keys.Count; i++)
            if (Input.GetKeyDown(keys[i]) && dice[i].ready && Time.timeScale == 1f) //checking if key pressed and if we have enough stamina and if the game is not paused
            {
                ad.PlayOneShot(attackSounds[Random.Range(0, attackSounds.Count)]);
                Throw(GameplayManager.curosorPosition, dice[i]); // perform a dice throw
                //if (i <= 1) animator.SetTrigger("attack");
                //else animator.SetTrigger("dash");
            }
    }
}
