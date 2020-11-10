using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    private readonly string CurrFPSStr = "FPS : ";
    private readonly string AvgFPSStr = "Avg FPS : ";
    private readonly string MinFPSStr = "Min FPS : ";
    private readonly string MaxFPSStr = "Max FPS : ";

    public Text fpsDisplay;
    public Text averageFPSDisplay;
    public Text minFPSDisplay, maxFPSDisplay;

    int framesPassed = 0;
    int fpsTotal = 0;
    
    float minFPS = Mathf.Infinity;
    float maxFPS = 0f;

    private int frames = 0;

    // To prevent redundant min and max FPS reports during initial game startup performance spikes
    private bool AllowMaxFPS = false;
    private bool AllowMinFPS = false;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(4);
        AllowMaxFPS = AllowMinFPS = true;
    }

    void Update() 
    {
        int fps = (int)(1 / Time.unscaledDeltaTime);

        frames++;
        if (frames % 30 == 0)
            fpsDisplay.text = CurrFPSStr + fps;

        fpsTotal += fps;
        framesPassed++;

        if (framesPassed > 3600)
            framesPassed = fpsTotal = 1;

        averageFPSDisplay.text = AvgFPSStr + (fpsTotal / framesPassed);

        if (fps > maxFPS && framesPassed > 10 && AllowMaxFPS)
        {
            if (fps < ((fpsTotal / framesPassed) * 2))
            {
                maxFPS = fps;
                maxFPSDisplay.text = MaxFPSStr + maxFPS;
            }
        }
        if (fps < minFPS && framesPassed > 10 && AllowMinFPS)
        {
            minFPS = fps;
            minFPSDisplay.text = MinFPSStr + minFPS;
        }
    }
}
