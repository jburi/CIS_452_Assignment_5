/*
 * Jake Buri
 * RPSGame.cs
 * Assignment 5
 * Handles spawning and comparison of RPS
 */

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RPSGame : MonoBehaviour
{
    public RPSFactory factory;
    public GameObject m_RockPrefab;            
    public GameObject m_PaperPrefab;		       
    public GameObject m_ScissorsPrefab;		  
    public Text m_MessageText;               
    public Transform m_PlayerSpawnPoint;  
    public Transform m_EnemySpawnPoint; 

    private string playerChoice;
    private string enemyChoice;
    private GameObject rps;

    private void Start()
    {
        Reset();
    }

    private void CompareRPS(string player, string enemy)
    {
		playerChoice = player.ToString();
        enemyChoice = enemy.ToString();

        //0 = null, 1 = Win, 2 = Lose, 3 = Tie
        switch (playerChoice)
        {
            case "Rock":
                if (enemyChoice == "Rock")
                {
                    m_MessageText.text = "Tie";
                    break;
                }
                else if (enemyChoice == "Paper")
                {
                    m_MessageText.text =  "Lose";
                    break;
                }
                else if (enemyChoice == "Scissors")
                {
                    m_MessageText.text =  "Win";
                    break;
                }
                else
                {
                    m_MessageText.text =  "NULL";
                    break;
                }
            case "Paper":
                if (enemyChoice == "Rock")
                {
                    m_MessageText.text =  "Win";
                    break;
                }
                else if (enemyChoice == "Paper")
                {
                    m_MessageText.text =  "Tie";
                    break;
                }
                else if (enemyChoice == "Scissors")
                {
                    m_MessageText.text =  "Lose";
                    break;
                }
                else
                {
                    m_MessageText.text =  "NULL";
                    break;
                }
            case "Scissors":
                if (enemyChoice == "Rock")
                {
                    m_MessageText.text =  "Lose";
                    break;
                }
                else if (enemyChoice == "Paper")
                {
                    m_MessageText.text =  "Win";
                    break;
                }
                else if (enemyChoice == "Scissors")
                {
                    m_MessageText.text =  "Tie";
                    break;
                }
                else
                {
                    m_MessageText.text =  "NULL";
                    break;
                }
        }
    }

    public void SetOpponentChoice()
    {
        int rnd = Random.Range(0, 3);

        switch (rnd)
        {
            case 0:
                enemyChoice = "Rock";
                break;
            case 1:
                enemyChoice = "Paper";
                break;
            case 2:
                enemyChoice = "Scissors";
                break;
        }

        SpawnEnemyRPS(enemyChoice);
        CompareRPS(playerChoice, enemyChoice);
    }

    public void SetPlayerChoice(string type)
    {
        switch (type)
        {
            case "Rock":
                playerChoice = "Rock";
                break;
            case "Paper":
                playerChoice = "Paper";
                break;
            case "Scissors":
                playerChoice = "Scissors";
                break;
        }
    }

    public void SpawnPlayerRPS(string type)
    {
        Debug.Log("Type passed in: " + type);
        rps = factory.CreateRPS(type);
        Debug.Log(rps);

        Instantiate(rps, m_PlayerSpawnPoint.position, m_PlayerSpawnPoint.rotation);
    }

    public void SpawnEnemyRPS(string type)
    {
        Debug.Log("Type passed in: " + type);
        rps = factory.CreateRPS(type);
        Debug.Log(rps);

        Instantiate(rps, m_EnemySpawnPoint.position, m_EnemySpawnPoint.rotation);
    }

    public void Reset()
    {
		Destroy(GameObject.Find("Paper(Clone)"));
		Destroy(GameObject.Find("Rock(Clone)"));
		Destroy(GameObject.Find("Scissors(Clone)"));
	}
}