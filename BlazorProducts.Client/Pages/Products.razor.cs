using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorProducts.Client.Features;
using BlazorProducts.Client.HttpRepository;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Components;

namespace BlazorProducts.Client.Pages
{
    public partial class Products
    {
        public List<Product> ProductList { get; set; } = new List<Product>();
        public MetaData MetaData { get; set; } = new MetaData();
        
        private ProductParameters _productParameters = new ProductParameters();
        
        [Inject]
        public IProductHttpRepository ProductRepo { get; set; }

        protected async override Task OnInitializedAsync()
        {
            await GetProducts();
        }

        private async Task SelectedPage(int page)
        {
            _productParameters.PageNumber = page;
            await GetProducts();
        }

        private async Task GetProducts()
        {
            var pagingResponse = await ProductRepo.GetProducts(_productParameters);
            ProductList = pagingResponse.Items;
            MetaData = pagingResponse.Metadata;
        }
    }
}