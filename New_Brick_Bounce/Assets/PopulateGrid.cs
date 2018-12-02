using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateGrid : MonoBehaviour {

    public GameObject prefab;
    public int numberToCreate;
    
    // Use this for initialization
	void Start ()
    {
        Populate();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void Populate()
    {
        GameObject newObject;
        
        for(int i = 0; i < numberToCreate; i++)
        {
            newObject = (GameObject)Instantiate(prefab, transform);     // transform is the parent
            //newObject.GetComponent<Button>().image.color = Random.ColorHSV();
            //newObject.GetComponentInChildren<Text>().text = "Level " + (i+1);
            newObject.GetComponentInChildren<Text>().text = " ";
            newObject.GetComponent<Button>().onClick.AddListener(delegate
            {
                LoadSceneOnClick click = new LoadSceneOnClick();
                click.LoadByIndex(i + 1);
            });
        }
    }
}
