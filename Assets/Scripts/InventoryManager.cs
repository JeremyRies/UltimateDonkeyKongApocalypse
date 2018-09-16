using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

	[SerializeField] private Text _bigAmountText;
	[SerializeField] private int _bigAmount;
	[SerializeField] private Text _luigiAmountText;
	[SerializeField] private int _luigiAmount;
	[SerializeField] private Text _rollingAmountText;
	[SerializeField] private int _rollingAmount;
	[SerializeField] private Text _powAmountText;
	[SerializeField] private int _powAmount;

	void Start()
	{
		_bigAmount = 0;
		_luigiAmount = 0;
		_rollingAmount = 0;
		_powAmount = 0;
	}

	public void AddCollectable(CollectableEnum type)
	{
		
	}
}
