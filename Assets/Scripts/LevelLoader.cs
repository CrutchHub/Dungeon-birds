using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int levelID;

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelID);
    }
}
