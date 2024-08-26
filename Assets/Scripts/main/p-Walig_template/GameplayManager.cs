using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour //generaly used for managing pause menu and gameover screeen
{
    //public static int score = 0;
    //static Text text;
    public static AudioSource ad;
    public static string checkpointName = "level1";
    public GameObject iconTemplate;
    public static GameObject icon;
    public GameObject areaTemplate;
    public static GameObject areaObj;
    public GameObject DiceTemplate;
    public static GameObject Dice;
    public static Vector3 curosorPosition;

    public static Transform playerTrans; //keeps player position for enemies to reference
    static GameObject GameOverGroup;
    static GameObject PauseGroup;
	public static bool destroyObjects=false;
    private void Start()
    {
        ad = GetComponent<AudioSource>();
        Dice = DiceTemplate;
        areaObj = areaTemplate;
        icon = iconTemplate;
        playerTrans = GameObject.Find("player").GetComponent<Transform>();
        //text = GameObject.Find("GameOverText").GetComponent<Text>();
        GameOverGroup = GameObject.Find("GameOverGroup");
        PauseGroup = GameObject.Find("PauseGroup");
        GameOverGroup.SetActive(false);
        PauseGroup.SetActive(false);
    }
    private void Update()
    {
        curosorPosition = Input.mousePosition;
        curosorPosition.z = Camera.main.nearClipPlane + 1f;
        curosorPosition = Camera.main.ScreenToWorldPoint(curosorPosition);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //destroyObjects = false;
			if (Time.timeScale == 1f) Pause();
            else if(!GameOverGroup.activeInHierarchy) UnPause();
        }
        if (Input.anyKeyDown && GameOverGroup.activeInHierarchy)
        {
            LoadCheckpoint();
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        PauseGroup.SetActive(true);
    }
    public void UnPause()
    {
        Time.timeScale = 1f;
        PauseGroup.SetActive(false);
    }
    public static void GameOver()
    {
        Time.timeScale = 0f;
        GameOverGroup.SetActive(true);
        //text.text = "Game Over\nYour Score: " + score;
    }
    public void LoadCheckpoint()
    {
        UnPause();
        Being player = playerTrans.gameObject.GetComponent<Being>();
        player.hp = player.maxhp;
        GameOverGroup.SetActive(false);
        SceneManager.LoadScene(checkpointName);
    }
    public void GoToMainMenu()
    {
        //score = 0;
        //text.text = "Game Over\nYour Score:";
        Time.timeScale = 1f;
        GameOverGroup.SetActive(false);
        PauseGroup.SetActive(false);
		SceneManager.LoadScene("menu");
		destroyObjects=true;
    }
}
