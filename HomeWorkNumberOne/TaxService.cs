using System;

namespace TaxService
{
    public class TaxService
    {
        private readonly IDateTimeService dateTimeService;
        private readonly IUserService userService;

        public TaxService(IDateTimeService dateTimeService, IUserService userService)
        {
            this.dateTimeService = dateTimeService;
            this.userService = userService;
        }

        public decimal ApplyTax(decimal val)
        {
            return val * (GetTax() + 1);
        }

        public decimal GetTax(DateTime date)
        {
            return GetTax((DateTime?)date);
        }

        private decimal GetTax(DateTime? date = null)
        {
            var requiredDay = date ?? GetCurrentDate();

            if (requiredDay.Year >= 2020)
            {
                return 0.2m; //20%
            }
            else if (requiredDay.Year > 2000)
            {
                return 0.3m; //30%
            }
            else
            {
                return 0.15m; //15%
            }
        }

        private DateTime GetCurrentDate()
        {
            return dateTimeService.GetCurrentDate(userService.GetUiCulture());
        }
    }

    public interface IUserService
    {
        string GetUiCulture();
    }

    public interface IDateTimeService
    {
        DateTime GetCurrentDate(string uiCulture);
    }
}
