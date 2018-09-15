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

    private float _timeSinceLastShot;

    void Start()
    {
        _timeSinceLastShot = _shotCooldown;
    }

    void Update ()
    {
        if (_timeSinceLastShot < _shotCooldown)
            _timeSinceLastShot += Time.deltaTime;
		if (Input.GetKey(KeyCode.LeftArrow))
            GoLeft();
        if (Input.GetKey(KeyCode.RightArrow))
            GoRight();
	    if (Input.GetKeyDown(KeyCode.Space))
	        TryFiring();
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
        gameObject.transform.position += Vector3.left * _movementSpeed;
    }

    private void GoRight()
    {
        gameObject.transform.position += Vector3.right * _movementSpeed;
    }
}