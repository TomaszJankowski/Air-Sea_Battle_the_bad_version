using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Dropdown : MonoBehaviour {

    public TMP_Dropdown quality;
    public TMP_Text label;

    private void Awake()
    {
        quality.value = QualitySettings.GetQualityLevel();
        List<TMP_Dropdown.OptionData> menuOptions = quality.options;
        label.text = menuOptions [quality.value].text;
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
