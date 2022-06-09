using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IBombable))]
public class Inventory
{
    public int GreenBombCount { get; private set; }
    public int RedBombCount { get; private set; }
    public int BlueBombCount { get; private set; }


    public void PutBomb(GameObject bomb)
    {
        IBombable bombType = bomb.GetComponent<IBombable>();

        if (typeof(GreenBomb).IsInstanceOfType(bombType))
        {
            GreenBombCount++;
            Debug.Log("Green" + GreenBombCount);
        }
        if (typeof(BlueBomb).IsInstanceOfType(bombType))
        {
            BlueBombCount++;
            Debug.Log("Blue " + BlueBombCount);
        }
        if (typeof(RedBomb).IsInstanceOfType(bombType))
        {
            RedBombCount++;
            Debug.Log("Red " + RedBombCount);
        }
    }

    public bool TakeBomb(BombType type)
    {

        return false;
    }

    private void SwitchBomb()
    {
        List<BombType> bombList = new List<BombType>();

        // TO DO
    }
}
