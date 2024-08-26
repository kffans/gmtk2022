using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MovingType
{
    //audio stuff
    public List<AudioClip> dashSounds;
    public List<AudioClip> walkSounds;
    public AudioSource ad;
    public float audioInterval = 0.3f;
    float audioTimer;
    public float dash = 20000f;
    float invincibleTime = 0f;
    void Awake()
    {
        //ad = gameObject.GetComponent<AudioSource>();
        audioTimer = audioInterval;

    }
    public override void Update()
    {
        base.Update();
        float x = Input.GetAxisRaw("Horizontal"); //read the input
        float y = Input.GetAxisRaw("Vertical");
        direction = new Vector2(x, y).normalized; //override the direction, ACTUAL MOVEMENT IS PERFORMED IN MovingType, which uses direction to apply a force
        if(direction.magnitude > 0f)
        {
            audioTimer -= Time.deltaTime;
            if(audioTimer <= 0f)
            {
                ad.PlayOneShot(walkSounds[Random.Range(0, walkSounds.Count)]);
                audioTimer = audioInterval;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && being.coolDown == 0f && direction.magnitude > 0f) //dash functionality
        {
            ad.PlayOneShot(dashSounds[Random.Range(0, dashSounds.Count)]);
            rb.AddForce(direction * dash);
            invincibleTime = 0.5f;
            gameObject.layer = 9;
            being.coolDown = 1f;
        }
        invincibleTime = Mathf.Clamp(invincibleTime - Time.deltaTime, 0f, 3f);
        if (invincibleTime == 0f) gameObject.layer = 8;
    }
    void FixedUpdate()
    {
        if (being.stun == 0f) rb.AddForce(direction * speed * Time.fixedDeltaTime); //if not stunned move in the dicrection with specified speed
    }
}
