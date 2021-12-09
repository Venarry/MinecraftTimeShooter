using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Component[] allComponents;
    [SerializeField] private GameObject _head;
    [SerializeField] private GameObject _brokenHead;

    private EnemyRagdoll _ragdoll;
    private Animator _animator;
    private EnemyCalculate _enemyCalculate;

    private void Start()
    {
        _ragdoll = GetComponent<EnemyRagdoll>();
        _animator = GetComponent<Animator>();
        _enemyCalculate = FindObjectOfType<EnemyCalculate>();
    }

    public void GetHit(bool isHead)
    {
        _animator.enabled = false;
        _ragdoll.ActiveRagdoll();
        DeleteComponent();
        DeleteChildrenComponents();
        

        if (isHead)
        {           
            _head.SetActive(false);
            _brokenHead.SetActive(true);
        }
    }

    private void DeleteComponent()
    {
        foreach (Component currentComponent in allComponents)
        {
            Destroy(currentComponent);
        }
    }
    private void DeleteChildrenComponents()
    {
        gameObject.AddComponent<TempObject>();
        Head[] headObjects = GetComponentsInChildren<Head>();
        foreach (Head currentObject in headObjects)
        {
            Destroy(currentObject);
            currentObject.gameObject.AddComponent<Ground>();
        }
        Body[] bodyObjects = GetComponentsInChildren<Body>();
        foreach (Body currentObject in bodyObjects)
        {
            Destroy(currentObject);
            currentObject.gameObject.AddComponent<Ground>();
        }
    }
    private void OnDestroy()
    {
        if (_enemyCalculate != null)
        {
            _enemyCalculate.StartCoroutine(_enemyCalculate.ChangeEnemyCount());
        }
    }
}
