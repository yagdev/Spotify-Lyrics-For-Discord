﻿#pragma checksum "..\..\..\Settings.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "96D53FB98A4FD6F72FEBFCC5EBD7B70CCE81DCC3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DiscordRPCAttempt2;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace DiscordRPCAttempt2 {
    
    
    /// <summary>
    /// Settings
    /// </summary>
    public partial class Settings : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 112 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridStuff;
        
        #line default
        #line hidden
        
        
        #line 118 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label TitleLbl;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SPDC;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle RectangleShit1;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ClientID;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle RectangleShit2;
        
        #line default
        #line hidden
        
        
        #line 152 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ClientSecret;
        
        #line default
        #line hidden
        
        
        #line 153 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle RectangleShit3;
        
        #line default
        #line hidden
        
        
        #line 167 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AppID;
        
        #line default
        #line hidden
        
        
        #line 168 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle RectangleShit4;
        
        #line default
        #line hidden
        
        
        #line 180 "..\..\..\Settings.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button StartButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DiscordRPCAttempt2;V23.9.2.0;component/settings.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Settings.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.11.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\Settings.xaml"
            ((DiscordRPCAttempt2.Settings)(target)).Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GridStuff = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.TitleLbl = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.SPDC = ((System.Windows.Controls.TextBox)(target));
            
            #line 122 "..\..\..\Settings.xaml"
            this.SPDC.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged);
            
            #line default
            #line hidden
            
            #line 122 "..\..\..\Settings.xaml"
            this.SPDC.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox_GotFocus);
            
            #line default
            #line hidden
            
            #line 122 "..\..\..\Settings.xaml"
            this.SPDC.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox_LostFocus);
            
            #line default
            #line hidden
            return;
            case 5:
            this.RectangleShit1 = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 6:
            
            #line 133 "..\..\..\Settings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Set1_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 134 "..\..\..\Settings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ClientID = ((System.Windows.Controls.TextBox)(target));
            
            #line 137 "..\..\..\Settings.xaml"
            this.ClientID.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox2_GotFocus);
            
            #line default
            #line hidden
            
            #line 137 "..\..\..\Settings.xaml"
            this.ClientID.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox2_LostFocus);
            
            #line default
            #line hidden
            return;
            case 9:
            this.RectangleShit2 = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 10:
            
            #line 148 "..\..\..\Settings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Set2_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 149 "..\..\..\Settings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button2_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ClientSecret = ((System.Windows.Controls.TextBox)(target));
            
            #line 152 "..\..\..\Settings.xaml"
            this.ClientSecret.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox3_GotFocus);
            
            #line default
            #line hidden
            
            #line 152 "..\..\..\Settings.xaml"
            this.ClientSecret.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox3_LostFocus);
            
            #line default
            #line hidden
            return;
            case 13:
            this.RectangleShit3 = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 14:
            
            #line 163 "..\..\..\Settings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Set3_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 164 "..\..\..\Settings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button2_Click);
            
            #line default
            #line hidden
            return;
            case 16:
            this.AppID = ((System.Windows.Controls.TextBox)(target));
            
            #line 167 "..\..\..\Settings.xaml"
            this.AppID.GotFocus += new System.Windows.RoutedEventHandler(this.TextBox4_GotFocus);
            
            #line default
            #line hidden
            
            #line 167 "..\..\..\Settings.xaml"
            this.AppID.LostFocus += new System.Windows.RoutedEventHandler(this.TextBox4_LostFocus);
            
            #line default
            #line hidden
            return;
            case 17:
            this.RectangleShit4 = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 18:
            
            #line 178 "..\..\..\Settings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Set4_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            
            #line 179 "..\..\..\Settings.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button3_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            this.StartButton = ((System.Windows.Controls.Button)(target));
            
            #line 180 "..\..\..\Settings.xaml"
            this.StartButton.Click += new System.Windows.RoutedEventHandler(this.Start);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

