using empresa_x.Context;
using empresa_x.Models;
using Xunit;

namespace empresa_x.Tests
{
    public class SaleServiceTests
    {
        [Fact]
        public void CreateSale()
        {
            var customerService = new CustomerServices();
            var productService = new ProductServices();
            var saleService = new SaleServices();

            var customer = new Customer { name = "TestCreate", address = "Test st.", phone = "123456789", email = "test@example.com" };
            var product = new Product { name = "TestCreateAAA", description = "Test", price = 1000, qty = 50 };

            customerService.Create(customer);
            productService.Create(product);

            var sale = new Sale { customer_id = customer.id, product_id = product.id, qty = 10 };
            var result = saleService.Create(sale);

            product = productService.Update(product.id, product.name, product.description, product.price, (product.qty - sale.qty));

            Assert.NotNull(result);
            Assert.Equal(40, productService.SelectById(product.id).qty);
        }
    }
}