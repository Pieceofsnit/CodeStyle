using System.Collections;
using UnityEngine;

public class AutomaticBurst : MonoBehaviour
{
    [SerializeField] private Bullet _prefabBullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _velocity;
    [SerializeField] private float _timeWaitShoot;
    [SerializeField] private float _shootForce;
    [SerializeField] private int _amountBullet;

    private void Start()
    {   
        StartCoroutine(BulletShot());
    }   

    private IEnumerator BulletShot()
    {
        var waitForSecond = new WaitForSeconds(_timeWaitShoot);

        while (_amountBullet >= 0)
        {
            _amountBullet--;
            Instantiate(_prefabBullet, _shootPoint.position, _shootPoint.rotation).Shoot(_shootPoint.forward * _shootForce);
            _prefabBullet._rigidbody.AddForce(_shootPoint.transform.forward * _shootForce * Time.deltaTime);
            yield return waitForSecond;
        }
    }

    private void Update()
    {
        transform.LookAt(_target.position);
    }
}