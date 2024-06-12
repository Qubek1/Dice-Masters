using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextUdateAnimation : MonoBehaviour
{
    public AnimationCurve sizeAnimationCurve;
    private float animationStartTime;
    private float size = 1;
    public void PlayAnimation(float newSize)
    {
        animationStartTime = Time.time;
        size = newSize;
    }

    private void Update()
    {
        transform.localScale = size * Vector3.one * sizeAnimationCurve.Evaluate(Time.time - animationStartTime);
    }
}
