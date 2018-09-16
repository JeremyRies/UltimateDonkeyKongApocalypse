using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

	[SerializeField] private Text _bigAmountText;
	[SerializeField] private int _bigAmount;
	[SerializeField] private GameObject _bigArrow;
	[SerializeField] private Text _luigiAmountText;
	[SerializeField] private int _luigiAmount;
	[SerializeField] private GameObject _luigiArrow;
	[SerializeField] private Text _rollingAmountText;
	[SerializeField] private int _rollingAmount;
	[SerializeField] private GameObject _rollingArrow;
	[SerializeField] private Text _powAmountText;
	[SerializeField] private int _powAmount;
	[SerializeField] private GameObject _powArrow;
	
	public Dictionary<CollectableEnum, Sprite> _collectableIconsDictionary;    
	public Dictionary<CollectableEnum, GameObject> _collectablePrefabDictionary;
	public Dictionary<CollectableEnum, int> _collectableAmountDictionary;
	private Dictionary<int, GameObject> _activeSpecialArrowDictionary;
	private Dictionary<int, CollectableEnum> _activeSpecialCollectableDictionary;

	[SerializeField] public int activeSpecial;

		
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
		activeSpecial = 0;
		_bigAmount = 0;
		_luigiAmount = 0;
		_rollingAmount = 0;
		_powAmount = 0;
		
		var types = Resources.LoadAll<CollectableObject>("CollectableTypes");
		
		_collectableIconsDictionary = types.ToDictionary(x => x.Type, y => y.Icon);
		_collectablePrefabDictionary = types.ToDictionary(x => x.Type, y => y.Prefab);
		_collectableAmountDictionary = types.ToDictionary(x => x.Type, y => y.Amount);

		_activeSpecialArrowDictionary = new Dictionary<int, GameObject>
		{
			{0, _bigArrow},
			{2, _luigiArrow},
			{1, _rollingArrow},
			{3, _powArrow}
		};
		
		_activeSpecialCollectableDictionary = new Dictionary<int, CollectableEnum>
		{
			{0, CollectableEnum.Big},
			{2, CollectableEnum.Luigi},
			{1, CollectableEnum.Rolling},
			{3, CollectableEnum.Pow}
		};
	}
	
	void Update()
	{
		_bigAmountText.text = _collectableAmountDictionary[CollectableEnum.Big].ToString();
		_luigiAmountText.text = _collectableAmountDictionary[CollectableEnum.Luigi].ToString();
		_rollingAmountText.text = _collectableAmountDictionary[CollectableEnum.Rolling].ToString();
		_powAmountText.text = _collectableAmountDictionary[CollectableEnum.Pow].ToString();
		
		if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
		{
			if (activeSpecial > 0)
			{
				_activeSpecialArrowDictionary[activeSpecial].SetActive(false);
				activeSpecial--;
				_activeSpecialArrowDictionary[activeSpecial].SetActive(true);
			}
			
		}
		
		if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
		{
			if (activeSpecial < 3)
			{
				_activeSpecialArrowDictionary[activeSpecial].SetActive(false);
				activeSpecial++;
				_activeSpecialArrowDictionary[activeSpecial].SetActive(true);
			}
		}
	}
	

	public void AddCollectable(CollectableEnum type)
	{
		_collectableAmountDictionary[type]++;
	}
	
	public void RemoveCollectableFromActive()
	{
		if(_collectableAmountDictionary[_activeSpecialCollectableDictionary[activeSpecial]]>0)
		_collectableAmountDictionary[_activeSpecialCollectableDictionary[activeSpecial]]--;
	}

	public GameObject GetActiveSpecial()
	{
		return _collectablePrefabDictionary[_activeSpecialCollectableDictionary[activeSpecial]];
	}
	
	public int GetActiveSpecialAmount()
	{
		return _collectableAmountDictionary[_activeSpecialCollectableDictionary[activeSpecial]];
	}
}
