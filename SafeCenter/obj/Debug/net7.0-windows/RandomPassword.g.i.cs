﻿#pragma checksum "..\..\..\RandomPassword.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6CE11A8E98C126375A76DEA2D761DC080DC8B527"
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
    /// RandomPassword
    /// </summary>
    public partial class RandomPassword : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\RandomPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.DialogHost DialogHost;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\RandomPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button menuBtn;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\RandomPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_exit;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\RandomPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Count;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\RandomPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button generate;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\RandomPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock result;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\RandomPassword.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button copyMessage;
        
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
            System.Uri resourceLocater = new System.Uri("/SafeCenter;component/randompassword.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\RandomPassword.xaml"
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
            
            #line 14 "..\..\..\RandomPassword.xaml"
            ((SafeCenter.RandomPassword)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DialogHost = ((MaterialDesignThemes.Wpf.DialogHost)(target));
            return;
            case 3:
            this.menuBtn = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\RandomPassword.xaml"
            this.menuBtn.Click += new System.Windows.RoutedEventHandler(this.menuOpen);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_exit = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\RandomPassword.xaml"
            this.btn_exit.Click += new System.Windows.RoutedEventHandler(this.exitApp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Count = ((System.Windows.Controls.TextBox)(target));
            
            #line 35 "..\..\..\RandomPassword.xaml"
            this.Count.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Count_PreviewTextInput);
            
            #line default
            #line hidden
            
            #line 35 "..\..\..\RandomPassword.xaml"
            this.Count.GotFocus += new System.Windows.RoutedEventHandler(this.Count_GotFocus);
            
            #line default
            #line hidden
            
            #line 35 "..\..\..\RandomPassword.xaml"
            this.Count.LostFocus += new System.Windows.RoutedEventHandler(this.Count_LostFocus);
            
            #line default
            #line hidden
            return;
            case 6:
            this.generate = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\RandomPassword.xaml"
            this.generate.Click += new System.Windows.RoutedEventHandler(this.generate_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.result = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.copyMessage = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\RandomPassword.xaml"
            this.copyMessage.Click += new System.Windows.RoutedEventHandler(this.copyMessage_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

