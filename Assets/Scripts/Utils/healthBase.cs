using System;
using UnityEngine;

public class healthBase : MonoBehaviour, IDamageble
{
    public float startLife = 10f;
    public bool destroyOnKill = false;
    [SerializeField] private float _currentLife;
    public UIGunUpdater uiGunUpdater;
    public Action<healthBase> OnDamage;
    public Action<healthBase> OnKill;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        ResetLife();
    }

    public void ResetLife()
    {
        _currentLife = startLife;
    }

    protected virtual void Kill()
    {
        if(destroyOnKill)
            Destroy(gameObject, 3f);
        OnKill?.Invoke(this);
    }

    [NaughtyAttributes.Button]
    public void Damage()
    {
        Damage(5);
    }

    public void Damage(float f)
    {
        _currentLife -= f;

        if(_currentLife <=0)
            Kill();
        OnDamage?.Invoke(this);
        UpdateUI();
    }

    public void Damage(float damage, Vector3 dir)
    {
        Damage(damage);
    }
    private void UpdateUI()
    {
        if(uiGunUpdater != null)
        {
            uiGunUpdater.UpdateValue((float) _currentLife / startLife);
        }
    }
}
