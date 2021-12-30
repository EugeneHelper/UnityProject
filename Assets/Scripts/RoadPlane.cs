using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadPlane : MonoBehaviour
{

	public bool Fetch(float z) //Проверка, проехал ли ship игрока этот roadPlane на достаточное расстояние
	{
		//GameObject obsticle = gameObject.transform.GetChild(0).gameObject;
		bool result = false;

		if (z > transform.position.z + 8)
		{
			result = true; //Если ship проехал на 8f от roadPlane, то возвращается true
		}

		return result;
	}

	public void Delete()
	{
			Destroy(gameObject); //Удаление блока	
	}
}
