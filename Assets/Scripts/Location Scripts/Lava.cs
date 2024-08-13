using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private float _lavaTop_Y;
    [SerializeField] private float _lavaStep; //Lava speed

    //Event
    [SerializeField] private Timer _timer;
    [SerializeField] private ColliderPlayer _gameOver;
    
    
   
    private Vector3 _lavaTop;
    private Vector3 _lavaStartPosition;
    private bool _lavaIsActive = false;


 
    
    private void Start()
    {
       //Set win position
        _lavaTop = new Vector3(transform.position.x, _lavaTop_Y, transform.position.z);
    }
    private void FixedUpdate()
    {
        if (_lavaIsActive) { LavaMove(); }
      
    }



    public void StartLava()
    {
        
        _lavaIsActive =true; //Lava start move
    }


    private void LavaMove()
    {
       if (this.gameObject.transform.position.y < _lavaTop_Y) 
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, _lavaTop, _lavaStep); 
        }

       //Win
        else 
        {
            LavaStop();

            _timer.WinTimer();

            

        }
    }

     public void  LavaStop()
     {
        _lavaIsActive = (false);
     }

    public void LavaRestart()
    {
        this.transform.position = _lavaStartPosition;
    }



 private void OnEnable()
    {  _lavaStartPosition = this.transform.position;
        _timer.TimeStart += StartLava;
        _gameOver.Lose += LavaStop;
        _timer.TimeRestart += LavaRestart;
    }

    private void OnDisable()
    {
        this.transform.position = _lavaStartPosition;
        _timer.TimeStart -= StartLava;
        _gameOver.Lose-= LavaStop;
        _timer.TimeRestart -= LavaRestart;
    }
}
