using UnityEngine;

public class GreenBomb : Bomb
{
    public override Bomb GetInstance()
    {
        this._size = new Vector3(0.3f, 0.3f, 0.3f);
        this._color = Color.green;
        return this;
    }
}
