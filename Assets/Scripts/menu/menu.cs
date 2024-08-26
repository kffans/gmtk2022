using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
	public main mn;
	
	public void Play()
	{
		SceneManager.LoadScene(1);
	}
	
	public void Options()
	{
		
	}
	
	public void Quit()
	{
		Application.Quit();
	}
	
	
	
	void Start()
	{
		Application.targetFrameRate = 60;
		GameplayManager.destroyObjects=false;
		StartCoroutine(mist());
	}
	
	public IEnumerator mist()
	{
		while(true){
			GameObject.Find("Image_1").GetComponent<RectTransform>().position = new Vector3(-633,-803,0);
			GameObject.Find("Image_2").GetComponent<RectTransform>().position = new Vector3(175,-803,0);
			GameObject.Find("Image_3").GetComponent<RectTransform>().position = new Vector3(675,-803,0);
			StartCoroutine(main.objectMove(GameObject.Find("Image_1").GetComponent<RectTransform>(), 8, 1600, 90, 2));
			StartCoroutine(main.objectMove(GameObject.Find("Image_2").GetComponent<RectTransform>(), 7, 1600, 90, 2));
			StartCoroutine(main.objectMove(GameObject.Find("Image_3").GetComponent<RectTransform>(), 9, 1600, 90, 2));
			for(int i=0; i<=200; i++)
				yield return null;
			GameObject.Find("Image_4").GetComponent<RectTransform>().position = new Vector3(-675,-803,0);
			GameObject.Find("Image_5").GetComponent<RectTransform>().position = new Vector3(-21,-803,0);
			GameObject.Find("Image_6").GetComponent<RectTransform>().position = new Vector3(600,-803,0);
			StartCoroutine(main.objectMove(GameObject.Find("Image_4").GetComponent<RectTransform>(), 8, 1600, 90, 2));
			StartCoroutine(main.objectMove(GameObject.Find("Image_5").GetComponent<RectTransform>(), 9, 1600, 90, 2));
			StartCoroutine(main.objectMove(GameObject.Find("Image_6").GetComponent<RectTransform>(), 7, 1600, 90, 2));
			for(int i=0; i<=200; i++)
				yield return null;
		}
	}
}
