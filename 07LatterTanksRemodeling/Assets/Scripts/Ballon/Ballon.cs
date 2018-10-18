using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballon : MonoBehaviour {

    private Rigidbody rigid;

    private Vector3 pos;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        pos.y = pos.y + 0.01f;
        rigid.MovePosition(new Vector3(pos.x + Mathf.PingPong(Time.time, 2), pos.y, pos.z));
    }
}
