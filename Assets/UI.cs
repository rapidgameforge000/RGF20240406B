using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    private TextMeshProUGUI _score_text;
    private int _score;


    public void aquireItem() {
        _score += 100;
        _score_text.text = _score.ToString();
    }
}
