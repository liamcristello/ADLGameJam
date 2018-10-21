using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Scoring : MonoBehaviour {
    public int score;
    public TextAsset topics;
    public Text contentArea;
    private float multiplier;
    private float percent;
    public string topic;
    private bool topicSeen;
    private char lineSep = '\n';
    private char rowSep = ',';
	// Use this for initialization
	void Start () {
        readData();
        multiplier = percent;
        addFollowers();
	}
	
	// Update is called once per frame
    void Update () {
        
    }

    private void addFollowers(){
        Debug.Log(multiplier);
        // Edits the follower count based on percent
        if (multiplier > 0 && multiplier < .33)
        {
            // Will set a follower count between -5 and 0
            multiplier *= 15;
            multiplier -= 5;
        }else if(multiplier >= .33 && multiplier<.5){
            // Will set a follower counnt between 0 and 1
            multiplier *= 6;
            multiplier -= 2;
        }else if(multiplier >= .5 && multiplier<=1){
            // Will set a follower counnt between 1 and 5
            multiplier *= 8;
            multiplier -= 3;
        }else{
            //If topic is not in list it will default to 1
            multiplier = 1;
        }
        multiplier *= 100; // This is a stand in for the time multiplier, that's an easy thing to add when ready
        multiplier = Mathf.Ceil(multiplier);
        contentArea.text += multiplier; //Put the final follower count onto the scene
    }

    private void readData(){
        //Parses topics.csv to get a percent
        string[] records = topics.text.Split(lineSep);
        foreach (string record in records) {
            string[] fields = record.Split(rowSep);
            foreach (string field in fields) {
                // When it finds the word, it will get the next element
                if (topicSeen) {
                    percent = float.Parse(field);
                }
                if(field == topic){
                    topicSeen = true;

                }else{
                    topicSeen = false;
                }
            }
        }
    }
}


