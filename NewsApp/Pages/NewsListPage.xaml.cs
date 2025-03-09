using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsListPage : ContentPage
{
    private readonly string _categoryName;
    private readonly ApiService _apiService = new ApiService();

    public NewsListPage(string categoryName)
    {
        InitializeComponent();
        _categoryName = categoryName;
        Title = _categoryName;
        LoadNews();
    }

    private async void LoadNews()
    {
        var newsData = await _apiService.GetNews(_categoryName);
        CvNews.ItemsSource = newsData.Articles;
    }

    private async void CvNews_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count > 0)
        {
            var selectedArticle = e.CurrentSelection[0] as Article;
            if (selectedArticle != null)
            {
                await Navigation.PushAsync(new NewsDetailPage(selectedArticle));
            }
        }
    }
}
