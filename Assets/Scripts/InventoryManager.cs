using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
	
	public Dictionary<CollectableEnum, Sprite> _collectableIconsDictionary;    
	public Dictionary<CollectableEnum, GameObject> _collectablePrefabDictionary;
	public Dictionary<CollectableEnum, int> _collectableAmountDictionary;

		
	public static InventoryManager Instance = null;

	private void Awake()
	{
		if (Instance == null)
			Instance = this;

		else if (Instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}

	void Start()
	{
		_bigAmount = 0;
		_luigiAmount = 0;
		_rollingAmount = 0;
		_powAmount = 0;
		
		var types = Resources.LoadAll<CollectableObject>("CollectableTypes");
		
		_collectableIconsDictionary = types.ToDictionary(x => x.Type, y => y.Icon);
		_collectablePrefabDictionary = types.ToDictionary(x => x.Type, y => y.Prefab);
		_collectableAmountDictionary = types.ToDictionary(x => x.Type, y => y.Amount);
	}
	
	void Update()
	{
		_bigAmountText.text = _collectableAmountDictionary[CollectableEnum.Big].ToString();
		_luigiAmountText.text = _luigiAmount.ToString();
		_rollingAmountText.text = _rollingAmount.ToString();
		_powAmountText.text = _powAmount.ToString();
	}
	

	public void AddCollectable(CollectableEnum type)
	{
		_collectableAmountDictionary[type]++;
	}
	
	public void RemoveCollectable(CollectableEnum type)
	{
		if(_collectableAmountDictionary[type]>0)
		_collectableAmountDictionary[type]--;
	}
}
