﻿using System;
using System.Windows.Input;

namespace Model.ViewModel
{
    class ActionBase : ICommand
    {
        #region private
        private readonly Action execute = null;
        private readonly Predicate<object> canExecute = null;
        #endregion

        public event EventHandler CanExecuteChanged;

        public ActionBase(Action execute) : this(execute, null) { }

        public ActionBase(Action execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute();
        }


        public void WhenCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }
    }
}
