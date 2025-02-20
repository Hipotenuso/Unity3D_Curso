using UnityEngine;

public class CheckPointbase : MonoBehaviour
{
    public CPmanager cPmanager;
    public MeshRenderer meshRenderer;
    public int key = 01;
    private bool checkPointActived = false;
    private string chekcpointKey = "ChekPointKey";
    private void OnTriggerEnter(Collider other)
    {
        if(!checkPointActived && other.transform.tag == "Player")
        {
            CheckCheckPoint();
        }
    }

    private void CheckCheckPoint()
    {
        TurnItOn();
        SaveCheckPoint();
    }

    [NaughtyAttributes.Button]
    private void TurnItOn()
    {
        //meshRenderer.material.SetColor("_EmissionColor", Color.white);
    }

    private void TurnItOff()
    {
        //meshRenderer.material.SetColor("_EmissionColor", Color.gray);
    }

    private void SaveCheckPoint()
    {
        //if(PlayerPrefs.GetInt(chekcpointKey, 0) > key)
            //PlayerPrefs.SetInt(chekcpointKey, key);

        
        cPmanager.SaveCheckPoint(key);
        checkPointActived = true;
    }
}

