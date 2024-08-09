using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Validations;
using DBAccessLayer;
using Models;
using Validations.RegexChecker;

namespace UnitTests
{
	public class PasswordValidationTest
	{
		private readonly Mock<IDataHandler> _dataHandler;
		public PasswordValidationTest()
		{
			_dataHandler = new Mock<IDataHandler>();
		}

		List<LoginModel> DBAccount = new List<LoginModel>
			{
				new LoginModel
				{
				Id = 1,
				UserName = "Bobby Joe",
				Password = "Bubba"
				}
			};
		[Fact]
		public async Task PasswordValidationTester()
		{
			//arrange
			_dataHandler.Setup(x => x.GetUsersFromRepoAsync()).ReturnsAsync(DBAccount);

			//act
			LoginModel userLogin = new LoginModel
			{
				UserName = "Bobby Joe",
				Password = "Bubba"
			};
			LoginValidationHandler loginValidation = new LoginValidationHandler(_dataHandler.Object);
			var result = await loginValidation.CheckUserPassword(userLogin);

			//assert
			Assert.True(result);
		}

		[Fact]
		public async Task PassordValidationTesterAlt()
		{
			//arrange
			_dataHandler.Setup(x => x.GetUsersFromRepoAsync()).ReturnsAsync(DBAccount);

			//act
			LoginModel userLogin = new LoginModel
			{
				UserName = "Bobby Joe",
				Password = "Budda"
			};
			LoginValidationHandler loginValidation = new LoginValidationHandler(_dataHandler.Object);
			var result = await loginValidation.CheckUserPassword(userLogin);

			//assert
			Assert.False(result);
		}
	}
}
