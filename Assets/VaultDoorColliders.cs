using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaultDoorColliders : MonoBehaviour
{
    static int _hit;
    [SerializeField] Rigidbody _vaultRB;

    private void Start()
    {
       _hit = 0;
       foreach (Transform child in transform)
       {
           child.gameObject.AddComponent<ColliderHandy>();
       }
    }

    private void Update()
    {
        if (_hit >= 5)
        {
            _vaultRB.isKinematic = false;
            Debug.Log("KINEAMTIC");
        }
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hit))
            {
                var c = hit.collider.GetComponent<ColliderHandy>();
                if (c)
                {
                    c.AddHitOne();
                }
            }
        }
        Debug.DrawRay(ray.origin,ray.direction * 10,Color.red,0.05f);
        
       
    }


    
    public class ColliderHandy : MonoBehaviour
    {
        bool canAdd = true;

        public void AddHitOne()
        {
            if (canAdd)
            {
                _hit++;
                canAdd = false;
            }
            
        }
    }
}
