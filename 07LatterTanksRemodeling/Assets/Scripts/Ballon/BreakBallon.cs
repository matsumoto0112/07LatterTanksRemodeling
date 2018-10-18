using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBallon : MonoBehaviour {

    float force = 500f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //デバック用
        if (Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("break");
            Break();
        }
    }

    public void Break()
    {
        foreach(Transform part in GetComponentInChildren<Transform>())
        {
            ExplodePart(part, force);
        }
        Destroy(gameObject, 10f);
    }

    private void ExplodePart(Transform part,float force)
    {
        part.transform.parent = null;
        Rigidbody rb = part.gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddExplosionForce(force, Vector3.zero, 0f);
        Destroy(part.gameObject, 10f);
    }

    //衝突判定
    //private void OnCollisionEnter(Collision col)
    //{
    //    if(Input.GetKeyDown(KeyCode.V))
    //    {
    //        Debug.Log("break");
    //        Break();
    //    }
    //}
}
