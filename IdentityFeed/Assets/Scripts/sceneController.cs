using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sceneController : MonoBehaviour {

    public TextAsset trivialMadlibs;
    public TextAsset sportsMadlibs;
    public TextAsset nationMadlibs;
    public TextAsset trivialTopics;
    public TextAsset sportTopics;
    public TextAsset nationTopics;
    public TextAsset randNames;


    public GameObject tweetPrefab;
    public static List<GameObject> allTweets;
    private BuildTweet tweetStringBuilder;
    private tweetGenerator tweetGen;
    private float lastTweetTime;
    private int level;
    private float timeInCurrentLevel;
	// Use this for initialization
	void Start () {
        timeInCurrentLevel = 0;
        tweetStringBuilder = this.GetComponent<BuildTweet>();
        allTweets = new List<GameObject>();
        lastTweetTime = 0;
        level = 0;
	}
	
	// Update is called once per frame
	void Update () {
        timeInCurrentLevel += Time.deltaTime;
        lastTweetTime += Time.deltaTime;
        if(timeInCurrentLevel > 20)
        {
            timeInCurrentLevel = 0;
            this.level++;
        }

        if(lastTweetTime > 5)
        {
            lastTweetTime = 0;
            string topic = topicGen(level);
            int isPos = posGen(topic);
            string madLib = madLibGen(level, isPos);
            createNewTweet(topic, isPos, madLib);
        }
	}

    private string madLibGen(int level, int isPos)
    {
        string text = "";
        if (level == 0)
        {
            text = trivialMadlibs.text;
        }
        else if (level == 1)
        {
            text = sportsMadlibs.text;
        }
        else
        {
            text = nationMadlibs.text;
        }


        var splitText = text.Split('\n');
        var randomIndex = UnityEngine.Random.Range(0, splitText.Length);
        return splitText[randomIndex];
    }

    void createNewTweet(string topic, int isPos, string madLib)
    {
        GameObject newTweet = UnityEngine.Object.Instantiate(tweetPrefab);
        newTweet.transform.parent = GameObject.Find("TweetScroler").transform;
        newTweet.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        allTweets.Add(newTweet);
        tweetGen = newTweet.GetComponent<tweetGenerator>();
        tweetGen.generateTweet(madeUpName(), tweetStringBuilder.buildTweet(topic, isPos, madLib), UnityEngine.Random.Range(0, 200), UnityEngine.Random.Range(0, 150));
        GameObject.Find("TweetScroler").GetComponent<RectTransform>().sizeDelta = new Vector2(500, 100 * allTweets.Count);

    }

    private string madeUpName()
    {
        string text = randNames.text;
        var splitText = text.Split('\n');
        var randomIndex = UnityEngine.Random.Range(0, splitText.Length);
        return splitText[randomIndex];
    }

    private string topicGen(int level)
    {
        string text = "";
        if (level == 0)
        {
            text = trivialTopics.text;
        }
        else if (level == 1)
        {
            text = sportTopics.text;
        }
        else { 
            text = nationTopics.text;
        }


        var splitText = text.Split('\n');
        var allTopics = new List<string>();
        foreach (string row in splitText)
        {
            allTopics.Add(row.Split(',')[0]);
        }


        var randomIndex = UnityEngine.Random.Range(0, allTopics.Count);
        return allTopics[randomIndex];
    }


    private int posGen(string topic)
    {
        string text = "";
        if (level == 0)
        {
            text = trivialTopics.text;
        }
        else if (level == 1)
        {
            text = sportTopics.text;
        }
        else
        {
            text = nationTopics.text;
        }

        float prob = 0.5f;
        var splitText = text.Split('\n');
        var allTopics = new List<string>();
        foreach (string row in splitText)
        {
            string first = row.Split(',')[0];
            if(first == topic) {
                prob = float.Parse(row.Split(',')[1]);
            }
        }
        if (UnityEngine.Random.value < prob)
        {
            return 1;
        }
        else if (UnityEngine.Random.value > prob)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}
