using UnityEngine;

public class Pellet : MonoBehaviour
{
    public int points = 10;

    protected GameManager manager;

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
    }

    protected virtual void Eat()
    {
        manager.PelletEaten(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Pacman"))
        {
            Eat();
        }
    }
}
