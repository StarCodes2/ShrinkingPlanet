using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour
{
    public Text fpsText;

    private float pullingTime = 0.5f;
    private float time;
    private int frameCount, rate;

    void Awake()
    {
        if (Screen.currentResolution.refreshRate <= 30)
            rate = 30;
        else
            rate = -1;

        Application.targetFrameRate = rate;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        frameCount++;

        if (time >= pullingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            fpsText.text = frameRate.ToString() + " FPS";

            time -= pullingTime;
            frameCount = 0;
        }
    }
}
