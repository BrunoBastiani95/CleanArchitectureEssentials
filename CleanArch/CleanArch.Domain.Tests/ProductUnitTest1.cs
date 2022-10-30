using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            var id = 1;
            var name = "Product Name";
            var description = "Product Description";
            var price = 1.50m;
            var stock = 1;
            var image = "Product Image";

            Action action = () => new Product(
                id, name, description, price, stock, image);
            var exception = Record.Exception(action);

            Assert.Null(exception);
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            var id = -1;
            var name = "Product Name";
            var description = "Product Description";
            var price = 1.50m;
            var stock = 1;
            var image = "Product Image";

            Action action = () => new Product(
                id, name, description, price, stock, image);

            Assert.Throws<DomainExceptionValidation>(action)
                .Message.Equals("Invalid Id value");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            var id = 1;
            var name = "Pr";
            var description = "Product Description";
            var price = 1.50m;
            var stock = 1;
            var image = "Product Image";

            Action action = () => new Product(
                id, name, description, price, stock, image);

            Assert.Throws<DomainExceptionValidation>(action)
                .Message.Equals("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            var id = 1;
            var name = string.Empty;
            var description = "Product Description";
            var price = 1.50m;
            var stock = 1;
            var image = "Product Image";

            Action action = () => new Product(
                id, name, description, price, stock, image);

            Assert.Throws<DomainExceptionValidation>(action)
                .Message.Equals("Invalid name. Name is required");
        }

        [Fact]
        public void CreateProduct_WithNullValue_DomainExceptionInvalidName()
        {
            var id = 1;
            string name = null;
            var description = "Product Description";
            var price = 1.50m;
            var stock = 1;
            var image = "Product Image";

            Action action = () => new Product(
                id, name, description, price, stock, image);

            Assert.Throws<DomainExceptionValidation>(action)
                .Message.Equals("Invalid name. Name is required");
        }

        [Fact]
        public void CreateProduct_ShortDescriptionValue_DomainExceptionShortDescription()
        {
            var id = 1;
            var name = "Pr";
            var description = "Product Description";
            var price = 1.50m;
            var stock = 1;
            var image = "Product Image";

            Action action = () => new Product(
                id, name, description, price, stock, image);

            Assert.Throws<DomainExceptionValidation>(action)
                .Message.Equals("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateProduct_MissingDescriptionValue_DomainExceptionRequiredDescription()
        {
            var id = 1;
            var name = "Product Name";
            var description = string.Empty;
            var price = 1.50m;
            var stock = 1;
            var image = "Product Image";

            Action action = () => new Product(
                id, name, description, price, stock, image);

            Assert.Throws<DomainExceptionValidation>(action)
                .Message.Equals("Invalid description. Description is required");
        }

        [Fact]
        public void CreateProduct_WithNullValue_DomainExceptionInvalidDescription()
        {
            var id = 1;
            var name = "Product Name";
            string description = null;
            var price = 1.50m;
            var stock = 1;
            var image = "Product Image";

            Action action = () => new Product(
                id, name, description, price, stock, image);

            Assert.Throws<DomainExceptionValidation>(action)
                .Message.Equals("Invalid description. Description is required");
        }

        [Fact]
        public void CreateProduct_WithNegativeValue_DomainExceptionInvalidPrice()
        {
            var id = 1;
            var name = "Product Name";
            var description = "Product Description";
            var price = -1;
            var stock = 1;
            var image = "Product Image";

            Action action = () => new Product(
                id, name, description, price, stock, image);

            Assert.Throws<DomainExceptionValidation>(action)
                .Message.Equals("Invalid price value");
        }

        [Fact]
        public void CreateProduct_WithNegativeValue_DomainExceptionInvalidStock()
        {
            var id = 1;
            var name = "Product Name";
            var description = "Product Description";
            var price = 1.50m;
            var stock = -1;
            var image = "Product Image";

            Action action = () => new Product(
                id, name, description, price, stock, image);

            Assert.Throws<DomainExceptionValidation>(action)
                .Message.Equals("Invalid stock value");
        }

        [Fact]
        public void CreateProduct_LargeImageName_DomainExceptionLargeImage()
        {
            var id = 1;
            var name = "Product Name";
            var description = "Product Description";
            var price = 1.50m;
            var stock = 1;
            var image = "PPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPPRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRROOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOODDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDUUUUUUUUUUUUUUUUUUUUUCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTTT";

            Action action = () => new Product(
                id, name, description, price, stock, image);

            Assert.Throws<DomainExceptionValidation>(action)
                .Message.Equals("Invalid image name, too short, maximum 250 characters");
        }

        [Fact]
        public void CreateProduct_WithNullValue_NullReferenceExceptionInvalidImage()
        {
            var id = 1;
            var name = "Product Name";
            var description = "Product Description";
            var price = 1.50m;
            var stock = 1;
            string image = null;

            Action action = () => new Product(
                id, name, description, price, stock, image);

            Assert.Throws<NullReferenceException>(action);
        }
    }
}