using System;
using UnityEngine;
using YG;

public class LocationsManager : MonoBehaviour
{

    [SerializeField] private GameObject[] _locations;
    [SerializeField] private GameObject _locationWin;

    //Event
    public event Action GetExp;
    [SerializeField] private Timer _timer;
    [SerializeField] private Vote _vote;

   // [SerializeField] private MenuGameOver _menuGameOver;
    
    
    private int _locationsSize;


    private void Start()
    {
        //Start random location
        _locationsSize = _locations.Length;
        _locationsSize = UnityEngine.Random.Range(0, _locationsSize);

        _locations[_locationsSize].SetActive(true);

       
        
    }

    

    //Start "Win Location"
    public void Win()
    {
        _locations[_locationsSize].SetActive(false);

        _locationWin.SetActive(true);

        GetExp?.Invoke();

        //Save coin
        LoadManager.Save();
       
    }

    //Set new location
    public void VoteLocation(int _locationNumber)
    {
        _locationWin.SetActive(false);
        _locationsSize = _locationNumber;
        _locations[_locationsSize].SetActive(true);
    }




    /*public void Restart()
    {
        _locations[_locationsSize].SetActive(false);
        _locations[_locationsSize].SetActive(true);
    }*/

    private void OnEnable()
    {
        _timer.Win += Win;
        _vote.VoneLoc += VoteLocation;
       // _menuGameOver.RestartMenu += Restart;
    }

    private void OnDisable()
    {
        _vote.VoneLoc -= VoteLocation;
        _timer.Win -= Win;
        //_menuGameOver.RestartMenu -= Restart;
    }
}
