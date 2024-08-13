using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Models;
using LogicLayer;

namespace UnitTests
{
	public class LoginModelConversionTest
	{
		[Fact]
		public void CreateUserToLoginModelConverterTest()
		{
			//arrange
			CreateUserModel newUser = new CreateUserModel
			{
				Name = "Test",
				Password = "password",
				checkPassword = "password"

			};
			//act
			var convedtedUser = CreateUserToLoginModelConverter.ConvertModel(newUser);
			var expected = new LoginModel
			{
				UserName = "Test",
				Password = "password",
			};

			//assert
			Assert.Equal(convedtedUser.UserName, expected.UserName);
			Assert.Equal(convedtedUser.Password, expected.Password);
		}
	}
}
