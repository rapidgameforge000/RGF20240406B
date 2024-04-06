using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score_text;
    [SerializeField] private TextMeshProUGUI _game_over;
    private int _score;

    private void Start() {
        _game_over.gameObject.SetActive(false);
    }

    public void aquireItem() {
        _score += 100;
        _score_text.text = _score.ToString();
    }

    public void gameOver()
    {
        _game_over.gameObject.SetActive(true);
    }
}
