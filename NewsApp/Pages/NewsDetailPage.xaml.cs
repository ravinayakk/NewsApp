using NewsApp.Models;

namespace NewsApp.Pages;

public partial class NewsDetailPage : ContentPage
{
    public NewsDetailPage(Article article)
    {
        InitializeComponent();
        Title = "News Details";

        NewsImage.Source = article.Image;
        NewsTitle.Text = article.Title;
        NewsContent.Text = article.Content;
    }
}
