using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingDetector : MonoBehaviour {

    private bool isPlayerOutsideDesk;
	
	void Start ()
    {
        isPlayerOutsideDesk = false;
	}
	
	
	void Update ()
    {
		if(transform.position.z > -1.4f && transform.position.z < 1.4f && 
            (transform.position.x > 0.43f || transform.position.x < -0.43f))
        {
            isPlayerOutsideDesk = true;
        }

        if(isPlayerOutsideDesk)
        {
            transform.Translate(new Vector3(0f, -0.25f, 0f));
        }
	}
}
