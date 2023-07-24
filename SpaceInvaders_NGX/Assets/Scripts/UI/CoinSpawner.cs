using UnityEngine;
using DG.Tweening;
using TMPro;

public class CoinSpawner : MonoBehaviour
{
    public int cointCount = 0;
    public TextMeshPro cointCountTxt;
    public static CoinSpawner _instance;

    private void Awake()
    {
        if(_instance == null) _instance = this; 
    }

    // Start is called before the first frame update
    public void SpawnCoin(Vector3 enemyPos)
    {
        GameObject coin = Instantiate(UIManager._instance.coinPrefab, enemyPos, Quaternion.identity);
        coin.transform.DOScale(1, 2.0f);    //used DoTween -> Scale
        coin.transform.DOLocalJump(UIManager._instance.UI_coin.position, 1.0f, 3, 2.0f).OnComplete(() => 
        {
            cointCount++;
            cointCountTxt.text = "x " + cointCount.ToString();
            Destroy(coin, 2.0f);
        }); // used DoTweem -> Jump and OnComplete Event
    }
}
