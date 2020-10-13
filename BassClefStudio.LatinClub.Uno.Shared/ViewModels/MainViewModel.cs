﻿using BassClefStudio.LatinClub.Uno.Helpers;
using BassClefStudio.NET.Core;
#if NETFX_CORE
using Microsoft.UI.Xaml.Input;
#else
using System.Windows.Input;
#endif
using System;
using System.Collections.Generic;
using System.Text;
using BassClefStudio.LatinClub.Uno.Data;
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.UI;

namespace BassClefStudio.LatinClub.Uno.ViewModels
{
    public class MainViewModel : Observable
    {
        private ClubContext context;
        public ClubContext Context { get => context; set => Set(ref context, value); }

        public AdvancedCollectionView EventsView { get; }

        public MainViewModel()
        {
            Context = new ClubContext();
            EventsView = new AdvancedCollectionView(Context.Events.Item);
            SetCommand = new RelayCommandBuilder(Set).Command;
        }

        public ICommand SetCommand { get; }

        public async Task Set()
        {
            await Context.Events.UpdateAsync();
        }
    }
}
