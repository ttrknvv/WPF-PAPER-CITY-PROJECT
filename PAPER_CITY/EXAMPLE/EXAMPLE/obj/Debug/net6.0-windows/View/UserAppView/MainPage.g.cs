﻿#pragma checksum "..\..\..\..\..\View\UserAppView\MainPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4C3DA20E738C1D515E2944918FEBC13F2B2A2B7F"
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
    /// MainPage
    /// </summary>
    public partial class MainPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 12 "..\..\..\..\..\View\UserAppView\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\..\..\View\UserAppView\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListOfPopularBooks;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\..\View\UserAppView\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListOfNewBooks;
        
        #line default
        #line hidden
        
        
        #line 108 "..\..\..\..\..\View\UserAppView\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListOfFreeBooks;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\..\..\View\UserAppView\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView ListOfPaidBooks;
        
        #line default
        #line hidden
        
        
        #line 190 "..\..\..\..\..\View\UserAppView\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid GridForBook;
        
        #line default
        #line hidden
        
        
        #line 202 "..\..\..\..\..\View\UserAppView\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView BookNowSelected;
        
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
            System.Uri resourceLocater = new System.Uri("/PaperCity;component/view/userappview/mainpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\UserAppView\MainPage.xaml"
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
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            
            #line 13 "..\..\..\..\..\View\UserAppView\MainPage.xaml"
            ((System.Windows.Controls.ScrollViewer)(target)).PreviewMouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.ScrollViewer_PreviewMouseWheel);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ListOfPopularBooks = ((System.Windows.Controls.ListView)(target));
            
            #line 28 "..\..\..\..\..\View\UserAppView\MainPage.xaml"
            this.ListOfPopularBooks.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ListOfPopularBooks_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ListOfNewBooks = ((System.Windows.Controls.ListView)(target));
            
            #line 70 "..\..\..\..\..\View\UserAppView\MainPage.xaml"
            this.ListOfNewBooks.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ListOfNewBooks_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ListOfFreeBooks = ((System.Windows.Controls.ListView)(target));
            
            #line 112 "..\..\..\..\..\View\UserAppView\MainPage.xaml"
            this.ListOfFreeBooks.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ListOfFreeBooks_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ListOfPaidBooks = ((System.Windows.Controls.ListView)(target));
            
            #line 153 "..\..\..\..\..\View\UserAppView\MainPage.xaml"
            this.ListOfPaidBooks.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.ListOfPaidBooks_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 7:
            this.GridForBook = ((System.Windows.Controls.Grid)(target));
            return;
            case 8:
            
            #line 201 "..\..\..\..\..\View\UserAppView\MainPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BookNowSelected = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 10:
            
            #line 285 "..\..\..\..\..\View\UserAppView\MainPage.xaml"
            ((System.Windows.Controls.ListView)(target)).PreviewMouseWheel += new System.Windows.Input.MouseWheelEventHandler(this.ReviewsList_PreviewMouseWheel);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

