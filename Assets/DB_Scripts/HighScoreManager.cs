using UnityEngine;
using System.Collections;
using System;
using System.Data;
using Mono.Data.Sqlite;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


/// This script handles all communication with the database

public class HighScoreManager : MonoBehaviour
{

    
    private string connectionString;


    private List<HighScore> highScores = new List<HighScore>();

   
    public GameObject scorePrefab;

   
    public Transform scoreParent;

 
    public int topRanks;

   
    public int saveScores;

  
    public InputField enterName;


    public GameObject nameDialog;

    // Use this for initialization

	void Awake(){
		if (PlayerPrefs.HasKey ("playerScore")) {
			nameDialog.SetActive (true);

		} else {
			nameDialog.SetActive (false);
		}
	}

    void Start()
    {
        
        connectionString = "URI=file:" + Application.dataPath + "/HighScoreDB.sqlite";

        CreateTable();
      
        DeleteExtraScore();

        ShowScores();
    }

    // Update is called once per frame
    void Update()
    {
		
    }



		
    private void CreateTable()
    {
        //Creates the connection
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            //Opens the connection
            dbConnection.Open();

            //Creates a command so that we can execute it on the database
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                //Create the query 
                string sqlQuery = String.Format("CREATE TABLE if not exists HighScores (PlayerID INTEGER PRIMARY KEY  AUTOINCREMENT  NOT NULL  UNIQUE , Name TEXT NOT NULL , Score INTEGER NOT NULL , Date DATETIME NOT NULL  DEFAULT CURRENT_DATE)");

                
                dbCmd.CommandText = sqlQuery;

        
                dbCmd.ExecuteScalar();

               
                dbConnection.Close();
            }
        }
    }


    public void EnterName()
    {

        if (enterName.text != string.Empty)
        {
			int score = PlayerPrefs.GetInt ("playerScore");
            InsertScore(enterName.text, score); 

            enterName.text = string.Empty; 

            ShowScores(); 

        }
    }

  
 
    private void InsertScore(string name, int newScore)
    {
        GetScores(); 

        int hsCount = highScores.Count; 

        if (highScores.Count > 0)
        {
            HighScore lowestScore = highScores[highScores.Count - 1]; 

            //If the lowest score needs to be replaced
            if (lowestScore != null && saveScores > 0 && highScores.Count >= saveScores && newScore > lowestScore.Score)
            {
                DeleteScore(lowestScore.ID); 

                hsCount--; 
            }
        }
        if (hsCount < saveScores) 
        {
            
            using (IDbConnection dbConnection = new SqliteConnection(connectionString))
            {
                //Opens the connection
                dbConnection.Open();

               
                using (IDbCommand dbCmd = dbConnection.CreateCommand())
                {
                    
                    string sqlQuery = String.Format("INSERT INTO HighScores(Name,Score) VALUES(\"{0}\",\"{1}\")", name, newScore);

                    dbCmd.CommandText = sqlQuery; 
                    dbCmd.ExecuteScalar(); 
                    dbConnection.Close();


                }
            }
        }
    }

   
    private void GetScores()
    {
        
        highScores.Clear();

      
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            //Opens the connection
            dbConnection.Open();

            //Creates a database comment
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                
                string sqlQuery = "SELECT * FROM HighScores";

                
                dbCmd.CommandText = sqlQuery;

                
                using (IDataReader reader = dbCmd.ExecuteReader())
                {
                    while (reader.Read()) 
                    {
                        
                        highScores.Add(new HighScore(reader.GetInt32(0), reader.GetInt32(2), reader.GetString(1), reader.GetDateTime(3)));
                    }

                    //Closes the connection
                    dbConnection.Close();
                    reader.Close();
                }
            }
        }

        highScores.Sort(); //Sorts the highscore from highest to lowest
    }

    
    private void DeleteScore(int id)
    {
        //Creates a database connection
        using (IDbConnection dbConnection = new SqliteConnection(connectionString))
        {
            dbConnection.Open(); //Opens the connection

            //Creates a database command
            using (IDbCommand dbCmd = dbConnection.CreateCommand())
            {
                //Creates a query
                string sqlQuery = String.Format("DELETE FROM HighScores WHERE PlayerID = \"{0}\"", id);

               
                dbCmd.CommandText = sqlQuery;

             
                dbCmd.ExecuteScalar();

                //Closes the connection
                dbConnection.Close();


            }
        }
    }

   
    private void ShowScores()
    {
        GetScores(); //Gets the scores from the database

        //Runs through all the scores
        foreach (GameObject score in GameObject.FindGameObjectsWithTag("Score"))
        {
            //Destroyes all the old scores
            Destroy(score);
        }

        for (int i = 0; i < topRanks; i++)
        {
            if (i <= highScores.Count - 1) 
            {
                GameObject tmpObjec = Instantiate(scorePrefab); 

                HighScore tmpScore = highScores[i]; 

                
                tmpObjec.GetComponent<HighScoreScript>().SetScore(tmpScore.Name, tmpScore.Score.ToString(), "#" + (i + 1).ToString());

                tmpObjec.transform.SetParent(scoreParent); //Sets the score of the parent

                tmpObjec.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1); //Makes sure that the object has the correct scale
            }

        }
    }

   
    private void DeleteExtraScore()
    {
        GetScores(); //Gets the current scores

        if (saveScores <= highScores.Count)
        {
            int deleteCount = highScores.Count - saveScores; 

            highScores.Reverse(); 

            using (IDbConnection dbConnection = new SqliteConnection(connectionString)) //Creates a connection
            {
                dbConnection.Open(); //Opens the connection

                using (IDbCommand dbCmd = dbConnection.CreateCommand()) //Creates a command
                {
                    for (int i = 0; i < deleteCount; i++) //Deletes the scores
                    {
                        
                        string sqlQuery = String.Format("DELETE FROM HighScores WHERE PlayerID = \"{0}\"", highScores[i].ID);

                        
                        dbCmd.CommandText = sqlQuery;

                        dbCmd.ExecuteScalar(); //Executes the command
                    }

                    dbConnection.Close(); //Closes the connection


                }
            }
        }
    }
}
