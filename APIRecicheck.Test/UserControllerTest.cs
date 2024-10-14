using APIRecicheck.Controllers;
using APIRecicheck.Data.Contexts;
using APIRecicheck.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRecicheck.Test
{
    public class UserControllerTest
    {
        private readonly Mock<DatabaseContext> _mockContext;
        private readonly UserController _userController;
        private readonly DbSet<UserModel> _mockSet;

        public UserControllerTest()
        {
            _mockContext = new Mock<DatabaseContext>();
            _mockSet = MockDbSet();
            _mockContext.Setup(m => m.Users).Returns(_mockSet);

            _userController = new UserController(_mockContext.Object);
        }
        private DbSet<UserModel> MockDbSet()
        {
            // Lista de clientes para simular dados no banco de dados
            var data = new List<UserModel>
            {
                new UserModel { UserId = 1, Username = "Leandro", Password = "leandro123", Role = "Desenvolvedor" },
                new UserModel { UserId = 2, Username = "Leandro", Password = "leandro123", Role = "Desenvolvedor" },
            }.AsQueryable();

            // Cria o mock do DbSet
            var mockSet = new Mock<DbSet<UserModel>>();

            // Configura o comportamento do mock DbSet para simular uma consulta ao banco de dados
            mockSet.As<IQueryable<UserModel>>()
                .Setup(m => m.Provider)
                .Returns(data.Provider);

            mockSet.As<IQueryable<UserModel>>()
                .Setup(m => m.Expression)
                .Returns(data.Expression);

            mockSet.As<IQueryable<UserModel>>()
                .Setup(m => m.ElementType)
                .Returns(data.ElementType);

            mockSet.As<IQueryable<UserModel>>()
                .Setup(m => m.GetEnumerator())
                .Returns(data.GetEnumerator());

            // Retorna o DbSet mock
            return mockSet.Object;
        }

        [Fact]
        public void Index_returnsViewUsuarios()
        {
            //act
            var result = _userController.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);

           // var model = Assert.IsAssignableFrom<UserModel>(viewResult.Model);
           var model = Assert.IsAssignableFrom<IEnumerable<UserModel>>(viewResult.Model);

           Assert.Equal(2, model.Count());
        }

        // se nao haver usuarios

        [Fact]
        public void Index_returnsViewNuloUsuarios()
        {
            //Arrenge 
            _mockSet.RemoveRange(_mockSet.ToList());
            _mockContext.Setup(m => m.Users).Returns(_mockSet);
            //act
            var result = _userController.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);

            // var model = Assert.IsAssignableFrom<UserModel>(viewResult.Model);
            var model = Assert.IsAssignableFrom<IEnumerable<UserModel>>(viewResult.Model);

            Assert.Empty(model);
        }

    }
}
