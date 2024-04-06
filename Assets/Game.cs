using UnityEngine;

public class Game : MonoBehaviour
{
    private Player _player;
    private Field _field;
    private UI _ui;
    private Item _item;

    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Player>();
        _field = GetComponent<Field>();
        _ui = GetComponent<UI>();
        _item = GetComponent<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_field.IsHitBlock(_player.Position)) {
            _player.BoundY();
        }
        if (_item.isHitPlayer(_player.Position)) {
            _ui.aquireItem( );
        }
    }
}
