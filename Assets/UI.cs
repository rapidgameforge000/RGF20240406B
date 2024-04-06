using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI _score;

    public void SetScore(int score) {
        _score.text = score.ToString();
    }
}
