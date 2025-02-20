using System.Collections.Generic;
using UnityEngine;

public class CPmanager : MonoBehaviour
{
    public CheckPointbase checkPointbase1;
    public CheckPointbase checkPointbase2;

    public int lastCheckPoint = 0;
    public List<CheckPointbase> checkPoints;

    public bool HasCheckPoint()
    {
        return lastCheckPoint > 0;
    }

    public void SaveCheckPoint(int i)
    {
        if(i > lastCheckPoint)
        {
            lastCheckPoint = i;
        }
    }

    public Vector3 GetPositionToRespawn()
    {
        var checkpuint = checkPoints.Find(i => i.key == lastCheckPoint);
        return checkpuint.transform.position;
    }
}
