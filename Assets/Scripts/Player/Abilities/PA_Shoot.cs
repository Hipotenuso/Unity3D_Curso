using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PA_Shoot : PlayerAbilityBase
{
    public StaffBase gun1;
    public StaffBase gun2;
    public Transform gunPosition;
    public StaffBase _currentGun;
    
    protected override void Init()
    {
        base.Init();

        CreateGun();

        inputs.Gameplay.Shoot.performed += ctx => StartShoot();
        inputs.Gameplay.Shoot.canceled += ctx => CancelShoot();
        inputs.Gameplay.SwitchToGun1.performed += ctx => SwitchToGun1();
        inputs.Gameplay.SwitchToGun2.performed += ctx => SwitchToGun2();

    }
    private void CreateGun()
    {
        _currentGun = Instantiate(gun1, gunPosition);

        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
    }

    private void SwitchToGun1()
    {
        if(_currentGun != null) 
        {
            Destroy(_currentGun.gameObject);
        }
        _currentGun = Instantiate(gun1, gunPosition);
    }

    private void SwitchToGun2()
    {
        if(_currentGun != null) 
        {
            Destroy(_currentGun.gameObject);
        }
        _currentGun = Instantiate(gun2, gunPosition);
    }

    private void StartShoot()
    {
        _currentGun.StartShooting();
        Debug.Log("Start Shoot");
    }

    private void CancelShoot()
    {
        Debug.Log("Cancel Shoot");
        _currentGun.StopShooting();
    }
}
