using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bang;

    private Cake _target;
    public Cake Target => _target;

    public void Init(Cake target)
    {
        _target = target;
    }

    public void DestroyEnemy()
    {
        _bang.Play();
        Destroy(gameObject,0.2f);
    }
}
        

   
