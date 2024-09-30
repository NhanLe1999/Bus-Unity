using DG.Tweening;
using TJ.Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

    public static UiManager instance;
    public GameObject gameOverPanle, winPanel;

    [SerializeField] private Button restartButtonForTest;
    [SerializeField] private Button btnRestart;
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
            SoundController.Instance.PlayOneShot(SoundController.Instance.buttonSound);
            DOVirtual.DelayedCall(0.3f, LevelManager.ReloadLevel);
        });
        //gameover panel restart Button
        btnRestart.onClick.AddListener(() =>
        {
            Vibration.Vibrate(30);
            SoundController.Instance.PlayOneShot(SoundController.Instance.buttonSound);
            HelperManager.OnLoadScene(ScStatic.GAME_SCENE);
        });
        //next button for WinPanel
        btnNext.onClick.AddListener(() =>
        {
            Vibration.Vibrate(30);
            SoundController.Instance.PlayOneShot(SoundController.Instance.buttonSound);
            HelperManager.OnLoadScene(ScStatic.GAME_SCENE);
        });
        skipButton.onClick.AddListener(() =>
        {
            LevelManager.LevelProgressed();
            SoundController.Instance.PlayOneShot(SoundController.Instance.buttonSound);
            DOVirtual.DelayedCall(0.3f, LevelManager.LoadScene);
        });

        levelText.text = "Level " + LevelManager.GetCurrentLeveLNumber();
    }

    public void TogglePanel(GameObject panel, bool value)
    {
        panel.SetActive(value);
    }

}