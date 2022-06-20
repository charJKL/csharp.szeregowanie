using System;
using System.Globalization;
using System.Windows.Controls;

namespace Szeregowanie.View
{
    class TaskValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int taskTime;
            bool isNumber = int.TryParse(value.ToString(), out taskTime);

            if (!isNumber)
            {
                Lobby.DatagridHasError = true;
                return new ValidationResult(false, "Podana wartość nie jest liczbą.");
            }
                
            if (taskTime < 0)
            {
                Lobby.DatagridHasError = true;
                return new ValidationResult(false, "Czas zadania nie może być ujemny.");
            }

            Lobby.DatagridHasError = false;
            return ValidationResult.ValidResult;
        }
    }
}
