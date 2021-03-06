using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace NPC
{
    public class IdleWalk : MonoBehaviour
    {
        [SerializeField] private int numOfPointsInPath;
        [SerializeField] private int minDistanceBetweenPoints;
        [SerializeField] private int maxDistanceBetweenPoints;
        
        private readonly List<Vector3> _points = new List<Vector3>();
        private int _nextPoint = 0;
        private NavMeshAgent _agent;

        private void Awake () {
            _agent = GetComponent<NavMeshAgent>();
            GoToNextPoint();
            var prevPoint = transform.position;
            for (var i = 0; i < numOfPointsInPath; ++i)
            {
                if (!RandomPoint(prevPoint, out var nextPoint))
                    break;
                prevPoint = nextPoint;
                _points.Add(prevPoint);
            }
        }

        private void Update () {
            if (_agent.enabled && !_agent.pathPending && _agent.remainingDistance < 0.5f)
                GoToNextPoint();
        }

        private void OnBecameInvisible()
        {
            _agent.enabled = false;
        }

        private void OnBecameVisible()
        {
            _agent.enabled = true;
        }
        
        private void GoToNextPoint() {
            if (_points.Count == 0)
                return;
            _agent.destination = _points[_nextPoint++];
            _nextPoint %= _points.Count;
        }
        
        private bool RandomPoint(Vector3 prevPoint, out Vector3 nextPoint)
        {
            for (var i = 0; i < 30; ++i)
            {
                var distance = Random.Range(minDistanceBetweenPoints + 1, maxDistanceBetweenPoints - 1);
                var randomPoint = prevPoint + Random.insideUnitSphere * distance;
                if (!NavMesh.SamplePosition(randomPoint, out var hit, 1.0f, NavMesh.AllAreas)) continue;
                nextPoint = hit.position;
                return true;
            }
            nextPoint = prevPoint;
            return false;
        }

        private void AnimatorDestroy()
        {
            Destroy(gameObject);
        }
    }
}
