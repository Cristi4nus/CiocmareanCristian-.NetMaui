using CiocmareanCristianLab7.Models;
using CiocmareanCristianLab7.Data;
namespace CiocmareanCristianLab7;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductPage((ShopList)
       this.BindingContext)
        {
            BindingContext = new Product()
        });

    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveShopListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext;
        await App.Database.DeleteShopListAsync(slist);
        await Navigation.PopAsync();
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (ShopList)BindingContext;

        listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
    }
    async void OnDeleteProductButtonClicked(object sender, EventArgs e)
    {
        var shop1 = (ShopList)BindingContext;
        var product = listView.SelectedItem as Product;
        if (product == null)
            return;
        await App.Database.DeleteProductFromListAsync(shop1.ID,product.ID);
        listView.ItemsSource = await App.Database.GetListProductsAsync(shop1.ID);
    }
}