using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[DisallowMultipleComponent]
public class PlatformControllerWaypoints : MonoBehaviour
{
    [Header("Waypoints (kolejność przejazdu)")]
    public List<Transform> waypoints = new List<Transform>();

    [Header("Parametry ruchu")]
    public float speed = 2f;
    public float waitAtPoint = 0.5f;

    private int currentIndex = 0;
    private bool forward = true;
    private bool moving = false;
    private float waitTimer = 0f;

    void Awake()
    {
        if (waypoints.Count == 0)
        {
            Debug.LogWarning("Brak waypointów – tworzę WP1 i WP2 obok platformy dla testu.");
            var container = new GameObject("Waypoints");
            container.transform.SetParent(transform.parent);

            var wp1 = new GameObject("WP1").transform;
            var wp2 = new GameObject("WP2").transform;
            wp1.SetParent(container.transform);
            wp2.SetParent(container.transform);

            wp1.position = transform.position;
            wp2.position = transform.position + Vector3.right * 5f;

            waypoints.Add(wp1);
            waypoints.Add(wp2);
        }
    }

    void Start()
    {
        if (waypoints.Count < 2)
        {
            Debug.LogError("Potrzeba co najmniej 2 waypointów. Dodaj WP1, WP2 (i kolejne) do listy.");
            enabled = false;
            return;
        }

        transform.position = waypoints[0].position;
        currentIndex = 1;
        Debug.Log($"Platforma ustawiona na {waypoints[0].name}. Cel: {waypoints[currentIndex].name}.");
    }

    void Update()
    {
        if (!moving && waitTimer > 0f)
        {
            waitTimer -= Time.deltaTime;
            if (waitTimer <= 0f) moving = true;
            return;
        }

        if (!moving) return;

        Transform target = waypoints[currentIndex];
        Vector3 dir = target.position - transform.position;
        float step = speed * Time.deltaTime;

        if (dir.sqrMagnitude <= step * step)
        {
            transform.position = target.position;
            moving = false;
            waitTimer = waitAtPoint;
            Debug.Log($"Dotarłem do {target.name}.");

            if (forward)
            {
                currentIndex++;
                if (currentIndex >= waypoints.Count)
                {
                    currentIndex = waypoints.Count - 2;
                    forward = false;
                    Debug.Log("Zawracam (jadę wstecz).");
                }
            }
            else
            {
                currentIndex--;
                if (currentIndex < 0)
                {
                    currentIndex = 1;
                    forward = true;
                    Debug.Log("Zawracam (jadę do przodu).");
                }
            }
        }
        else
        {
            transform.Translate(dir.normalized * step, Space.World);
        }
    }

    public void StartMoving()
    {
        if (waypoints.Count < 2) return;
        if (!moving && waitTimer <= 0f)
        {
            moving = true;
            Debug.Log("StartMoving() → ruszam.");
        }
    }

    public void StopMoving()
    {
        moving = false;
        Debug.Log("StopMoving() → zatrzymuję.");
    }
}
