
using Lightbug.CharacterControllerPro.Demo;
using UnityEngine;

public class BoostManager : MonoBehaviour
{
    [SerializeField] NormalMovement _normalMovement;
    [SerializeField] ColliderPlayer _player;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpPower;

    void Start()
    {
        _normalMovement.verticalMovementParameters.availableNotGroundedJumps = 0;

        Speed();
        Jump();
        DubleJump();
        Shield();

    }

    void Speed()
    {
        
         _normalMovement.planarMovementParameters.baseSpeedLimit = _speed;

    }

    void Jump()
    {
        
        _normalMovement.verticalMovementParameters.jumpSpeed = _jumpPower;

    }

    void DubleJump()
    {
        
         _normalMovement.verticalMovementParameters.availableNotGroundedJumps = 1;

    }

    void Magnet()
    {
        
    }
    void Jetpack()
    {
        _normalMovement.verticalMovementParameters.availableNotGroundedJumps = int.MaxValue;
        
    }

    void Shield()
    {
        _player.damage = 0.5f;
    }

}
