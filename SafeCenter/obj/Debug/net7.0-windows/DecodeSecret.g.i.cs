﻿#pragma checksum "..\..\..\DecodeSecret.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7C5D3C5F21DDC7F19338360DD969E155A8B28831"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using SafeCenter;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SafeCenter {
    
    
    /// <summary>
    /// DecodeSecret
    /// </summary>
    public partial class DecodeSecret : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\DecodeSecret.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost DialogHost;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\DecodeSecret.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button menuBtn;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\DecodeSecret.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_exit;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\DecodeSecret.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Message;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\DecodeSecret.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Decrypted;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\DecodeSecret.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Publickey;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\DecodeSecret.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Privatekey;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\DecodeSecret.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock result;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SafeCenter;component/decodesecret.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DecodeSecret.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 14 "..\..\..\DecodeSecret.xaml"
            ((SafeCenter.DecodeSecret)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DialogHost = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 3:
            this.menuBtn = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\DecodeSecret.xaml"
            this.menuBtn.Click += new System.Windows.RoutedEventHandler(this.menuOpen);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_exit = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\DecodeSecret.xaml"
            this.btn_exit.Click += new System.Windows.RoutedEventHandler(this.exitApp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Message = ((System.Windows.Controls.TextBox)(target));
            
            #line 37 "..\..\..\DecodeSecret.xaml"
            this.Message.GotFocus += new System.Windows.RoutedEventHandler(this.Message_GotFocus);
            
            #line default
            #line hidden
            
            #line 37 "..\..\..\DecodeSecret.xaml"
            this.Message.LostFocus += new System.Windows.RoutedEventHandler(this.Message_LostFocus);
            
            #line default
            #line hidden
            
            #line 37 "..\..\..\DecodeSecret.xaml"
            this.Message.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Message_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Decrypted = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            
            #line 49 "..\..\..\DecodeSecret.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.copyMessage_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Publickey = ((System.Windows.Controls.TextBox)(target));
            
            #line 56 "..\..\..\DecodeSecret.xaml"
            this.Publickey.GotFocus += new System.Windows.RoutedEventHandler(this.Publickey_GotFocus);
            
            #line default
            #line hidden
            
            #line 56 "..\..\..\DecodeSecret.xaml"
            this.Publickey.LostFocus += new System.Windows.RoutedEventHandler(this.Publickey_LostFocus);
            
            #line default
            #line hidden
            
            #line 56 "..\..\..\DecodeSecret.xaml"
            this.Publickey.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Publickey_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Privatekey = ((System.Windows.Controls.TextBox)(target));
            
            #line 64 "..\..\..\DecodeSecret.xaml"
            this.Privatekey.GotFocus += new System.Windows.RoutedEventHandler(this.Privatekey_GotFocus);
            
            #line default
            #line hidden
            
            #line 64 "..\..\..\DecodeSecret.xaml"
            this.Privatekey.LostFocus += new System.Windows.RoutedEventHandler(this.Privatekey_LostFocus);
            
            #line default
            #line hidden
            
            #line 64 "..\..\..\DecodeSecret.xaml"
            this.Privatekey.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Privatekey_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 72 "..\..\..\DecodeSecret.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.decodeBtn_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.result = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

