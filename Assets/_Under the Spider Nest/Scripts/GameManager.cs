using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI enemiesDefeatedText;
    int totalEnemiesDefeated = 0;

    public int currentLevel;
    int enemiesToDefeat;
    public int enemiesDefeated = 0;


    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    public int ConditionToWin()
    {
        switch (currentLevel)
        {
            case 1:
                enemiesToDefeat = 10;
                break;
            case 2:
                enemiesToDefeat = 20;
                break;
            case 3:
                enemiesToDefeat = 30;
                break;
            case 4:
                enemiesToDefeat = 40;
                break;
        }

        return enemiesToDefeat;
    }

    public void CheckWinCondition()
    {
        if (enemiesDefeated >= ConditionToWin())
        {
            
            switch (currentLevel)
            {
                case 1:
                    SceneManager.LoadScene("Level02");
                    break;
                case 2:
                    SceneManager.LoadScene("Level03");
                    break;
                case 3:
                    SceneManager.LoadScene("Level04");
                    break;
                case 4:
                    SceneManager.LoadScene("Win");
                    break;
            }
        }
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++;
        enemiesDefeatedText.text = "Enemies Defeated: " + enemiesDefeated.ToString() + "/" + ConditionToWin().ToString();
        CheckWinCondition();
    }

}
