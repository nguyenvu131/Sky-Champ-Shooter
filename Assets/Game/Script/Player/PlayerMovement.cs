using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float moveSpeed = 5f;
	public Rigidbody2D rb;
	public Vector2 boundaryMin;
	public Vector2 boundaryMax;
	private Vector3 offset;
	public bool isDragging = false;
	
	//
    // public float originalSpeed;
    // private Coroutine slowCoroutine;

	void Start() {
		
		// originalSpeed = moveSpeed;
		rb = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate() 
	{
		Movement();
	}

	void Update() {
		
		// HandleMovement();
	}
	
	// void HandleMovement() 
	// {
		// float moveX = Input.GetAxis("Horizontal");
		// float moveY = Input.GetAxis("Vertical");
		// Vector3 moveDir = new Vector3(moveX, moveY, 0f).normalized;
		// transform.position += moveDir * moveSpeed * Time.deltaTime;

		// Giới hạn trong màn hình
		// Vector3 pos = transform.position;
		// pos.x = Mathf.Clamp(pos.x, -10f, 7.8f);  // giới hạn trục X
		// pos.y = Mathf.Clamp(pos.y, -14f, 8f);  // giới hạn trục Y
		// transform.position = pos;
	// }
	
	// public void ApplySlow(float factor, float duration)
    // {
        // if (slowCoroutine != null)
            // StopCoroutine(slowCoroutine);

        // slowCoroutine = StartCoroutine(SlowRoutine(factor, duration));
    // }

    // private IEnumerator SlowRoutine(float factor, float duration)
    // {
        // moveSpeed = originalSpeed * factor;

        // Optional: hiệu ứng mờ/hud/slowed VFX
        // yield return new WaitForSeconds(duration);

        // moveSpeed = originalSpeed;
        // slowCoroutine = null;
    // }
	public void Movement()
	{
		float moveX = Input.GetAxis("Horizontal");
		float moveY = Input.GetAxis("Vertical");
		Vector2 moveDir = new Vector2(moveX, moveY).normalized;
		rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
	}
}
