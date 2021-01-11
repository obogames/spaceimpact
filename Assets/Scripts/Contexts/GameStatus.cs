using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour 
{
    public static GameStatus Instance {get; private set;}

    private void Awake()
    {
        if (Instance == null)
        {
            Debug.Log("[DontDie] Setup 1st time");
            Instance = this;

            DontDestroyOnLoad(this);
        }
        Debug.Log("[DontDie] Game Started");
    }
    
    public int Score {get; private set;}

    public void AddScore(int n)
    {
        Score += n;
    }
}
