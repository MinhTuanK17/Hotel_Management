﻿#pragma checksum "..\..\..\..\Admins\AddNewRoom.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "FF800C72C44E0C7132E30A6092177F4C53377685"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HotelManagement.Admins;
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


namespace HotelManagement.Admins {
    
    
    /// <summary>
    /// AddNewRoom
    /// </summary>
    public partial class AddNewRoom : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 47 "..\..\..\..\Admins\AddNewRoom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRoomID;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Admins\AddNewRoom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRoomNumber;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\..\Admins\AddNewRoom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbRoomType;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Admins\AddNewRoom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock txtRoomStatus;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Admins\AddNewRoom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtCapacity;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Admins\AddNewRoom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPricePerDay;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\..\Admins\AddNewRoom.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDescription;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HotelManagement;component/admins/addnewroom.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Admins\AddNewRoom.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\..\Admins\AddNewRoom.xaml"
            ((HotelManagement.Admins.AddNewRoom)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtRoomID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtRoomNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.cbRoomType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.txtRoomStatus = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.txtCapacity = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.txtPricePerDay = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.txtDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            
            #line 90 "..\..\..\..\Admins\AddNewRoom.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Save_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 96 "..\..\..\..\Admins\AddNewRoom.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

