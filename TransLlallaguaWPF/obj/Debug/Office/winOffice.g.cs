﻿#pragma checksum "..\..\..\Office\winOffice.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8B0C126FBAA787334C91630D8980219B47ECC4DB60501AB398E38DBA79809273"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
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
using TransLlallaguaWPF.Office;


namespace TransLlallaguaWPF.Office {
    
    
    /// <summary>
    /// winOffice
    /// </summary>
    public partial class winOffice : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\Office\winOffice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TabControl tbControl;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Office\winOffice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtName;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Office\winOffice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPhone;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Office\winOffice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtAdress;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Office\winOffice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRegister;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\Office\winOffice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgvTable;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Office\winOffice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUpdate;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Office\winOffice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDelete;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\Office\winOffice.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MaterialDesignThemes.Wpf.PackIcon btnBack;
        
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
            System.Uri resourceLocater = new System.Uri("/TransLlallaguaWPF;component/office/winoffice.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Office\winOffice.xaml"
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
            this.tbControl = ((System.Windows.Controls.TabControl)(target));
            return;
            case 2:
            this.txtName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.txtPhone = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.txtAdress = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.btnRegister = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Office\winOffice.xaml"
            this.btnRegister.Click += new System.Windows.RoutedEventHandler(this.btnRegister_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dgvTable = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.btnUpdate = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\..\Office\winOffice.xaml"
            this.btnUpdate.Click += new System.Windows.RoutedEventHandler(this.btnUpdate_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnDelete = ((System.Windows.Controls.Button)(target));
            
            #line 34 "..\..\..\Office\winOffice.xaml"
            this.btnDelete.Click += new System.Windows.RoutedEventHandler(this.btnDelete_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnBack = ((MaterialDesignThemes.Wpf.PackIcon)(target));
            
            #line 42 "..\..\..\Office\winOffice.xaml"
            this.btnBack.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.btnBack_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
