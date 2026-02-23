using BuOdeh.Data;
using BuOdeh.Data.Setting;
using Microsoft.EntityFrameworkCore;

namespace BuOdeh.Services
{
    public interface IRecipeService
    {
        Task<int> InsertRecipe(Recipe recipe);
        Task<List<Recipe>> GetAllRecipes();
        Task<Recipe> GetRecipeById(int id);
        Task<List<Recipe>> GetRecipesByProductId(int productId);
        Task<int> UpdateRecipe(Recipe recipe);
        Task<int> DeleteRecipe(int id);
        Task<List<Product>> GetAllProducts();
    }

    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext _context;

        public RecipeService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Insert a new recipe into the database
        /// </summary>
        public async Task<int> InsertRecipe(Recipe recipe)
        {
            try
            {
                recipe.AddedDate = DateTime.Now;
                recipe.IsActive = true;

                _context.Recipes.Add(recipe);
                await _context.SaveChangesAsync();

                return recipe.ID;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error inserting recipe: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Retrieve all active recipes
        /// </summary>
        public async Task<List<Recipe>> GetAllRecipes()
        {
            try
            {
                return await _context.Recipes
                    .Where(r => r.IsActive)
                    .OrderBy(r => r.ProductName)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving recipes: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Retrieve a single recipe by ID
        /// </summary>
        public async Task<Recipe> GetRecipeById(int id)
        {
            try
            {
                return await _context.Recipes
                    .Where(r => r.ID == id && r.IsActive)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving recipe: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Retrieve all recipes for a specific parent product
        /// Example: Get all ingredients for Peanut Cookie (ProductId = 5)
        /// </summary>
        public async Task<List<Recipe>> GetRecipesByProductId(int productId)
        {
            try
            {
                return await _context.Recipes
                    .Where(r => r.ProductId == productId && r.IsActive)
                    .OrderBy(r => r.ProductIngredientId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving recipes for product: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Retrieve all active products for use in dropdowns
        /// </summary>
        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                return await _context.Product
                    .Where(p => p.IsActive)
                    .OrderBy(p => p.ProductName)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving products: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Update an existing recipe
        /// </summary>
        public async Task<int> UpdateRecipe(Recipe recipe)
        {
            try
            {
                var existingRecipe = await _context.Recipes.FindAsync(recipe.ID);
                if (existingRecipe == null)
                    throw new Exception("Recipe not found.");

                existingRecipe.Quantity = recipe.Quantity;
                existingRecipe.UOM = recipe.UOM;
                existingRecipe.ProductName = recipe.ProductName;
                existingRecipe.ModifyDate = DateTime.Now;

                _context.Recipes.Update(existingRecipe);
                await _context.SaveChangesAsync();

                return existingRecipe.ID;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating recipe: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Soft delete a recipe (mark as inactive)
        /// </summary>
        public async Task<int> DeleteRecipe(int id)
        {
            try
            {
                var recipe = await _context.Recipes.FindAsync(id);
                if (recipe == null)
                    throw new Exception("Recipe not found.");

                recipe.IsActive = false;
                recipe.ModifyDate = DateTime.Now;

                _context.Recipes.Update(recipe);
                await _context.SaveChangesAsync();

                return recipe.ID;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting recipe: {ex.Message}", ex);
            }
        }
    }
}