﻿using System.Windows.Input;
using Chalk.viewmodels.admin;
using Chalk.views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Chalk.viewmodels;

[AvaUtils.ForView(typeof(FrameView))]
public partial class FrameViewModel : ObservableObject {
    public static ICommand NavigateToHomeCommand => new RelayCommand(() => {
        AvaUtils.Manager.SetCurrentPage("main", new HomeViewModel());
    });

    public static ICommand NavigateToAdminSubjectsCommand => new RelayCommand(() => {
        AvaUtils.Manager.SetCurrentPage("main", new SubjectsViewModel());
    });
}