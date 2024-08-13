using UnityEngine;

public class LookUI : MonoBehaviour
{
    [SerializeField] private Transform _cameraPC;
    [SerializeField] private Transform _cameraMobile;

    private Transform _camera;


    void Start()
    {
        if (LoadManager.IsPc == true) 
        {
            _camera = _cameraPC;
        }
        else 
        {
            _camera = _cameraMobile;
        }

        
    }


    void LateUpdate()
    {
        this.transform.LookAt(_camera);
    }


}

