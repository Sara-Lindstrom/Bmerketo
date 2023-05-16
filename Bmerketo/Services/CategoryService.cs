using Bmerketo.Contexts;
using Bmerketo.Models.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Bmerketo.Models.Enums.CategoryEnumModel;

namespace Bmerketo.Services
{
    public class CategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }

        public List<SelectListItem> GetCategorySelectListItems()
        {
            return Enum.GetValues(typeof(CategoryAlternativeEnum))
                                    .Cast<CategoryAlternativeEnum>()
                                    .Select(v => new SelectListItem
                                    {
                                        Text = v.ToString(),
                                        Value = Convert.ToInt32(v).ToString()
                                    })
                                    .ToList();
        }

        public List<SelectListItem> GetCategorySelectListItems(string[] selectedtags)
        {
            return Enum.GetValues(typeof(CategoryAlternativeEnum))
                                    .Cast<CategoryAlternativeEnum>()
                                    .Select(v => new SelectListItem
                                    {
                                        Text = v.ToString(),
                                        Value = Convert.ToInt32(v).ToString(),
                                        Selected = selectedtags.Contains(Convert.ToInt32(v).ToString())
                                    })
                                    .ToList();
        }

        public async Task RegisterCategoryAsync(CategoryEntity entity)
        {
            _context.Categories.Add(entity);
            await _context.SaveChangesAsync();
        }
    }
}
