using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace FoodConveyor
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Animator _playerAnimator;
        [SerializeField] private Transform _handHolder;
        [SerializeField] private Cart _cartHolder;
        [SerializeField] private Transform _centerPlayer;
        [SerializeField] private Transform _target;
        [SerializeField] private Rig _bodyRig;
        [SerializeField] private Rig _handRig;
        [SerializeField] private Rig _cartRig;
        private Transform _holdable;
        private float _targetWeight;

        private void Update()
        {
            _bodyRig.weight = Mathf.Lerp(_bodyRig.weight, _targetWeight, Time.deltaTime * 15);
        }

        public void AddToHand(GameObject holdable)
        {
            _holdable = holdable.transform;
            _target.position = new Vector3(_holdable.position.x, _holdable.position.y + 0.35f, _holdable.position.z);
            float distance = Vector3.Distance(_centerPlayer.position, _target.position);

            _playerAnimator.CrossFade("Take", 0.025f);
            _targetWeight = distance / 2.25f;

            Invoke(nameof(TakeHoldable), 0.2f);
            Invoke(nameof(ResetWeightRig), 0.3f);
            Invoke(nameof(AddToCart), 0.5f);
        }

        public void TakeHoldable()
        {
            _holdable.transform.parent = _handHolder;
            _holdable.transform.localPosition = Vector3.zero;
        }

        public void AddToCart()
        {
            _cartHolder.AddToCart(_holdable);
            _holdable = null;
        }

        public void ResetWeightRig()
        {
            _targetWeight = 0;
        }
    }
}