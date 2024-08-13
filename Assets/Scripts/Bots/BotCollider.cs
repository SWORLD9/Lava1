using System;
using System.Collections;
using UnityEngine;

public class BotCollider : MonoBehaviour
{
    //Event
    
 
    
 

    public float damage;
    private float _health = 4f;
    private bool _death = false;
    private bool _exitLava = false;



    private void OnEnable()
    {
        RestartPlayer();
    }




    private void OnTriggerEnter(Collider other)
    {


        //Lose
        if (other.gameObject.tag == "Lava")
        {
            if (!_exitLava)
            {
                StartCoroutine(TimeDeath());

                _exitLava = true;

            }
        }



    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Lava")
        {
            StopAllCoroutines();
            _exitLava = false;


        }

    }
    private IEnumerator TimeDeath()
    {
        while (!_death)

        {
            yield return new WaitForSeconds(1f);
            _health -= damage;




            if (_health < 1)
            {
                this.gameObject.SetActive(false);

            }
        }




    }

    private void RestartPlayer()
    {
        _health = 4;

        _exitLava = false;

    }

}
