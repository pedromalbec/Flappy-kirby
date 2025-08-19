using UnityEngine;

public class Player : MonoBehaviour
{
  public SpriteRenderer spriteRenderer;
  public Sprite spriteA;
  public Sprite spriteB;

  private Vector3 direction;
  public float gravity = -9.8f;
  public float strength = 5f;

  private float flapDuration = 0.1f;
  private float flapTimer = 0f;

  public AudioManager audioManager;

  private void Update()
  {
    // Input
    if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
        direction = Vector3.up * strength;
        spriteRenderer.sprite = spriteB;
        flapTimer = flapDuration;
        audioManager.PlaySFX(audioManager.fly);
    }

    if (Input.touchCount > 0)
    {
      Touch touch = Input.GetTouch(0);

      if (touch.phase == TouchPhase.Began){
        direction = Vector3.up * strength;
        spriteRenderer.sprite = spriteB;
        flapTimer = flapDuration;
        audioManager.PlaySFX(audioManager.fly);
      }
    }

    // Gravity and movement
    direction.y += gravity * Time.deltaTime;
    transform.position += direction * Time.deltaTime;

    // Flap timer logic
    if (flapTimer > 0)
    {
      flapTimer -= Time.deltaTime;
      if (flapTimer <= 0)
      {
        spriteRenderer.sprite = spriteA;
      }
    }
  }

  private void OnEnable()
  {
    Vector3 position = transform.position;
    position.y = 0f;
    transform.position = position;
    direction = Vector3.zero;
  }
  
  // Collisions 
  private void OnTriggerEnter2D(Collider2D other)
  {
     if (other.gameObject.tag == "Obstacle"){
          FindObjectOfType<GameManager>().GameOver();
     } else if (other.gameObject.tag == "Scoring"){
      FindObjectOfType<GameManager>().IncreaseScore();
     }
  }

}
