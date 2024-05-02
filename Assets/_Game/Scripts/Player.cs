using _Game.Scripts.Interfaces;
using _Game.Scripts.Services;
using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace _Game.Scripts
{
    public class Player : GameBehaviour
    {
        private const float AddToSlotTime = 0.2f;
        private const float ResetBodyWeightTime = 0.3f;
        private const float AddToCartTime = 0.5f;
        private const float CrossFadeDuration = 0.025f;
        private const float TargetRigHeightOffset = 0.35f;
        private const float AddToHandWeightFactor = 2.25f;

        private const string MenuState = "Menu";
        private const string PlayState = "Play";
        private const string TakeState = "Take";
        private const string WinState = "Win";
        private const string LossState = "Loss";
    
        [SerializeField] private Animator playerAnimator;
    
        [Header("Slot")]
        [SerializeField] private Transform handSlot;
        [SerializeField] private Cart cartHolder;
    
        [Header("Rig")]
        [SerializeField] private Transform centerPlayer;
        [SerializeField] private Transform targetRig;
        [SerializeField] private Rig bodyRig;
        [SerializeField] private Rig handRig;
        [SerializeField] private Rig cartRig;
        private float _bodyWeight;
        private float _cartWeight;
        private ISlotable _slot;
        private bool _isAction;

        private void Update()
        {
            float deltaFactor = Time.deltaTime * 10;

            bodyRig.weight = Mathf.Lerp(bodyRig.weight, _bodyWeight, deltaFactor);
            cartRig.weight = Mathf.Lerp(cartRig.weight, _cartWeight, deltaFactor);
        }

        protected override void OnMenuHandler()
        {
            _bodyWeight = 0;
            _cartWeight = 0;

            playerAnimator.CrossFade(MenuState, CrossFadeDuration);
        }

        protected override void OnPlayHandler()
        {
            _cartWeight = 1;

            playerAnimator.CrossFade(PlayState, CrossFadeDuration);
        }

        protected override void OnEndHandler()
        {
            _bodyWeight = 0;
            _cartWeight = 0;

            string animationName = GameManager.GetResult == GameResult.Win ? WinState : LossState;
            
            playerAnimator.CrossFade(animationName, CrossFadeDuration);
        }

        public void AddToHand(ISlotable slot)
        {
            if (_isAction == false)
            {
                _isAction = true;

                _slot = slot;
                Vector3 slotPosition = _slot.GetTransform.position;

                targetRig.position = new Vector3(slotPosition.x, slotPosition.y + TargetRigHeightOffset, slotPosition.z);
                float distance = Vector3.Distance(centerPlayer.position, targetRig.position);

                playerAnimator.CrossFade(TakeState, CrossFadeDuration);
                _bodyWeight = distance / AddToHandWeightFactor;
            
                Invoke(nameof(AddToSlot), AddToSlotTime);
                Invoke(nameof(ResetBodyWeight), ResetBodyWeightTime);
                Invoke(nameof(AddToCart), AddToCartTime);
            }
        }
    
        private void AddToSlot() => _slot.AddToSlot(SlotType.Hand, handSlot);

        private void ResetBodyWeight() => _bodyWeight = 0;

        private void AddToCart()
        {
            cartHolder.AddToCart(_slot);
            _slot = null;
            _isAction = false;
        }
    }
}