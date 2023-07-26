using UnityEngine;
using UnityEngine.SceneManagement;

public class Stars : MonoBehaviour
{
    [SerializeField] TotalScore score;
    [SerializeField] int oneStarThreshold;
    [SerializeField] int secondStarThreshold;
    [SerializeField] int thirdStarThreshold;

    public void SaveProgress()
    {
        if (score.totalScore >= oneStarThreshold && score.totalScore < secondStarThreshold) PlayerPrefs.SetInt("" + SceneManager.GetActiveScene().buildIndex, 1);
        else if (score.totalScore >= secondStarThreshold && score.totalScore < thirdStarThreshold) PlayerPrefs.SetInt("" + SceneManager.GetActiveScene().buildIndex, 2);
        else if (score.totalScore >= thirdStarThreshold) PlayerPrefs.SetInt("" + SceneManager.GetActiveScene().buildIndex, 3);
        SceneManager.LoadScene(0);
    }
}
