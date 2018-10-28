using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
    public GameObject player;

    int startPosition;
    bool directionChosen;
    Vector2 startPos;
    Vector2 endingPos;
    Vector2 direction;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.touches.Length > 0 && Input.touchCount == 1)
        {
            Touch current = Input.GetTouch(0);
            Debug.Log(startPos);

            switch(current.phase)
            {
                case TouchPhase.Began:
                    startPos = current.position;
                    directionChosen = false;
                    break;
                case TouchPhase.Moved:
                    direction = current.position - startPos;
                    break;
                case TouchPhase.Ended:
                    directionChosen = true;
                    break;
            }
        }
        if(directionChosen)
        {
            player.GetComponent<Rigidbody>().AddForce(direction);
        }
	}
}
