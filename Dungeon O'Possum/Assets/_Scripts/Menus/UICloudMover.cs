using UnityEngine;

public class UICloudMover : MonoBehaviour
{
	[Header("Basic Variables:")]
	public float speed = 50.0f;         // Current speed of clouds (per sec)
	public float Ypos = 0.0f;           // Y position for reset
	//private float scale = 1.0f;          // Cloud size
	//private float resetDistance = 1700f; // Distance after which cloud resets

	[Header("Randomizer Variables:")]
	float minSpd = 10f;
	float maxSpd = 27f;
	float minY = -75f;
	float maxY = 75f;
	float minScale = 0.5f;
	float maxScale = 1.5f;

	[Header("References")]

    [SerializeField] RectTransform resetPoint;
	[SerializeField] RectTransform startPoint;


	private RectTransform rt;
	private float startX;

	void Start()
	{
		rt = GetComponent<RectTransform>();
		startX = rt.anchoredPosition.x; // Use the cloud's initial X as the starting point
		// Get the original scale of the cloud
    	//scale = rt.localScale.x;
		speed = Random.Range(minSpd, maxSpd);
		//scale = Random.Range(minScale, maxScale);
	}

	void Update()
	{
		moveCloud();

		if (rt.anchoredPosition.x >= resetPoint.anchoredPosition.x)
		{
			ResetCloud();
		}
	}

	void moveCloud()
	{
		rt.anchoredPosition += Vector2.right * speed * Time.deltaTime;
	}

	void ResetCloud()
	{
		float newX = startPoint.anchoredPosition.x; // To start point
		Ypos = Random.Range(minY, maxY);
		rt.anchoredPosition = new Vector2(newX, Ypos);

		// Randomize speed and scale
		speed = Random.Range(minSpd, maxSpd);
		//scale = Random.Range(scale - 0.25f, maxScale + 0.25f);
		//rt.localScale = new Vector3(scale, scale, 1f);
	}
}
