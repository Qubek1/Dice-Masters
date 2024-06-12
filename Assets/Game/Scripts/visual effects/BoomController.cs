using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    private float startTime;
    public AnimationCurve lightAnimationCurve;
    public Light boomLight;

    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > 2)
        {
            Destroy(gameObject);
        }
        boomLight.intensity = lightAnimationCurve.Evaluate(Time.time - startTime);
    }
}
