﻿#pragma checksum "..\..\..\..\View\FormForBuyBook.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E6E9D118C80B5A499CAF5325A313CD6A47C26892"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using EXAMPLE.View;
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


namespace EXAMPLE.View {
    
    
    /// <summary>
    /// FormForBuyBook
    /// </summary>
    public partial class FormForBuyBook : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\View\FormForBuyBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumberCard;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\View\FormForBuyBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NumberPlug;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\View\FormForBuyBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Date;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\View\FormForBuyBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DatePlug;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\View\FormForBuyBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameOwner;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\View\FormForBuyBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NamePlug;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\View\FormForBuyBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Ok;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\View\FormForBuyBook.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NotOk;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/EXAMPLE;component/view/formforbuybook.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\FormForBuyBook.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.NumberCard = ((System.Windows.Controls.TextBox)(target));
            
            #line 17 "..\..\..\..\View\FormForBuyBook.xaml"
            this.NumberCard.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NumberCard_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.NumberPlug = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Date = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\..\View\FormForBuyBook.xaml"
            this.Date.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Date_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DatePlug = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.NameOwner = ((System.Windows.Controls.TextBox)(target));
            
            #line 51 "..\..\..\..\View\FormForBuyBook.xaml"
            this.NameOwner.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.NameOwner_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.NamePlug = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.Ok = ((System.Windows.Controls.Button)(target));
            
            #line 69 "..\..\..\..\View\FormForBuyBook.xaml"
            this.Ok.Click += new System.Windows.RoutedEventHandler(this.Ok_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.NotOk = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\..\..\View\FormForBuyBook.xaml"
            this.NotOk.Click += new System.Windows.RoutedEventHandler(this.NotOk_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

