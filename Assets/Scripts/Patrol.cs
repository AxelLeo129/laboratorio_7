using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{

    [SerializeField] private Transform wp_start;
    [SerializeField] private Transform wp_end;
    private int position;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        this.agent = GetComponent<NavMeshAgent>();
        this.position = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1f)
            MovePatrol();
    }

    void MovePatrol()
    {
        if (this.position == 0)
        {
            this.agent.SetDestination(this.wp_end.position);
        }
        else
        {
            this.agent.SetDestination(this.wp_start.position);
        }
        if (transform.position == this.wp_start.position)
            this.position = 0;
        else if (transform.position == this.wp_end.position)
            this.position = 1;
    }

}
