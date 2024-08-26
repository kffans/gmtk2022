using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ExitGate : MonoBehaviour
{
    public string nextLevel;
    public Sprite opened;
    SpriteRenderer sprenderer;
    bool open;

    private void Start()
    {
        sprenderer = gameObject.GetComponent<SpriteRenderer>();
        CheckIfOpen();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(nextLevel);
        }

    }

    public void CheckIfOpen()
    {
        if (FindObjectOfType<Enemy>() == null)
        {
            open = true;
            sprenderer.sprite = opened;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (open && collision.gameObject.name == "player")
        {
            SceneManager.LoadScene(nextLevel);
        }
        else Debug.Log("kill remaining enemies first");
    }
}
