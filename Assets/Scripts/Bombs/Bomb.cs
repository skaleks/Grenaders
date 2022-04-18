using UnityEngine;

public abstract class Bomb
{
    public Color _color { get; protected set; }
    public Vector3 _size { get; protected set; }

    public abstract Bomb GetInstance();
}

