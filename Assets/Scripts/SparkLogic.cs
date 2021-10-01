using UnityEngine.VFX;
using System.Collections.Generic;
using UnityEngine;

public class SparkLogic : MonoBehaviour
{
    public Sparks sparks;
    public List<VisualEffect> sparksFx;
    private void Start()
    {
        sparksFx = new List<VisualEffect>();
        var fx = sparks.Spark.gameObject.GetComponent<VisualEffect>();
        for(int i = 0; i<10; i++)
        {
            sparksFx.Add(fx);
        }
    }
    public void ShowFx(int i,Vector3 position, Vector3 rotationAngles)
    {
        
    }
}
