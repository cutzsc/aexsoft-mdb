using System;
using System.Linq;
using System.Collections.Generic;
using Xunit;
using Moq;
using aexsoftmdb.Models;
using aexsoftmdb.Models.Entities;
using aexsoftmdb.Models.Repositories;
using aexsoftmdb.Models.ViewModels;
using aexsoftmdb.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using aexsoftmdb.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace aexsoftmdb.Tests
{
	public class PaginationTests
	{
		[Fact]
		public void Can_Paginate()
		{
			// Arrange
			var urlHelper = new Mock<IUrlHelper>();
			urlHelper.SetupSequence(x => x.Action(It.IsAny<UrlActionContext>()))
				.Returns("Test/CanPag/?page=0")
				.Returns("Test/CanPag/?page=0")
				.Returns("Test/CanPag/?page=1")
				.Returns("Test/CanPag/?page=2")
				.Returns("Test/CanPag/?page=2");

			var urlHelperFactory = new Mock<IUrlHelperFactory>();
			urlHelperFactory.Setup(f => f
				.GetUrlHelper(It.IsAny<ActionContext>()))
				.Returns(urlHelper.Object);

			PaginationTagHelper paginator = new PaginationTagHelper(urlHelperFactory.Object)
			{
				PaginationOptions = new PaginationOptions
				{
					CurrentPage = 1,
					PageSize = 3,
					TotalElements = 8
				},
				PaginationAction = "CanPag",
				PaginationController = "Test",
				PaginationItemActive = "active",
				PaginationItem = "item",
				PaginationLink = "link",
				PaginationItemDisabled = "disabled"
			};

			TagHelperContext ctx = new TagHelperContext(new TagHelperAttributeList(),
				new Dictionary<object, object>(), "");

			var content = new Mock<TagHelperContent>();
			TagHelperOutput output = new TagHelperOutput("ul",
				new TagHelperAttributeList(),
				(cache, encoder) => Task.FromResult(content.Object));

			// Act
			paginator.Process(ctx, output);

			// Assert
			Assert.Equal(
				"<li class=\"item\"><a class=\"link\" href=\"Test/CanPag/?page=0\">Previous</a></li>" +
				"<li class=\"item\"><a class=\"link\" href=\"Test/CanPag/?page=0\">1</a></li>" +
				"<li class=\"active item\"><a class=\"link\" href=\"Test/CanPag/?page=1\">2</a></li>" +
				"<li class=\"item\"><a class=\"link\" href=\"Test/CanPag/?page=2\">3</a></li>" +
				"<li class=\"item\"><a class=\"link\" href=\"Test/CanPag/?page=2\">Next</a></li>",
				output.Content.GetContent());
			
		}
	}
}
