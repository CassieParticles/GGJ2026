using UnityEngine;
using UnityEngine.UI;
using Wwise;
using TMPro;

public class VolumeSlider : MonoBehaviour
{
        //Editor accessible values
    [Header("Sliders & Text")]
    [SerializeField, Tooltip("Drag and drop the slider for Main Volume")] private Slider sliderMain;
    [SerializeField, Tooltip("Drag and drop the text you want to show the value")] private TMP_Text mainText;
    [Space(10)]
    [SerializeField, Tooltip("Drag and drop the slider for Music Volume")] private Slider sliderMusic;
    [SerializeField, Tooltip("Drag and drop the text you want to show the value")] private TMP_Text musicText;
    [Space(10)]
    [SerializeField, Tooltip("Drag and drop the slider for SFX Volume")] private Slider sliderSfx;
    [SerializeField, Tooltip("Drag and drop the text you want to show the value")] private TMP_Text sfxText;
    [Space(10)]
    [SerializeField, Tooltip("Drag and drop the slider for Shark Volume")] private Slider sliderShark;
    [SerializeField, Tooltip("Drag and drop the text you want to show the value")] private TMP_Text sharkText;
    [Space(10)]
    [SerializeField, Tooltip("Drag and drop the slider for Bee Volume")] private Slider sliderBee;
    [SerializeField, Tooltip("Drag and drop the text you want to show the value")] private TMP_Text beeText;
    [Space(10)]
    [SerializeField, Tooltip("Drag and drop the slider for Alligator Volume")] private Slider sliderAlligator;
    [SerializeField, Tooltip("Drag and drop the text you want to show the value")] private TMP_Text alligatorText;
    [Space(10)]
    [SerializeField, Tooltip("Drag and drop the slider for Skunk Volume")] private Slider sliderSkunk;
    [SerializeField, Tooltip("Drag and drop the text you want to show the value")] private TMP_Text skunkText;
    [Space(20)]
    [Header("Default Settings")]
    [Space(10)]
    [SerializeField, Range(1, 100), Tooltip("Set the default value, limited 1-100")] private float mainVolumeDefault;
    [SerializeField, Range(1, 100), Tooltip("Set the default value, limited 1-100")] private float musicVolumeDefault;
    [SerializeField, Range(1, 100), Tooltip("Set the default value, limited 1-100")] private float sfxVolumeDefault;
    [SerializeField, Range(1, 100), Tooltip("Set the default value, limited 1-100")] private float sharkVolumeDefault;
    [SerializeField, Range(1, 100), Tooltip("Set the default value, limited 1-100")] private float beeVolumeDefault;
    [SerializeField, Range(1, 100), Tooltip("Set the default value, limited 1-100")] private float alligatorVolumeDefault;
    [SerializeField, Range(1, 100), Tooltip("Set the default value, limited 1-100")] private float skunkVolumeDefault;

    //value stored in the script, to later be saved to PlayerPrefs
    private float mainValue;
    private float musicValue;
    private float sfxValue;
    private float sharkValue;
    private float beeValue;
    private float alligatorValue;
    private float skunkValue;

        
    void Awake()
    {
        // Loads the saved values when settings screen is activated
        Load();
    }

  
    void Update()
    {
        //Updates the scripts saved value to what the sliders current value is
        //Updates the corresponding RTCP value to the same value
        //Updates the sliders text to show the value rounded to the nearest 2 decimal places

        mainValue = sliderMain.value;
        AkUnitySoundEngine.SetRTPCValue("MainVolume", mainValue);
        mainText.text = mainValue.ToString("#.00");

        musicValue = sliderMusic.value;
        AkUnitySoundEngine.SetRTPCValue("MusicVolume", musicValue);
        musicText.text = musicValue.ToString("#.00");

        sfxValue = sliderSfx.value;
        AkUnitySoundEngine.SetRTPCValue("SfxVolume", sfxValue);
        sfxText.text = sfxValue.ToString("#.00");

        sharkValue = sliderShark.value;
        AkUnitySoundEngine.SetRTPCValue("SharkVolume", sharkValue);
        sharkText.text = sharkValue.ToString("#.00");

        beeValue = sliderBee.value;
        AkUnitySoundEngine.SetRTPCValue("BeeVolume", beeValue);
        beeText.text = beeValue.ToString("#.00");

        alligatorValue = sliderAlligator.value;
        AkUnitySoundEngine.SetRTPCValue("AlligatorVolume", alligatorValue);
        alligatorText.text = alligatorValue.ToString("#.00");

        skunkValue = sliderSkunk.value;
        AkUnitySoundEngine.SetRTPCValue("SkunkVolume", skunkValue);
        skunkText.text = skunkValue.ToString("#.00");
    }

    void Save()
    {
        //saves the current value to playerprefs
        //attach as an onclick function to the back button
        //not sure how to implement if a keypress exits the screen but anywhere your code closes Settings - trigger this BEFORE the UI is disabled

        PlayerPrefs.SetFloat("mainValue", mainValue);
        PlayerPrefs.SetFloat("musicValue", musicValue);
        PlayerPrefs.SetFloat("sfxValue", sfxValue);
        PlayerPrefs.SetFloat("sharkValue", sharkValue);
        PlayerPrefs.SetFloat("beeValue", beeValue);
        PlayerPrefs.SetFloat("alligatorValue", alligatorValue);
        PlayerPrefs.SetFloat("skunkValue", skunkValue);
    
    }
    void Load()
    {
        //retrieves any saved values from playerprefs, or sets it to default
        //then immediately adjusts the slider position to match
        mainValue = PlayerPrefs.GetFloat("mainValue",mainVolumeDefault);
        sliderMain.value = mainValue;
        musicValue = PlayerPrefs.GetFloat("musicValue", musicVolumeDefault);
        sliderMusic.value = musicValue;
        sfxValue = PlayerPrefs.GetFloat("sfxValue",sfxVolumeDefault);
        sliderSfx.value = sfxValue;
        sharkValue = PlayerPrefs.GetFloat("sharkValue",sharkVolumeDefault);
        sliderShark.value = sharkValue;
        beeValue = PlayerPrefs.GetFloat("beeValue", beeVolumeDefault);
        sliderBee.value = beeValue;
        alligatorValue = PlayerPrefs.GetFloat("alligatorValue", alligatorVolumeDefault);
        sliderAlligator.value = alligatorValue;
        skunkValue = PlayerPrefs.GetFloat("skunkValue",skunkVolumeDefault);
        sliderSkunk.value = skunkValue;
    }

    private void ResetToDefault()
    {
        //Sets Values to default
        //Updates Slider to default
        mainValue = mainVolumeDefault;
        sliderMain.value = mainValue;

        musicValue = musicVolumeDefault;
        sliderMusic.value = musicValue;

        sfxValue = sfxVolumeDefault;
        sliderSfx.value = sfxValue;

        sharkValue = sharkVolumeDefault;
        sliderShark.value = sharkValue;

        beeValue = beeVolumeDefault;
        sliderBee.value = beeValue;

        alligatorValue = alligatorVolumeDefault;
        sliderAlligator.value = alligatorValue;

        skunkValue = skunkVolumeDefault;
        sliderSkunk.value = skunkValue;
        Save();

    }

    private void Mute()
    {
        PlayerPrefs.SetFloat("mainValue", mainValue);
        mainValue = 0f;
        //insert wwise code here
        sliderMain.value = mainValue;


    }
    private void UnMute()
    {
        mainValue = PlayerPrefs.GetFloat("mainValue", mainVolumeDefault);
        sliderMain.value = mainValue;
        //insert wwise code here
        sliderMain.value = mainValue;


    }

}
