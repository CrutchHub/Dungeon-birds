using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    [SerializeField] public int totalScore;
    [SerializeField] TextMeshProUGUI stat;

    public void AddScore(int value)
    {
        totalScore += value;
        stat.text = "Очки:" + totalScore.ToString();
    }
}
