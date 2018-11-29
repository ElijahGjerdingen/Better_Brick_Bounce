using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
    public GameObject player;
    public GameObject goal;

    int startPosition;
    bool directionChosen;
    Vector2 startPos;
    Vector2 endingPos;
    Vector2 direction;
    Collider cylCollider;
    bool goalTriggered = false;

    // Use this for initialization
    void Start () {
        cylCollider = goal.GetComponent<CapsuleCollider>();
        cylCollider.isTrigger = true;
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
            player.GetComponent<Rigidbody>().AddForce((direction.x/2), player.transform.position.y, (direction.y/2));
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Goal")
        {
            goalTriggered = true;
        }
    }
}
