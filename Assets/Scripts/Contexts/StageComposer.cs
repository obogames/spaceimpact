using UnityEngine;

public class StageComposer : MonoBehaviour 
{
    public static StageComposer Instance {get; private set;}

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(this);
    }

    public int Score {get; private set;}

    public void AddScore(int n)
    {
        Score += n;
    }

    public void Die()
    {

    }
}