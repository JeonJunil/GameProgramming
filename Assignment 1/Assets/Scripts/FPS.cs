using UnityEngine;
using TMPro;

public class FPS : MonoBehaviour
{
    public TMP_Text fpsText;

    void Update()
    {
        float fps = 1.0f / Time.unscaledDeltaTime;
        fpsText.text = "FPS: " + Mathf.Round(fps).ToString();
    }
}
