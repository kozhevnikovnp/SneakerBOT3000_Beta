﻿#pragma checksum "..\..\Tasks.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "58013195C173A6BDE863A9BA39096AD1BE8785EC877B4FF10B9B61B4495CEB16"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using ShopBot;
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


namespace ShopBot {
    
    
    /// <summary>
    /// Tasks
    /// </summary>
    public partial class Tasks : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 36 "..\..\Tasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Task_Name;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Tasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Link;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\Tasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Keywords;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\Tasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Retailers;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\Tasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Profiles;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\Tasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Card;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\Tasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Tasks_save;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\Tasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Clear_all;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\Tasks.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox time;
        
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
            System.Uri resourceLocater = new System.Uri("/ShopBot;component/tasks.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Tasks.xaml"
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
            this.Task_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.Link = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Keywords = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Retailers = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.Profiles = ((System.Windows.Controls.ComboBox)(target));
            
            #line 68 "..\..\Tasks.xaml"
            this.Profiles.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Profiles_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Card = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.Tasks_save = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\Tasks.xaml"
            this.Tasks_save.Click += new System.Windows.RoutedEventHandler(this.Tasks_save_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Clear_all = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\Tasks.xaml"
            this.Clear_all.Click += new System.Windows.RoutedEventHandler(this.Clear_all_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.time = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

