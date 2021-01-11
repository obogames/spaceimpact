using UnityEngine;
using TMPro;

public class GUIScript : MonoBehaviour
{
    Transform hpbar;
    TextMeshProUGUI scoreBar;

    void Start()
    {
        hpbar = transform.Find("HpBar");
        scoreBar = transform.Find("ScoreBar").GetComponent<TextMeshProUGUI>();

        if (hpbar is null)
            Debug.LogError("[GUI] HpBar not found!");

        if (scoreBar is null)
            Debug.LogError("[GUI] ScoreBar not found!");

        SetHealth(3);
    }

    public void SetHealth(int n) {
        for(int i = 0; i<4; i++)
            hpbar.GetChild(i).gameObject.SetActive(i < n);
    }

    public void SetActiveSpec() {

    }

    public void SetSpecCount(int n) {

    }

    public void SetScore(int n) {
        scoreBar.text = n.ToString();
    }
}
