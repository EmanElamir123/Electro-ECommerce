using Electro_ECommerce.Models;
using Electro_ECommerce.Controllers;
using Electro_ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EYouthMVCDemo.Tests
{
    public class CategoriesControllerTests
    {
        private readonly CategoriesController _controller;
        private readonly TechXpressDbContext _context;

        public CategoriesControllerTests()
        {
            var options = new DbContextOptionsBuilder<TechXpressDbContext>()
           .UseSqlServer("Server=.;Database=TechXpressDbContext;Trusted_Connection=True;TrustServerCertificate=True;") 
           .Options;

            _context = new TechXpressDbContext(options);
            _context.Database.EnsureCreated();

            SeedDatabase();
        }
        private void SeedDatabase()
        {
            _context.Categories.Add(new Category { Name = "Category 1" });
            _context.Categories.Add(new Category { Name = "Category 2" });
            _context.SaveChanges();
        }
        [Fact]
        public void Index_ReturnViewWithCategories()
        {
            //Act
            var result = _controller.Index() as ViewResult;
            //Assert
            Assert.NotNull(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Category>>(result.Model);
            Assert.Equal(2, model.Count());
        }
        [Fact]
        public void Details_CategoryExsists_ReturnView()
        {
            //Act 
            var result = _controller.Details(1) as ViewResult;
            //Assert
            Assert.NotNull(result);
            var model = Assert.IsType<Category>(result.Model);
            Assert.Equal("Category 1", model.Name);
        }
        [Fact]
        public void Details_CategoryDoesNotExsists_ReturnNotFound()
        {
            var result = _controller.Details(99);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void Create_Get_ReturnsView()
        {
            var result = _controller.Create() as ViewResult;
            Assert.NotNull(result);
        }

       
        [Fact]
        public void Edit_Get_CategoryExsists_ReturnView()
        {
            var result = _controller.Edit(1) as ViewResult;
            Assert.NotNull(result);
            var model = Assert.IsType<Category>(result.Model);
            Assert.Equal("Category 1", model.Name);
        }
        [Fact]
        public void Edit_Get_CategoryDoesNotExsists_ReturnNotFound()
        {
            var result = _controller.Edit(88);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void Edit_Post_ValidCategory_RedirectToIndex()
        {
            //Arrange
            var originalCatgegory = _context.Categories.FirstOrDefault(c => c.CategoryId== 1);
            Assert.NotNull(originalCatgegory);
            originalCatgegory.Name = "Updated Category";

            //Act
            var result = _controller.Edit(originalCatgegory.CategoryId, originalCatgegory) as RedirectToActionResult;
            //Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);

            var category = _context.Categories.Find(originalCatgegory.CategoryId);
            Assert.NotNull(category);
            Assert.Equal("Updated Category", category.Name);
        }
        [Fact]
        public void Edit_Post_InvalidModel_ReturnsView()
        {
            var updatedCategory = new Category { Name = "", CategoryId = 1 };
            _controller.ModelState.AddModelError("Name", "Requied");

            var result = _controller.Edit(1, updatedCategory) as ViewResult;

            Assert.NotNull(result);
            Assert.IsType<Category>(result.Model);
        }
        [Fact]
        public void Delete_CategoryExsists_ReturnView()
        {
            var result = _controller.Delete(1) as ViewResult;

            Assert.NotNull(result);
            var model = Assert.IsType<Category>(result.Model);
            Assert.Equal("Category 1", model.Name);
        }
        [Fact]
        public void Delete_CategoryDoesNotExsists_ReturnNotFound()
        {
            var result = _controller.Delete(99);
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void DeleteConfirmed_CategoryExsists_RedierctToIndex()
        {
            var result = _controller.DeleteConfirmed(1) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            Assert.Equal(1, _context.Categories.Count());
        }
        [Fact]
        public void DeleteConfirmed_CategoriesDoesNotExsists_ReturnNotFound()
        {
            var result = _controller.DeleteConfirmed(45);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
