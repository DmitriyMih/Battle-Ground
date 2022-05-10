using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [Header("Connect Settings")]
    public GameSettings gameSettings;

    [Header("View Settings")]
    public Slider volumeSlider;
    public Slider soundSlider;

    public void Awake()
    {
        gameSettings = GameSettings.gameSettings;
    }

    public void InitializationView()
    {
        if (gameSettings == null)
            return;

        volumeSlider.value = gameSettings.volume / 100;
        soundSlider.value = gameSettings.sound / 100;
    }

    
}
