using aexsoftmdb.Models.ViewModels;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aexsoftmdb.TagHelpers
{
	[HtmlTargetElement("ul", Attributes = "pagination-options")]
	public class PaginationTagHelper : TagHelper
	{
		private IUrlHelperFactory urlHelperFactory;

		[ViewContext]
		[HtmlAttributeNotBound]
		public ViewContext ViewContext { get; set; }

		// Attributes
		public PaginationOptions PaginationOptions { get; set; }
		[HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
		public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();
		public string PaginationAction { get; set; }
		public string PaginationController { get; set; }
		public string PaginationItem { get; set; }
		public string PaginationLink { get; set; }
		public string PaginationItemActive { get; set; }
		public string PaginationItemDisabled { get; set; }

		public PaginationTagHelper(IUrlHelperFactory urlHelperFactory)
			=> this.urlHelperFactory = urlHelperFactory;

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
			TagBuilder result = new TagBuilder("ul");

			// Previous button
			result.InnerHtml.AppendHtml(CreatePaginationItem(urlHelper,
				PaginationOptions.CurrentPage - 1,
				"Previous"));

			for (int i = 0; i < PaginationOptions.TotalPages; i++)
			{
				result.InnerHtml.AppendHtml(CreatePaginationItem(urlHelper, i, (i + 1).ToString()));
			}

			// Next button
			result.InnerHtml.AppendHtml(CreatePaginationItem(urlHelper,
				PaginationOptions.CurrentPage + 1,
				"Next"));

			output.Content.AppendHtml(result.InnerHtml);
		}

		/// <summary>
		/// Creates html element as pagination item.
		/// </summary>
		/// <param name="urlHelper">Url Helper</param>
		/// <param name="page">Page number</param>
		/// <param name="text">Html tag inner text</param>
		/// <returns>HTML tag as TagBuilder</returns>
		private TagBuilder CreatePaginationItem(IUrlHelper urlHelper, int page, string text)
		{
			TagBuilder item = new TagBuilder("li");
			TagBuilder link = new TagBuilder("a");

			PageUrlValues["page"] = page;
			link.Attributes["href"] = urlHelper.Action(PaginationAction, PaginationController, PageUrlValues);
			link.AddCssClass(PaginationLink);

			item.AddCssClass(PaginationItem);
			if (page == PaginationOptions.CurrentPage)
				item.AddCssClass(PaginationItemActive);

			if (page < 0 ||
				page >= PaginationOptions.TotalPages)
				item.AddCssClass(PaginationItemDisabled);

			link.InnerHtml.Append(text);
			item.InnerHtml.AppendHtml(link);

			return item;
		}
	}
}
