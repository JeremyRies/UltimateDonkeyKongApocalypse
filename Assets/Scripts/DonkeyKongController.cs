using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class DonkeyKongController : MonoBehaviour
{
    [SerializeField] public float _projectileSpeed;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _shotCooldown;
    [SerializeField] private float _collectableDuration;
    [Space(10)]

    private GameObject projectile;


    Animator DonkeyAnimator;
    private float _timeSinceLastShot;
    public bool _collectableRunning;

    void Start()
    {
       DonkeyAnimator = GetComponent<Animator>();
        _timeSinceLastShot = _shotCooldown;
        projectile = InventoryManager.Instance._collectablePrefabDictionary[CollectableEnum.Normal];
    }

    void Update ()
    {
        if (StateController.IsPaused) return;

        if (_timeSinceLastShot < _shotCooldown)
        { 
                _timeSinceLastShot += Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            GoLeft();
            DonkeyAnimator.SetBool("move", true);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            GoRight();
            DonkeyAnimator.SetBool("move", true);
        }
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.A) )
        {
            DonkeyAnimator.SetBool("move", false);
        }

        if (Input.GetKey(KeyCode.X))
        {
            if (InventoryManager.Instance.GetActiveSpecialAmount()!=0 && !_collectableRunning)
            {
                var obj = InventoryManager.Instance.GetActiveSpecial();
                if (InventoryManager.Instance._collectableProjectileDictionary[obj])
                {
                    projectile = InventoryManager.Instance._collectablePrefabDictionary[obj];
                    StartCoroutine(CollectableTimer());
                }
                else
                {
                    Instantiate(InventoryManager.Instance._collectablePrefabDictionary[obj]);
                }
            
                InventoryManager.Instance.RemoveCollectableFromActive();
               
            }
            
        }
        
        if (Input.GetKey(KeyCode.Space))
        {
            TryFiring();
        }
        else
        {
            DonkeyAnimator.SetBool("shoot", false);
        }
    }

    private void TryFiring()
    {
        if (_timeSinceLastShot < _shotCooldown) return;
        Fire();
        _timeSinceLastShot = 0f;
    }

    private void Fire()
    {
        DonkeyAnimator.SetBool("shoot", true);
        var barrelInstance = Instantiate(projectile, new Vector2(transform.position.x, transform.position.y+0.5f), Quaternion.identity);
    }

    private void GoLeft()
    {
        
        gameObject.transform.position += Vector3.left * Time.deltaTime * _movementSpeed;
    }

    private void GoRight()
    {
        gameObject.transform.position += Vector3.right * Time.deltaTime * _movementSpeed;
    }

    public void ReceivedCollectable(CollectableEnum typeOfCollectable)
    {
        InventoryManager.Instance.AddCollectable(typeOfCollectable);
    }

    IEnumerator CollectableTimer()
    {
        _collectableRunning = true;
        yield return new WaitForSeconds(_collectableDuration);
        projectile = InventoryManager.Instance._collectablePrefabDictionary[CollectableEnum.Normal];
        _collectableRunning = false;
    }
}
