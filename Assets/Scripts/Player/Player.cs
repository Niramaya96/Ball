using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public int Money { get; private set; }

    public void AddMoney(int money)
    {
        Money += money;
    }

}

        
    
    
