using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace StartNow.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboCategories();

        IEnumerable<SelectListItem> GetComboCountries();

        IEnumerable<SelectListItem> GetComboCities(int countryId);
    }
}
