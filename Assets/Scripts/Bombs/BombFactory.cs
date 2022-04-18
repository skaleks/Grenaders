using UnityEngine;

public class BombFactory
{
    public GameObject GetBombByType(BombType type)
    {
        Bomb bomb = 
            (type == BombType.Blue ? new BlueBomb().GetInstance() 
            : (type == BombType.Red ? new RedBomb().GetInstance() : new GreenBomb().GetInstance()));

        GameObject prefab = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        prefab.transform.localScale = bomb._size;
        prefab.GetComponent<Renderer>().material.color = bomb._color;

        return prefab;
    }

    public GameObject GetBomb()
    {

        return null;
    }
}
