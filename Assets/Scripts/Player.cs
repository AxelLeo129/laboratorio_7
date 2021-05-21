using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private NavMeshAgent agent;
    private int score = 0;
    [SerializeField] private Text score_text;
    [SerializeField] private GameObject win_text;
    [SerializeField] private GameObject warning_text;

    // Start is called before the first frame update
    void Start()
    {
        this.agent = GetComponent<NavMeshAgent>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        this.score_text.text = "Score: " + this.score.ToString();
        if (Input.GetMouseButtonDown(0))
        {
            Ray left_click_ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit_info;
            if (Physics.Raycast(left_click_ray, out hit_info))
            {
                NavMeshHit navHit;
                if(NavMesh.SamplePosition(hit_info.point, out navHit, 0.1f, NavMesh.AllAreas))
                {
                    this.agent.SetDestination(navHit.position);
                }
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacule"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("point"))
        {
            Destroy(other.gameObject);
            this.score++;
        }
        if (other.gameObject.CompareTag("win") && this.score == 4)
        {
            this.win_text.SetActive(true);
            Time.timeScale = 0.0f;
        } else if(other.gameObject.CompareTag("win"))
        {
            this.warning_text.SetActive(true);
        }
    }

}
