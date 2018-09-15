using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonkeyKongController : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _shotCooldown;
    [Space(10)]

    [SerializeField] private TopDownBarrel _barrelPrefab;

    Animator DonkeyAnimator;
    private float _timeSinceLastShot;

    void Start()
    {
       DonkeyAnimator = GetComponent<Animator>();
        _timeSinceLastShot = _shotCooldown;
    }

    void Update ()
    {
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
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.A))
        {
            DonkeyAnimator.SetBool("move", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryFiring();
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
        var barrelInstance = Instantiate(_barrelPrefab, transform.position, Quaternion.identity);
        barrelInstance.Throw(_projectileSpeed);
    }

    private void GoLeft()
    {
        
        gameObject.transform.position += Vector3.left * Time.deltaTime * _movementSpeed;
    }

    private void GoRight()
    {
        gameObject.transform.position += Vector3.right * Time.deltaTime * _movementSpeed;
    }

    public void ReceivedCollectable()
    {
        Debug.Log("Collected Collectable :D");
    }
}
