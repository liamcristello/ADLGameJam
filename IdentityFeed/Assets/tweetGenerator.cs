using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tweetGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        generateTweet("Xx_bonyBoy_xX", "How tf the moon even exist", 999, 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void generateTweet(string name, string content, int upvotes, int downvotes)
    {
        foreach(Transform child in this.transform)
        {
            if(child.name == "Name")
            {
                child.GetComponent<Text>().text = name;
            }
            else if(child.name == "Content")
            {
                child.GetChild(0).GetComponent<Text>().text = content;
            }
            else if(child.name == "Upvotes")
            {
                Debug.Log(child.GetChild(0).GetComponent<Text>().text);
                child.GetChild(0).GetComponent<Text>().text = upvotes.ToString();
            }
            else if (child.name == "Downvotes")
            {
                child.GetChild(0).GetComponent<Text>().text = downvotes.ToString();
            }
            else if(child.name == "Image")
            {
                child.GetComponent<Image>().color = Random.ColorHSV(0, 1, 0f, 1, .5f, 1);
            }
        }
        
    }
}
