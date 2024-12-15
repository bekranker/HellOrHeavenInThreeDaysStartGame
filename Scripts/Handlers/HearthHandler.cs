using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class HearthHandler : MonoBehaviour
{
	[SerializeField] private List<Image> _Hearts = new();
	[SerializeField] private Color _DisabledColor;
	[SerializeField] private List<Jugment> _Jugment = new();

	void OnEnable()
	{
		_Jugment[0].OnWrong += DecreaseHearth;
		_Jugment[1].OnWrong += DecreaseHearth;
	}
	void OnDisable()
	{
		_Jugment[0].OnWrong -= DecreaseHearth;
		_Jugment[1].OnWrong -= DecreaseHearth;
	}
	private int _hearthCount;
	public void SetHearthCount(int v)
	{
		_hearthCount = v;
	}
	public int GetHEarthCount() => _hearthCount;
	public void DecreaseHearth()
	{
		_Hearts[0].color = _DisabledColor;
		_Hearts.Remove(_Hearts[0]);
		SetHearthCount(_hearthCount - 1);
		if (_hearthCount <= 0)
		{
			//Cinematic dead from Hearth Count
		}

	}
}