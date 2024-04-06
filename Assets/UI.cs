using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI _score;

    void Start()
    {
        _score.text = "ooooo";
    }

    float aaa = 0.0f;

    void Update()
    {
        int i = 0;

        aaa += Time.deltaTime;
        if (2.0f < aaa ) {
            i++;
            aaa = 0.0f;
        }
        _score.text = i.ToString();
    }
}
