using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using NaughtyAttributes;

public class Cooldown : MonoBehaviour
{
	[SerializeField] bool useRandom = false;
	[ShowIf("useRandom")]
	[SerializeField] [MinMaxSlider(0, 20)] Vector2 randomValue;
	[HideIf("useRandom")]
	public FloatReference startTimeValue;
	public bool RunOnAwake = false;
	public UnityFloatEvent OnCooldown;

	public UnityEvent OnCooldownEnd;

	private float cooldown;
	bool isStart = false;

	void OnEnable ()
	{
		if (useRandom)
			InitCooldown(Random.Range(randomValue.x, randomValue.y));
		else
			InitCooldown(startTimeValue.Value);

        if (RunOnAwake)
		{
			StartCooldown();
		}
	}

	public void StartCooldown()
	{
        if (isStart == true) return;
		isStart = true;
		StartCoroutine(IECooldown());
	}

	IEnumerator IECooldown()
	{
		while(isStart)
		{
			// Start Cooldown
			if(cooldown <= 0)
			{
				cooldown = 0;
				isStart = false;
				if (useRandom)
					InitCooldown(Random.Range(randomValue.x, randomValue.y));
				else
					InitCooldown(startTimeValue.Value);
                OnCooldownEnd.Invoke();
                // canStart = false;
            }
			else
			{
                cooldown -= Time.deltaTime;
			}

			OnCooldown.Invoke(cooldown);

			yield return null;
		}
	}

	public void Restart(float waitTime)
	{
		StartCoroutine(IERestart(waitTime));
	}

	IEnumerator IERestart(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		StartCooldown();
	}

	public void InitCooldown(float time)
	{
		cooldown = (int)time;
	}

	public void InitCooldown(FloatVariable time)
	{
		cooldown = time.Value;
	}

	public void InitCooldown()
	{
		if (useRandom)
			cooldown = Random.Range(randomValue.x, randomValue.y);
		else
			cooldown = startTimeValue.Value;
	}
}