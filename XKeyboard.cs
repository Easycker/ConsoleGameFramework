﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameFramework
{
    public enum XKeys
    {
        A = 0x41,
        Add = 0x6b,
        Alt = 0x40000,
        Apps = 0x5d,
        Attn = 0xf6,
        B = 0x42,
        Back = 8,
        BrowserBack = 0xa6,
        BrowserFavorites = 0xab,
        BrowserForward = 0xa7,
        BrowserHome = 0xac,
        BrowserRefresh = 0xa8,
        BrowserSearch = 170,
        BrowserStop = 0xa9,
        C = 0x43,
        Cancel = 3,
        Capital = 20,
        CapsLock = 20,
        Clear = 12,
        Control = 0x20000,
        ControlKey = 0x11,
        Crsel = 0xf7,
        D = 0x44,
        D0 = 0x30,
        D1 = 0x31,
        D2 = 50,
        D3 = 0x33,
        D4 = 0x34,
        D5 = 0x35,
        D6 = 0x36,
        D7 = 0x37,
        D8 = 0x38,
        D9 = 0x39,
        Decimal = 110,
        Delete = 0x2e,
        Divide = 0x6f,
        Down = 40,
        E = 0x45,
        End = 0x23,
        Enter = 13,
        EraseEof = 0xf9,
        Escape = 0x1b,
        Execute = 0x2b,
        Exsel = 0xf8,
        F = 70,
        F1 = 0x70,
        F10 = 0x79,
        F11 = 0x7a,
        F12 = 0x7b,
        F13 = 0x7c,
        F14 = 0x7d,
        F15 = 0x7e,
        F16 = 0x7f,
        F17 = 0x80,
        F18 = 0x81,
        F19 = 130,
        F2 = 0x71,
        F20 = 0x83,
        F21 = 0x84,
        F22 = 0x85,
        F23 = 0x86,
        F24 = 0x87,
        F3 = 0x72,
        F4 = 0x73,
        F5 = 0x74,
        F6 = 0x75,
        F7 = 0x76,
        F8 = 0x77,
        F9 = 120,
        FinalMode = 0x18,
        G = 0x47,
        H = 0x48,
        HanguelMode = 0x15,
        HangulMode = 0x15,
        HanjaMode = 0x19,
        Help = 0x2f,
        Home = 0x24,
        I = 0x49,
        IMEAccept = 30,
        IMEAceept = 30,
        IMEConvert = 0x1c,
        IMEModeChange = 0x1f,
        IMENonconvert = 0x1d,
        Insert = 0x2d,
        J = 0x4a,
        JunjaMode = 0x17,
        K = 0x4b,
        KanaMode = 0x15,
        KanjiMode = 0x19,
        KeyCode = 0xffff,
        L = 0x4c,
        LaunchApplication1 = 0xb6,
        LaunchApplication2 = 0xb7,
        LaunchMail = 180,
        LControlKey = 0xa2,
        Left = 0x25,
        LineFeed = 10,
        LMenu = 0xa4,
        LShiftKey = 160,
        LWin = 0x5b,
        M = 0x4d,
        MediaNextTrack = 0xb0,
        MediaPlayPause = 0xb3,
        MediaPreviousTrack = 0xb1,
        MediaStop = 0xb2,
        Menu = 0x12,
        Modifiers = -65536,
        Multiply = 0x6a,
        N = 0x4e,
        Next = 0x22,
        NoName = 0xfc,
        None = 0,
        NumLock = 0x90,
        NumPad0 = 0x60,
        NumPad1 = 0x61,
        NumPad2 = 0x62,
        NumPad3 = 0x63,
        NumPad4 = 100,
        NumPad5 = 0x65,
        NumPad6 = 0x66,
        NumPad7 = 0x67,
        NumPad8 = 0x68,
        NumPad9 = 0x69,
        O = 0x4f,
        Oem1 = 0xba,
        Oem102 = 0xe2,
        Oem2 = 0xbf,
        Oem3 = 0xc0,
        Oem4 = 0xdb,
        Oem5 = 220,
        Oem6 = 0xdd,
        Oem7 = 0xde,
        Oem8 = 0xdf,
        OemBackslash = 0xe2,
        OemClear = 0xfe,
        OemCloseBrackets = 0xdd,
        Oemcomma = 0xbc,
        OemMinus = 0xbd,
        OemOpenBrackets = 0xdb,
        OemPeriod = 190,
        OemPipe = 220,
        Oemplus = 0xbb,
        OemQuestion = 0xbf,
        OemQuotes = 0xde,
        OemSemicolon = 0xba,
        Oemtilde = 0xc0,
        P = 80,
        Pa1 = 0xfd,
        Packet = 0xe7,
        PageDown = 0x22,
        PageUp = 0x21,
        Pause = 0x13,
        Play = 250,
        Print = 0x2a,
        PrintScreen = 0x2c,
        Prior = 0x21,
        ProcessKey = 0xe5,
        Q = 0x51,
        R = 0x52,
        RControlKey = 0xa3,
        Return = 13,
        Right = 0x27,
        RMenu = 0xa5,
        RShiftKey = 0xa1,
        RWin = 0x5c,
        S = 0x53,
        Scroll = 0x91,
        Select = 0x29,
        SelectMedia = 0xb5,
        Separator = 0x6c,
        Shift = 0x10000,
        ShiftKey = 0x10,
        Sleep = 0x5f,
        Snapshot = 0x2c,
        Space = 0x20,
        Subtract = 0x6d,
        T = 0x54,
        Tab = 9,
        U = 0x55,
        Up = 0x26,
        V = 0x56,
        VolumeDown = 0xae,
        VolumeMute = 0xad,
        VolumeUp = 0xaf,
        W = 0x57,
        X = 0x58,
        XButton1 = 5,
        XButton2 = 6,
        Y = 0x59,
        Z = 90,
        Zoom = 0xfb
    }

    internal sealed class XKeyboard : XInput
    {
        /// <summary>
        /// 键盘事件委托
        /// </summary>
        /// <typeparam name="TEventsArgs"></typeparam>
        /// <param name="e"></param>
        internal delegate void XKeyboardHandler<TEventsArgs>(TEventsArgs e);

        /// <summary>
        /// 按下按键
        /// </summary>
        private event XKeyboardHandler<XKeyboardEventArgs> m_keyDown;

        /// <summary>
        /// 释放按键
        /// </summary>
        private event XKeyboardHandler<XKeyboardEventArgs> m_keyUp;

        /// <summary>
        /// 记录 [上一次] 按下的键值
        /// </summary>
        private XKeys m_oldKey = XKeys.None;

        /// <summary>
        /// 构造函数
        /// </summary>
        public XKeyboard()
        { }

        /// <summary>
        /// 检测键位是否被按下
        /// </summary>
        /// <param name="vKey"></param>
        /// <returns></returns>
        private Boolean isKeyDown(XKeys vKey)
        {
            return 0 != (GetAsyncKeyState((Int32)vKey) & KEY_STATE);
        }

        /// <summary>
        /// 检测当前被按下的键值
        /// Enum.GetValues (https://msdn.microsoft.com/zh-cn/library/system.enum.getvalues.aspx)
        /// typeof (https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/keywords/typeof)
        /// </summary>
        /// <returns></returns>
        private XKeys GetCurDownKey()
        {
            XKeys vKey = XKeys.None;
            foreach (Int32 key in Enum.GetValues(typeof(XKeys)))
            {
                if (isKeyDown((XKeys)key))
                {
                    vKey = (XKeys)key;
                    break;
                }
            }
            return vKey;
        }

        /// <summary>
        /// 响应键盘按下事件
        /// </summary>
        /// <param name="args"></param>
        private void OnKeyDown(XKeyboardEventArgs args)
        {
            XKeyboardHandler<XKeyboardEventArgs> temp = m_keyDown;
            if (temp != null)
            {
                temp.Invoke(args);
            }
        }

        /// <summary>
        /// 响应键盘释放事件
        /// Invoke (https://msdn.microsoft.com/zh-cn/library/zyzhdc6b.aspx)
        /// </summary>
        /// <param name="args"></param>
        private void OnKeyUp(XKeyboardEventArgs args)
        {
            XKeyboardHandler<XKeyboardEventArgs> temp = m_keyUp;
            if (temp != null)
            {
                temp.Invoke(args);
            }
        }

        /// <summary>
        /// 添加键盘按下事件
        /// </summary>
        /// <param name="func"></param>
        public void addKeyDownEvent(XKeyboardHandler<XKeyboardEventArgs> func)
        {
            m_keyDown += func;
        }

        /// <summary>
        /// 添加键盘释放事件
        /// </summary>
        /// <param name="func"></param>
        public void addKeyUpEvent(XKeyboardHandler<XKeyboardEventArgs> func)
        {
            m_keyUp += func;
        }

        public void KeyboardEventsHandler()
        {
            XKeyboardEventArgs e;
            XKeys xKeyDown = GetCurDownKey();

            if (xKeyDown != XKeys.None)
            {
                // 有新的按键被按下
                this.m_oldKey = xKeyDown;
                e = new XKeyboardEventArgs(xKeyDown);
                this.OnKeyDown(e);
            }
            else if(this.m_oldKey != XKeys.None && !isKeyDown(this.m_oldKey))
            {
                // 有旧的按键被释放
                e = new XKeyboardEventArgs(this.m_oldKey);
                this.OnKeyUp(e);
                this.m_oldKey = XKeys.None;
            }
        }
    }
}
