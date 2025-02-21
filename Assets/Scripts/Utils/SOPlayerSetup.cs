using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
    [Header("References")]
    public Animator player;
    
    [Header("Player Moviment Setup")]
    public float _CurrentSpeed;
    public int Playerside;
    public float speed;
    public float speedRun;
    public float jumpForce;
    public float jumpDuration;
    public float attackDuration;
    public float particlesJumpDuration;
}
