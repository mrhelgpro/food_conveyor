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
        private float _bodyWeight;
        private float _cartWeight;

        // Gameplay
        private bool _isAction = false;

        private void Update()
        {
            float delta = Time.deltaTime * 10;

            _bodyRig.weight = Mathf.Lerp(_bodyRig.weight, _bodyWeight, delta);
            _cartRig.weight = Mathf.Lerp(_cartRig.weight, _cartWeight, delta);

        }

        public void SetMenu()
        {
            _bodyWeight = 0;
            _cartWeight = 0;

            _playerAnimator.CrossFade("Menu", 0.025f);
        }

        public void SetPlay()
        {
            _cartWeight = 1;

            _playerAnimator.CrossFade("Play", 0.025f);
        }

        public void SetEnd(GameResult result)
        {
            _bodyWeight = 0;
            _cartWeight = 0;

            if (result == GameResult.Win)
            {
                _playerAnimator.CrossFade("Win", 0.025f);
            }
            else
            {
                _playerAnimator.CrossFade("Loss", 0.025f);
            }
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
                _bodyWeight = distance / 2.25f;

                // Invoke Take Food
                Invoke(nameof(AddToSlot), 0.2f);
                Invoke(nameof(ResetBodyWeight), 0.3f);
                Invoke(nameof(AddToCart), 0.5f);
            }
        }

        // Invoke Take Food
        private void AddToSlot() => _slotable.AddToSlot(SlotType.Hand, _handSlot);

        private void ResetBodyWeight() => _bodyWeight = 0;

        private void AddToCart()
        {
            _cartHolder.AddToCart(_slotable);
            _slotable = null;
            _isAction = false;
        }
    }
}