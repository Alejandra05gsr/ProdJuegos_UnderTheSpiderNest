using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
                    SceneManager.LoadScene("Win");
                    break;
            }
        }
    }

    public void EnemyDefeated()
    {
        enemiesDefeated++;
        CheckWinCondition();
    }

}
