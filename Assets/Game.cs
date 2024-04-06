using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private enum State
    {
        GamePlay,
        GameOver,
    }

    private Player _player;
    private Field _field;
    private UI _ui;
    private Item _item;
    private State _state;

    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        _field = GetComponent<Field>();
        _ui = GetComponent<UI>();
        _item = GetComponent<Item>();
        _state = State.GamePlay;
    }

    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case State.GamePlay:
                if (_field.IsHitBlock(_player.Position)) {
                    _player.BoundY();
                }
                if (_item.isHitPlayer(_player.Position)) {
                    _ui.aquireItem( );
                }
                if (_player.IsDead())
                {
                    _ui.gameOver();
                    Time.timeScale = 0.0f;
                    _state = State.GameOver;
                }
                break;
            case State.GameOver:
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Time.timeScale = 1.0f;
                    SceneManager.LoadScene("Title");
                }
                break;
        }
    }
}
