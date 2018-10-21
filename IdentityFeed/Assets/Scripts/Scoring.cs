using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Scoring : MonoBehaviour {
    public int score;
    public TextAsset topics;
    public Text contentArea;
    private string topic;
    private char lineSep = '\n';
    private char rowSep = ',';
	// Use this for initialization
	void Start () {
        topic = "cats";
        readData();
	}
	
	// Update is called once per frame
    void Update () {
        
    }

    private void readData(){
        string[] records = topics.text.Split(lineSep);
        foreach (string record in records)
        {
            string[] fields = record.Split(rowSep);
            foreach (string field in fields)
            {
                contentArea.text += field + "\t";
            }
            contentArea.text += '\n';
        }
    }
}


