using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ViewChecker : MonoBehaviour
{
    private MoveController _player;
    [SerializeField] private LayerMask _mask;

    private void Start()
    {
        _player = FindObjectOfType<MoveController>();
    }
    private void Update()
    {
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1.2f, transform.position.z), (_player.transform.position - transform.position), Color.red);
    }

    public bool IsView()
    {
        RaycastHit hitInfo;
        Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1.2f, transform.position.z), (_player.transform.position - transform.position), out hitInfo, 100f, _mask);
        if (hitInfo.collider.CompareTag("Player"))
        {
            return true;
        }
        else return false;
        

    }
}
