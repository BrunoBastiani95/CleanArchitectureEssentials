using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            var id = 1;
            var name = "Category Name";

            Action action = () => new Category(id, name);
            var ex = Record.Exception(action);

            Assert.Null(ex);
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            var id = -1;
            var name = "Category Name";

            Action action = () => new Category(id, name);

            Assert.Throws<DomainExceptionValidation>(action)
                .Message.Equals("Invalid Id value");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            var id = 1;
            var name = "Ca";

            Action action = () => new Category(id, name);

            Assert.Throws<DomainExceptionValidation>(action)
                .Message.Equals("Invalid name, too short, minimum 3 characters");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            var id = 1;
            var name = string.Empty;

            Action action = () => new Category(id, name);

            Assert.Throws<DomainExceptionValidation>(action)
                .Message.Equals("Invalid name. Name is required");
        }

        [Fact]
        public void CreateCategory_WithNullValue_DomainExceptionInvalidName()
        {
            var id = 1;
            string name = null;

            Action action = () => new Category(id, name);

            Assert.Throws<DomainExceptionValidation>(action)
                .Message.Equals("Invalid name. Name is required");
        }
    }
}