using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] Text _scoreText;
    void Start()
    {
           UpdateScoreText();
    }

    public void AddToScore(int pointsToAdd)
    {
        _score += pointsToAdd;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        _scoreText.text = _score.ToString();
    }
}
