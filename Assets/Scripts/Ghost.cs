using UnityEngine;

[DefaultExecutionOrder(-10)]
public class Ghost : MonoBehaviour
{   
    public Movement movement {  get; private set; }
    public GhostHome home { get; private set; }
    public GhostScatter scatter { get; private set; }
    public GhostChase chase { get; private set; }
    public GhostFrightened frightened { get; private set; }
    
    public GhostBehavior initialBehaviour;
    public Transform target;

    public int points = 200;

    private GameManager manager;

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
        
        movement = GetComponent<Movement>();
        home = GetComponent<GhostHome>();
        scatter = GetComponent<GhostScatter>();
        chase = GetComponent<GhostChase>();
        frightened = GetComponent<GhostFrightened>();
    }

    private void Start()
    {
        ResetState();
    }


    public void ResetState()
    {
        gameObject.SetActive(true);
        movement.ResetState();

        frightened.Disable();
        chase.Disable();
        scatter.Enable();

        if (home != initialBehaviour)
        {
            home.Disable();
        }

        if (initialBehaviour != null)
        {
            initialBehaviour.Enable();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            if (frightened.enabled)
            {
                manager.GhostEaten(this);
            }
            else
            {
                manager.PacmanEaten();
            }
            
        }
    }
}
    