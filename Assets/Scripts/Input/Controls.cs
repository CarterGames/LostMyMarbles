// GENERATED AUTOMATICALLY FROM 'Assets/Input/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace CarterGames.LostMyMarbles
{
    public class @Controls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @Controls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Marble Movement Controls"",
            ""id"": ""a04141b7-7357-455a-bd7a-dfee7f4724a5"",
            ""actions"": [
                {
                    ""name"": ""Hoz"",
                    ""type"": ""PassThrough"",
                    ""id"": ""407e35e1-960a-4951-a3cd-cc7e291099ff"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ver"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c9094e03-7bf4-4bc9-8349-bca008e57100"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""c29ce151-c3c8-4ca5-928d-98ebbb8be746"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UsePowerUp"",
                    ""type"": ""Button"",
                    ""id"": ""4ab4999a-ae4e-4e8a-90b6-1cc0131a6288"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""a481b399-513f-44cd-9018-91f4f1178683"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Hoz"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""a65f3108-ed56-4602-949d-65f4d0b3b2c7"",
                    ""path"": ""<Keyboard>/#(A)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Hoz"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f052f6c7-846b-47fe-9a9d-a516d2931242"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Hoz"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""0d234c30-d0f2-4e67-8263-83dd6a6051dc"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ver"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""4c27c98a-e45b-44ae-b039-3b0982e0c365"",
                    ""path"": ""<Keyboard>/#(S)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Ver"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""d1f44e66-0d1b-4ae3-b927-53c42a456a3f"",
                    ""path"": ""<Keyboard>/#(W)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Ver"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""02339a85-a840-446d-80d2-8ae61204b048"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""122ead6e-c019-49cc-b819-3608df9e132d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": ""Press(behavior=2)"",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""UsePowerUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Camera Controls"",
            ""id"": ""ec7dbc02-d522-4aa9-bbb8-6df37307f7c6"",
            ""actions"": [
                {
                    ""name"": ""Mouse_X"",
                    ""type"": ""Value"",
                    ""id"": ""d53a5dd7-0272-4cc5-a437-d47caf8ed358"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mouse_Y"",
                    ""type"": ""Value"",
                    ""id"": ""7a215d21-cd05-4cc5-8978-445f67cdd70b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ec861e07-0024-4b57-a0d2-6a34432db5c9"",
                    ""path"": ""<Mouse>/position/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Mouse_X"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f2c4771c-00c8-4b4c-9600-bc344b67b620"",
                    ""path"": ""<Mouse>/position/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""PC"",
                    ""action"": ""Mouse_Y"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""PC"",
            ""bindingGroup"": ""PC"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Marble Movement Controls
            m_MarbleMovementControls = asset.FindActionMap("Marble Movement Controls", throwIfNotFound: true);
            m_MarbleMovementControls_Hoz = m_MarbleMovementControls.FindAction("Hoz", throwIfNotFound: true);
            m_MarbleMovementControls_Ver = m_MarbleMovementControls.FindAction("Ver", throwIfNotFound: true);
            m_MarbleMovementControls_Jump = m_MarbleMovementControls.FindAction("Jump", throwIfNotFound: true);
            m_MarbleMovementControls_UsePowerUp = m_MarbleMovementControls.FindAction("UsePowerUp", throwIfNotFound: true);
            // Camera Controls
            m_CameraControls = asset.FindActionMap("Camera Controls", throwIfNotFound: true);
            m_CameraControls_Mouse_X = m_CameraControls.FindAction("Mouse_X", throwIfNotFound: true);
            m_CameraControls_Mouse_Y = m_CameraControls.FindAction("Mouse_Y", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }

        // Marble Movement Controls
        private readonly InputActionMap m_MarbleMovementControls;
        private IMarbleMovementControlsActions m_MarbleMovementControlsActionsCallbackInterface;
        private readonly InputAction m_MarbleMovementControls_Hoz;
        private readonly InputAction m_MarbleMovementControls_Ver;
        private readonly InputAction m_MarbleMovementControls_Jump;
        private readonly InputAction m_MarbleMovementControls_UsePowerUp;
        public struct MarbleMovementControlsActions
        {
            private @Controls m_Wrapper;
            public MarbleMovementControlsActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Hoz => m_Wrapper.m_MarbleMovementControls_Hoz;
            public InputAction @Ver => m_Wrapper.m_MarbleMovementControls_Ver;
            public InputAction @Jump => m_Wrapper.m_MarbleMovementControls_Jump;
            public InputAction @UsePowerUp => m_Wrapper.m_MarbleMovementControls_UsePowerUp;
            public InputActionMap Get() { return m_Wrapper.m_MarbleMovementControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MarbleMovementControlsActions set) { return set.Get(); }
            public void SetCallbacks(IMarbleMovementControlsActions instance)
            {
                if (m_Wrapper.m_MarbleMovementControlsActionsCallbackInterface != null)
                {
                    @Hoz.started -= m_Wrapper.m_MarbleMovementControlsActionsCallbackInterface.OnHoz;
                    @Hoz.performed -= m_Wrapper.m_MarbleMovementControlsActionsCallbackInterface.OnHoz;
                    @Hoz.canceled -= m_Wrapper.m_MarbleMovementControlsActionsCallbackInterface.OnHoz;
                    @Ver.started -= m_Wrapper.m_MarbleMovementControlsActionsCallbackInterface.OnVer;
                    @Ver.performed -= m_Wrapper.m_MarbleMovementControlsActionsCallbackInterface.OnVer;
                    @Ver.canceled -= m_Wrapper.m_MarbleMovementControlsActionsCallbackInterface.OnVer;
                    @Jump.started -= m_Wrapper.m_MarbleMovementControlsActionsCallbackInterface.OnJump;
                    @Jump.performed -= m_Wrapper.m_MarbleMovementControlsActionsCallbackInterface.OnJump;
                    @Jump.canceled -= m_Wrapper.m_MarbleMovementControlsActionsCallbackInterface.OnJump;
                    @UsePowerUp.started -= m_Wrapper.m_MarbleMovementControlsActionsCallbackInterface.OnUsePowerUp;
                    @UsePowerUp.performed -= m_Wrapper.m_MarbleMovementControlsActionsCallbackInterface.OnUsePowerUp;
                    @UsePowerUp.canceled -= m_Wrapper.m_MarbleMovementControlsActionsCallbackInterface.OnUsePowerUp;
                }
                m_Wrapper.m_MarbleMovementControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Hoz.started += instance.OnHoz;
                    @Hoz.performed += instance.OnHoz;
                    @Hoz.canceled += instance.OnHoz;
                    @Ver.started += instance.OnVer;
                    @Ver.performed += instance.OnVer;
                    @Ver.canceled += instance.OnVer;
                    @Jump.started += instance.OnJump;
                    @Jump.performed += instance.OnJump;
                    @Jump.canceled += instance.OnJump;
                    @UsePowerUp.started += instance.OnUsePowerUp;
                    @UsePowerUp.performed += instance.OnUsePowerUp;
                    @UsePowerUp.canceled += instance.OnUsePowerUp;
                }
            }
        }
        public MarbleMovementControlsActions @MarbleMovementControls => new MarbleMovementControlsActions(this);

        // Camera Controls
        private readonly InputActionMap m_CameraControls;
        private ICameraControlsActions m_CameraControlsActionsCallbackInterface;
        private readonly InputAction m_CameraControls_Mouse_X;
        private readonly InputAction m_CameraControls_Mouse_Y;
        public struct CameraControlsActions
        {
            private @Controls m_Wrapper;
            public CameraControlsActions(@Controls wrapper) { m_Wrapper = wrapper; }
            public InputAction @Mouse_X => m_Wrapper.m_CameraControls_Mouse_X;
            public InputAction @Mouse_Y => m_Wrapper.m_CameraControls_Mouse_Y;
            public InputActionMap Get() { return m_Wrapper.m_CameraControls; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(CameraControlsActions set) { return set.Get(); }
            public void SetCallbacks(ICameraControlsActions instance)
            {
                if (m_Wrapper.m_CameraControlsActionsCallbackInterface != null)
                {
                    @Mouse_X.started -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnMouse_X;
                    @Mouse_X.performed -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnMouse_X;
                    @Mouse_X.canceled -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnMouse_X;
                    @Mouse_Y.started -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnMouse_Y;
                    @Mouse_Y.performed -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnMouse_Y;
                    @Mouse_Y.canceled -= m_Wrapper.m_CameraControlsActionsCallbackInterface.OnMouse_Y;
                }
                m_Wrapper.m_CameraControlsActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Mouse_X.started += instance.OnMouse_X;
                    @Mouse_X.performed += instance.OnMouse_X;
                    @Mouse_X.canceled += instance.OnMouse_X;
                    @Mouse_Y.started += instance.OnMouse_Y;
                    @Mouse_Y.performed += instance.OnMouse_Y;
                    @Mouse_Y.canceled += instance.OnMouse_Y;
                }
            }
        }
        public CameraControlsActions @CameraControls => new CameraControlsActions(this);
        private int m_PCSchemeIndex = -1;
        public InputControlScheme PCScheme
        {
            get
            {
                if (m_PCSchemeIndex == -1) m_PCSchemeIndex = asset.FindControlSchemeIndex("PC");
                return asset.controlSchemes[m_PCSchemeIndex];
            }
        }
        public interface IMarbleMovementControlsActions
        {
            void OnHoz(InputAction.CallbackContext context);
            void OnVer(InputAction.CallbackContext context);
            void OnJump(InputAction.CallbackContext context);
            void OnUsePowerUp(InputAction.CallbackContext context);
        }
        public interface ICameraControlsActions
        {
            void OnMouse_X(InputAction.CallbackContext context);
            void OnMouse_Y(InputAction.CallbackContext context);
        }
    }
}
