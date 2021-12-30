using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObsticleScript : MonoBehaviour
{
	public UnityEvent increaceScore;
	

 
    void Update()
	{
		transform.Rotate(0f, 1f, 0f); //астероид с каждым кадром будет вращаться

    }

    private void OnDestroy()
    {
		Debug.Log("Events Works");
		increaceScore.Invoke();
		gameObject.transform.root.GetComponent<Road>().increaceProbabilityObsticle();
    }
    public void Delete() //Удаление монеты
	{
		Destroy(gameObject); //Сама монета удалится сразу
	}

	//public void Fetch() //Проверка, проехал ли корабль игрока эту RoadPlane
	//{

	//	if (this.transform.position.z < becameUnvisible)
	//	{
	//		Destroy(this.gameObject);
	//	}
	//}
}




