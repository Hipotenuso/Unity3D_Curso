using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class StaffBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public float shootDelay;
    public float speed = 50f;
    private Coroutine _currentCoroutine;

    protected virtual IEnumerator StartShoot()
    {
        while(true)
        {
            yield return new WaitForSeconds(shootDelay);
            Shoot();
        }
    }


    public virtual void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.transform.rotation = positionToShoot.rotation;
        projectile.speed = speed;
    }

    public void StartShooting()
    {
        StopShooting();
        _currentCoroutine = StartCoroutine(StartShoot());
    }

    public void StopShooting()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);
    }
    
}
