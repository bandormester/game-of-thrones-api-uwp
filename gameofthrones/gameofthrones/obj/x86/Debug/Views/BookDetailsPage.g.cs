﻿#pragma checksum "F:\Egyetem\Kliensoldali\NAGYHAZI\gameofthrones\gameofthrones\gameofthrones\Views\BookDetailsPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6D7E8AEFBE29A2F8E0F273D6DC732C7C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gameofthrones.Views
{
    partial class BookDetailsPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.ViewModel = (global::gameofthrones.ViewModels.BookDetailsPageViewModel)(target);
                }
                break;
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.GridView element2 = (global::Windows.UI.Xaml.Controls.GridView)(target);
                    #line 87 "..\..\..\Views\BookDetailsPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.GridView)element2).ItemClick += this.Characters_Click;
                    #line default
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.GridView element3 = (global::Windows.UI.Xaml.Controls.GridView)(target);
                    #line 104 "..\..\..\Views\BookDetailsPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.GridView)element3).ItemClick += this.Characters_Click;
                    #line default
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 99 "..\..\..\Views\BookDetailsPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.PreviousButton_Click;
                    #line default
                }
                break;
            case 5:
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 100 "..\..\..\Views\BookDetailsPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.NextButton_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

