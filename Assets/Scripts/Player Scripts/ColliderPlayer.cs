using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColliderPlayer : MonoBehaviour
{
    //Event
    public event Action Lose;
    public event Action TakeCoin;
    [SerializeField] private MenuGameOver _gameOver;
    [SerializeField] private Timer _timer;

    public float damage;
    public Slider healthBar;
    private float _health = 4f;
    private bool _death = false;
    private bool _exitLava = false;



    private void OnEnable()
    {
        if (_gameOver != null) { _gameOver.RestartMenu += RestartPlayer; }
        if (_timer != null) { _timer.Win += RestartPlayer; }
    }
    private void OnDisable()
    {
        if (_gameOver != null) { _gameOver.RestartMenu -= RestartPlayer; }
        if (_timer != null) { _timer.Win -= RestartPlayer; }
    }



    private void OnTriggerEnter(Collider other)
    {


        //Lose
        if (other.gameObject.tag == "Lava")
        {
            if (!_exitLava)
            {
                StartCoroutine(TimeDeath());
                Debug.Log("Start " + _health);
                _exitLava = true;
                
            }
        }
        //Take coin
        else if (other.gameObject.tag == "Coin")
        {
            TakeCoin?.Invoke();
            other.gameObject.SetActive(false);

        }


    }

    private void OnTriggerExit(Collider other) 
    {
        if (other.gameObject.tag == "Lava")
        {
            StopAllCoroutines();
            _exitLava = false;
            Debug.Log("Stop Curotine " + _health);

        }

    }
    private IEnumerator TimeDeath()
    {
        while (!_death)

        {
            yield return new WaitForSeconds(1f);
            _health -= damage;
            Debug.Log(_health);

            healthBar.gameObject.SetActive(true);
            healthBar.value = _health;

            if (_health < 1)
            {
                _death = true;
                
            }
        }

        RestartPlayer();
        Lose?.Invoke();
        this.gameObject.SetActive(false);
    }

    private void RestartPlayer()
    {
     _health = 4;
     _death = false;
     _exitLava = false;
     healthBar.gameObject.SetActive(false);
    }

}
