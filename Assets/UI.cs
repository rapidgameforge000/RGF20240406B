using System.Drawing;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _score_text;
    [SerializeField] private TextMeshProUGUI _game_over;
    [SerializeField] private TextMeshProUGUI _high_score;

    private void Start() {
        _game_over.gameObject.SetActive(false);
        _score_text.SetText("{0}", UserData.NowScore);
        _high_score.SetText("HighScore\n<size=20>{0}</size>", UserData.HighScore);
    }

    public void aquireItem() {
        _score_text.SetText("{0}", UserData.NowScore);
    }

    public void gameOver()
    {
        _game_over.gameObject.SetActive(true);
    }
}
