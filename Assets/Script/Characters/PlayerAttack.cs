using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    Animator _anim;
    Camera _mainCamera;

    Ray _ray;
    RaycastHit _hit;

    List<IDamagable> _damagablesInRange;
    [SerializeField] LayerMask _layerMask;
    [SerializeField] float _attackRange = 5f; // Rango de ataque del jugador

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _damagablesInRange = new List<IDamagable>();
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(_damagablesInRange.Count > 0)
            {
                SimpleAttack();
            }

            _ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit, 20, _layerMask))
            {
                Debug.DrawRay(_ray.origin, _ray.direction * 20, Color.red);

                // Melee Attack
                var damagable = _hit.transform.GetComponent<IDamagable>();

                if (damagable != null)
                {
                    SimpleAttack(_hit.point); // Pasar el punto de impacto para la dirección de ataque
                }
            }
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            _anim.SetBool("Defense", true);
        }
        else
        {
            _anim.SetBool("Defense", false);
        }
    }

    void SimpleAttack(Vector3 toLook = default(Vector3))
    {
        if (_damagablesInRange.Count >= 1)
        {
            if (toLook != default(Vector3))
            {
                // Obtiene la dirección en el plano horizontal
                Vector3 direction = new Vector3(toLook.x - transform.position.x, 0, toLook.z - transform.position.z);
                if (direction != Vector3.zero)
                {
                    // Establece la rotación solo en el eje Y
                    Quaternion targetRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
                }
            }
    
            _damagablesInRange[0].Damage(10);
            _anim.SetTrigger("SimpleAttack");
        }
    }

    void StrongAttack()
    {
        _anim.SetTrigger("StrongAttack");
    }

    private void OnTriggerEnter(Collider other)
    {
        var damagable = other.GetComponent<IDamagable>();

        if (damagable != null && IsInAttackRange(other.transform))
        {
            if (!_damagablesInRange.Contains(damagable))
            {
                _damagablesInRange.Add(damagable);
                Debug.Log("Damagable Added " + other.name);
                Debug.Log("Damagables in Range " + _damagablesInRange.Count);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var damagable = other.GetComponent<IDamagable>();

        if (damagable != null && _damagablesInRange.Contains(damagable))
        {
            _damagablesInRange.Remove(damagable);
            //Debug.Log("Damagable Removed " + other.name);
            //Debug.Log("Damagables in Range " + _damagablesInRange.Count);
        }
    }

    bool IsInAttackRange(Transform target)
    {
        float distance = Vector3.Distance(transform.position, target.position);
        return distance <= _attackRange;
    }
}
