using empresa_x.Context;
using empresa_x.Models;
using Xunit;

namespace empresa_x.Tests
{
    public class CustomerServiceTests
    {
        [Fact]
        public void CreateCustomer()
        {
            var customerService = new CustomerServices();
            var customer = new Customer { name = "TestCreate", address = "Test st.", phone = "123456789", email = "test@example.com" };

            var result = customerService.Create(customer);

            Assert.NotNull(result);
            Assert.Equal("TestCreate", result.name);
        }

        [Fact]
        public void UpdateCustomer()
        {
            var customerService = new CustomerServices();
            var customer = new Customer { name = "TestUpdate", address = "Test st.", phone = "123456789", email = "test@example.com" };
            customerService.Create(customer);

            customer.name = "TestUpdate2";
            var result = customerService.Update(customer.id, customer.name, customer.address, customer.phone, customer.email);

            Assert.NotNull(result);
            Assert.Equal("TestUpdate2", result.name);
        }

        [Fact]
        public void DeleteCustomer()
        {
            var customerService = new CustomerServices();
            var customer = new Customer { name = "TestDelete", address = "Test st.", phone = "123456789", email = "test@example.com" };
            customerService.Create(customer);

            customerService.Delete(customer.id);
            var result = customerService.SelectById(customer.id);

            Assert.Null(result);
        }
    }
}