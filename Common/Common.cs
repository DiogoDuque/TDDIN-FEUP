using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    [Serializable]
    public class Diginote
    {
        private long serialNumber;
        private int facialValue;
        private string ownerNickname;

        public long SerialNumber
        {
            get => serialNumber;
        }

        public int FacialValue
        {
            get => facialValue;
            set => facialValue = value;
        }

        public string OwnerNickname
        {
            get => ownerNickname;
            set => ownerNickname = value;
        }

        public Diginote(long serial, string owner)
        {
            facialValue = 1;
            serialNumber = serial;
            ownerNickname = owner;
        }

        public override bool Equals(object obj)
        {
            Diginote item = obj as Diginote;

            if (item == null)
                return false;

            if (this.serialNumber.Equals(item.serialNumber) &&
                this.ownerNickname.Equals(item.ownerNickname) &&
                this.facialValue.Equals(item.facialValue))
                return true;
            else
                return false;
        }
    }

    /**
     * Nickname should be unique
     **/
    [Serializable]
    public class User
    {
        private string name;
        private string nickname;
        private string password;
        private bool isLoggedIn;
        public string Name
        {
            get => name;
        }
        public string Nickname
        {
            get => nickname;
        }
        public string Password
        {
            get => password;
        }

        public bool IsLoggedIn
        {
            get => isLoggedIn;
            set => isLoggedIn = value;
        }
        public User(string name, string nickname, string password)
        {
            this.name = name;
            this.nickname = nickname;
            this.password = password;
            this.isLoggedIn = false;
        }

        public override bool Equals(object obj)
        {
            User item = obj as User;

            if (item == null)
                return false;

            if (this.nickname.Equals(item.nickname) &&
                this.name.ToLower().Equals(item.name.ToLower()) &&
                this.password.Equals(item.password)) //TODO Acho que é só o nickname
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            return nickname.GetHashCode();
        }

        public override string ToString()
        {
            return "[" + name + "|" + nickname + "|" + isLoggedIn.ToString() + "]";
        }
    }

    public delegate void LogDelegate(string oldOwner, string newOwner, int quantity);

    public delegate void UpdateDelegate();

    public delegate void QuoteChange(string username, decimal quote, OrderType orderType);

    public class Utils
    {
        public static string GetSha256FromString(string strData)
        {
            var message = Encoding.ASCII.GetBytes(strData);
            SHA256Managed hashString = new SHA256Managed();
            string hex = "";

            var hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;
        }
    }


    public enum OrderType { BUYING, SELLING };

    [Serializable]
    public class Order
    {
        public string owner;
        public OrderType type;
        
        public Order(string orderOwner, OrderType orderType)
        {
            this.owner = orderOwner;
            this.type = orderType;
        }
    }

    public class MessageBoxEx
    {
        public static DialogResult Show(string text, uint uTimeout)
        {
            Setup("", uTimeout);
            return MessageBox.Show(text);
        }

        public static DialogResult Show(string text, string caption, uint uTimeout)
        {
            Setup(caption, uTimeout);
            return MessageBox.Show(text, caption);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, uint uTimeout)
        {
            Setup(caption, uTimeout);
            return MessageBox.Show(text, caption, buttons);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, uint uTimeout)
        {
            Setup(caption, uTimeout);
            return MessageBox.Show(text, caption, buttons, icon);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defButton, uint uTimeout)
        {
            Setup(caption, uTimeout);
            return MessageBox.Show(text, caption, buttons, icon, defButton);
        }

        public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defButton, MessageBoxOptions options, uint uTimeout)
        {
            Setup(caption, uTimeout);
            return MessageBox.Show(text, caption, buttons, icon, defButton, options);
        }

        public static DialogResult Show(IWin32Window owner, string text, uint uTimeout)
        {
            Setup("", uTimeout);
            return MessageBox.Show(owner, text);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, uint uTimeout)
        {
            Setup(caption, uTimeout);
            return MessageBox.Show(owner, text, caption);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, uint uTimeout)
        {
            Setup(caption, uTimeout);
            return MessageBox.Show(owner, text, caption, buttons);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, uint uTimeout)
        {
            Setup(caption, uTimeout);
            return MessageBox.Show(owner, text, caption, buttons, icon);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defButton, uint uTimeout)
        {
            Setup(caption, uTimeout);
            return MessageBox.Show(owner, text, caption, buttons, icon, defButton);
        }

        public static DialogResult Show(IWin32Window owner, string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defButton, MessageBoxOptions options, uint uTimeout)
        {
            Setup(caption, uTimeout);
            return MessageBox.Show(owner, text, caption, buttons, icon, defButton, options);
        }

        public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        public delegate void TimerProc(IntPtr hWnd, uint uMsg, UIntPtr nIDEvent, uint dwTime);

        public const int WH_CALLWNDPROCRET = 12;
        public const int WM_DESTROY = 0x0002;
        public const int WM_INITDIALOG = 0x0110;
        public const int WM_TIMER = 0x0113;
        public const int WM_USER = 0x400;
        public const int DM_GETDEFID = WM_USER + 0;

        [DllImport("User32.dll")]
        public static extern UIntPtr SetTimer(IntPtr hWnd, UIntPtr nIDEvent, uint uElapse, TimerProc lpTimerFunc);

        [DllImport("User32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

        [DllImport("user32.dll")]
        public static extern int UnhookWindowsHookEx(IntPtr idHook);

        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int maxLength);

        [DllImport("user32.dll")]
        public static extern int EndDialog(IntPtr hDlg, IntPtr nResult);

        [StructLayout(LayoutKind.Sequential)]
        public struct CWPRETSTRUCT
        {
            public IntPtr lResult;
            public IntPtr lParam;
            public IntPtr wParam;
            public uint message;
            public IntPtr hwnd;
        };

        private const int TimerID = 42;
        private static HookProc hookProc;
        private static TimerProc hookTimer;
        private static uint hookTimeout;
        private static string hookCaption;
        private static IntPtr hHook;

        static MessageBoxEx()
        {
            hookProc = new HookProc(MessageBoxHookProc);
            hookTimer = new TimerProc(MessageBoxTimerProc);
            hookTimeout = 0;
            hookCaption = null;
            hHook = IntPtr.Zero;
        }

        private static void Setup(string caption, uint uTimeout)
        {
            if (hHook != IntPtr.Zero)
                throw new NotSupportedException("multiple calls are not supported");

            hookTimeout = uTimeout;
            hookCaption = caption != null ? caption : "";
            hHook = SetWindowsHookEx(WH_CALLWNDPROCRET, hookProc, IntPtr.Zero, AppDomain.GetCurrentThreadId());
        }

        private static IntPtr MessageBoxHookProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
                return CallNextHookEx(hHook, nCode, wParam, lParam);

            CWPRETSTRUCT msg = (CWPRETSTRUCT)Marshal.PtrToStructure(lParam, typeof(CWPRETSTRUCT));
            IntPtr hook = hHook;

            if (hookCaption != null && msg.message == WM_INITDIALOG)
            {
                int nLength = GetWindowTextLength(msg.hwnd);
                StringBuilder text = new StringBuilder(nLength + 1);

                GetWindowText(msg.hwnd, text, text.Capacity);

                if (hookCaption == text.ToString())
                {
                    hookCaption = null;
                    SetTimer(msg.hwnd, (UIntPtr)TimerID, hookTimeout, hookTimer);
                    UnhookWindowsHookEx(hHook);
                    hHook = IntPtr.Zero;
                }
            }

            return CallNextHookEx(hook, nCode, wParam, lParam);
        }

        private static void MessageBoxTimerProc(IntPtr hWnd, uint uMsg, UIntPtr nIDEvent, uint dwTime)
        {
            if (nIDEvent == (UIntPtr)TimerID)
            {
                short dw = (short)SendMessage(hWnd, DM_GETDEFID, IntPtr.Zero, IntPtr.Zero);

                EndDialog(hWnd, (IntPtr)dw);
            }
        }
    }
}
