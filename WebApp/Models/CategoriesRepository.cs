namespace WebApp.Models
{
    public class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category { CategoryId=1, Description="Beverage", Name="Beverage" },
            new Category { CategoryId=2, Description="Bakery", Name="Bakery" },
            new Category { CategoryId=3, Description="Meat", Name="Meat"}
        };

        public static void AddCategory(Category category)
        {
            int maxId = _categories.Max(c => c.CategoryId);
            category.CategoryId = maxId;
            _categories.Add(category);
        }

        public static List<Category> GetCategories() => _categories;

        public static Category? GetCategory(int categoryId)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryId == categoryId);

            if(category != null)
            {
                return new Category
                {
                    CategoryId = category.CategoryId,
                    Description = category.Description,
                    Name = category.Name
                };
            }

            return null;
        }

        public static void UpdateCategory(int categoryId, Category category)
        {
            if (categoryId != category.CategoryId) return;

            var categoryUpdate = GetCategory(categoryId);
            if (categoryUpdate != null)
            {
                categoryUpdate.Name = category.Name;
                categoryUpdate.Description = category.Description;
            }
        }

        public static void DeleteCategory(int categoryId)
        {
            var categoryDelete = _categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if( categoryDelete != null )
            {
                _categories.Remove(categoryDelete);
            }
        }
    }
}
