using System;
using System.Collections.Generic;
using System.Text;

namespace JixhDb.Test.Controllers
{
    using FluentAssertions;
    using JixhDb.Web.Areas.Admin;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using Mocks;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Xunit;
    using static JixhDb.Common.GlobalConstants;

    public class AdminAccountControllerTest
    {


        [Fact]
        public void AccountControllerShouldBeOnlyForAdminUsers()
        {
            // Arrange
            var controller = typeof(AccountController);

            // Act
            var areaAttribute = controller
                .GetCustomAttributes(true)
                .FirstOrDefault(a => a.GetType() == typeof(AuthorizeAttribute))
                as AuthorizeAttribute;

            // Assert
            areaAttribute.Should().NotBeNull();
            areaAttribute.Roles.Should().Be(AdministratorRoleName);
        }


    }
}
