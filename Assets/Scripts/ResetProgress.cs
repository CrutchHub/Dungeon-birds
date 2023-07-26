using UnityEngine;

public class ResetProgress : MonoBehaviour
{
    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
