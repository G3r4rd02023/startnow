using StartNow.Data.Entities;
using StartNow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StartNow.Helpers
{
    public interface IConverterHelper
    {
        Category ToCategory(CategoryViewModel model, Guid imageId, bool isNew);

        CategoryViewModel ToCategoryViewModel(Category category);

        Country ToCountry(CountryViewModel model, Guid imageId, bool isNew);

        CountryViewModel ToCountryViewModel(Country country);

        Task<Company> ToCompanyAsync(CompanyViewModel model, Guid imageId, bool isNew);

        CompanyViewModel ToCompanyViewModel(Company company);

        Task<Product> ToProductAsync(ProductViewModel model, bool isNew);

        ProductViewModel ToProductViewModel(Product product);

    }

}

