using UnityEngine;
using UnityEngine.AI;

public class DogSimpleMoveFix : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 velocity = agent.velocity;

        if (velocity.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(velocity),
                Time.deltaTime * 5f
            );
        }
    }
}