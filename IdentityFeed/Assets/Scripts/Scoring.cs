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
        if (multiplier > 0 && multiplier < .33)
        {
            multiplier *= 15;
            multiplier -= 5;
        }else if(multiplier >= .33 && multiplier<.5){
            multiplier *= 6;
            multiplier -= 2;
        }else if(multiplier >= .5 && multiplier<=1){
            multiplier *= 8;
            multiplier -= 3;
        }else{
            multiplier = 1;
        }
        multiplier *= 100;
        multiplier = Mathf.Ceil(multiplier);
        contentArea.text += multiplier;
    }

    private void readData(){
        string[] records = topics.text.Split(lineSep);
        foreach (string record in records) {
            string[] fields = record.Split(rowSep);
            foreach (string field in fields) {
                if (topicSeen)
                {
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


