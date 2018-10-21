using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tweetGenerator : MonoBehaviour {
    public Toggle upvoteToggle;
    public Toggle downvoteToggle;
    public Sprite prof1;
    public Sprite prof2;
    public Sprite prof3;
    public Sprite prof4;
    public Sprite prof5;
    public Sprite prof6;
    public Sprite prof7;
    public Sprite prof8;
    public Sprite prof9;
    public Sprite prof10;
    public Sprite prof11;
    public Sprite prof12;
    public Sprite prof13;
    public Sprite prof14;
    Sprite[] sprites;
    // Use this for initialization
    void Start()
    {
        sprites = new Sprite[14];
        sprites[0] = prof1;
        sprites[1] = prof2;
        sprites[2] = prof3;
        sprites[3] = prof4;
        sprites[4] = prof5;
        sprites[5] = prof6;
        sprites[6] = prof7;
        sprites[7] = prof8;
        sprites[8] = prof9;
        sprites[9] = prof10;
        sprites[10] = prof11;
        sprites[11] = prof12;
        sprites[12] = prof13;
        sprites[13] = prof14;
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
                child.GetComponent<Image>().sprite = sprites[Random.Range(0, 14)];
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
