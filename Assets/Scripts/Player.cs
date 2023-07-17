using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace FoodConveyor
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Animator _playerAnimator;

        [Header("Slot")]
        [SerializeField] private Transform _handSlot;
        [SerializeField] private Cart _cartHolder;
        private ISlotable _slotable;

        [Header("Rig")]
        [SerializeField] private Transform _centerPlayer;
        [SerializeField] private Transform _targetRig;
        [SerializeField] private Rig _bodyRig;
        [SerializeField] private Rig _handRig;
        [SerializeField] private Rig _cartRig;
        private float _targetWeight;

        // Gameplay
        private bool _isAction = false;

        private void Update()
        {
            _bodyRig.weight = Mathf.Lerp(_bodyRig.weight, _targetWeight, Time.deltaTime * 15);
        }

        public void AddToHand(ISlotable slotable)
        {
            if (_isAction == false)
            {
                _isAction = true;

                _slotable = slotable;
                Vector3 slotablePosition = _slotable.GetTransform.position;

                _targetRig.position = new Vector3(slotablePosition.x, slotablePosition.y + 0.35f, slotablePosition.z);
                float distance = Vector3.Distance(_centerPlayer.position, _targetRig.position);

                _playerAnimator.CrossFade("Take", 0.025f);
                _targetWeight = distance / 2.25f;

                Invoke(nameof(TakeHoldable), 0.2f);
                Invoke(nameof(ResetWeightRig), 0.3f);
                Invoke(nameof(AddToCart), 0.5f);
            }
        }

        public void TakeHoldable()
        {
            _slotable.AddToSlot(SlotType.Hand, _handSlot);
        }

        public void AddToCart()
        {
            _cartHolder.AddToCart(_slotable);
            _slotable = null;
            _isAction = false;
        }

        public void ResetWeightRig()
        {
            _targetWeight = 0;
        }
    }
}