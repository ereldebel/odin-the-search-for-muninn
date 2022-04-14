using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace NPC
{
    public class IdleWalk : MonoBehaviour
    {
        [SerializeField] private int numOfPointsInPath;
        [SerializeField] private int minDistanceBetweenPoints;
        [SerializeField] private int maxDistanceBetweenPoints;
        
        private List<Transform> points = new List<Transform>();
        private int _nextPoint = 0;
        private NavMeshAgent _agent;

        private void Awake () {
            _agent = GetComponent<NavMeshAgent>();
            GotoNextPoint();
            // for (var i = 0; i < numOfPointsInPath; ++i)
                // if ()
                
        }

        private void GotoNextPoint() {
            if (points.Count == 0)
                return;
            _agent.destination = points[_nextPoint++].position;
            _nextPoint %= points.Count;
        }

        private void Update () {
            if (!_agent.pathPending && _agent.remainingDistance < 0.5f)
                GotoNextPoint();
        }
        
        private bool RandomPoint(Vector3 prevPoint, out Vector3 nextPoint)
        {
            for (var i = 0; i < 30; i++)
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
    }
}
