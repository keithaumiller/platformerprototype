using UnityEngine;

public class Collectible : MonoBehaviour
{
    [Header("Collectible Settings")]
    public int pointValue = 100;
    public AudioClip collectSound;
    public GameObject collectEffect;
    
    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CollectItem();
        }
    }
    
    private void CollectItem()
    {
        // Add score
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(pointValue);
        }
        
        // Play sound effect
        if (audioSource != null && collectSound != null)
        {
            audioSource.PlayOneShot(collectSound);
        }
        
        // Spawn effect
        if (collectEffect != null)
        {
            Instantiate(collectEffect, transform.position, Quaternion.identity);
        }
        
        // Hide the collectible
        GetComponent<Renderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        
        // Destroy after sound finishes
        float destroyDelay = collectSound != null ? collectSound.length : 0f;
        Destroy(gameObject, destroyDelay);
    }
}