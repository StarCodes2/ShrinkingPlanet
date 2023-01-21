using UnityEngine.UI;
using UnityEngine;

public class ScoreUI : MonoBehaviour {

	public Text text;

	RectTransform rt;
	Vector2 startPos;
	private float hiScore;
	private static bool inMain;

	void Start ()
	{
		rt = GetComponent<RectTransform>();
		startPos = rt.anchoredPosition;
		hiScore = PlayerPrefs.GetFloat("HiScore", 100.0f);
		if (hiScore == 100.0)
			hiScore = 0.0f;

		text.text = "d = <i><b>" + hiScore.ToString("0.#") + "</b>m</i>";
	}

	void Update ()
	{
		if (!inMain)
			return;

		text.text = Planet.Score.ToString("0.#") + "m";

		rt.anchoredPosition = Vector2.Lerp(Vector2.zero, startPos, Planet.Size);
	}

	public static void Scene(string scene)
    {
		if (scene == "main")
			inMain = true;
		else
			inMain = false;
    }

}
