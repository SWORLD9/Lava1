using UnityEngine.UI;
using UnityEngine;
using YG;

public class CoinManager : MonoBehaviour
{
    //UI coin
    [SerializeField] Text _coinText;

    //Event
    [SerializeField] ColliderPlayer _player;

   

    private void OnEnable()
    {
        _player.TakeCoin += TakeCoin;
    }

    private void OnDisable()
    {
        _player.TakeCoin -= TakeCoin;
    }


    private void Start()
    {
       //Update UI
        _coinText.text = "Coin: " + LoadManager.coin.ToString();
    }

    //Coin + 1 and Update UI
    public void TakeCoin()
    {
        LoadManager.coin++;
        _coinText.text = "Coin: " + LoadManager.coin.ToString();

    }
}
