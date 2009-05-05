using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// code from http://www.devnewsgroups.net/group/microsoft.public.dotnet.framework.windowsforms/topic25839.aspx

namespace ClipNote
{
    class MyClipboard
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetClipboardData(uint uFormat);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool OpenClipboard(IntPtr hWndNewOwner);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool CloseClipboard();
        [DllImport("user32.dll", SetLastError = true)]
        static extern uint RegisterClipboardFormatA(string lpszFormat);
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool IsClipboardFormatAvailable(uint format);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GlobalLock(IntPtr hMem);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern uint GlobalSize(IntPtr hMem);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GlobalUnlock(IntPtr hMem);


        public static string GetHtml(IntPtr handle)
        {
            uint CF_HTML = RegisterClipboardFormatA("HTML Format");

            if (IsClipboardFormatAvailable(CF_HTML))
            {
                if (OpenClipboard(handle))
                {
                    IntPtr hGMem = GetClipboardData(CF_HTML);
                    IntPtr pMFP = GlobalLock(hGMem);
                    uint len = GlobalSize(hGMem);
                    byte[] bytes = new byte[len];
                    Marshal.Copy(pMFP, bytes, 0, (int)len);

                    string strMFP = System.Text.Encoding.UTF8.GetString(bytes);
                    GlobalUnlock(hGMem);
                    CloseClipboard();
                    return strMFP;
                }
            }
            return String.Empty;
        }
    }
}
