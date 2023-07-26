using UnityEngine;
using UnityEngine.UI;

public class LoadStars : MonoBehaviour
{
    [SerializeField] int levelNumber;
    [SerializeField] Image firstStar;
    [SerializeField] Image secondStar;
    [SerializeField] Image thirdStar;
    private void Awake()
    {
        int stars = PlayerPrefs.GetInt("" + levelNumber, 0);
        switch (stars)
        {
            case 0: break;
                case 1:
                firstStar.color = new Color(255, 218, 0);
                break;
            case 2:
                firstStar.color = new Color(255, 218, 0);
                secondStar.color = new Color(255, 218, 0);
                break;
            case 3:
                firstStar.color = new Color(255, 218, 0);
                secondStar.color = new Color(255, 218, 0);
                thirdStar.color = new Color(255, 218, 0);
                break;
        }
    }
}
