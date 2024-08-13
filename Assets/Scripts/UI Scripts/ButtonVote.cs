using UnityEngine;

public class ButtonVote : MonoBehaviour
{
    [SerializeField] private Vote _vote;
    [SerializeField][Range(0, 2)] private int _numberLoc;

    //Button Vote
    public void NumberLocation()
    {
        //Transmitting the number of the location to be uploaded
        
        _vote.Button(_numberLoc);



    }
}
