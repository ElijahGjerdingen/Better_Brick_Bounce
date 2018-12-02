using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject goal;
    public Text victoryText;
    public Text movedText;

    float currentVolY = 0f;
    float currentVolX = 0f;
    int startPosition;
    bool directionChosen;
    Vector2 startPos;
    Vector2 endingPos;
    Vector2 direction;
    Collider cylCollider;
    bool goalTriggered = false;
    int moves = 0;

    // Use this for initialization
    void Start()
    {
        cylCollider = goal.GetComponent<CapsuleCollider>();
        cylCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touches.Length > 0 && Input.touchCount == 1)
        {
            Touch current = Input.GetTouch(0);
            Debug.Log(startPos);

            switch (current.phase)
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
                    moves++;
                    break;
            }
        }
        movedText.text = "Number of moves : " + moves;
        if (directionChosen)
        {
            player.GetComponent<Rigidbody>().AddForce((direction.x / 2), player.transform.position.y, (direction.y / 2));
            currentVolX = direction.x / 2;
            currentVolY = direction.y / 2;

        }
        /*if(!player.GetComponent<Rigidbody>().GetRelativePointVelocity(direction).Equals(0))
        {
            player.GetComponent<Rigidbody>().AddForce(currentVolX, player.transform.position.y, currentVolY);
            currentVolX -= 0.5f;
            currentVolY -= 0.5f;
        }*/
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goal")
        {
            goalTriggered = true;
            victoryText.enabled = true;
        }
    }
}
