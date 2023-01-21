using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public static bool gameOver, pause;

	public GameObject gameOverUI, hiScoreUI, pauseGameUI;

	private float score, hiScore;

	private 

	void Awake ()
	{
		instance = this;
		gameOver = pause = false;
	}

	public void EndGame ()
	{
		gameOver = true;
		score = Planet.Score;
		hiScore = PlayerPrefs.GetFloat("HiScore", 100.0f);

		if (score < hiScore)
        {
			hiScore = score;
			PlayerPrefs.SetFloat("HiScore", hiScore);
			hiScoreUI.SetActive(true);
        }
		
		pauseGameUI.SetActive(false);
		gameOverUI.SetActive(true);
	}

	public void OnPause(bool onPause)
	{
		pause = onPause;
		if (!onPause)
		{
			Time.timeScale = 1;
		}
		else
		{
			Time.timeScale = 0;
		}
		AudioManager.instance.Play("Click");
	}

	public void Restart ()
	{
		AudioManager.instance.Play("Click");
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

}
