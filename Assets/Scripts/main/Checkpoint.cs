using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Sprite fire;
    public string levelName;
    SpriteRenderer sprenderer;
    private void Start()
    {
        sprenderer = gameObject.GetComponent<SpriteRenderer>();
        if (GameplayManager.checkpointName == levelName)
        {
            sprenderer.sprite = fire;

            GameObject.Find("player").transform.position = transform.position + Vector3.down * 200f;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player")
        {
            sprenderer.sprite = fire;
            GameplayManager.checkpointName = levelName;
            Being player = collision.gameObject.GetComponent<Being>();
            player.hp = player.maxhp;
        }
        
    }
}
