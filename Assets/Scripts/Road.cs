using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Road : MonoBehaviour
{

	public List<GameObject> blocks; //Коллекция всех дорожных блоков
	public GameObject player; //Игрок
	public GameObject roadPrefab; //Префаб дорожного блока
	//public GameObject spaceShipPrefab; 
	public GameObject obsticlePrefab; //Префаб asteroid
	public int probabilityObsticle=15;

	internal void increaceProbabilityObsticle()
	{
		probabilityObsticle++;
	}

	private System.Random rand = new System.Random(); //Генератор случайных чисел

	void Update()
	{
		float z = player.transform.position.z; //Получение положения игрока

		var last = blocks[blocks.Count - 1]; //Номер дорожного блока, который дальше всех от игрока

		if (z > last.transform.position.z - 10 * 20f) //Если игрок подъехал к последнему блоку ближе, чем на 10 блоков
		{
			//Инстанцирование нового блока
			var block = Instantiate(roadPrefab, new Vector3(last.transform.position.x, last.transform.position.y, last.transform.position.z + 10), Quaternion.identity);
			block.transform.SetParent(gameObject.transform); //Перемещение блока в объект Road
			blocks.Add(block); //Добавление блока в коллекцию

			float side = rand.Next(1, 3) == 1 ? -1f : 1f; //Случаное определение стороны появления блока


			if (rand.Next(0, 100) < probabilityObsticle) //Добавление asteroid с вероятностью 
			{
				var coin = Instantiate(obsticlePrefab, new Vector3(last.transform.position.x + 1.50f * side * -1f, last.transform.position.y + rand.Next(3,8), last.transform.position.z + 10), Quaternion.identity);
				coin.transform.SetParent(block.transform);
			}
		}

		try
		{
			foreach (GameObject block in blocks)
			{
				if (block != null)
				{
					bool fetched = block.GetComponent<RoadPlane>().Fetch(z); //Проверка, проехал ли игрок этот блок


					if (fetched) //Если проехал
					{

						blocks.Remove(block); //Удаление блока из коллекции
						block.GetComponent<RoadPlane>().Delete(); //Удаление блока со сцены
					
					}
				}
			}
        }
        catch { }
	}
}
