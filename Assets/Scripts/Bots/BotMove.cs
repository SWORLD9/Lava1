using UnityEngine;
using UnityEngine.AI;

public class BotMove : MonoBehaviour
{

    public GameObject[] Bots;

    public Transform[] Spawns;

    private void OnEnable()
    {
        for (int i = 0; i < Bots.Length; i++) 
        {
            Bots[i].SetActive(false);
            Bots[i].gameObject.transform.position = Spawns[i].position;
            Bots[i].SetActive(true);
        }
    }
}
