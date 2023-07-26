using System;
using UnityEngine;

public class Score : MonoBehaviour
{   
    [SerializeField] private TotalScore score;
    [SerializeField] public int scoreFromObject;
    [SerializeField] private int scoreScale;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") || scoreFromObject < collision.relativeVelocity.x * scoreScale)
        {
            score.AddScore(scoreFromObject);
            scoreFromObject = 0;
            Destroy(gameObject);
        }
        else
        {
            scoreFromObject -= CalculateScore(collision);
            score.AddScore(CalculateScore(collision));
        }
        
    }

    private int CalculateScore(Collision collision)
    {
        return (int)MathF.Abs(collision.relativeVelocity.x * scoreScale);
    }
}
