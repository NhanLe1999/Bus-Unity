using DG.Tweening;
using TJ.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    public static UiManager instance;
    public GameObject gameOverPanle, winPanel, uiPause;

    [SerializeField] private Button restartButtonForTest;
    [SerializeField] private Button btnSetting;
    [SerializeField] private Button btnNext;
    [SerializeField] private Button skipButton;
    [SerializeField] private TextMeshProUGUI levelText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //Restart For Testing
        restartButtonForTest.onClick.AddListener(() =>
        {
            Vibration.Vibrate(30);
            Audio.Play(ScStatic.SFX_BUTTONSOUND);
            DOVirtual.DelayedCall(0.3f, LevelManager.ReloadLevel);
        });

        //next button for WinPanel
        btnNext.onClick.AddListener(() =>
        {
            Vibration.Vibrate(30);
            Audio.Play(ScStatic.SFX_BUTTONSOUND);
            HelperManager.OnLoadScene(ScStatic.GAME_SCENE);
        });
        skipButton.onClick.AddListener(() =>
        {
            LevelManager.LevelProgressed();
            Audio.Play(ScStatic.SFX_BUTTONSOUND);
            DOVirtual.DelayedCall(0.3f, LevelManager.LoadScene);
        });

        //Setting
        btnSetting.onClick.AddListener(() =>
        {
            Vibration.Vibrate(30);
            Audio.Play(ScStatic.SFX_BUTTONSOUND);
            HelperManager.OnLoadScene(ScStatic.GAME_SCENE);
        });

        levelText.text = "Level " + LevelManager.GetCurrentLeveLNumber();
    }

    public void TogglePanel(GameObject panel, bool value)
    {
        panel.SetActive(value);
    }

}