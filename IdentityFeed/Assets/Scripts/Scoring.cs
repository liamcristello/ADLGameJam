using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.IO;

public class Scoring : MonoBehaviour
{
    public TextAsset topics;
    public TextAsset bad;
    public TextAsset good;
    public Text contentArea;
    public InputField inputer;
    private float followers;
    //private float multiplier;
    //private float percent;
    //public string topic;
    private char lineSep = '\n';
    private char rowSep = ',';


    private HashSet<string> goodWords;
    private HashSet<string> badWords;


    // Use this for initialization
    void Start()
    {

    }

    public void getTextin()
    {
        var tweet = inputer.text;
        string topic = newReadTweet(tweet);
        int isPos = posOrNeg(tweet);
        float multiplier;
        multiplier = readTopic(topic);
        if (isPos == 0)
        {
            multiplier = .5f;
        }else if(isPos < 0){
            multiplier = 1 - multiplier;
        }
        addFollowers(multiplier);
    }

    private void addFollowers(float multiplier)
    {
        Debug.Log(multiplier);
        // Edits the follower count based on percent
        if (multiplier > 0 && multiplier < .33)
        {
            // Will set a follower count between -5 and 0
            multiplier *= 15;
            multiplier -= 5;
        }
        else if (multiplier >= .33 && multiplier < .5)
        {
            // Will set a follower counnt between 0 and 1
            multiplier *= 6;
            multiplier -= 2;
        }
        else if (multiplier >= .5 && multiplier <= 1)
        {
            // Will set a follower counnt between 1 and 5
            multiplier *= 8;
            multiplier -= 3;
        }
        else
        {
            //If topic is not in list it will default to 1
            multiplier = 1;
        }
        multiplier *= 100; // This is a stand in for the time multiplier, that's an easy thing to add when ready
        multiplier = Mathf.Ceil(multiplier);
        followers += multiplier;
        contentArea.text = "";
        contentArea.text += followers; //Put the final follower count onto the scene
    }

    private float readTopic(string topic)
    {

        bool topicSeen = false;
        //Parses topics.csv to get a percent
        string[] records = topics.text.Split(lineSep);
        foreach (string record in records)
        {
            string[] fields = record.Split(rowSep);
            foreach (string field in fields)
            {
                // When it finds the word, it will get the next element
                if (topicSeen)
                {
                    return float.Parse(field);
                }
                if (field == topic)
                {
                    topicSeen = true;

                }
                else
                {
                    topicSeen = false;
                }
            }
        }
        return 0.5f;
    }




    private void newUpdateScore(bool agree, float percentage)
    {
        // agree = true   means that we just sue percentage
        // agree = false  measns we use 1-perfecntage
    }




    private bool isTopic(string word)
    {
        string[] records = topics.text.Split(lineSep);
        foreach (string record in records)
        {
            string[] fields = record.Split(rowSep);
            foreach (string field in fields)
            {

                if (word == field)
                {
                    return true;
                }
            }
        }
        return false;

    }

    private string newReadTweet(string userTweet)
    {
        // return the topic we foudn

        var words = userTweet.Split(' ');
        foreach (string word in words)
        {
            if (isTopic(word))
            {
                return word;
            }
        }
        return "";
    }

    private int posOrNeg(string userTweet)
    {
        // Did the twee containn a positive or negative word?   
        int total = 0;
        var words = userTweet.Split(' ');
        foreach (string word in words)
        {
            if (isGoodWord(word)) { total++; }
            if (isBadWord(word)) { total--; }
        }

        return total;
    }

    private bool isGoodWord(string word)
    {
        string[] records = good.text.Split(lineSep);
        foreach (string record in records)
        {
            if (word == record)
            {
                return true;
            }
        }
        return false;
    }

    private bool isBadWord(string word)
    {
        string[] records = bad.text.Split(lineSep);
        foreach (string record in records)
        {
            if (word == record)
            {
                return true;
            }
        }
        return false;
    }
}





/**
 * 
 * 1) parse topic
 * 2) matches user topic to csv topic
 *      pull out %
 * 3) use % to update score
 * 
 * 
 * 
 * 1) Parse topic
 * 2) pos or neg on topic
 * 3) match topic to %
 * 4) Use pos/neg and % to update score
 */

