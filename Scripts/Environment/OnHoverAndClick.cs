using UnityEngine;
using DG.Tweening;
public class OnHoverAndClick : MonoBehaviour
{
	[SerializeField] private Interaction _Interaction;
	[SerializeField] private SpriteRenderer _SpriteRenderer;
	[SerializeField] private Sprite _OutlineVersion;

	private Sprite _startSprite;
	void Start()
	{
		_startSprite = _SpriteRenderer.sprite;
		_Interaction = GetComponent<Interaction>();
		print(_Interaction);
	}

	void OnEnable()
	{
		_Interaction.OnHover += SpriteChangeToOutline;
		_Interaction.OnExitHover += SpriteChangeToYO;
	}
	void OnDisable()
	{
		_Interaction.OnHover -= SpriteChangeToOutline;
		_Interaction.OnExitHover -= SpriteChangeToYO;

	}
	void SpriteChangeToOutline()
	{
		_SpriteRenderer.sprite = _OutlineVersion;
	}
	void SpriteChangeToYO()
	{
		_SpriteRenderer.sprite = _startSprite;
	}
}