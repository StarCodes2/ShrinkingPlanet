using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	void Update ()
	{
		if (Input.GetButtonDown("Jump"))
		{
			GameManager.instance.Restart();
		}

		GetComponent<RectTransform>().localScale = Vector3.one * Planet.Size;
	}

	public void Menu ()
	{
		ScoreUI.Scene("menu");
		SceneManager.LoadScene("Menu");
	}

	public void Restart()
    {
		GameManager.instance.Restart();
	}

}
