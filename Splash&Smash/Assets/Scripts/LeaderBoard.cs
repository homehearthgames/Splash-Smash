using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    public GameObject rankTemplate;
    public GameObject nameTemplate;
    public GameObject ScoreTemplate;

    public GameObject levelText;
    private string levelMatch;

    public Sprite[] spr;
    public Image BGImage;

    private TMP_Text txtName;
    private TMP_Text txtRank;
    private TMP_Text txtScore;

    dreamloLeaderBoard dl;
    List<dreamloLeaderBoard.Score> scoreList;

    void Start()
    {
        // get the reference here...
        dl = dreamloLeaderBoard.GetSceneDreamloLeaderboard();

        //dl.AddScore("CCD", 10);
        dl.GetScores();

        //GameManager.score = 500;
        //GameManager.levelName = "SurfsideCityScene";

        levelText.GetComponent<TMP_Text>().text = GameManager.levelName.Substring(0, GameManager.levelName.Length - 5);

        // change background
        if (GameManager.levelName == "SurfsideCityScene")
        {
            BGImage.sprite = spr[0];
            levelMatch = "Sur";
        }
        if (GameManager.levelName == "JumanjiJungleScene")
        {
            BGImage.sprite = spr[1];
            levelMatch = "Jum";
        }
        if (GameManager.levelName == "SantoriniSunsetScene")
        {
            BGImage.sprite = spr[2];
            levelMatch = "San";
        }

        Debug.Log("Scene:" + GameManager.levelName);
        Debug.Log("Score:" + GameManager.score);

        StartCoroutine(PopulateScores());

    }


    IEnumerator PopulateScores()
    {
        int maxToDisplay = 10;
        int count = 0;
        int rank = 999;
        Debug.Log("displaying leaderboard");
        scoreList = dl.ToListHighToLow();
        float delay = 2.5f;
        float startTime = Time.time;
        while (scoreList.Count == 0 && Time.time<startTime+delay)
        {
            scoreList = dl.ToListHighToLow();
            yield return null;
        }
        Debug.Log("count:" + scoreList.Count);

        foreach (dreamloLeaderBoard.Score currentScore in scoreList)
        {
            // instantiate Text GameObjects
            GameObject rt=(GameObject)Instantiate(rankTemplate, rankTemplate.transform.parent);
            GameObject nt = (GameObject)Instantiate(nameTemplate, rankTemplate.transform.parent);
            GameObject st = (GameObject)Instantiate(ScoreTemplate, rankTemplate.transform.parent);

            string name = currentScore.playerName.Substring(0, 3);
            string level= currentScore.playerName.Substring(3, 3);

            if (level == levelMatch)
            {
                rt.SetActive(true);
                nt.SetActive(true);
                st.SetActive(true);

                count++;

                if (GameManager.score >= currentScore.score && rank == 999) // if you got a high score
                {
                    rank = count;
                    rt.GetComponent<TMP_Text>().color = new Color32(4, 255, 29, 255);
                    rt.GetComponent<TMP_Text>().text = count.ToString();
                    nt.GetComponent<TMP_Text>().color = new Color32(4, 255, 29, 255);
                    nt.GetComponent<TMP_Text>().text = "";
                    st.GetComponent<TMP_Text>().color = new Color32(4, 255, 29, 255);
                    st.GetComponent<TMP_Text>().text = GameManager.score.ToString();

                    txtName = nt.GetComponent<TMP_Text>();
                    txtRank = rt.GetComponent<TMP_Text>();
                    txtScore = st.GetComponent<TMP_Text>();

                    Debug.Log("High score Rank:" + rank);

                    GameObject nrt = (GameObject)Instantiate(rankTemplate, rankTemplate.transform.parent);
                    GameObject nnt = (GameObject)Instantiate(nameTemplate, rankTemplate.transform.parent);
                    GameObject nst = (GameObject)Instantiate(ScoreTemplate, rankTemplate.transform.parent);

                    nrt.SetActive(true);
                    nnt.SetActive(true);
                    nst.SetActive(true);
                    count++;
                    nrt.GetComponent<TMP_Text>().text = count.ToString();
                    nnt.GetComponent<TMP_Text>().text = name;
                    nst.GetComponent<TMP_Text>().text = currentScore.score.ToString();
                }
                else
                {
                    rt.GetComponent<TMP_Text>().text = count.ToString();
                    nt.GetComponent<TMP_Text>().text = name;
                    st.GetComponent<TMP_Text>().text = currentScore.score.ToString();
                }

                Debug.Log("nt:" + currentScore.playerName);
            }


            if (count >= maxToDisplay) break;
        }


        Debug.Log("r:" + rank + " count:" + count);
        if(rank==999 && count<10)
        {
            // instantiate Text GameObjects
            GameObject rt = (GameObject)Instantiate(rankTemplate, rankTemplate.transform.parent);
            GameObject nt = (GameObject)Instantiate(nameTemplate, rankTemplate.transform.parent);
            GameObject st = (GameObject)Instantiate(ScoreTemplate, rankTemplate.transform.parent);
            rank = count+1;
            rt.GetComponent<TMP_Text>().color = new Color32(4, 255, 29, 255);
            rt.GetComponent<TMP_Text>().text = rank.ToString();
            nt.GetComponent<TMP_Text>().color = new Color32(4, 255, 29, 255);
            nt.GetComponent<TMP_Text>().text = "";
            st.GetComponent<TMP_Text>().color = new Color32(4, 255, 29, 255);
            st.GetComponent<TMP_Text>().text = GameManager.score.ToString();

            txtName = nt.GetComponent<TMP_Text>();
            txtRank = rt.GetComponent<TMP_Text>();
            txtScore = st.GetComponent<TMP_Text>();

            rt.SetActive(true);
            nt.SetActive(true);
            st.SetActive(true);

            Debug.Log("You still got a High score Rank:" + rank);
        }


        // input name
            StartCoroutine(WaitForKeyDown(new KeyCode[] { KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O, KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T, KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y, KeyCode.Z, KeyCode.Alpha0, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Return, KeyCode.Backspace }));


        yield return null;
    }

    IEnumerator WaitForKeyDown(KeyCode[] codes)
    {
        bool pressed = false;

        if (txtName!=null)
        {

            Debug.Log("txtName.text:" + txtName.text);

            while (txtName.text.Length < 4) // do forever
            {
                while (!pressed)
                {
                    foreach (KeyCode k in codes)
                    {
                        if (Input.GetKeyUp(k))
                        {
                            //pressed = true;
                            AddCharToName(k);
                            break;
                        }
                    }
                    yield return null;
                }
            }
        }
        yield return null;

    }

    private void AddCharToName(KeyCode keyCode)
    {
        if (keyCode== KeyCode.Backspace)
        {
            if (txtName.text.Length>=1)
                txtName.text = txtName.text.Substring(0, txtName.text.Length-1);
        }
        else
        {
            txtName.text += keyCode.ToString();
            if (txtName.text.Length > 3)
                txtName.text = txtName.text.Substring(0, 3);

            if (keyCode == KeyCode.Return)
            {
                txtName.color = new Color32(255, 255, 255, 255);
                txtRank.color = new Color32(255, 255, 255, 255);
                txtScore.color = new Color32(255, 255, 255, 255);

                // random number
                int ran = Random.Range(0, 999999);
                string name = txtName.text + GameManager.levelName.Substring(0, 3)+ran.ToString();
                dl.AddScore(name, GameManager.score);
            }
        }  

    }



    // public void AddScoreToLeaderboard(int Score)
    // {
    //     dl.AddScore(this.playerName, Score);
    // }

    /*

    void OnGUI()
    {
        var width200 = new GUILayoutOption[] { GUILayout.Width(500) };

        var width = 920;  // Make this wider to add more columns
        var height = 570;

        var r = new Rect((Screen.width / 2) - (width / 2), 20, width, height);
        GUILayout.BeginArea(r, new GUIStyle("box"));

        GUILayout.BeginVertical();
        GUI.skin.label.fontSize = 18;



        //if (this.gs == gameState.enterscore)
        {
            GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
            myButtonStyle.fontSize = 18;
            Font myFont = (Font)Resources.Load("Fonts/Power", typeof(Font));
            myButtonStyle.font = myFont;


            GUILayout.Label("Total Score: " + GameManager.gameManager.GetScore(), myButtonStyle);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Your Name: ");

            this.playerName = GUILayout.TextField(this.playerName, myButtonStyle);

            if (GUILayout.Button("Save Score", myButtonStyle))
            {
                // add the score...
                if (dl.publicCode == "") Debug.LogError("You forgot to set the publicCode variable");
                if (dl.privateCode == "") Debug.LogError("You forgot to set the privateCode variable");



                //UnityWebRequest www = new UnityWebRequest("http://dreamlo.com/lb/" + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);
                //yield return www.SendWebRequest();

                dl.AddScore(this.playerName+SceneManager.GetActiveScene(), GameManager.gameManager.GetScore());

                //this.gs = gameState.leaderboard;
            }
            GUILayout.EndHorizontal();
        }

        //if (this.gs == gameState.leaderboard)
        {
            GUIStyle myButtonStyle = new GUIStyle(GUI.skin.button);
            myButtonStyle.fontSize = 18;
            Font myFont = (Font)Resources.Load("Fonts/Power", typeof(Font));
            myButtonStyle.font = myFont;

            GUILayout.Label("High Scores:", myButtonStyle);
            List<dreamloLeaderBoard.Score> scoreList = dl.ToListHighToLow();

            if (scoreList == null)
            {
                GUILayout.Label("(loading...)");
            }
            else
            {
                int maxToDisplay = 10;
                int count = 0;
                //Debug.Log("displaying leaderboard");
                foreach (dreamloLeaderBoard.Score currentScore in scoreList)
                {
                    count++;
                    GUILayout.BeginHorizontal();
                    GUILayout.Label(currentScore.playerName, myButtonStyle);
                    GUILayout.Label(currentScore.score.ToString(), myButtonStyle);
                    GUILayout.EndHorizontal();
                    //Debug.Log("LB: " + currentScore.playerName + " " + currentScore.score);
                    if (count >= maxToDisplay) break;

                }
            }

            if (GUILayout.Button("Play Again", myButtonStyle))
            {
                Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
            }

        }
        GUILayout.EndVertical();
        GUILayout.EndArea();

    }
    */

}

