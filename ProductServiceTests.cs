using empresa_x.Context;
using empresa_x.Models;
using Xunit;

namespace empresa_x.Tests
{
    public class ProductServiceTests
    {
        [Fact]
        public void CreateProduct()
        {
            var productService = new ProductServices();
            var product = new Product { name = "TestCreate", description = "Test", price = 1000, qty = 50 };

            var result = productService.Create(product);

            Assert.NotNull(result);
            Assert.Equal("TestCreate", result.name);
        }

        [Fact]
        public void UpdateProduct()
        {
            var productService = new ProductServices();
            var product = new Product { name = "TestUpdate", description = "Test", price = 1000, qty = 50 };
            productService.Create(product);

            product.name = "TestUpdate2";
            var result = productService.Update(product.id, product.name, product.description, product.price, product.qty);

            Assert.NotNull(result);
            Assert.Equal("TestUpdate2", result.name);
        }

        [Fact]
        public void DeleteProduct()
        {
            var productService = new ProductServices();
            var product = new Product { name = "TestUpdate", description = "Test", price = 1000, qty = 50 };
            productService.Create(product);

            productService.Delete(product.id);
            var result = productService.SelectById(product.id);

            Assert.Null(result);
        }
    }
}