﻿#pragma checksum "..\..\..\AddEmployeeDialog.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C866EAF16AF6F56B150C676B84337B7F144DEC7D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Assignment1_PhamHoangTien_SE160239;
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


namespace Assignment1_PhamHoangTien_SE160239 {
    
    
    /// <summary>
    /// AddEmployeeDialog
    /// </summary>
    public partial class AddEmployeeDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 47 "..\..\..\AddEmployeeDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbEmail;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\AddEmployeeDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbDepartment;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\AddEmployeeDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbJob;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\AddEmployeeDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpHiredDate;
        
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
            System.Uri resourceLocater = new System.Uri("/Assignment1_PhamHoangTien_SE160239;component/addemployeedialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddEmployeeDialog.xaml"
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
            
            #line 21 "..\..\..\AddEmployeeDialog.xaml"
            ((System.Windows.Controls.Image)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Image_MouseUp);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 38 "..\..\..\AddEmployeeDialog.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Border_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbEmail = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.cbDepartment = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.cbJob = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.dpHiredDate = ((System.Windows.Controls.DatePicker)(target));
            
            #line 73 "..\..\..\AddEmployeeDialog.xaml"
            this.dpHiredDate.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.dpHiredDate_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 81 "..\..\..\AddEmployeeDialog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddEmployeeButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 82 "..\..\..\AddEmployeeDialog.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BackToManagerMenuButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

