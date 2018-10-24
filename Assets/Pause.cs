using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;//interacting with scene change

namespace Assets.Scripts
{
    public class Pause : MonoBehaviour
    {
        public static bool paused;
        public GameObject pauseMenu;
        public GameObject gamePanel;

        public GameObject optionsMenu;
        public AudioSource audioSource;
        public Slider volumeSlider;
        public Toggle volumeToggle;
        public Slider brightnessSlider;
        public Slider ambientSlider;

        public bool isFullScreen;
        public Toggle fullscreenToggle;
        public Dropdown resDropdown;

        [Header("Keys")]
        public KeyCode holdingKey;
        public KeyCode forward, backward, left, right, jump, crouch, sprint, interact;

        [Header("Keybind References")]
        public Text forwardText;
        public Text backwardText, leftText, rightText, jumpText, crouchText, sprintText, interactText;

        Resolution[] resolutions;
        public int resolutionIndex;

        public Light dirLight;
        public Image brightnessImage;

        [HideInInspector]
        public bool showOptions;

        public int levelSelect;

        void Start()
        {
            resolutions = Screen.resolutions;

            List<string> options = new List<string>();

            int currentResolutionIndex = 0;

            for (int i = 0; i < resolutions.Length; i++)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);

                if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = i;
                }
            }

            pauseMenu = GameObject.Find("PauseMenu");
            gamePanel = GameObject.Find("GamePanel");
            optionsMenu = GameObject.Find("OptionsMenu");

            pauseMenu.SetActive(false);
            gamePanel.SetActive(true);
            optionsMenu.SetActive(false);

            Time.timeScale = 1;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                if (paused == true && !showOptions) //if currently paused, UNpause
                {
                    Time.timeScale = 1;
                    pauseMenu.SetActive(false);
                    gamePanel.SetActive(true);
                    paused = false;
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }
                else //PAUSE now
                {
                    Time.timeScale = 0;
                    Inventory.showInv = false;
                    pauseMenu.SetActive(true);
                    gamePanel.SetActive(false);
                    paused = true;
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                }
            }

            if (showOptions == true && Input.GetKeyDown(KeyCode.T))
            {
                OptionToggle();
            }
        }

        public void ToggleOptions()
        {
            OptionToggle();

        }
        bool OptionToggle()
        {
            if (showOptions)//showOptions == true or showOptions is true
            {
                showOptions = false;
                //Set to not display Options Menu as it is not actived

                optionsMenu.SetActive(false);
                pauseMenu.SetActive(true);

                return true;
            }
            else
            {
                showOptions = true;
                optionsMenu.SetActive(true);
                pauseMenu.SetActive(false);

                volumeSlider = GameObject.Find("VolumeSlider").GetComponent<Slider>();
                volumeToggle = GameObject.Find("VolumeToggle").GetComponent<Toggle>();
                brightnessSlider = GameObject.Find("BrightnessSlider").GetComponent<Slider>();
                brightnessImage = GameObject.Find("BrightnessPanel").GetComponent<Image>();
                var tempColour = brightnessImage.color;
                brightnessSlider.value = 1.0f - tempColour.a;

                audioSource = GameObject.Find("MainMusic").GetComponent<AudioSource>();

                resDropdown = GameObject.Find("ResolutionDropdown").GetComponent<Dropdown>();
                fullscreenToggle = GameObject.Find("FullscreenToggle").GetComponent<Toggle>();
                //resDropdown.ClearOptions();
                for (int i = 0; i < resolutions.Length; i++)
                {
                    resDropdown.options[i].text = ResolutionToString(resolutions[i]);
                    //resDropdown.value = i;
                    resDropdown.options.Add(new Dropdown.OptionData(resDropdown.options[i].text));
                }

                volumeSlider.value = audioSource.volume;

                return false;
            }
        }

        string ResolutionToString(Resolution res)
        {
            return res.width + " x " + res.height;
        }

        public void Fullscreen()
        {
            isFullScreen = !fullscreenToggle.isOn;
            Resolution();
        }

        public void Volume()
        {
            audioSource.volume = volumeSlider.value;
        }

        public void Mute()
        {
            audioSource.mute = !volumeToggle.isOn;
        }

        public void Brightness()
        {
            var tempColour = brightnessImage.color;
            tempColour.a = 1.0f - brightnessSlider.value;
            brightnessImage.color = tempColour;
            //dirLight.intensity = brightnessSlider.value;
        }

        public void Ambience()
        {
            RenderSettings.ambientIntensity = ambientSlider.value;
        }

        public void Resolution()
        {
            resolutionIndex = resDropdown.value;
            Screen.SetResolution((int)resolutions[resolutionIndex].width, (int)resolutions[resolutionIndex].height, isFullScreen);
        }

        public void LoadGame(int level)
        {
            SceneManager.LoadScene(level);
        }

    }
}
