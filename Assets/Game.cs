using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

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

    private readonly int[] SCORE = new int[]
    {
        200,//â©
        500,//ê‘
        100,//óŒ
    };


    // Start is called before the first frame update
    void Start()
    {
        UserData.NowScore = 0;
        _state = State.GamePlay;
        _player = GetComponent<Player>();
        _field = GetComponent<Field>();
        _ui = GetComponent<UI>();
        _item = GetComponent<Item>();
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
                int type = _item.getItemType(_player.Position);
                if (type != -1) {
                    UserData.NowScore += SCORE[ type ];
                    _ui.aquireItem( );
                }
                if (_player.IsDead())
                {
                    _ui.gameOver();
                    if (UserData.NowScore > UserData.HighScore)
                    {
                        UserData.HighScore = UserData.NowScore;
                    }
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
