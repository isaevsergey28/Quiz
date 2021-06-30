using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Cell : MonoBehaviour
{
    [SerializeField] private GameObject _congratulationPrefab;

    public delegate void OnRightClick();
    public static event OnRightClick onRightClick;

    private Transform _objectInsideCard;

    private string _cellName;
    private bool _isGameOver = false;


    private void OnMouseDown()
    {
        if(!_isGameOver)
        {
            if (LevelData.AssignmentPurpose.Equals(_cellName))
            {
                CreateCongratulationEffect();
                MakeVictoriousBounceEffect(_objectInsideCard);
                StartCoroutine(MakeDelay());
            }
            else
            {
                transform.GetChild(0).GetChild(0).DOShakePosition(2.0f, strength: new Vector3(0, 1, 0), vibrato: 4, randomness: 0, snapping: false, fadeOut: true);
            }
        }
    }

    private void CreateCongratulationEffect()
    {
        GameObject congratulation = Instantiate(_congratulationPrefab, transform.position, Quaternion.identity, transform);
    }

    private void Start()
    {
        _objectInsideCard = transform.GetChild(0).GetChild(0).transform;
        MakeStartBounceEffect();
        _cellName = _objectInsideCard.GetComponent<SpriteRenderer>().sprite.name;
    }

    public void MakeInactive()
    {
        _isGameOver = true;
    }
    private void MakeStartBounceEffect()
    {
        var bounceEffect = DOTween.Sequence();
        bounceEffect.Append(transform.DOScale(0, 0));
        bounceEffect.Append(transform.DOScale(0.5f, 0.5f));
    }
    private void MakeVictoriousBounceEffect(Transform _objectInsideCard)
    {
        var bounceEffect = DOTween.Sequence();
        bounceEffect.Append(_objectInsideCard.transform.DOScale(0.9f, 0.3f));
        bounceEffect.Append(_objectInsideCard.transform.DOScale(0.8f, 0.3f));
        bounceEffect.Append(_objectInsideCard.transform.DOScale(0.9f, 0.3f));
        bounceEffect.Append(_objectInsideCard.transform.DOScale(0.7f, 0.3f));
    }
    private IEnumerator MakeDelay()
    {
        yield return new WaitForSeconds(1.2f);
        onRightClick?.Invoke();
    }
   
}
