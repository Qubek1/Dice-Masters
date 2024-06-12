using System.Collections;
using UnityEngine;

public class BasicDiceRotation : MonoBehaviour
{
    private Quaternion StartRotation;
    [SerializeField]
    private Transform DiceTransform;
    [SerializeField]
    private float followSpeed = 0.2f;
    [SerializeField]
    private float rotationSpeed = 20f;
    public bool rotating = false;

    private void Awake()
    {
        StartRotation = Quaternion.AngleAxis(-45f, new Vector3(0, 1, 0));
        StartRotation *= Quaternion.FromToRotation(new Vector3(0, Mathf.Sqrt(2) / 2, -1), new Vector3(0, 0, -1));
    }

    private void Update()
    {
        if (rotating)
            Rotate();
    }

    private void Rotate()
    {
        Quaternion TargetRotation = StartRotation * Quaternion.AngleAxis(Time.time * rotationSpeed, new Vector3(1, 1, -1));
        DiceTransform.rotation = Quaternion.Lerp(DiceTransform.rotation, TargetRotation, followSpeed);
    }
}
