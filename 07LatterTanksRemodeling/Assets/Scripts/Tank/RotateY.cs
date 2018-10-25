using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateY : MonoBehaviour
{

    [SerializeField]
    private CameraChangeFirstThird cameraChangeFirstThird;
    [SerializeField]
    private float speed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (cameraChangeFirstThird.mode == Person.Third) return;
        float y = Input.GetAxisRaw("Horizontal1");
        this.transform.Rotate(new Vector3(0, 1, 0), y * speed);
    }
}
