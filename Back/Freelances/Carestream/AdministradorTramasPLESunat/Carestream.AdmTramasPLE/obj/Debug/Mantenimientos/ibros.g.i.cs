﻿#pragma checksum "..\..\..\Mantenimientos\ibros.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EB4F7C82AA30FEF41B38226D5DE406BF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
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


namespace Carestream.AdmTramasPLE.Mantenimientos {
    
    
    /// <summary>
    /// Libros
    /// </summary>
    public partial class Libros : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\Mantenimientos\ibros.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblNombre;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\Mantenimientos\ibros.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxTNombre;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\Mantenimientos\ibros.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblCodigo;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Mantenimientos\ibros.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TxTCodigo;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Mantenimientos\ibros.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LblEstructura;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Mantenimientos\ibros.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CmbEstructura;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Mantenimientos\ibros.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnGuardar;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Mantenimientos\ibros.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid GridLibros;
        
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
            System.Uri resourceLocater = new System.Uri("/Carestream.AdmTramasPLE;component/mantenimientos/ibros.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Mantenimientos\ibros.xaml"
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
            
            #line 4 "..\..\..\Mantenimientos\ibros.xaml"
            ((Carestream.AdmTramasPLE.Mantenimientos.Libros)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LblNombre = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.TxTNombre = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.LblCodigo = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.TxTCodigo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.LblEstructura = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.CmbEstructura = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.BtnGuardar = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.GridLibros = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

