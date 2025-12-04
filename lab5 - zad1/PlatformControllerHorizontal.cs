using UnityEngine;

public class PlatformControllerHorizontal : MonoBehaviour
{
    [Header("Target positions")]
    public Transform startPoint;    
    public Transform targetPoint;   
    public float speed = 2f;
    public float waitAtTarget = 1f; 

    private Vector3 _startPos;
    private Vector3 _targetPos;
    private bool _moving = false;
    private bool _toTarget = true;
    private float _waitTimer = 0f;

    void Start()
    {
        _startPos = startPoint != null ? startPoint.position : transform.position;
        _targetPos = targetPoint != null ? targetPoint.position : transform.position + transform.right * 5f;

        transform.position = _startPos;
    }

    void Update()
    {
        if (!_moving) return;

        Vector3 dest = _toTarget ? _targetPos : _startPos;
        Vector3 dir = dest - transform.position;
        float step = speed * Time.deltaTime;

        if (dir.sqrMagnitude <= step * step)
        {
 
            transform.position = dest;
            _moving = false;
            _waitTimer = waitAtTarget;
            _toTarget = !_toTarget; 
        }
        else
        {
            transform.Translate(dir.normalized * step, Space.World);
        }

        if (!_moving && _waitTimer > 0f)
        {
            _waitTimer -= Time.deltaTime;
            if (_waitTimer <= 0f)
            {
                _moving = true;
            }
        }
    }

    public void StartMoving()
    {
        if (!_moving && _waitTimer <= 0f)
        {
            _moving = true;
        }
        
    }

    public void StopMoving()
    {
        _moving = false;
    }

}
