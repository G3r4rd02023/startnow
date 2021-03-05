using StartNow.Data;
using StartNow.Data.Entities;
using StartNow.Models;
using System;
using System.Threading.Tasks;

namespace StartNow.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _context;
        private readonly ICombosHelper _combosHelper;

        public ConverterHelper(DataContext context, ICombosHelper combosHelper)
        {
            _context = context;
            _combosHelper = combosHelper;
        }

        public Category ToCategory(CategoryViewModel model, Guid imageId, bool isNew)
        {
            return new Category
            {
                Id = isNew ? 0 : model.Id,
                ImageId = imageId,
                Name = model.Name
            };
        }

        public CategoryViewModel ToCategoryViewModel(Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                ImageId = category.ImageId,
                Name = category.Name
            };
        }

        public Country ToCountry(CountryViewModel model, Guid imageId, bool isNew)
        {
            return new Country
            {
                Id = isNew ? 0 : model.Id,
                ImageId = imageId,
                Name = model.Name
            };
        }

        public CountryViewModel ToCountryViewModel(Country country)
        {
            return new CountryViewModel
            {
                Id = country.Id,
                ImageId = country.ImageId,
                Name = country.Name
            };
        }

        public async Task<Company> ToCompanyAsync(CompanyViewModel model, Guid imageId, bool isNew)
        {
            return new Company
            {
                Id = isNew ? 0 : model.Id,
                ImageId = imageId,
                Name = model.Name,
                Phone = model.Phone,
                Address = model.Address,
                City = await _context.Cities.FindAsync(model.CityId),
                Country = await _context.Countries.FindAsync(model.CountryId)
            };
        }

        public CompanyViewModel ToCompanyViewModel(Company company)
        {
            return new CompanyViewModel
            {
                Id = company.Id,
                ImageId = company.ImageId,               
                Name = company.Name,
                Phone = company.Phone,
                Address = company.Address,
                Cities = _combosHelper.GetComboCities(company.Country.Id),
                CityId = company.City.Id,
                Countries = _combosHelper.GetComboCountries(),
                CountryId = company.Country.Id,
                Country = company.Country,
                City = company.City
            };
        }

        public async Task<Product> ToProductAsync(ProductViewModel model, bool isNew)
        {
            return new Product
            {
                Category = await _context.Categories.FindAsync(model.CategoryId),
                Description = model.Description,
                Id = isNew ? 0 : model.Id,                
                Name = model.Name,
                Price = model.Price,
                ProductImages = model.ProductImages,
                Company = model.Company
            };
        }

        public ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Categories = _combosHelper.GetComboCategories(),
                Category = product.Category,
                CategoryId = product.Category.Id,
                Company = product.Company,               
                Description = product.Description,
                Id = product.Id,                
                Name = product.Name,
                Price = product.Price,
                ProductImages = product.ProductImages
            };
        }


    }
}
