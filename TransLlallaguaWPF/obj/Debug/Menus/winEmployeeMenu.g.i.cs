﻿#pragma checksum "..\..\..\Menus\winEmployeeMenu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EF0926EAC3315FBBBE4C436EA17C503606ADB899CCFCBD1972CB9208E0FE59BA"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using TransLlallaguaWPF.Menus;


namespace TransLlallaguaWPF.Menus {
    
    
    /// <summary>
    /// winEmployeeMenu
    /// </summary>
    public partial class winEmployeeMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Menus\winEmployeeMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image keyImage;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Menus\winEmployeeMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image localityImage;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\Menus\winEmployeeMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image off2Image;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\Menus\winEmployeeMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ticketImage;
        
        #line default
        #line hidden
        
        
        #line 107 "..\..\..\Menus\winEmployeeMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image travelImage;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\Menus\winEmployeeMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image passangerImage;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\Menus\winEmployeeMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image seatImage;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TransLlallaguaWPF;component/menus/winemployeemenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Menus\winEmployeeMenu.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.keyImage = ((System.Windows.Controls.Image)(target));
            
            #line 17 "..\..\..\Menus\winEmployeeMenu.xaml"
            this.keyImage.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.keyImage_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.localityImage = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.off2Image = ((System.Windows.Controls.Image)(target));
            
            #line 57 "..\..\..\Menus\winEmployeeMenu.xaml"
            this.off2Image.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.off2Image_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ticketImage = ((System.Windows.Controls.Image)(target));
            return;
            case 5:
            this.travelImage = ((System.Windows.Controls.Image)(target));
            return;
            case 6:
            this.passangerImage = ((System.Windows.Controls.Image)(target));
            return;
            case 7:
            this.seatImage = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

