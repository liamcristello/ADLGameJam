using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tweetGenerator : MonoBehaviour {
    public Toggle upvoteToggle;
    public Toggle downvoteToggle;
    // Use this for initialization
    void Start()
    {
        generateTweet("Anthony", "It really do be like that", 35, 200);
        upvoteToggle.onValueChanged.AddListener(delegate { valueChanged(upvoteToggle.isOn, upvoteToggle); });
        downvoteToggle.onValueChanged.AddListener(delegate { valueChanged(downvoteToggle.isOn, downvoteToggle); });

    }
    // Update is called once per frame
    void Update () {
		
	}

    public void generateTweet(string name, string content, int upvotes, int downvotes)
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

    void valueChanged(bool isOn, Toggle currTog){
      
            string currText = currTog.transform.Find("Text").GetComponent<Text>().text;
            if (isOn)
            {
                currTog.transform.Find("Text").GetComponent<Text>().text = (int.Parse(currText) + 1).ToString();
            }
            else if(!isOn)
            {
                currTog.transform.Find("Text").GetComponent<Text>().text = (int.Parse(currText) -1).ToString();

            }
        }
}
