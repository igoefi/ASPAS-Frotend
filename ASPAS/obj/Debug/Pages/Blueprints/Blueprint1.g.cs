﻿#pragma checksum "..\..\..\..\Pages\Blueprints\Blueprint1.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4336961EA4A38427B182D95215D5F1A4CFC5BCC1FF00295488DE48FE61A389B2"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ASPAS.Pages.Blueprints;
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


namespace ASPAS.Pages.Blueprints {
    
    
    /// <summary>
    /// Blueprint1
    /// </summary>
    public partial class Blueprint1 : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\..\..\Pages\Blueprints\Blueprint1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FirstButton;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\Pages\Blueprints\Blueprint1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SecondButton;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\Pages\Blueprints\Blueprint1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ThirdButton;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\..\..\Pages\Blueprints\Blueprint1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ThourthButton;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\Pages\Blueprints\Blueprint1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border ErrorTextBorder;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\..\Pages\Blueprints\Blueprint1.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TxbError;
        
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
            System.Uri resourceLocater = new System.Uri("/ASPAS;component/pages/blueprints/blueprint1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\Blueprints\Blueprint1.xaml"
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
            this.FirstButton = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\Pages\Blueprints\Blueprint1.xaml"
            this.FirstButton.Click += new System.Windows.RoutedEventHandler(this.BtnClickShowError);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SecondButton = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\..\Pages\Blueprints\Blueprint1.xaml"
            this.SecondButton.Click += new System.Windows.RoutedEventHandler(this.BtnClickShowError);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ThirdButton = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\..\..\Pages\Blueprints\Blueprint1.xaml"
            this.ThirdButton.Click += new System.Windows.RoutedEventHandler(this.BtnClickShowError);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ThourthButton = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\..\Pages\Blueprints\Blueprint1.xaml"
            this.ThourthButton.Click += new System.Windows.RoutedEventHandler(this.BtnClickShowError);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ErrorTextBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            
            #line 99 "..\..\..\..\Pages\Blueprints\Blueprint1.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BtnClickCloseTextBorder);
            
            #line default
            #line hidden
            return;
            case 7:
            this.TxbError = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

