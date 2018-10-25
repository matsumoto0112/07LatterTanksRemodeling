using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBreak : MonoBehaviour {

    private Score score;

    private Score comboBonus;

	// Use this for initialization
	void Start () {
        score = Score.Instance;

        comboBonus = Score.Instance;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="Bullet")
        {
            Destroy(this.gameObject);

            score.Add(100);
            comboBonus.Add(1);
        }
    }
}
