using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationObject : MonoBehaviour
{
    [SerializeField] float speed = 100.0f;

    private void Start()
    {
      
    }

    private void Update()
    {
        transform.Rotate(0, 0, speed * Time.unscaledDeltaTime);
    }
}
