using UnityEngine;

public class Spawn : MonoBehaviour
{
    //Player
    [SerializeField] public GameObject _player;



    [SerializeField] private GameObject[] _coins;
   
    //Event
    [SerializeField] public Timer _timer;


    public GameObject[] Bots;
    public Transform[] SpawnsBot;
   
    //Change position Player


    
    public void SpawnPlayer()
    {
        _player.SetActive(false);
        _player.transform.position = this.transform.position;
        _player.SetActive(true);


        for (int i = 0; i < Bots.Length; i++)
        {
            Bots[i].SetActive(false);
            Bots[i].gameObject.transform.position = SpawnsBot[i].position;
            Bots[i].SetActive(true);
        }



        for (int coin =0; coin < _coins.Length; coin++) 
        {
            _coins[coin].SetActive(true);
        }

    }

    private void OnEnable()
    {
       
        SpawnPlayer();
        _timer.TimeRestart += SpawnPlayer;
    }
    private void OnDisable()
    {
        _timer.TimeRestart -= SpawnPlayer;
    }

}
