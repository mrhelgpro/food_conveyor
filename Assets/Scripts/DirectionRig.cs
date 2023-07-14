using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionRig : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Update()
    {
        transform.localEulerAngles = new Vector3(90, _target.eulerAngles.y - 180, 0);
    }
}
