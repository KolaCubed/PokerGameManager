using PokerGameManager.Models;
using PokerGameManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PokerGameManager.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlindPage : ContentPage
    {
        BlindVM vm;

        public BlindPage()
        {
            InitializeComponent();
        }

        public BlindPage(int blindsId)
        {
            InitializeComponent();

            vm = Resources["vm"] as BlindVM;
            vm.Load(blindsId);
        }
    }
}