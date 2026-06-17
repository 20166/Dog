using UnityEngine;
using UnityEngine.AI;

public class SimpleDogWalk : MonoBehaviour
{
    public Transform[] points;
    public Transform WayGroup;
    private NavMeshAgent agent;
    private int index;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GoNext();

        points = new Transform[WayGroup.childCount];
        for (int i = 0; i < WayGroup.childCount; i++)
        {
            points[i] = WayGroup.GetChild(i);
        }
    }

    void Update()
    {

        // if (agent.velocity.magnitude > 0.1f)
        // {
        //     Vector3 dir = -agent.velocity.normalized;

        //     Quaternion targetRot = Quaternion.LookRotation(dir);

        //     transform.rotation = Quaternion.Slerp(
        //         transform.rotation,
        //         targetRot,
        //         Time.deltaTime * 5f
        //     );
        // }

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
    
            GoNext();
        }
    }

    void GoNext()
    {
        if (points.Length == 0) return;

        agent.SetDestination(points[index].position);
        index = (index + 1) % points.Length;
    }

      void OnDrawGizmos()
    {
        if (points == null) return;

        Gizmos.color = Color.red;

        for (int i = 0; i < WayGroup.childCount; i++)
        {
            //if (points[i] == null) continue;

            Gizmos.DrawSphere(WayGroup.GetChild(i).position, 0.1f);

                  // draw line to next point
            if (i < WayGroup.childCount - 1 && WayGroup.GetChild(i + 1) != null)
            {
                Gizmos.color = Color.green;
                if(points.Length <= i) continue;
                Gizmos.DrawLine(points[i].position, points[i + 1].position);
            }
        }
    }
}