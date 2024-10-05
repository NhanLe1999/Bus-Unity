using DG.Tweening;
using TJ.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    public static UiManager instance;
    public GameObject gameOverPanle, winPanel, uiPause;

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

        levelText.text = "Level " + HelperManager.DataPlayer.NumLevel.ToString();
    }

    public void OnShowSetting()
    {
        TogglePanel(uiPause, true);
    }

    public void TogglePanel(GameObject panel, bool value)
    {
        panel.SetActive(value);
    }

    public void OnHomeClick()
    {
        HelperManager.OnLoadScene(ScStatic.HOME_SCENE);
    }

    public void OnRestartClick()
    {
        HelperManager.OnLoadScene(ScStatic.GAME_SCENE);
    }

}