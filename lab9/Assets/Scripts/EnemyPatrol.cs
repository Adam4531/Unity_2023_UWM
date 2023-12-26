using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator anim;
    public float runSpeed = 1f;
    public GameObject PunktA;
    public GameObject PunktB;
    public GameObject player;
    private GameObject currentTarget;
    private bool followingPlayer = false;

    void Start()
    {
        currentTarget = PunktA;
    }

    void Update()
    { 
        if (isPlayerInArea() && (Mathf.Abs(player.transform.position.y - transform.position.y) < 1f))
        {
            followingPlayer = true;
        }
        else
        {
            followingPlayer = false;
        }
        if (followingPlayer)
        {
            if (Vector2.Distance(transform.position, player.transform.position) < 2f)
            {
                anim.SetFloat("Speed", 0f);
            }
            else
            {
                anim.SetFloat("Speed", 1f);
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, runSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, currentTarget.transform.position) < 0.1f)
            {
                anim.SetFloat("Speed", 1f);
                currentTarget = (currentTarget == PunktA) ? PunktB : PunktA;
            }
            transform.position = Vector2.MoveTowards(transform.position, currentTarget.transform.position, runSpeed * Time.deltaTime);
        }
    }

    bool isPlayerInArea()
    {
        float playerPos = player.transform.position.x;
        float PunktAPos = PunktA.transform.position.x;
        float PunktBPos = PunktB.transform.position.x;

        return (playerPos > Mathf.Min(PunktAPos, PunktBPos) && playerPos < Mathf.Max(PunktAPos, PunktBPos));
    }

        private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PunktA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(PunktB.transform.position, 0.5f);
        Gizmos.DrawLine(PunktA.transform.position, PunktB.transform.position);
    }
}