using UnityEngine;

public class GameState : MonoBehaviour
{
	[SerializeField] private AsteroidGenerator _asteroidGenerator;
	[SerializeField] private GameObject _currentShip;

	public Boundary boundary;
	public GameObject warningUI;

	private void Update()
	{
		float distance = (_currentShip.transform.position - boundary.transform.position).magnitude;

		if (distance < boundary.warningRadius)
		{
			warningUI.SetActive(false);
		}
		else
		{
			warningUI.SetActive(true);

			if (distance > boundary.destroyRadius)
			{
				EndGame();
			}
		}
	}	

	public void StartGame() { }
	public void SetPaused() { }
	public void EndGame()
	{
		_asteroidGenerator.StopGenerating();
		Debug.Log("Game over");
	}
}