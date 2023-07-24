using TMPro;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public GameObject coinPrefab, enemyParticle, GameOverWindow, winParticles, UI_Buttons;
    public TMP_Text scoreTxt, winTxt;
    public Transform UI_coin;

    [SerializeField] private Toggle toggle;

    [HideInInspector] public bool isTouchControlsOn;
    [HideInInspector] public int score = 0;
    
    private bool isColorChanged;
    
    public static UIManager _instance;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        ChangeRandomColor();
    }

    private void Awake()
    {
        if (_instance == null) _instance = this;
    }

    private void Start()
    {
#if (UNITY_IOS || UNITY_ANDROID) && !UNITY_EDITOR
        toggle.gameObject.SetActive(true);
#endif
    }

    public void ToggleValueChange()
    {
        isTouchControlsOn = !isTouchControlsOn;
        UI_Buttons.SetActive(isTouchControlsOn);
    }

    public void EnableParticle(Vector3 enemyPos)
    {
        GameObject particleEmemy =  Instantiate(enemyParticle, enemyPos, Quaternion.identity);
        Destroy(particleEmemy, 2.0f);
    }

    private void ChangeRandomColor()
    {
        if (!isColorChanged)
        {
            Color randomColor = Random.ColorHSV();

            spriteRenderer.DOColor(randomColor, 2.0f).OnComplete(() =>
            {
                ChangeRandomColor();
            });
        }
    }

    public void WinLoss(string winLoss)
    {
        winTxt.text = "You " + winLoss + "!";
        GameOverWindow.SetActive(true);
        if(winLoss == "WIN")
            Instantiate(winParticles);
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(0);
    }
}
