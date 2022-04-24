using System;
using UnityEngine;

namespace UI
{
	public class LifeUI : MonoBehaviour
	{
		[SerializeField] private float fractionPerSecond = 1;
		[SerializeField] private RectTransform odinLives;
		[SerializeField] private RectTransform komusoLives;

		private const float OneLifeHeight = 89.6f;
		private float _currOdinHeight;
		private float _currKomusoHeight;

		private void Start()
		{
			_currOdinHeight = (5 - GameManager.NumOfOdinLives) * OneLifeHeight + 540;
			_currKomusoHeight = (5 - GameManager.NumOfKomusoLives) * OneLifeHeight + 540;
			var komusoPos = komusoLives.localPosition;
			var odinPos = odinLives.localPosition;
			odinPos.y = _currOdinHeight;
			komusoPos.y = _currKomusoHeight;
			komusoLives.localPosition = komusoPos;
			odinLives.localPosition = odinPos;
			GameManager.OdinTookHit += RemoveOdinLife;
			GameManager.KomusoTookHit += RemoveKomusoLife;
		}

		private void OnDestroy()
		{
			GameManager.OdinTookHit -= RemoveOdinLife;
			GameManager.KomusoTookHit -= RemoveKomusoLife;
		}

		private void Update()
		{
			var komusoPos = komusoLives.localPosition;
			var odinPos = odinLives.localPosition;
			if (komusoPos.y < _currKomusoHeight)
				komusoPos.y += OneLifeHeight * fractionPerSecond * Time.deltaTime;
			else if (komusoPos.y > _currKomusoHeight)
				komusoPos.y -= OneLifeHeight * fractionPerSecond * Time.deltaTime;
			if (odinPos.y < _currOdinHeight)
				odinPos.y += OneLifeHeight * fractionPerSecond * Time.deltaTime;
			komusoLives.localPosition = komusoPos;
			odinLives.localPosition = odinPos;
		}

		private void AddKomusoLife()
		{
			_currKomusoHeight -= OneLifeHeight;
		}
		
		private void RemoveKomusoLife()
		{
			_currKomusoHeight += OneLifeHeight;
		}
		
		private void RemoveOdinLife()
		{
			_currOdinHeight += OneLifeHeight;
		}
	}
}