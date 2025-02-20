using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

public class Effectmanager : MonoBehaviour
{
    public CinemachineVolumeSettings _effects;
    public float duration = 1f;

    [SerializeField] private Vignette _vignette;

    [NaughtyAttributes.Button]
    public void ChangeVignette()
    {
        StartCoroutine(FlashColorVignette());
    }

    IEnumerator FlashColorVignette()
    {
        Vignette temp;

        if(_effects.Profile.TryGet<Vignette>(out temp))
        {  
            _vignette = temp;
        }

        ColorParameter c = new ColorParameter(Color.red, false);

        float time = 0;
        while(time < duration)
        {
            c.value = Color.Lerp(Color.black, Color.red, time / duration);
            time += Time.deltaTime;
            _vignette.color.Override(c.value);
            yield return new WaitForEndOfFrame();
        }
        time = 0;
        while(time < duration)
        {
            c.value = Color.Lerp(Color.red, Color.black, time / duration);
            time += Time.deltaTime;
            _vignette.color.Override(c.value);
            yield return new WaitForEndOfFrame();
        }

        

        
    }



}
