using UnityEngine;
public class RedBomb : Bomb
{
    public override Bomb GetInstance()
    {
        this._size = new Vector3(0.3f, 0.3f, 0.3f);
        this._color = Color.red;
        return this;
    }
}
